using PasswordlessAuthApp.Localization;
using Volo.Abp.Application.Services;

namespace PasswordlessAuthApp;

/* Inherit your application services from this class.
 */
public abstract class PasswordlessAuthAppAppService : ApplicationService
{
    protected PasswordlessAuthAppAppService()
    {
        LocalizationResource = typeof(PasswordlessAuthAppResource);
    }
}
