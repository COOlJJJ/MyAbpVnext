using MyAbpVnext.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyAbpVnext.Permissions;

/// <summary>
/// 定义权限类
/// </summary>
public class MyAbpVnextPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //这个类定义了一个 权限组 (在UI上分组权限, 下文会看到) 和 权限组中的4个权限.
        //而且, 创建, 编辑 和 删除 是 BookStorePermissions.Books.Default 权限的子权限. 仅当父权限被选择时, 子权限才能被选择.
        var bookStoreGroup = context.AddGroup(MyAbpVnextPermissions.GroupName, L("Permission:BookStore"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MyAbpVnextPermissions.MyPermission1, L("Permission:MyPermission1"));
        var booksPermission = bookStoreGroup.AddPermission(MyAbpVnextPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(MyAbpVnextPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(MyAbpVnextPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(MyAbpVnextPermissions.Books.Delete, L("Permission:Books.Delete"));


        var authorsPermission = bookStoreGroup.AddPermission(MyAbpVnextPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(MyAbpVnextPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(MyAbpVnextPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(MyAbpVnextPermissions.Authors.Delete, L("Permission:Authors.Delete"));

        //AuditLogging
        var auditLogGroup = context.AddGroup(AuditLogPermissions.GroupName,AuditLoggingL("Permission:AuditLogManagement"));
        var aduditLogPermission = auditLogGroup.AddPermission(AuditLogPermissions.AuditLogs.Default, AuditLoggingL("Permission:AuditLogManagement"));
        aduditLogPermission.AddChild(AuditLogPermissions.AuditLogs.Delete, AuditLoggingL("Permission:Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyAbpVnextResource>(name);
    }

    private static LocalizableString AuditLoggingL(string name)
    {
        return LocalizableString.Create<AuditLoggingResource>(name);
    }
}
