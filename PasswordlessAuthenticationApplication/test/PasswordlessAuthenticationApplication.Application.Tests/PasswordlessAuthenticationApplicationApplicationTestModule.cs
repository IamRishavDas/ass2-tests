using Volo.Abp.Modularity;

namespace PasswordlessAuthenticationApplication;

[DependsOn(
    typeof(PasswordlessAuthenticationApplicationApplicationModule),
    typeof(PasswordlessAuthenticationApplicationDomainTestModule)
)]
public class PasswordlessAuthenticationApplicationApplicationTestModule : AbpModule
{

}
