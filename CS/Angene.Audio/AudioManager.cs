using Angene.Audio.Common;

namespace Angene.Audio
{
    public sealed class AudioManager : IDisposable
    {
        private readonly IAudioPlayer _player;

        public bool IsPlaying => _player.IsPlaying;
        public bool IsPaused => _player.IsPaused;
        public float Volume => _player.Volume;
        public bool Looping => _player.Looping;

        public AudioManager(AudioFile file, bool playOnLoad = true,
            bool loop = false, float volume = 1f)
        {
            _player = AudioFactory.Create(file);
            _player.SetLooping(loop);
            _player.SetVolume(volume);
            if (playOnLoad) _player.Play();
        }

        public void Play() => _player.Play();
        public void Stop() => _player.Stop();
        public void Pause() => _player.Pause();
        public void Resume() => _player.Resume();
        public void SetVolume(float v) => _player.SetVolume(v);
        public void SetLooping(bool loop) => _player.SetLooping(loop);

        public void Dispose() => _player.Dispose();
    }
}