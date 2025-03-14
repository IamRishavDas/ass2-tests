using PasswordlessAuthenticationApplication.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace PasswordlessAuthenticationApplication.Permissions;

public class PasswordlessAuthenticationApplicationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PasswordlessAuthenticationApplicationPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(PasswordlessAuthenticationApplicationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PasswordlessAuthenticationApplicationResource>(name);
    }
}
