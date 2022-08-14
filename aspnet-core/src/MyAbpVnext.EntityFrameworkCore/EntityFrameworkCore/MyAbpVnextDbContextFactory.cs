using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyAbpVnext.EntityFrameworkCore;

/// <summary>
/// DBContext制造工厂
/// </summary>
/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MyAbpVnextDbContextFactory : IDesignTimeDbContextFactory<MyAbpVnextDbContext>
{
    public MyAbpVnextDbContext CreateDbContext(string[] args)
    {
        MyAbpVnextEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MyAbpVnextDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);

        return new MyAbpVnextDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MyAbpVnext.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
