IF NOT EXISTS ( SELECT 1 FROM {databaseOwner}{objectQualifier}HostSettings WHERE SettingName = 'ControlPanel' )
BEGIN
  INSERT INTO {databaseOwner}{objectQualifier}HostSettings ( SettingName, SettingValue, SettingIsSecure, CreatedByUserID, CreatedOnDate, LastModifiedByUserID, LastModifiedOnDate )
  VALUES ( 'ControlPanel', 'DesktopModules/Hotcakes/ControlPanel/ControlBar.ascx', 0, -1, getdate(), -1, getdate() )
END
ELSE
BEGIN
  UPDATE {databaseOwner}{objectQualifier}HostSettings
	SET SettingValue = 'DesktopModules/Hotcakes/ControlPanel/ControlBar.ascx'
	WHERE SettingName = 'ControlPanel'
END
GO