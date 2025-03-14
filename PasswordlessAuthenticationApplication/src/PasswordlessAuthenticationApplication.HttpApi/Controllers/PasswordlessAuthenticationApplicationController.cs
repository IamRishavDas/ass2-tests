using PasswordlessAuthenticationApplication.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PasswordlessAuthenticationApplication.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PasswordlessAuthenticationApplicationController : AbpControllerBase
{
    protected PasswordlessAuthenticationApplicationController()
    {
        LocalizationResource = typeof(PasswordlessAuthenticationApplicationResource);
    }
}
