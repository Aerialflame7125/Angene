using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Common;
using static Angene.Extensions.Audio.MiniAudio.Interop.Methods;
using System.Collections.Concurrent;
using Angene.Extensions.Audio.Common;
using Angene.Extensions.Audio.MiniAudio.Interop;
using static Angene.Extensions.Audio.Common.AudioDefs;

namespace Angene.Extensions.Audio.MiniAudio;

public enum MiniAudioPlayerType
{
    Memory,
    Stream
}

public unsafe class MiniAudioPlayer : IAudioPlayer
{
    private AudioFile _audioFile;
    private MiniAudioPlayerType _type;
    private byte[] _bytes;
    private Stream _stream;
    private bool _disposed = false;
    private float _playPosition = 0;
    public float PlayPos => _playPosition;
    
#region IAudioPlayer
    private volatile bool _isPlaying;
    private volatile bool _isPaused;
    private volatile float _volume = 1f;
    private volatile bool _loop = false;

    public bool IsPlaying => _isPlaying;
    public bool IsPaused => _isPaused;
    public float Volume => _volume;
    public bool Looping => _loop;
    
    public void Play() => Enqueue(AudioDefs.AudioCommandType.Play);
    public void Stop() => Enqueue(AudioDefs.AudioCommandType.Stop);
    public void Pause() => Enqueue(AudioDefs.AudioCommandType.Pause);
    public void Resume() => Enqueue(AudioDefs.AudioCommandType.Resume);
    public void SetVolume(float v) => Enqueue(AudioDefs.AudioCommandType.Volume, System.Math.Clamp(v, 0f, 1f));
    public void SetLooping(bool loop) => Enqueue(AudioDefs.AudioCommandType.Loop, loop ? 1f : 0f);
#endregion
#region Threading
    private readonly ConcurrentQueue<AudioDefs.AudioCommand> _commands = new();
    private readonly ManualResetEventSlim _signal = new(false);
    private readonly CancellationTokenSource _cts = new();
    private readonly Thread _audioThread;
#endregion
#region MiniAudio stuff
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void data_callback(ma_device* pDevice, void* pOutput, void* pInput, uint frameCount)
    {
        var state = (CallbackState*)pDevice->pUserData;
        if (state == null || state->Decoder == null) return;

        const uint bpf = 2 * sizeof(float);
        byte* dst = (byte*)pOutput;
        ulong total = 0;
        bool seeked = false;

        while (total < frameCount)
        {
            ulong read = 0;
            ma_decoder_read_pcm_frames(state->Decoder, dst + total * bpf, frameCount - total, &read);
            total += read;

            if (total >= frameCount) break;
            if (Volatile.Read(ref state->Loop) == 0 || (read == 0 && seeked)) break;

            ma_decoder_seek_to_pcm_frame(state->Decoder, 0);
            seeked = read == 0;
        }

        if (total < frameCount)
            NativeMemory.Clear(dst + total * bpf, (nuint)((frameCount - total) * bpf));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnLogCallback(void* arg1, uint arg2, sbyte* str)
    {
        string log = new string(str);

        Logger.LogDebug($"[MiniAudio|OnLogCallback] '{log}', level = {arg2}", LoggingTarget.Engine);
    }

    private ma_device* _device;
    private ma_sound* _sound = null;
    private ma_decoder* _decoder;
    private ma_context* _context;
    private ma_log* _log;
    private ma_resource_manager_config resourceManagerConfig;
    private ma_resource_manager resourceManager;
    private ma_device_info* pPlaybackDeviceInfo;
    private uint playbackDeviceCount;
    private ma_engine* engine;
    private struct CallbackState { public ma_decoder* Decoder; public int Loop; }
    private CallbackState* _state;
    private byte* _data; // native copy of the file bytes
#endregion
#region Constructors
    public MiniAudioPlayer() { }

    private MiniAudioPlayer(AudioFile file, MiniAudioPlayerType type)
    {
        _audioFile = file;
        _type = type;
        _audioThread = new Thread(AudioLoop)
        {
            IsBackground = true,
            Priority = ThreadPriority.AboveNormal,
            Name = "Angene.Extensions.Audio"
        };
        _audioThread.Start();
    }
    
    private void AudioLoop()
    {
        try
        {
            switch (_type)
            {
                case  MiniAudioPlayerType.Memory:
                    _bytes = _audioFile.GetAudioBytes();
                    if (_bytes != null)
                        InitMemory(_bytes);
                    break;
                case MiniAudioPlayerType.Stream:
                    _stream = _audioFile.GetAudioStream();
                    if (_stream != null)
                    {
                        using var ms = new MemoryStream();
                        _stream.CopyTo(ms);
                        InitMemory(ms.ToArray());
                    }
                    break;
            }
            while (!_cts.IsCancellationRequested)
            {
                while (_commands.TryDequeue(out var cmd))
                    ProcessCommand(cmd);

                if (_decoder != null)
                {
                    ulong frames;
                    if (ma_decoder_get_cursor_in_pcm_frames(_decoder, &frames) == ma_result.MA_SUCCESS)
                        Volatile.Write(ref _playPosition, frames / 48000f);
                }
                
                _signal.Wait(16);
                _signal.Reset();
            }
        }
        catch (Exception ex)
        {
            Logger.LogCritical(
                $"Angene.Extensions.Audio thread crashed: {ex.Message}",
                LoggingTarget.Engine, ex);
            _isPlaying = false;
            _isPaused = false;
        }
    }
#endregion
#region Inits

    public static MiniAudioPlayer InitAudioPlayer(AudioFile file, MiniAudioPlayerType type)
    {
        return new MiniAudioPlayer(file, type);
    }
    public bool InitMemory(byte[] bytes)
    {
        ma_result result;

        _context = (ma_context*)NativeMemory.AllocZeroed(ma_context_sizeof());
        result = ma_context_init(null, 0, null, _context);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_init] Failed to initialize context.", LoggingTarget.Engine);
            return false;
        }

