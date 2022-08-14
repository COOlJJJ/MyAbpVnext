namespace MyAbpVnext.Permissions;


/// <summary>
/// 添加自己的权限
/// </summary>
public static class MyAbpVnextPermissions
{
    public const string GroupName = "MyAbpVnext";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    //添加书本的权限
    //权限名称具有层次结构. 例如, "创建图书" 权限被定义为 BookStore.Books.Create. ABP不强制必须如此, 但这是一种有益的做法.
    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }


    // *** ADDED a NEW NESTED CLASS ***
    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
