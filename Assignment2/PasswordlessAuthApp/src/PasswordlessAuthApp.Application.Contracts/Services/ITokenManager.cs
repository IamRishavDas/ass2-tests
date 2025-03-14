using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PasswordlessAuthApp.Services
{
    public interface ITokenManager: IApplicationService
    {
        string EncryptObject<T>(T obj);
        T DecryptObject<T>(string encryptedText);
    }
}
