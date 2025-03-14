using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PasswordlessAuthenticationApplication.Data;

/* This is used if database provider does't define
 * IPasswordlessAuthenticationApplicationDbSchemaMigrator implementation.
 */
public class NullPasswordlessAuthenticationApplicationDbSchemaMigrator : IPasswordlessAuthenticationApplicationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
