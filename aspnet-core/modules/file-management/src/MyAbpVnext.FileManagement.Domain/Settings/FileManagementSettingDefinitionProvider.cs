using Volo.Abp.Settings;

namespace MyAbpVnext.FileManagement.Settings;

public class FileManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        /* Define module settings here.
         * Use names from FileManagementSettings class.
         */

        context.Add(new SettingDefinition(
            FileManagementSettings.AllowedMaxFileSize,
            "1024"),
                    new SettingDefinition(
            FileManagementSettings.AllowedUploadFormats,
                ".jpg,.jpeg,.png,.gif,.txt")
            );
    }
}
