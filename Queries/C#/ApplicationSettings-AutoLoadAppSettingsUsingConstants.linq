<Query Kind="Program">
  <Namespace>System.Configuration</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="sims8.integration.storage.storage-account-connection-string" value="This is storage connection string" />
          <add key="sims8.integration.storage.setting.table-name" value="This is table name" />
          <add key="capitasims.simslabs.management.servicebus.service-bus-connection-string" value="This is service bus connection string" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

public class ReflectionUtility
{
	public static IEnumerable<string> GetAllStaticStringFields(Type type)
	{
		return type.GetFields(BindingFlags.Public | BindingFlags.Static)
			  .Where(f => f.FieldType == typeof(string))
			  .Select(f => f.GetValue(null).ToString());
	}
}

public interface IApplicationSettings
{
	string GetSetting(string settingName);
}

public class ApplicationSettings : IApplicationSettings
{
	private Dictionary<string, string> applicationSettings = new Dictionary<string, string>();

	//[InjectionConstructor]
	public ApplicationSettings()
	{

	}

	public ApplicationSettings(IEnumerable<string> settingNames, Func<string, string> settingSource)
	{
		foreach (var setting in settingNames)
		{
			applicationSettings[setting] = settingSource(setting);
		}
	}

	public ApplicationSettings(Type type, Func<string, string> settingSource)
		: this(ReflectionUtility.GetAllStaticStringFields(type), settingSource)
	{

	}

	public string GetSetting(string settingName)
	{
		return applicationSettings[settingName];
	}
}

void Main()
{
	ReflectionUtility.GetAllStaticStringFields(typeof(Constants.ApplicationSettingNames)).Dump();

	var appSettings =
		new ApplicationSettings(
			typeof(Constants.ApplicationSettingNames),
			(key) => ConfigurationManager.AppSettings[key]);
	
	appSettings.GetSetting(Constants.ApplicationSettingNames.IntegrationStorageConnectionString).Dump();
}

public static class Constants
{
	public static class ApplicationSettingNames
	{
		public readonly static string IntegrationStorageConnectionString = "sims8.integration.storage.storage-account-connection-string";
		public readonly static string SchoolInfoStorageTableName = "sims8.integration.storage.setting.table-name";
		public readonly static string ManagementServiceBusConnectionString = "capitasims.simslabs.management.servicebus.service-bus-connection-string";
	}
}

/*
<configuration>
  <appSettings>
    <add key="sims8.integration.storage.storage-account-connection-string" value="This is storage connection string" />
    <add key="sims8.integration.storage.setting.table-name" value="This is table name" />
    <add key="capitasims.simslabs.management.servicebus.service-bus-connection-string" value="This is service bus connection string" />
  </appSettings>
</configuration>

*/
