﻿using Volo.Abp.Settings;

namespace PasswordlessAuthenticationApplication.Settings;

public class PasswordlessAuthenticationApplicationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(PasswordlessAuthenticationApplicationSettings.MySetting1));
    }
}
