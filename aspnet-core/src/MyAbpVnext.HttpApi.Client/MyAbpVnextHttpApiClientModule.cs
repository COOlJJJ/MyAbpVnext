using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Http.Client.IdentityModel;

namespace MyAbpVnext;


/// <summary>
/// .HttpApi.Client 项目
///定义C#客户端代理使用解决方案的HTTP API项目. 可以将上编辑共享给第三方客户端,使其轻松的在DotNet应用程序中使用你的HTTP API(其他类型的应用程序可以手动或使用其平台的工具来使用你的API).
///ABP有动态 C# API 客户端功能,所以大多数情况下你不需要手动的创建C#客户端代理.
///.HttpApi.Client.ConsoleTestApp 项目是一个用于演示客户端代理用法的控制台应用程序.
///它依赖.Application.Contracts 项目, 因为它需要使用应用服务接口和DTO.
///如果你不需要为API创建动态C#客户端代理,可以删除此项目和依赖项
///------------------------------------------------------------------
///在主项目中将模块的Application层和Domain层的大部分项目都引用了一遍，那种方式是单体部署的情况，模块和主项目托管在同一个进程里。
///1.第一次就是添加了各种引用和DependsOn 这种算是单体项目的合体的感觉 同时会遗漏DependsOn。
///DependsOn依赖注意的是EFCORE注册自定义仓储和Api层注入权限，但本质是用到了契约层。只不过在Api层注入可以获得Api同时把权限也注入。
///2.下面使用C# API客户端来代理远程模块。
///然后在你需要调用模块的项目中，添加模块的HttpApi.Client项目的依赖即可。比如我这里的MyAbpVnext.HttpApi.Host项目：
///首先删除项目中模块的引用和DependsOn
///这样的只需要添加Client和Api的项目引用和依赖即可。
/// </summary>
[DependsOn(
    typeof(MyAbpVnextApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule),
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
