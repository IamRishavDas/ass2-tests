using Microsoft.Extensions.Localization;
using PasswordlessAuthenticationApplication.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PasswordlessAuthenticationApplication;

[Dependency(ReplaceServices = true)]
public class PasswordlessAuthenticationApplicationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<PasswordlessAuthenticationApplicationResource> _localizer;

    public PasswordlessAuthenticationApplicationBrandingProvider(IStringLocalizer<PasswordlessAuthenticationApplicationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
