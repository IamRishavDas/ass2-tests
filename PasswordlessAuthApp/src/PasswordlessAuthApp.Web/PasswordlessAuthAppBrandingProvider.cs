using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using PasswordlessAuthApp.Localization;

namespace PasswordlessAuthApp.Web;

[Dependency(ReplaceServices = true)]
public class PasswordlessAuthAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PasswordlessAuthAppResource> _localizer;

    public PasswordlessAuthAppBrandingProvider(IStringLocalizer<PasswordlessAuthAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
