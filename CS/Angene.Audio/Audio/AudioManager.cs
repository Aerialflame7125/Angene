using Angene.Audio.Windows;

namespace Angene.Audio.Audio
{
    public class AudioManager : IDisposable
    {
        private readonly AudioFile _audioFile;

        private readonly bool _loop;
        private bool _mute;
        private int _priority;
        private float _volume;

        private WindowsAudioPlayer _player; // backend abstraction

        public AudioManager(
            AudioFile audioFile,
            bool startOnLoad = true, bool loop = false, bool mute = false,
            int priority = 128, int volume = 1)
        {
            _audioFile = audioFile;
            _loop = loop;
            _mute = mute;
            _priority = priority;
            _volume = Math.Clamp(volume / 100f, 0f, 1f);

            InitializePlayer();

            if (startOnLoad)
                Play();
        }

        public static bool IsValidWav(byte[] bytes)
        {
            // WAV files start with "RIFF" and contain "WAVE" at offset 8
            return bytes.Length > 12 &&
                   bytes[0] == 'R' && bytes[1] == 'I' && bytes[2] == 'F' && bytes[3] == 'F' &&
                   bytes[8] == 'W' && bytes[9] == 'A' && bytes[10] == 'V' && bytes[11] == 'E';
        }

        private void InitializePlayer()
        {
            switch (_audioFile._loadType)
            {
                case AudioFile.LoadType.streamed:
                    {
                        var stream = _audioFile.GetAudioStream();
                        _player = WindowsAudioPlayer.FromStream(stream);
                        break;
                    }

                case AudioFile.LoadType.loadOnInstantiate:
                case AudioFile.LoadType.loadOnGet:
                case AudioFile.LoadType.loadOnGetThenDestroy:
                    {
                        var bytes = _audioFile.GetAudioBytes();
                        if (!IsValidWav(bytes))
                            throw new InvalidOperationException(
                                $"Audio data is not a valid WAV file. First 4 bytes: {BitConverter.ToString(bytes.Take(4).ToArray())}");
                        _player = WindowsAudioPlayer.FromBytes(bytes);
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            _player.SetLooping(_loop);
            _player.SetVolume(_mute ? 0f : _volume);
        }

        public void Play() => _player?.Play();

        public void Stop() => _player?.Stop();

        public void Pause() => _player?.Pause();

        public void SetMute(bool mute)
        {
            _mute = mute;
            _player?.SetVolume(mute ? 0f : _volume);
        }

        public void SetVolume(int volume)
        {
            _volume = Math.Clamp(volume / 100f, 0f, 1f);
            if (!_mute)
                _player?.SetVolume(_volume);
        }

        public void Dispose()
        {
            _player?.Dispose();
            _player = null;

            _audioFile?.Dispose();
        }
    }
}
