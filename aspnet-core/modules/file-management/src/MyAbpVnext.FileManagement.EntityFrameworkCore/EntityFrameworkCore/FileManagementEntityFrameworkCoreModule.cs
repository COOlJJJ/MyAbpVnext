using Microsoft.Extensions.DependencyInjection;
using MyAbpVnext.FileManagement.Files;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyAbpVnext.FileManagement.EntityFrameworkCore;

[DependsOn(
    typeof(FileManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class FileManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<FileManagementDbContext>(options =>
        {
            //注册自定义仓储
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<File, EfCoreFileRepository>();
        });
    }
}