        ma_device_info* _pPlaybackDeviceInfo;
        uint _playbackDeviceCount;
        result = ma_context_get_devices(_context, &_pPlaybackDeviceInfo, &_playbackDeviceCount, null, null);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_get_devices] Failed to enumerate playback devices.", LoggingTarget.Engine);
            ma_context_uninit(_context);
            return false;
        }

        playbackDeviceCount = _playbackDeviceCount;
        pPlaybackDeviceInfo = _pPlaybackDeviceInfo;

        _log = (ma_log*)NativeMemory.AllocZeroed(144);
        if (ma_log_init(null, _log) != ma_result.MA_SUCCESS)
            Logger.LogError("Failed to init MiniAudio log", LoggingTarget.Engine);

        _device = (ma_device*)NativeMemory.AllocZeroed(3776);
        _decoder = (ma_decoder*)NativeMemory.AllocZeroed(552);

        fixed (byte* pBytes = bytes)
        {
            _data = (byte*)NativeMemory.Alloc((nuint)bytes.Length);
            new ReadOnlySpan<byte>(bytes).CopyTo(new Span<byte>(_data, bytes.Length));

            _state = (CallbackState*)NativeMemory.AllocZeroed((nuint)sizeof(CallbackState));
            _state->Decoder = _decoder;

            ma_decoder_config decoderConfig = ma_decoder_config_init(ma_format.ma_format_f32, 2, 48000);
            if (ma_decoder_init_memory(_data, (nuint)bytes.Length, &decoderConfig, _decoder) != ma_result.MA_SUCCESS)
                goto CleanupAndFail;

            var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
            deviceConfig.playback.format   = ma_format.ma_format_f32;
            deviceConfig.playback.channels = 2;
            deviceConfig.sampleRate        = 48000;
            deviceConfig.dataCallback      = &data_callback;
            deviceConfig.pUserData         = _state;

            bool contextOk = false;
        #if LINUX
            ma_backend[] backends = { ma_backend.ma_backend_alsa, ma_backend.ma_backend_pulseaudio, ma_backend.ma_backend_jack };
        #elif WINDOWS
            ma_backend[] backends = { ma_backend.ma_backend_wasapi, ma_backend.ma_backend_winmm };
        #endif

            foreach (var backend in backends)
            {
                if (_context != null)
                {
                    ma_context_uninit(_context);
                    NativeMemory.Free(_context);
                    _context = null;
                }

                _context = (ma_context*)NativeMemory.AllocZeroed(ma_context_sizeof());

                ma_context_config cfg = ma_context_config_init();
                cfg.pLog = _log;

                if (ma_context_init(&backend, 1, &cfg, _context) == ma_result.MA_SUCCESS)
                {
                    contextOk = true;
                    break;
                }

                ma_context_uninit(_context);
                NativeMemory.Free(_context);
                _context = null;
                Logger.LogWarning($"Failed {backend}, trying next...", LoggingTarget.Engine);
            }

            if (!contextOk)
            {
                Logger.LogError("All audio backends failed.", LoggingTarget.Engine);
                goto CleanupAndFail;
            }

            if (ma_device_init(_context, &deviceConfig, _device) != ma_result.MA_SUCCESS)
            {
                Logger.LogError("Failed to open playback device.", LoggingTarget.Engine);
                goto CleanupAndFail;
            }

            return true;
        }

    CleanupAndFail:
        if (_decoder != null) { ma_decoder_uninit(_decoder); NativeMemory.Free(_decoder); _decoder = null; }
        if (_device != null) { NativeMemory.Free(_device); _device = null; }
        if (_context != null) { ma_context_uninit(_context); NativeMemory.Free(_context); _context = null; }
        if (_log != null) { ma_log_uninit(_log); NativeMemory.Free(_log); _log = null; }
        return false;
    }
        
    public bool InitFile(string path)
    {
        sbyte* filepath = Main.Window.ToSBytePtr(path);

        ma_result result;
        
        ma_resource_manager_config _resourceManagerConfig = ma_resource_manager_config_init();
        _resourceManagerConfig.decodedFormat     = ma_format.ma_format_f32;
        _resourceManagerConfig.decodedChannels   = 0;
        _resourceManagerConfig.decodedSampleRate = 48000;
        ma_resource_manager _resourceManager;
        
        result = ma_resource_manager_init(&_resourceManagerConfig, &_resourceManager);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_resource_manager_init] Failed to initialize resource manager.", LoggingTarget.Engine);
            return false;
        }
        
        result = ma_context_init(null, 0, null, _context);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_init] Failed to initialize context.", LoggingTarget.Engine);
            return false;
        }
        
        ma_device_info* _pPlaybackDeviceInfo;
        uint _playbackDeviceCount;
        result = ma_context_get_devices(_context, &_pPlaybackDeviceInfo, &_playbackDeviceCount, null, null);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_get_devices] Failed to enumerate playback devices.", LoggingTarget.Engine);
            ma_context_uninit(_context);
            return false;
        }

        playbackDeviceCount = _playbackDeviceCount;
        pPlaybackDeviceInfo = _pPlaybackDeviceInfo;
        
        // miniaudio log
        _log = (ma_log*)NativeMemory.AllocZeroed(144);
        if (ma_log_init(null, _log) != ma_result.MA_SUCCESS)
            Logger.LogError("Failed to init MiniAudio log", LoggingTarget.Engine);

        // values grabbed from miniaudio.h (0.11.25)
        _device = (ma_device*)NativeMemory.AllocZeroed(3776);
        _decoder = (ma_decoder*)NativeMemory.AllocZeroed(552);
        
        if (ma_decoder_init_file(filepath, null, _decoder) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("[MiniAudio | InitMemory] Could not load audio file from memory", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
        deviceConfig.playback.format = resourceManager.config.decodedFormat;
        deviceConfig.playback.channels = resourceManager.config.decodedChannels;
        deviceConfig.sampleRate = resourceManager.config.decodedSampleRate;
        deviceConfig.dataCallback = &data_callback;
        deviceConfig.pUserData = _decoder;

        bool contextOk = false;
    #if LINUX
        ma_backend[] backends = { ma_backend.ma_backend_alsa, ma_backend.ma_backend_pulseaudio, ma_backend.ma_backend_jack };
    #elif WINDOWS
        ma_backend[] backends = { ma_backend.ma_backend_wasapi, ma_backend.ma_backend_winmm };
    #endif

        foreach (var backend in backends)
        {
            if (_context != null)
            {
                ma_context_uninit(_context);
                NativeMemory.Free(_context);
                _context = null;
            }

            _context = (ma_context*)NativeMemory.AllocZeroed(ma_context_sizeof());

            ma_context_config cfg = ma_context_config_init();
            cfg.pLog = _log;

            if (ma_context_init(&backend, 1, &cfg, _context) == ma_result.MA_SUCCESS)
            {
                contextOk = true;
                break;
            }

            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
            Logger.LogWarning($"Failed {backend}, trying next...", LoggingTarget.Engine);
        }

        if (!contextOk)
        {
            Logger.LogError("All audio backends failed.", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        if (ma_device_init(_context, &deviceConfig, _device) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to open playback device.", LoggingTarget.Engine);
            goto CleanupAndFail;
        }
        
        ma_engine_config engineConfig = ma_engine_config_init();
        engineConfig.pDevice = _device;
        engineConfig.pResourceManager = &_resourceManager;
        engineConfig.noAutoStart = 1;

        ma_engine* _engine = engine;
        result = ma_engine_init(&engineConfig, _engine);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError($"[MiniAudio | ma_engine_init] Failed to initialize engine for {pPlaybackDeviceInfo->name}", LoggingTarget.Engine);
            ma_device_uninit(_device);
            return false;
        }

        return true;

    CleanupAndFail:
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }

        if (engine != null)
        {
            ma_engine_uninit(engine);
            NativeMemory.Free(engine);
            engine = null;
        }
        if (_device != null)
        {
            // if device, free
            NativeMemory.Free(_device);
            _device = null;
        }
        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }
        if (_log != null)
        {
            ma_log_uninit(_log);
            NativeMemory.Free(_log);
            _log = null;
        }
        return false;
    }
