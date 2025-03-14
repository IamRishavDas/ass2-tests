using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PasswordlessAuthenticationApplication.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class PasswordlessAuthenticationApplicationDbContextFactory : IDesignTimeDbContextFactory<PasswordlessAuthenticationApplicationDbContext>
{
    public PasswordlessAuthenticationApplicationDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var configuration = BuildConfiguration();
        
        PasswordlessAuthenticationApplicationEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<PasswordlessAuthenticationApplicationDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));
        
        return new PasswordlessAuthenticationApplicationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PasswordlessAuthenticationApplication.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
