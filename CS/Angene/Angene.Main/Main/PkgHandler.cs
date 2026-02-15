using Angene.Crypto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Angene.Main
{
    // Simple package loader compatible with the AngeneCompiler format.
    // Use Package.Open(path, key) to read manifest and extract entries.
    public sealed class Package : IDisposable
    {
        private readonly FileStream _fs;
        private readonly Manifest _manifest;
        private readonly byte[] _key;
        private readonly long _manifestOffset;
        private readonly bool _manifestEncrypted;
        private readonly bool _manifestCompressed;
        private readonly byte[] _manifestNonce;

        public IReadOnlyList<ManifestEntry> Entries => _manifest.Files;

        private Package(FileStream fs, Manifest manifest, byte[] key,
            bool manifestEncrypted, bool manifestCompressed, byte[] manifestNonce, long manifestOffset)
        {
            _fs = fs;
            _manifest = manifest;
            _key = key;
            _manifestEncrypted = manifestEncrypted;
            _manifestCompressed = manifestCompressed;
            _manifestNonce = manifestNonce;
            _manifestOffset = manifestOffset;
        }

        public static Package Open(string path, byte[] key = null)
        {
            var fs = File.OpenRead(path);
            using var br = new BinaryReader(fs, Encoding.UTF8, leaveOpen: true);

            var magic = br.ReadBytes(8);
            var magicStr = Encoding.ASCII.GetString(magic);
            if (!magicStr.StartsWith("ANGEPKG"))
                throw new InvalidDataException("Not an ANGENEPKG file.");

            var version = br.ReadUInt32();
            var manifestLength = br.ReadInt64();
            var manifestFlags = br.ReadByte();
            bool manifestEncrypted = (manifestFlags & 0x01) != 0;
            bool manifestCompressed = (manifestFlags & 0x02) != 0;
            byte[] manifestNonce = null;
            if (manifestEncrypted)
            {
                manifestNonce = br.ReadBytes(12);
            }

            long manifestOffset = fs.Position;

            if (manifestLength < 0 || manifestLength > int.MaxValue)
                throw new InvalidDataException("Invalid manifest length.");

            var manifestBytes = new byte[manifestLength];

            // BinaryReader doesn't provide ReadExactly with offset/count overload.
            // Read using the underlying stream to ensure we fill the buffer.
            int toRead = (int)manifestLength;
            int totalRead = 0;
            while (totalRead < toRead)
            {
                int r = fs.Read(manifestBytes, totalRead, toRead - totalRead);
                if (r == 0)
                    throw new EndOfStreamException("Unexpected end of file while reading manifest.");
                totalRead += r;
            }

            // decrypt manifest if necessary
            if (manifestEncrypted)
            {
                if (key == null) throw new InvalidOperationException("Manifest is encrypted; a key must be provided.");
                var plaintext = new byte[manifestBytes.Length];
                var tag = new byte[16]; // tag not stored separately in header for this simple format; if you modify format make sure to persist tag.
                // In the packer above the tag is not stored in header; manifest encryption stores tag in same place? (packer stored tag but did not write it to header)
                // For simplicity the packer writes ciphertext and tag was not separately written; in this loader we assume the packer appended tag at end of ciphertext.
                // So if manifestBytes.Length >= 16 we split last 16 bytes as tag:
                if (manifestBytes.Length < 16) throw new InvalidDataException("Manifest encrypted but too short for tag.");
                var cipher = new byte[manifestBytes.Length - 16];
                Array.Copy(manifestBytes, 0, cipher, 0, cipher.Length);
                Array.Copy(manifestBytes, cipher.Length, tag, 0, 16);

                using var aes = new Angene.Crypto.AesGcm(key);
                aes.Decrypt(manifestNonce, cipher, tag, plaintext, null);

                manifestBytes = plaintext;
            }

            // decompress manifest if necessary
            if (manifestCompressed)
            {
                using var ms = new MemoryStream(manifestBytes);
                using var gz = new GZipStream(ms, CompressionMode.Decompress);
                using var outMs = new MemoryStream();
                gz.CopyTo(outMs);
                manifestBytes = outMs.ToArray();
            }

            var manifestJson = Encoding.UTF8.GetString(manifestBytes);
            var manifest = JsonConvert.DeserializeObject<Manifest>(manifestJson);

            return new Package(fs, manifest, key, manifestEncrypted, manifestCompressed, manifestNonce, manifestOffset);
        }

        // Extract a file to disk (will decrypt/decompress as needed)
        public void ExtractTo(string relativePath, string outPath)
        {
            var entry = FindEntry(relativePath);
            if (entry == null) throw new FileNotFoundException(relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(outPath) ?? ".");
            using var outFs = File.Create(outPath);
            using var inStream = OpenStream(entry);
            inStream.CopyTo(outFs);
        }

        // Open a stream for a package entry (decrypted & decompressed)
        public Stream OpenStream(ManifestEntry entry)
        {
            // read raw bytes
            var buffer = new byte[entry.Length];
            _fs.Seek(entry.Offset, SeekOrigin.Begin);
            int read = 0;
            while (read < buffer.Length)
            {
                var r = _fs.Read(buffer, read, buffer.Length - read);
                if (r == 0) throw new EndOfStreamException();
                read += r;
            }

            byte[] plaintext = buffer;

            // if encrypted: decrypt (ciphertext + tag)
            if (entry.Encrypted)
            {
                if (_key == null) throw new InvalidOperationException("Package is encrypted - key required.");
                var nonce = Convert.FromBase64String(entry.Nonce);
                var tag = Convert.FromBase64String(entry.Tag);
                var cipher = buffer;
                var dest = new byte[cipher.Length];
                using var aes = new Angene.Crypto.AesGcm(_key);
                aes.Decrypt(nonce, cipher, tag, dest, null);
                plaintext = dest;
            }

            // if compressed: decompress
            if (entry.Compressed)
            {
                using var ms = new MemoryStream(plaintext);
                using var gz = new GZipStream(ms, CompressionMode.Decompress);
                var outMs = new MemoryStream();
                gz.CopyTo(outMs);
                outMs.Seek(0, SeekOrigin.Begin);
                return outMs;
            }

            return new MemoryStream(plaintext, writable: false);
        }

        public void Dispose()
        {
            _fs?.Dispose();
        }

        private ManifestEntry FindEntry(string relativePath)
        {
            foreach (var e in _manifest.Files)
                if (string.Equals(e.Path, relativePath.Replace('\\', '/'), StringComparison.OrdinalIgnoreCase))
                    return e;
            return null;
        }

        // Manifest types (must match packer)
        private class Manifest
        {
            public ManifestEntry[] Files { get; set; }
            public DateTime Created { get; set; }
        }

        public class ManifestEntry
        {
            public string Path { get; set; }
            public long Offset { get; set; }
            public long Length { get; set; }
            public bool Compressed { get; set; }
            public bool Encrypted { get; set; }
            public string Nonce { get; set; }
            public string Tag { get; set; }
        }
    }
}