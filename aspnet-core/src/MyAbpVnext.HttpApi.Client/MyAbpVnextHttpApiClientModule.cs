using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace MyAbpVnext;


/// <summary>
/// .HttpApi.Client 项目
///定义C#客户端代理使用解决方案的HTTP API项目. 可以将上编辑共享给第三方客户端,使其轻松的在DotNet应用程序中使用你的HTTP API(其他类型的应用程序可以手动或使用其平台的工具来使用你的API).
///ABP有动态 C# API 客户端功能,所以大多数情况下你不需要手动的创建C#客户端代理.
///.HttpApi.Client.ConsoleTestApp 项目是一个用于演示客户端代理用法的控制台应用程序.
///它依赖.Application.Contracts 项目, 因为它需要使用应用服务接口和DTO.
///如果你不需要为API创建动态C#客户端代理,可以删除此项目和依赖项
/// </summary>
[DependsOn(
    typeof(MyAbpVnextApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class MyAbpVnextHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MyAbpVnextApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MyAbpVnextHttpApiClientModule>();
        });
    }
}
