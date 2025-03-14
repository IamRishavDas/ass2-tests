using Volo.Abp.Modularity;

namespace PasswordlessAuthApp;

/* Inherit from this class for your domain layer tests. */
public abstract class PasswordlessAuthAppDomainTestBase<TStartupModule> : PasswordlessAuthAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
