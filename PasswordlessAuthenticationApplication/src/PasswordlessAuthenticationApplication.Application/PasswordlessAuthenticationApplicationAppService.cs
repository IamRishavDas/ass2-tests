using PasswordlessAuthenticationApplication.Localization;
using Volo.Abp.Application.Services;

namespace PasswordlessAuthenticationApplication;

/* Inherit your application services from this class.
 */
public abstract class PasswordlessAuthenticationApplicationAppService : ApplicationService
{
    protected PasswordlessAuthenticationApplicationAppService()
    {
        LocalizationResource = typeof(PasswordlessAuthenticationApplicationResource);
    }
}
