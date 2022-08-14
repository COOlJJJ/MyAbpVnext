using MyAbpVnext.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyAbpVnext;

[DependsOn(
    typeof(MyAbpVnextEntityFrameworkCoreTestModule)
    )]
public class MyAbpVnextDomainTestModule : AbpModule
{

}
