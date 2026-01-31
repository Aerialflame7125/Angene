using System;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace Angene.Crypto
{
    /// <summary>
    /// AES-GCM wrapper for .NET Framework 4.8 using Bouncy Castle.
    /// Provides the same interface as System.Security.Cryptography.AesGcm
    /// which is only available in .NET Core 3.0+
    /// </summary>
    public sealed class AesGcm : IDisposable
    {
        private readonly byte[] _key;

        public AesGcm(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // AES-GCM supports 128, 192, and 256-bit keys
            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                throw new ArgumentException("Key must be 128, 192, or 256 bits", nameof(key));

            _key = new byte[key.Length];
            Array.Copy(key, _key, key.Length);
        }

        /// <summary>
        /// Decrypt data using AES-GCM.
        /// </summary>
        /// <param name="nonce">12-byte nonce</param>
        /// <param name="ciphertext">Encrypted data</param>
        /// <param name="tag">16-byte authentication tag</param>
        /// <param name="plaintext">Buffer to receive decrypted data</param>
        /// <param name="associatedData">Optional associated data (AAD)</param>
        public void Decrypt(byte[] nonce, byte[] ciphertext, byte[] tag, byte[] plaintext, byte[]? associatedData)
        {
            if (nonce == null)
                throw new ArgumentNullException(nameof(nonce));
            if (ciphertext == null)
                throw new ArgumentNullException(nameof(ciphertext));
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            if (plaintext == null)
                throw new ArgumentNullException(nameof(plaintext));

            // Bouncy Castle expects ciphertext + tag concatenated
            var ciphertextWithTag = new byte[ciphertext.Length + tag.Length];
            Array.Copy(ciphertext, 0, ciphertextWithTag, 0, ciphertext.Length);
            Array.Copy(tag, 0, ciphertextWithTag, ciphertext.Length, tag.Length);

            // Create GCM cipher
            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(
                new KeyParameter(_key),
                tag.Length * 8, // tag size in bits
                nonce,
                associatedData);

            cipher.Init(false, parameters); // false = decrypt

            // Process the data
            try
            {
                int len = cipher.ProcessBytes(ciphertextWithTag, 0, ciphertextWithTag.Length, plaintext, 0);
                cipher.DoFinal(plaintext, len);
            }
            catch (Exception ex)
            {
                throw new System.Security.Cryptography.CryptographicException("Decryption failed", ex);
            }
        }

        /// <summary>
        /// Encrypt data using AES-GCM.
        /// </summary>
        /// <param name="nonce">12-byte nonce</param>
        /// <param name="plaintext">Data to encrypt</param>
        /// <param name="ciphertext">Buffer to receive encrypted data</param>
        /// <param name="tag">Buffer to receive 16-byte authentication tag</param>
        /// <param name="associatedData">Optional associated data (AAD)</param>
        public void Encrypt(byte[] nonce, byte[] plaintext, byte[] ciphertext, byte[] tag, byte[]? associatedData)
        {
            if (nonce == null)
                throw new ArgumentNullException(nameof(nonce));
            if (plaintext == null)
                throw new ArgumentNullException(nameof(plaintext));
            if (ciphertext == null)
                throw new ArgumentNullException(nameof(ciphertext));
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            // Create GCM cipher
            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(
                new KeyParameter(_key),
                tag.Length * 8, // tag size in bits
                nonce,
                associatedData);

            cipher.Init(true, parameters); // true = encrypt

            // Process the data
            // Bouncy Castle produces ciphertext + tag concatenated
            var output = new byte[ciphertext.Length + tag.Length];
            try
            {
                int len = cipher.ProcessBytes(plaintext, 0, plaintext.Length, output, 0);
                cipher.DoFinal(output, len);
            }
            catch (Exception ex)
            {
                throw new System.Security.Cryptography.CryptographicException("Encryption failed", ex);
            }

            // Split into ciphertext and tag
            Array.Copy(output, 0, ciphertext, 0, ciphertext.Length);
            Array.Copy(output, ciphertext.Length, tag, 0, tag.Length);
        }

        public void Dispose()
        {
            // Clear the key from memory
            if (_key != null)
                Array.Clear(_key, 0, _key.Length);
        }
    }
}