#endregion
#region Methods
    private void Enqueue(AudioDefs.AudioCommandType type, float value = 0f)
    {
        if (_disposed) return;
        _commands.Enqueue(new AudioDefs.AudioCommand(type, value));
        _signal.Set();
    }

    private void ProcessCommand(AudioDefs.AudioCommand cmd)
    {
        if (_device == null) return; // init failed or disposed

        switch (cmd.Type)
        {
            case AudioDefs.AudioCommandType.Play:
                ma_device_stop(_device);
                ma_decoder_seek_to_pcm_frame(_decoder, 0);
                if (ma_device_start(_device) != ma_result.MA_SUCCESS) { LogFail("start"); break; }
                _isPlaying = true; _isPaused = false;
                break;

            case AudioDefs.AudioCommandType.Stop:
                ma_device_stop(_device);
                ma_decoder_seek_to_pcm_frame(_decoder, 0);
                Volatile.Write(ref _playPosition, 0f);
                _isPlaying = false; _isPaused = false;
                break;

            case AudioDefs.AudioCommandType.Pause:
                ma_device_stop(_device);
                _isPlaying = false; _isPaused = true;
                break;

            case AudioDefs.AudioCommandType.Resume:
                if (ma_device_start(_device) != ma_result.MA_SUCCESS) { LogFail("resume"); break; }
                _isPlaying = true; _isPaused = false;
                break;

            case AudioDefs.AudioCommandType.Volume:
                _volume = cmd.Value;
                ma_device_set_master_volume(_device, _volume);
                break;

            case AudioDefs.AudioCommandType.Loop:
                _loop = cmd.Value > 0f;
                Volatile.Write(ref _state->Loop, _loop ? 1 : 0);
                break;

            case AudioDefs.AudioCommandType.Dispose:
                Teardown();
                _cts.Cancel();
                break;
        }
    }
    
    private static void LogFail(string op) =>
        Logger.LogError($"[MiniAudio | {op}] Playback device call failed.", LoggingTarget.Engine);
    
    private void Teardown()
    {
        if (_device != null)
        {
            ma_device_uninit(_device);
            NativeMemory.Free(_device);
            _device = null;
        }

        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }
        if (_state != null) { NativeMemory.Free(_state); _state = null; }
        if (_data != null)  { NativeMemory.Free(_data);  _data = null; }

        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }

        if (_log != null)
        {
            ma_log_uninit(_log);
            NativeMemory.Free(_log);
            _log = null;
        }
    }
    
    public void StopPlayer()
    {
        if (_device != null)
        {
            ma_device_uninit(_device);
            NativeMemory.Free(_device);
            _device = null;
        }
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }
        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }
    }

    public void Dispose()
    {
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }

        if (engine != null)
        {
            ma_engine_uninit(engine);
            NativeMemory.Free(engine);
            engine = null;
        }
        if (_device != null)
        {
            // if device, free
            NativeMemory.Free(_device);
            _device = null;
        }
        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }
        if (_log != null)
        {
            ma_log_uninit(_log);
            NativeMemory.Free(_log);
            _log = null;
        }
    }
#endregion
}