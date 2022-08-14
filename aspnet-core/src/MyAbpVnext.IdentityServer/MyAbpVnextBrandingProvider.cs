using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MyAbpVnext;

[Dependency(ReplaceServices = true)]
public class MyAbpVnextBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyAbpVnext";
}
