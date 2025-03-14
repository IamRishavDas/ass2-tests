using PasswordlessAuthApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PasswordlessAuthApp.Web.Pages;

public abstract class PasswordlessAuthAppPageModel : AbpPageModel
{
    protected PasswordlessAuthAppPageModel()
    {
        LocalizationResourceType = typeof(PasswordlessAuthAppResource);
    }
}
