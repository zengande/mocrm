using YunStorm.MoCRM.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace YunStorm.MoCRM.Permissions
{
    public class MoCRMPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MoCRMPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MoCRMPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MoCRMResource>(name);
        }
    }
}
