using System.Threading.Tasks;

namespace MyAbpVnext.Data;

public interface IMyAbpVnextDbSchemaMigrator
{
    Task MigrateAsync();
}
