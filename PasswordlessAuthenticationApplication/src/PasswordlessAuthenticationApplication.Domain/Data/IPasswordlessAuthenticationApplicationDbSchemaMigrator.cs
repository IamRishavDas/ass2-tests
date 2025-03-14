using System.Threading.Tasks;

namespace PasswordlessAuthenticationApplication.Data;

public interface IPasswordlessAuthenticationApplicationDbSchemaMigrator
{
    Task MigrateAsync();
}
