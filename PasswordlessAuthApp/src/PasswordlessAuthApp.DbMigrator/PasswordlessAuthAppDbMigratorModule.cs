using PasswordlessAuthApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace PasswordlessAuthApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PasswordlessAuthAppEntityFrameworkCoreModule),
    typeof(PasswordlessAuthAppApplicationContractsModule)
)]
public class PasswordlessAuthAppDbMigratorModule : AbpModule
{
}
