using Volo.Abp.Settings;

namespace MyAbpVnext.Settings;

public class MyAbpVnextSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MyAbpVnextSettings.MySetting1));
    }
}
