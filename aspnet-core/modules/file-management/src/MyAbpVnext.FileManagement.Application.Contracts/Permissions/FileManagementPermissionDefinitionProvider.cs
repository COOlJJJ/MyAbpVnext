using MyAbpVnext.FileManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyAbpVnext.FileManagement.Permissions;

public class FileManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FileManagementPermissions.GroupName, L("Permission:FileManagement"));

        var filesPermission = myGroup.AddPermission(FileManagementPermissions.Files.Default, L("Permission:Files"));
        filesPermission.AddChild(FileManagementPermissions.Files.Create, L("Permission:Files.Create"));
    
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FileManagementResource>(name);
    }
}
