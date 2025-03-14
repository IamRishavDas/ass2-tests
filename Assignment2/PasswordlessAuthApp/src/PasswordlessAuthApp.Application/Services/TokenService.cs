using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace PasswordlessAuthApp.Services
{
    public class TokenService : ApplicationService, ITokenManager
    {

        private static readonly string EncryptionKey = "YourSecretKey1234";

        public T DecryptObject<T>(string encryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);
            using Aes aes = Aes.Create();
            using Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(TokenService.EncryptionKey, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256);
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();

            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            return JsonSerializer.Deserialize<T>(jsonString) ?? throw new Exception("Invalid DecryptObject");
        }

        public string EncryptObject<T>(T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            byte[] clearBytes = Encoding.UTF8.GetBytes(jsonString);
            using Aes aes = Aes.Create();
            using Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(TokenService.EncryptionKey, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256);
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
