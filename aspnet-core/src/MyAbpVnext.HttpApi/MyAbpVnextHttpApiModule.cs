using Localization.Resources.AbpUi;
using MyAbpVnext.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace MyAbpVnext;


//.HttpApi 项目
//用于定义API控制器.
//大多数情况下,你不需要手动定义API控制器,因为ABP的动态API功能会根据你的应用层自动创建API控制器.
//但是,如果你需要编写API控制器,那么它是最合适的地方.
//它依赖.Application.Contracts 项目, 因为它需要注入应用服务接口.
[DependsOn(
    typeof(MyAbpVnextApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class MyAbpVnextHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MyAbpVnextResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
