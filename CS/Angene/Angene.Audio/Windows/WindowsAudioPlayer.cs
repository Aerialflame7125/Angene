using Angene.Audio;
using Angene.Audio.Common;
using Angene.Common;
using Angene.Audio.Methods;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using static Angene.Audio.Windows.WinMM;
using static Angene.Audio.Common.AudioDefs;

namespace Angene.Audio.Windows
{
    internal sealed class WindowsAudioPlayer : IAudioPlayer
    {
        private volatile bool _isPlaying;
        private volatile bool _isPaused;

        public bool IsPlaying => _isPlaying;
        public bool IsPaused => _isPaused;
        public float Volume => _volume;
        public bool Looping => _loop;

        private volatile float _volume = 1f;
        private volatile bool _loop = false;

        // --- Threading ---
        private readonly ConcurrentQueue<AudioCommand> _commands = new();
        private readonly ManualResetEventSlim _signal = new(false);
        private readonly CancellationTokenSource _cts = new();
        private readonly Thread _audioThread;

        // wave-out state
        private IntPtr _hWaveOut = IntPtr.Zero;
        private WaveHeader[] _buffers;
        private readonly byte[] _pcmData;
        private readonly WaveFormatEx _format;
        private int _playPosition;
        private const int BufferSize = 22050;
        private bool _disposed;

        private WindowsAudioPlayer(byte[] pcmData, WaveFormatEx format)
        {
            _pcmData = pcmData;
            _format = format;
            _audioThread = new Thread(AudioLoop)
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Angene.Audio"
            };
            _audioThread.Start();
        }

        private void AudioLoop()
        {
            try
            {
                OpenWaveOut();
                AllocateBuffers();

                while (!_cts.IsCancellationRequested)
                {
                    while (_commands.TryDequeue(out var cmd))
                        ProcessCommand(cmd);

                    if (_isPlaying && !_isPaused)
                        FillAndSubmitBuffers();

                    _signal.Wait(16);
                    _signal.Reset();
                }

                DrainAndClose();
            }
            catch (Exception ex)
            {
                Logger.LogCritical(
                    $"Angene.Audio thread crashed: {ex.Message}",
                    LoggingTarget.Engine, ex);
                _isPlaying = false;
                _isPaused = false;
            }
        }

        public static void ParseWav(byte[] wav, out WinMM.WaveFormatEx fmt, out byte[] pcm)
        {
            fmt = default;
            pcm = null;

            if (wav.Length < 44 ||
                wav[0] != 'R' || wav[1] != 'I' || wav[2] != 'F' || wav[3] != 'F' ||
                wav[8] != 'W' || wav[9] != 'A' || wav[10] != 'V' || wav[11] != 'E')
                throw new InvalidDataException("Not a valid WAV file.");

            using var ms = new MemoryStream(wav);
            using var br = new BinaryReader(ms);

            br.ReadBytes(12); // RIFF + file size + WAVE

            // Find fmt chunk
            while (ms.Position < ms.Length - 8)
            {
                var chunkId = new string(br.ReadChars(4));
                var chunkSize = br.ReadInt32();

                if (chunkId == "fmt ")
                {
                    fmt = new WinMM.WaveFormatEx
                    {
                        wFormatTag = br.ReadUInt16(),
                        nChannels = br.ReadUInt16(),
                        nSamplesPerSec = br.ReadUInt32(),
                        nAvgBytesPerSec = br.ReadUInt32(),
                        nBlockAlign = br.ReadUInt16(),
                        wBitsPerSample = br.ReadUInt16(),
                        cbSize = 0
                    };

                    // skip any extra fmt bytes
                    if (chunkSize > 16)
                        br.ReadBytes(chunkSize - 16);
                }
                else if (chunkId == "data")
                {
                    pcm = br.ReadBytes(chunkSize);
                    return;
                }
                else
                {
                    br.ReadBytes(chunkSize); // skip unknown chunks
                }
            }

            throw new InvalidDataException("WAV file missing data chunk.");
        }

        public static WindowsAudioPlayer FromBytes(byte[] wavBytes)
        {
            ParseWav(wavBytes, out var fmt, out var pcm);
            return new WindowsAudioPlayer(pcm, fmt);
        }

        public static WindowsAudioPlayer FromStream(Stream stream)
        {
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return FromBytes(ms.ToArray());
        }

