using Volo.Abp.Modularity;

namespace PasswordlessAuthApp;

[DependsOn(
    typeof(PasswordlessAuthAppApplicationModule),
    typeof(PasswordlessAuthAppDomainTestModule)
)]
public class PasswordlessAuthAppApplicationTestModule : AbpModule
{

}
