using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAbpVnext.Data;
using Volo.Abp.DependencyInjection;

namespace MyAbpVnext.EntityFrameworkCore;

/// <summary>
/// 迁移类
/// </summary>
public class EntityFrameworkCoreMyAbpVnextDbSchemaMigrator
    : IMyAbpVnextDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMyAbpVnextDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MyAbpVnextDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MyAbpVnextDbContext>()
            .Database
            .MigrateAsync();
    }
}
