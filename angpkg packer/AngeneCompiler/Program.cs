using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AngeneCompiler
{
    internal class Program
    {
        // Simple packer for .angpkg
        // Usage:
        //   AngeneCompiler pack <inputFolder> <outputFile> [--key hexkey] [--compress] [--encrypt]
        static int Main(string[] args)
        {
            if (args.Length < 3 || args[0] != "pack")
            {
                Console.WriteLine("Usage: AngeneCompiler pack <inputFolder> <outputFile> [--key hexkey] [--compress] [--encrypt]");
                return 1;
            }

            var input = args[1];
            var output = args[2];

            bool compress = args.Contains("--compress");
            bool encrypt = args.Contains("--encrypt");
            byte[] key = null;

            var keyArgIndex = Array.FindIndex(args, a => a == "--key");
            if (keyArgIndex >= 0 && keyArgIndex + 1 < args.Length)
            {
                key = HexToBytes(args[keyArgIndex + 1]);
                if (key == null || (key.Length != 16 && key.Length != 24 && key.Length != 32))
                {
                    Console.WriteLine("Key must be hex and 16/24/32 bytes long (AES-128/192/256).");
                    return 2;
                }
            }
            else if (encrypt)
            {
                Console.WriteLine("Encryption requested but no --key provided.");
                return 3;
            }

            try
            {
                PackDirectory(input, output, compress, encrypt, key);
                Console.WriteLine("Packed successfully to: " + output);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Packing failed: " + ex);
                return 99;
            }
        }

        private static void PackDirectory(string inputFolder, string outputFile, bool compress, bool encrypt, byte[] key)
        {
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"ERROR: Input folder not found: {inputFolder}");
                throw new DirectoryNotFoundException(inputFolder);
            }

            var files = Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories)
                .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            Console.WriteLine($"Found {files.Length} files in '{inputFolder}'");

            // STEP 1: Process all files and prepare their data in memory
            var entries = new List<ManifestEntry>();
            var fileDataList = new List<byte[]>();

            foreach (var path in files)
            {
                var rel = Path.GetRelativePath(inputFolder, path).Replace('\\', '/');
                var fileBytes = File.ReadAllBytes(path);
                Console.WriteLine($"  Processing: {rel} ({fileBytes.Length} bytes)");

                // compress if requested
                bool entryCompressed = false;
                byte[] processed = fileBytes;
                if (compress)
                {
                    entryCompressed = true;
                    using var msOut = new MemoryStream();
                    using (var gz = new GZipStream(msOut, CompressionLevel.Optimal, leaveOpen: true))
                    {
                        gz.Write(fileBytes, 0, fileBytes.Length);
                    }
                    processed = msOut.ToArray();
                }

                bool entryEncrypted = false;
                byte[] nonce = null;
                byte[] tag = null;
                if (encrypt)
                {
                    entryEncrypted = true;
                    using var rng = RandomNumberGenerator.Create();
                    nonce = new byte[12];
                    rng.GetBytes(nonce);

                    var ciphertext = new byte[processed.Length];
                    tag = new byte[16];
                    using var aes = new AesGcm(key);
                    aes.Encrypt(nonce, processed, ciphertext, tag, null);
                    processed = ciphertext;
                }

                fileDataList.Add(processed);

                // Use large placeholder offsets (will be updated later)
                entries.Add(new ManifestEntry
                {
                    Path = rel,
                    Offset = 99999999,  // Large placeholder to account for manifest size
                    Length = processed.Length,
                    Compressed = entryCompressed,
                    Encrypted = entryEncrypted,
                    Nonce = nonce != null ? Convert.ToBase64String(nonce) : null,
                    Tag = tag != null ? Convert.ToBase64String(tag) : null
                });
            }

            // STEP 2: Build manifest with placeholder offsets and determine final manifest size
            var manifest = new Manifest
            {
                Files = entries.ToArray(),
                Created = DateTime.UtcNow
            };

            // Serialize to JSON (uncompressed/unencrypted)
            var manifestJsonRaw = JsonSerializer.SerializeToUtf8Bytes(manifest, new JsonSerializerOptions { WriteIndented = false });
            Console.WriteLine($"Manifest JSON (raw): {manifestJsonRaw.Length} bytes");

            // STEP 3: Calculate header size
            int headerSize = 8 + 4 + 8 + 1; // magic + version + manifestLen + flags
            byte[] manifestNonce = null;

            if (encrypt)
            {
                headerSize += 12; // nonce
                manifestNonce = new byte[12];
                RandomNumberGenerator.Create().GetBytes(manifestNonce);
            }

            // STEP 4: Now compress/encrypt manifest to get FINAL size
            // (but keep using placeholder offsets for now)
            byte[] finalManifest = ProcessManifest(manifestJsonRaw, compress, encrypt, key, manifestNonce);
            Console.WriteLine($"Manifest (processed): {finalManifest.Length} bytes");

            // STEP 5: Calculate actual file offsets
            long currentOffset = headerSize + finalManifest.Length;
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].Offset = currentOffset;
                currentOffset += fileDataList[i].Length;
                Console.WriteLine($"  File {i}: offset={entries[i].Offset}, length={entries[i].Length}");
            }

            // STEP 6: Rebuild manifest with ACTUAL offsets
            manifest.Files = entries.ToArray();
            manifestJsonRaw = JsonSerializer.SerializeToUtf8Bytes(manifest, new JsonSerializerOptions { WriteIndented = false });

            // Process manifest again with actual offsets
            finalManifest = ProcessManifest(manifestJsonRaw, compress, encrypt, key, manifestNonce);

            // Verify size didn't change (it shouldn't change much since we used large placeholders)
            int sizeChange = Math.Abs(finalManifest.Length - (int)(currentOffset - headerSize));
            if (sizeChange > 0)
            {
                Console.WriteLine($"Warning: Manifest size changed by {sizeChange} bytes after updating offsets");
                // Recalculate if there was a significant change
                currentOffset = headerSize + finalManifest.Length;
                for (int i = 0; i < entries.Count; i++)
                {
                    entries[i].Offset = currentOffset;
                    currentOffset += fileDataList[i].Length;
                }
                manifest.Files = entries.ToArray();
                manifestJsonRaw = JsonSerializer.SerializeToUtf8Bytes(manifest, new JsonSerializerOptions { WriteIndented = false });
                finalManifest = ProcessManifest(manifestJsonRaw, compress, encrypt, key, manifestNonce);
            }

            // STEP 7: Write the file in correct order
            using var outFs = File.Create(outputFile);
            using var bw = new BinaryWriter(outFs, Encoding.UTF8, leaveOpen: true);

            // Write header
            bw.Write(Encoding.ASCII.GetBytes("ANGEPKG\0")); // 8 bytes
            bw.Write((uint)1); // version
            bw.Write((long)finalManifest.Length); // manifest length

            byte flags = 0;
            if (encrypt) flags |= 0x01;
            if (compress) flags |= 0x02;
            bw.Write(flags);

            if (encrypt)
            {
                bw.Write(manifestNonce); // 12 bytes
            }

            Console.WriteLine($"Header size: {outFs.Position} bytes");

            // Write manifest immediately after header
            bw.Write(finalManifest);
            Console.WriteLine($"Manifest written at offset {headerSize}, size {finalManifest.Length}");

            // Write all file data
            long fileStartOffset = outFs.Position;
            foreach (var fileData in fileDataList)
            {
                bw.Write(fileData);
            }

            bw.Flush();

            Console.WriteLine($"\nPackage created: {outFs.Length} bytes");
            Console.WriteLine($"  Header: {headerSize} bytes");
            Console.WriteLine($"  Manifest: {finalManifest.Length} bytes");
            Console.WriteLine($"  File data: {fileDataList.Sum(f => f.Length)} bytes (starts at offset {fileStartOffset})");
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