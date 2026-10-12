using Angene.Extensions.Audio;
using Angene.Extensions.Audio.MiniAudio;

namespace Angene.Extensions.Audio.Common
{
    public static class AudioFactory
    {
        public static IAudioPlayer Create(AudioFile file)
        {
            return file._loadType == AudioFile.LoadType.streamed
                ? MiniAudio.MiniAudioPlayer.InitAudioPlayer(file, MiniAudioPlayerType.Stream)
                : MiniAudio.MiniAudioPlayer.InitAudioPlayer(file, MiniAudioPlayerType.Memory);
        }
    }
}