IF EXISTS (SELECT 1 FROM {databaseOwner}[{objectQualifier}HostSettings] WHERE SettingName = N'ControlPanel' AND [SettingValue] = N'DesktopModules/Hotcakes/ControlPanel/ControlBar.ascx')
BEGIN
    UPDATE {databaseOwner}[{objectQualifier}HostSettings]
        SET [SettingValue] = N'DesktopModules/admin/Dnn.PersonaBar/UserControls/PersonaBarContainer.ascx'
        WHERE [SettingName] = N'ControlPanel';
END
GO