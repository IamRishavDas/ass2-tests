using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PasswordlessAuthenticationApplication.Data;
using Volo.Abp.DependencyInjection;

namespace PasswordlessAuthenticationApplication.EntityFrameworkCore;

public class EntityFrameworkCorePasswordlessAuthenticationApplicationDbSchemaMigrator
    : IPasswordlessAuthenticationApplicationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePasswordlessAuthenticationApplicationDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PasswordlessAuthenticationApplicationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PasswordlessAuthenticationApplicationDbContext>()
            .Database
            .MigrateAsync();
    }
}