        public void Play() => Enqueue(AudioCommandType.Play);
        public void Stop() => Enqueue(AudioCommandType.Stop);
        public void Pause() => Enqueue(AudioCommandType.Pause);
        public void Resume() => Enqueue(AudioCommandType.Resume);
        public void SetVolume(float v) => Enqueue(AudioCommandType.Volume, Math.Clamp(v, 0f, 1f));
        public void SetLooping(bool loop) => Enqueue(AudioCommandType.Loop, loop ? 1f : 0f);

        private void Enqueue(AudioCommandType type, float value = 0f)
        {
            if (_disposed) return;
            _commands.Enqueue(new AudioCommand(type, value));
            _signal.Set();
        }

        private void ProcessCommand(AudioCommand cmd)
        {
            switch (cmd.Type)
            {
                case AudioCommandType.Play:
                    _playPosition = 0;
                    _isPlaying = true;
                    _isPaused = false;
                    break;

                case AudioCommandType.Stop:
                    WinMM.waveOutReset(_hWaveOut);
                    _playPosition = 0;
                    _isPlaying = false;
                    _isPaused = false;
                    break;

                case AudioCommandType.Pause:
                    WinMM.waveOutPause(_hWaveOut);
                    _isPaused = true;
                    break;

                case AudioCommandType.Resume:
                    WinMM.waveOutRestart(_hWaveOut);
                    _isPaused = false;
                    break;

                case AudioCommandType.Volume:
                    _volume = cmd.Value;
                    // waveOutSetVolume packs L and R into a single uint
                    uint vol = (uint)(_volume * 0xFFFF);
                    WinMM.waveOutSetVolume(_hWaveOut, (vol << 16) | vol);
                    break;

                case AudioCommandType.Loop:
                    _loop = cmd.Value > 0f;
                    break;

                case AudioCommandType.Dispose:
                    _cts.Cancel();
                    break;
            }
        }

        private void FillAndSubmitBuffers()
        {
            foreach (var buf in _buffers)
            {
                // poll flag to see if done
                if (!buf.IsDone && (buf.Header.dwFlags & WinMM.WHDR_DONE) != 0)
                    buf.IsDone = true;

                if (!buf.IsDone) continue;

                int remaining = _pcmData.Length - _playPosition;
                if (remaining <= 0)
                {
                    if (_loop) _playPosition = 0;
                    else { _isPlaying = false; return; }
                    remaining = _pcmData.Length;
                }

                int toWrite = Math.Min(BufferSize, remaining);
                Marshal.Copy(_pcmData, _playPosition, buf.DataPtr, toWrite);
                _playPosition += toWrite;

                buf.Header.dwBufferLength = (uint)toWrite;
                buf.IsDone = false;
                WinMM.waveOutWrite(_hWaveOut, ref buf.Header, Marshal.SizeOf<WAVEHDR>());
            }
        }

        private void OpenWaveOut()
        {
            var fmt = _format;
            int result = WinMM.waveOutOpen(
                out _hWaveOut,
                WinMM.WAVE_MAPPER,
                ref fmt,
                IntPtr.Zero, IntPtr.Zero,
                WinMM.CALLBACK_NULL);

            if (result != 0)
                throw new InvalidOperationException($"waveOutOpen failed: {result}");
        }

        private void AllocateBuffers()
        {
            _buffers = new WaveHeader[2];
            for (int i = 0; i < 2; i++)
            {
                _buffers[i] = new WaveHeader(BufferSize);
                WinMM.waveOutPrepareHeader(_hWaveOut,
                    ref _buffers[i].Header,
                    Marshal.SizeOf<WAVEHDR>());
                _buffers[i].IsDone = true; // mark ready
            }
        }

        private void DrainAndClose()
        {
            WinMM.waveOutReset(_hWaveOut);
            foreach (var buf in _buffers)
            {
                WinMM.waveOutUnprepareHeader(_hWaveOut,
                    ref buf.Header,
                    Marshal.SizeOf<WAVEHDR>());
                buf.Dispose();
            }
            WinMM.waveOutClose(_hWaveOut);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            Enqueue(AudioCommandType.Dispose);
            _audioThread.Join(500); // give audio thread 500ms to clean up
            _cts.Dispose();
            _signal.Dispose();
        }
    }
}