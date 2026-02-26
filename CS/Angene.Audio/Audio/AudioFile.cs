using Angene.Main;
using Angene.Essentials;
using Angene.Common;

namespace Angene.Audio.Audio
{
    public class AudioFile : IDisposable
    {
        private string _path;
        public byte[] _audioBytes = null;
        private Package _package;
        private string _packagePath;
        public LoadType _loadType;
        private byte[] _key;

        public enum LoadType
        {
            loadOnInstantiate = 0,
            loadOnGet = 1,
            streamed = 2,
            loadOnGetThenDestroy = 3
        };

        /// <summary>
        /// AudioFile instance to use in AudioManager or other class.
        /// NOTE: If you are using AudioManager, make sure your format is WAV.
        /// </summary>
        /// <param name="path"></param>
        public AudioFile(IScene scene, string packagePath, string path, LoadType loadType, byte[] key = null)
        {
            _path = path;
            _loadType = loadType;
            _packagePath = packagePath;
            _key = key;

            if (_loadType == LoadType.loadOnInstantiate)
                _audioBytes = ReadEntryBytes();
        }

        private void EnsurePackageOpen()
        {
            if (_package != null) return;

            _package = _key != null
                ? Package.Open(_packagePath, _key)
                : Package.Open(_packagePath);
        }

        private byte[] ReadEntryBytes()
        {
            EnsurePackageOpen();

            var entry = _package.Entries
                .FirstOrDefault(e =>
                    string.Equals(
                        e.Path,
                        _path.Replace('\\', '/'),
                        StringComparison.OrdinalIgnoreCase));

            if (entry == null)
                throw new FileNotFoundException(
                    $"Audio entry '{_path}' not found in package.");

            using var stream = _package.OpenStream(entry);
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }

        public byte[] GetAudioBytes()
        {
            switch (_loadType)
            {
                case LoadType.loadOnInstantiate:
                case LoadType.loadOnGet:
                    if (_audioBytes == null)
                        _audioBytes = ReadEntryBytes();
                    return _audioBytes;

                case LoadType.loadOnGetThenDestroy:
                    if (_audioBytes == null)
                        _audioBytes = ReadEntryBytes();

                    var bytes = _audioBytes;
                    _audioBytes = null;

                    Dispose(); // release
                    return bytes;

                case LoadType.streamed:
                    throw new InvalidOperationException(
                        "GetAudioBytes() cannot be used for streamed audio.");

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Stream GetAudioStream()
        {
            if (_loadType != LoadType.streamed)
                Logger.LogError("AudioFile is not in streamed mode.", LoggingTarget.Package);

            EnsurePackageOpen();

            var entry = _package.Entries
                .FirstOrDefault(e =>
                    string.Equals(
                        e.Path,
                        _path.Replace('\\', '/'),
                        StringComparison.OrdinalIgnoreCase));

            if (entry == null)
                throw new FileNotFoundException(
                    $"Audio entry '{_path}' not found in package.");

            return _package.OpenStream(entry);
        }

        public void Dispose()
        {
            _audioBytes = null;

            _package?.Dispose();
            _package = null;

            _path = null;
        }
    }
}
