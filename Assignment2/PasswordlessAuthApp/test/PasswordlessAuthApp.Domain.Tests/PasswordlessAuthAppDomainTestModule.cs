using Volo.Abp.Modularity;

namespace PasswordlessAuthApp;

[DependsOn(
    typeof(PasswordlessAuthAppDomainModule),
    typeof(PasswordlessAuthAppTestBaseModule)
)]
public class PasswordlessAuthAppDomainTestModule : AbpModule
{

}
