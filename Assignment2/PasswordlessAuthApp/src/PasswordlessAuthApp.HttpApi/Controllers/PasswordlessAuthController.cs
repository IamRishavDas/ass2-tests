using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PasswordlessAuthApp.Dtos;
using PasswordlessAuthApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordlessAuthApp.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class PasswordlessAuthController: ControllerBase
    {
        //private readonly ITokenManager _tokenManager;
        private readonly IEmailSender _emailSender;

        public PasswordlessAuthController(/*ITokenManager tokenManager,*/ IEmailSender emailSender)
        {
            //_tokenManager = tokenManager;
            _emailSender = emailSender;
        }

        [HttpGet("passwordless-token")]
        public async Task<IActionResult> GetPasswordlessAuthenticationTokenToMail(string email)
        {
            var token = EncryptObject<PasswordlessAuthDto>(new PasswordlessAuthDto(email));
            var loginUrl = $"https://localhost:44349/api/auth/login?{token}";
            await _emailSender.SendEmailAsync(
                    email,
                    "Log in using this link",
                    $"Click link to login: <a href='{loginUrl}'>Login</a>"
                );
            return Ok(loginUrl);
        }

        [HttpPost("login")]
        public IActionResult ValidatePasswordlessAuthenticationToken(string token)
        {
            return Ok(DecryptObject<PasswordlessAuthDto>(token));
        }

        private static readonly string EncryptionKey = "dfh232asdjfashd23423*/2fhak3422dfjasdk34fj";

        private static T DecryptObject<T>(string encryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);
            using Aes aes = Aes.Create();
            using Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(EncryptionKey, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256);
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using MemoryStream ms = new();
            using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherBytes, 0, cipherBytes.Length);
            cs.Close();

            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            return JsonSerializer.Deserialize<T>(jsonString) ?? throw new Exception("Invalid DecryptObject");
        }

        private static string EncryptObject<T>(T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            byte[] clearBytes = Encoding.UTF8.GetBytes(jsonString);
            using Aes aes = Aes.Create();
            using Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(EncryptionKey, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256);
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
