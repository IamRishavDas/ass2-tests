using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Encryption;

namespace PasswordlessAuthApp.Authentication
{
    public class PasswordlessTokenProviderService: ITransientDependency, IPasswordlessTokenProviderService
    {
        private readonly IStringEncryptionService _encryptionService;

        public PasswordlessTokenProviderService(IStringEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public string GenerateTokenString(Guid userId)
        {
            var token = $"{userId}:{DateTime.UtcNow.AddMinutes(15)}";
            var encryptedToken = _encryptionService.Encrypt(token);
            return encryptedToken ?? throw new InvalidOperationException("Encryption service returned null.");
        }

        public Guid? ValidateToken(string entryptedString)
        {
            try
            {
                var decryptedToken = _encryptionService.Decrypt(entryptedString);
                if (decryptedToken == null) throw new InvalidOperationException("Decryption service returned null.");
                var parts = decryptedToken.Split(":");

                if (parts.Length != 2 || !Guid.TryParse(parts[0], out Guid userId) || !DateTime.TryParse(parts[1], out DateTime expiry))
                    return null;

                return expiry > DateTime.UtcNow ? userId : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
