using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Encryption;

namespace PasswordlessAuthenticationApplication.Identity
{
    public class PasswordlessTokenProvider: ITransientDependency
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IStringEncryptionService _encryptionService;

        public PasswordlessTokenProvider(IIdentityUserRepository userRepository, IStringEncryptionService encryptionService)
        {
            _userRepository = userRepository;
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
