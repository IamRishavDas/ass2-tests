using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PasswordlessAuthApp.Data;

/* This is used if database provider does't define
 * IPasswordlessAuthAppDbSchemaMigrator implementation.
 */
public class NullPasswordlessAuthAppDbSchemaMigrator : IPasswordlessAuthAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
