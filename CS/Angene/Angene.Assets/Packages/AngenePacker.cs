using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Angene.Common;

namespace Angene.Assets.Packages
{ 
    public class AngenePacker
    {
        public static void PackDirectory(string inputFolder, string outputFile, bool compress, bool encrypt, byte[] key)
        {
            if (!Directory.Exists(inputFolder))
            {
                Logger.LogError($"ERROR: Input folder not found: {inputFolder}", LoggingTarget.Engine);
                throw new DirectoryNotFoundException(inputFolder);
            }

            var files = Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories)
                .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            var entries = new List<ManifestEntry>();
            var blobs = new List<Blob>();

            foreach (var path in files)
            {
                var rel = Path.GetRelativePath(inputFolder, path).Replace('\\', '/');
                var bytes = File.ReadAllBytes(path);
                var (entry, data) = PrepareEntry(rel, bytes, compress, encrypt, key);
                entries.Add(entry);
                blobs.Add(new Blob { Bytes = data, Length = data.Length });
            }

            WritePackage(outputFile, entries, blobs, null, compress, encrypt, key, DateTime.UtcNow);
        }

        private static byte[] ProcessManifest(byte[] manifestJson, bool compress, bool encrypt, byte[] key, byte[] nonce)
        {
            byte[] result = manifestJson;

            // Compress if requested
            if (compress)
            {
                using var ms = new MemoryStream();
                using (var gz = new GZipStream(ms, CompressionLevel.Optimal, leaveOpen: true))
                    gz.Write(result, 0, result.Length);
                result = ms.ToArray();
            }

            // Encrypt if requested
            if (encrypt)
            {
                var ciphertext = new byte[result.Length];
                var tag = new byte[16];
                using var aes = new AesGcm(key);
                aes.Encrypt(nonce, result, ciphertext, tag, null);

                // Append tag to ciphertext
                var combined = new byte[ciphertext.Length + tag.Length];
                Array.Copy(ciphertext, 0, combined, 0, ciphertext.Length);
                Array.Copy(tag, 0, combined, ciphertext.Length, tag.Length);
                result = combined;
            }

            return result;
        }
        
        private sealed class Blob
        {
            public long SrcOffset;
            public byte[] Bytes;
            public long Length;
        }

        private static (ManifestEntry entry, byte[] data) PrepareEntry(
            string rel, byte[] raw, bool compress, bool encrypt, byte[] key)
        {
            byte[] processed = raw, nonce = null, tag = null;

            if (compress)
            {
                using var ms = new MemoryStream();
                using (var gz = new GZipStream(ms, CompressionLevel.Optimal, leaveOpen: true))
                    gz.Write(raw, 0, raw.Length);
                processed = ms.ToArray();
            }

            if (encrypt)
            {
                nonce = new byte[12];
                RandomNumberGenerator.Fill(nonce);
                var ct = new byte[processed.Length];
                tag = new byte[16];
                using var aes = new AesGcm(key);
                aes.Encrypt(nonce, processed, ct, tag, null);
                processed = ct;
            }

            return (new ManifestEntry
            {
                Path = rel,
                Offset = 0,
                Length = processed.Length,
                Compressed = compress,
                Encrypted = encrypt,
                Nonce = nonce != null ? Convert.ToBase64String(nonce) : null,
                Tag = tag != null ? Convert.ToBase64String(tag) : null
            }, processed);
        }
        
        private static void WritePackage(string outputFile, List<ManifestEntry> entries, List<Blob> blobs,
            Stream source, bool compress, bool encrypt, byte[] key, DateTime created)
        {
            int headerSize = 8 + 4 + 8 + 1 + (encrypt ? 12 : 0);
            
            byte[] manifestNonce = null;
            if (encrypt) { manifestNonce = new byte[12]; RandomNumberGenerator.Fill(manifestNonce); }

            byte[] finalManifest = null;
            long dataStart = headerSize;
            for (int attempt = 0; ; attempt++)
            {
                long off = dataStart;
                for (int i = 0; i < entries.Count; i++) { entries[i].Offset = off; off += blobs[i].Length; }

                var raw = JsonSerializer.SerializeToUtf8Bytes(
                    new Manifest { Files = entries.ToArray(), Created = created },
                    new JsonSerializerOptions { WriteIndented = false });
                var processed = ProcessManifest(raw, compress, encrypt, key, manifestNonce);

                if (headerSize + processed.Length == dataStart) { finalManifest = processed; break; }
                if (attempt >= 16) throw new InvalidOperationException("Manifest size failed to converge.");
                dataStart = headerSize + processed.Length;
            }

            using var outFs = File.Create(outputFile);
            using var bw = new BinaryWriter(outFs, Encoding.UTF8, leaveOpen: true);

            bw.Write(Encoding.ASCII.GetBytes("ANGEPKG\0"));
            bw.Write((uint)1);
            bw.Write((long)finalManifest.Length);
            byte flags = 0;
            if (encrypt) flags |= 0x01;
            if (compress) flags |= 0x02;
            bw.Write(flags);
            if (encrypt) bw.Write(manifestNonce);
            bw.Write(finalManifest);
            bw.Flush();

            var buf = new byte[81920];
            foreach (var blob in blobs)
            {
                if (blob.Bytes != null) { outFs.Write(blob.Bytes, 0, blob.Bytes.Length); continue; }

                source.Seek(blob.SrcOffset, SeekOrigin.Begin);   // stream old data, don't load it all
                long remaining = blob.Length;
                while (remaining > 0)
                {
                    int n = source.Read(buf, 0, (int)System.Math.Min(buf.Length, remaining));
                    if (n <= 0) throw new EndOfStreamException("Package ended before an entry's data did.");
                    outFs.Write(buf, 0, n);
                    remaining -= n;
                }
            }
        }

