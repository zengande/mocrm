using Volo.Abp.Settings;

namespace YunStorm.MoCRM.Settings
{
    public class MoCRMSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MoCRMSettings.MySetting1));
        }
    }
}
