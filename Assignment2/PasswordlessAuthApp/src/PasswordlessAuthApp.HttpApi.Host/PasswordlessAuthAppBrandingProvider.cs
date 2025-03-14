using Microsoft.Extensions.Localization;
using PasswordlessAuthApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PasswordlessAuthApp;

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
