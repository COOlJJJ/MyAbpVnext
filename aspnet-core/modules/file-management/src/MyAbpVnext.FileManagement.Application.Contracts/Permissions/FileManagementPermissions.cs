using Volo.Abp.Reflection;

namespace MyAbpVnext.FileManagement.Permissions;

public class FileManagementPermissions
{
    public const string GroupName = "FileManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(FileManagementPermissions));
    }

    public static class Files
    {
        public const string Default = GroupName + ".Files";
        public const string Create = Default + ".Create";
    }
}
