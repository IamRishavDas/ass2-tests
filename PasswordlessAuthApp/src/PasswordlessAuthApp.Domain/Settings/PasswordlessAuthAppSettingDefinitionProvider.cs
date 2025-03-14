using Volo.Abp.Settings;

namespace PasswordlessAuthApp.Settings;

public class PasswordlessAuthAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PasswordlessAuthAppSettings.MySetting1));
    }
}
