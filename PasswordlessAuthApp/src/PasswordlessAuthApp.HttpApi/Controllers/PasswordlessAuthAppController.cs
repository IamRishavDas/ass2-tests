using PasswordlessAuthApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PasswordlessAuthApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class PasswordlessAuthAppController : AbpControllerBase
{
    protected PasswordlessAuthAppController()
    {
        LocalizationResource = typeof(PasswordlessAuthAppResource);
    }
}
