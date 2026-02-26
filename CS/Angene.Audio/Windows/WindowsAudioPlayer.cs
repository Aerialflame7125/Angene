using System.Text;

namespace Angene.Audio.Windows
{
    internal sealed class WindowsAudioPlayer
    {
        private readonly string _alias;
        private readonly string _tempFile;
        private bool _loop;

        private WindowsAudioPlayer(string tempFile)
        {
            _tempFile = tempFile;
            _alias = "audio_" + Guid.NewGuid().ToString("N");

            Send($"open \"{_tempFile}\" type waveaudio alias {_alias}");
        }

        public static WindowsAudioPlayer FromBytes(byte[] bytes)
        {
            var temp = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString("N") + ".wav");

            File.WriteAllBytes(temp, bytes);
            return new WindowsAudioPlayer(temp);
        }

        public static WindowsAudioPlayer FromStream(Stream stream)
        {
            var temp = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString("N") + ".wav");

            using (var fs = File.Create(temp))
            {
                if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fs);
            }
                
            return new WindowsAudioPlayer(temp);
        }

        public void Play()
        {
            Send(_loop
                ? $"play {_alias} repeat"
                : $"play {_alias}");
        }

        public void Pause()
        {
            Send($"pause {_alias}");
        }

        public void Stop()
        {
            Send($"stop {_alias}");
            Send($"seek {_alias} to start");
        }

        public void SetLooping(bool loop)
        {
            _loop = loop;
        }

        public void SetVolume(float volume)
        {
            int v = (int)(Math.Clamp(volume, 0f, 1f) * 1000);
            Send($"setaudio {_alias} volume to {v}");
        }

        public void Dispose()
        {
            try
            {
                Send($"close {_alias}");
            }
            finally
            {
                if (File.Exists(_tempFile))
                    File.Delete(_tempFile);
            }
        }

        private static void Send(string command)
        {
            int err = WinMM.mciSendString(command, null, 0, IntPtr.Zero);
            if (err != 0)
                throw new InvalidOperationException(
                    $"MCI error {err} executing: {command}");
        }
    }
}