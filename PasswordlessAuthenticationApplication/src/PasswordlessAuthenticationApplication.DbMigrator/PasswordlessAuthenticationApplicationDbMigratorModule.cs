using PasswordlessAuthenticationApplication.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace PasswordlessAuthenticationApplication.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PasswordlessAuthenticationApplicationEntityFrameworkCoreModule),
    typeof(PasswordlessAuthenticationApplicationApplicationContractsModule)
)]
public class PasswordlessAuthenticationApplicationDbMigratorModule : AbpModule
{
}
