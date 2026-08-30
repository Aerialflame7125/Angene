using Angene.Audio;

namespace Angene.Audio.Common
{
    public static class AudioFactory
    {
        public static IAudioPlayer Create(AudioFile file)
        {
#if WINDOWS
        return file._loadType == AudioFile.LoadType.streamed
            ? Windows.WindowsAudioPlayer.FromStream(file.GetAudioStream())
            : Windows.WindowsAudioPlayer.FromBytes(file.GetAudioBytes());
#else
            return file._loadType == AudioFile.LoadType.streamed
                ? MiniAudio.MiniAudioPlayer.
#endif
        }
    }
}