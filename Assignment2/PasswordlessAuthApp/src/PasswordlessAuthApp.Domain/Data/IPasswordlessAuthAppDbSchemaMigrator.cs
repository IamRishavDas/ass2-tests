using System.Threading.Tasks;

namespace PasswordlessAuthApp.Data;

public interface IPasswordlessAuthAppDbSchemaMigrator
{
    Task MigrateAsync();
}
