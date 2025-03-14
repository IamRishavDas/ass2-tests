using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PasswordlessAuthApp.Authentication
{
    public interface IPasswordlessTokenProviderService: IApplicationService
    {
        public string GenerateTokenString(Guid userId);
        public Guid? ValidateToken(string entryptedString);
    }
}
