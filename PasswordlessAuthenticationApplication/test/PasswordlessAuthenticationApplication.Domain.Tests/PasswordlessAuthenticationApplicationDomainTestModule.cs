using Volo.Abp.Modularity;

namespace PasswordlessAuthenticationApplication;

[DependsOn(
    typeof(PasswordlessAuthenticationApplicationDomainModule),
    typeof(PasswordlessAuthenticationApplicationTestBaseModule)
)]
public class PasswordlessAuthenticationApplicationDomainTestModule : AbpModule
{

}
