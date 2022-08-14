using MyAbpVnext.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MyAbpVnext.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyAbpVnextEntityFrameworkCoreModule),
    typeof(MyAbpVnextApplicationContractsModule)
    )]
public class MyAbpVnextDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
