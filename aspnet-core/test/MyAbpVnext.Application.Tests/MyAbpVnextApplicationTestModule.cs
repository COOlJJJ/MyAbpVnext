using Volo.Abp.Modularity;

namespace MyAbpVnext;

[DependsOn(
    typeof(MyAbpVnextApplicationModule),
    typeof(MyAbpVnextDomainTestModule)
    )]
public class MyAbpVnextApplicationTestModule : AbpModule
{

}
