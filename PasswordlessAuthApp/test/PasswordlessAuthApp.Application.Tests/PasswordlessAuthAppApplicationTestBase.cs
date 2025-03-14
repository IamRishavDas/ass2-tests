using Volo.Abp.Modularity;

namespace PasswordlessAuthApp;

public abstract class PasswordlessAuthAppApplicationTestBase<TStartupModule> : PasswordlessAuthAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
