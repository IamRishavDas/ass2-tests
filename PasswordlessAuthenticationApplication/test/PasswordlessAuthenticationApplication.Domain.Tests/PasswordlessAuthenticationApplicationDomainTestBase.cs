using Volo.Abp.Modularity;

namespace PasswordlessAuthenticationApplication;

/* Inherit from this class for your domain layer tests. */
public abstract class PasswordlessAuthenticationApplicationDomainTestBase<TStartupModule> : PasswordlessAuthenticationApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
