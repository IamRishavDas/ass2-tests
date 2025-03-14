using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordlessAuthApp.Data;
using Volo.Abp.DependencyInjection;

namespace PasswordlessAuthApp.EntityFrameworkCore;

public class EntityFrameworkCorePasswordlessAuthAppDbSchemaMigrator
    : IPasswordlessAuthAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePasswordlessAuthAppDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PasswordlessAuthAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PasswordlessAuthAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
