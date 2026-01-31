using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;

namespace Angene.Protection
{
    // Lightweight assembly-integrity helper — intended as a build-time assist,
    // not a security silver bullet. Use this in combination with a proper
    // obfuscator and native code for anything security-critical.
    public static class Integrity
    {
        // Compute SHA256 hash of the running assembly file.
        public static byte[] ComputeCurrentAssemblyHash()
        {
            var asm = Assembly.GetExecutingAssembly();
            var path = asm.Location;
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                return Array.Empty<byte>();

            using var fs = File.OpenRead(path);
            using var sha = SHA256.Create();
            return sha.ComputeHash(fs);
        }

        // Assert the running assembly matches the expected hash.
        // Call this early from your game (e.g., at Start). Provide the expected
        // hash when you build/publish (compute it once and embed the bytes).
        public static void AssertAssemblyHash(byte[] expectedHash)
        {
            if (expectedHash == null || expectedHash.Length == 0)
                throw new ArgumentException("expectedHash must be provided", nameof(expectedHash));

            var actual = ComputeCurrentAssemblyHash();
            if (!actual.SequenceEqual(expectedHash))
                throw new SecurityException("Assembly integrity check failed.");
        }
    }
}