        private static Manifest ReadManifest(Stream src, byte[] key, out bool compress, out bool encrypt)
        {
            using var br = new BinaryReader(src, Encoding.UTF8, leaveOpen: true);

            if (!br.ReadBytes(8).SequenceEqual(Encoding.ASCII.GetBytes("ANGEPKG\0")))
                throw new InvalidDataException("Not an .angpkg file.");
            if (br.ReadUInt32() != 1)
                throw new InvalidDataException("Unsupported package version.");

            long manifestLen = br.ReadInt64();
            byte flags = br.ReadByte();
            encrypt = (flags & 0x01) != 0;
            compress = (flags & 0x02) != 0;

            byte[] nonce = encrypt ? br.ReadBytes(12) : null;
            byte[] data = br.ReadBytes(checked((int)manifestLen));

            if (encrypt)
            {
                if (key == null) throw new ArgumentException("This package is encrypted; a key is required.");
                var ct = data[..^16];
                var tag = data[^16..];
                var pt = new byte[ct.Length];
                using var aes = new AesGcm(key);
                aes.Decrypt(nonce, ct, tag, pt, null);
                data = pt;
            }

            if (compress)
            {
                using var gz = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
                using var o = new MemoryStream();
                gz.CopyTo(o);
                data = o.ToArray();
            }

            return JsonSerializer.Deserialize<Manifest>(data)
                   ?? throw new InvalidDataException("Package manifest is empty or corrupt.");
        }
        
        public static Package AppendToPackage(string packagePath,
            IEnumerable<(string Path, byte[] Data)> newFiles,
            byte[] key = null, bool replaceExisting = false)
        {
            var incoming = newFiles
                .Select(f => (Path: f.Path.Replace('\\', '/'), f.Data))
                .ToList();

            if (incoming.GroupBy(f => f.Path, StringComparer.OrdinalIgnoreCase).Any(g => g.Count() > 1))
                throw new ArgumentException("The files being appended contain duplicate paths.");

            string tmp = packagePath + ".tmp";
            try
            {
                using (var src = new FileStream(packagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var manifest = ReadManifest(src, key, out bool compress, out bool encrypt);
                    var entries = manifest.Files.ToList();

                    foreach (var f in incoming)
                    {
                        int idx = entries.FindIndex(e => string.Equals(e.Path, f.Path, StringComparison.OrdinalIgnoreCase));
                        if (idx < 0) continue;
                        if (!replaceExisting)
                            throw new InvalidOperationException($"'{f.Path}' already exists in the package.");
                        entries.RemoveAt(idx);
                    }
                    
                    var blobs = entries.Select(e => new Blob { SrcOffset = e.Offset, Length = e.Length }).ToList();
                    
                    foreach (var f in incoming)
                    {
                        var (entry, data) = PrepareEntry(f.Path, f.Data, compress, encrypt, key);
                        entries.Add(entry);
                        blobs.Add(new Blob { Bytes = data, Length = data.Length });
                    }

                    WritePackage(tmp, entries, blobs, src, compress, encrypt, key, manifest.Created);
                }

                File.Move(tmp, packagePath, overwrite: true);   // never leaves a half-written package
            }
            catch
            {
                if (File.Exists(tmp)) File.Delete(tmp);
                throw;
            }

            return Package.Open(packagePath);
        }

        public static Package AppendToPackage(string packagePath, string entryPath, byte[] data,
            byte[] key = null, bool replaceExisting = false)
            => AppendToPackage(packagePath, new[] { (entryPath, data) }, key, replaceExisting);

        // Manifest types
        private class Manifest
        {
            public ManifestEntry[] Files { get; set; }
            public DateTime Created { get; set; }
        }

        private class ManifestEntry
        {
            public string Path { get; set; }
            public long Offset { get; set; }
            public long Length { get; set; }
            public bool Compressed { get; set; }
            public bool Encrypted { get; set; }
            public string Nonce { get; set; }
            public string Tag { get; set; }
        }

        private static byte[] HexToBytes(string hex)
        {
            try
            {
                if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) hex = hex.Substring(2);
                if (hex.Length % 2 != 0) hex = "0" + hex;
                var outb = new byte[hex.Length / 2];
                for (int i = 0; i < outb.Length; i++)
                    outb[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                return outb;
            }
            catch { return null; }
        }
    }
}