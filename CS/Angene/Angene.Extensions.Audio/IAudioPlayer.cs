namespace Angene.Extensions.Audio
{
    public interface IAudioPlayer : IDisposable
    {
        bool IsPlaying { get; }
        bool IsPaused { get; }
        float Volume { get; }
        bool Looping { get; }
        float PlayPos { get; }

        void Play();
        void Stop();
        void Pause();
        void Resume();
        void SetVolume(float volume);   // 0.0 - 1.0
        void SetLooping(bool loop);
    }
}
