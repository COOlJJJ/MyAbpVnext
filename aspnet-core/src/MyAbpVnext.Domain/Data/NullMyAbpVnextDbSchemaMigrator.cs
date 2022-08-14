using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MyAbpVnext.Data;

/* This is used if database provider does't define
 * IMyAbpVnextDbSchemaMigrator implementation.
 */
public class NullMyAbpVnextDbSchemaMigrator : IMyAbpVnextDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
