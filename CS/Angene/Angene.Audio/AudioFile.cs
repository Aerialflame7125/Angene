using Angene.Main;
using Angene.Essentials;
using Angene.Common;

namespace Angene.Audio
{
    public class AudioFile : IDisposable
    {
        private string _path;
        private byte[] _audioBytes = null;
        private Package _package;
        private readonly string _packagePath;
        private readonly byte[] _key;
        public LoadType _loadType;

        public enum LoadType
        {
            loadOnInstantiate = 0,
            loadOnGet = 1,
            streamed = 2,
            loadOnGetThenDestroy = 3
        };

        /// <summary>
        /// AudioFile instance to use in AudioManager.
        /// Make sure your format is WAV when using AudioManager.
        /// </summary>
        public AudioFile(string packagePath, string path, LoadType loadType, byte[] key = null)
        {
            _path = path;
            _loadType = loadType;
            _packagePath = packagePath;
            _key = key;

            if (_loadType == LoadType.loadOnInstantiate)
            {
                _audioBytes = ReadEntryBytes();
                // package not needed, disposed.
                _package?.Dispose();
                _package = null;
            }
        }

        private void EnsurePackageOpen()
        {
            if (_package != null) return;
            // key defaulted to null
            _package = Package.Open(_packagePath, _key);
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
                    Dispose();
                    return bytes;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Stream GetAudioStream()
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