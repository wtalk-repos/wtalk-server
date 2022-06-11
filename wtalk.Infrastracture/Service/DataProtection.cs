using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Wtalk.Core.Interfaces;

namespace Wtalk.Infrastracture.Service
{
    public class DataProtection : IDataProtection
    {
        private readonly IConfiguration _config;

        public DataProtection(IConfiguration config)
        {
            _config = config;
        }

        public string Decrypt(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(_config["AES:Key"]);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        public string Encrypt(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_config["AES:Key"]);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }

                array = memoryStream.ToArray();
            }

            return Convert.ToBase64String(array);
        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            var rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);

        }

        public string Hash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password: password,
           salt: Encoding.UTF8.GetBytes(salt),
           prf: KeyDerivationPrf.HMACSHA256,
           iterationCount: 100000,
           numBytesRequested: 256 / 8));

        }
    }
}
