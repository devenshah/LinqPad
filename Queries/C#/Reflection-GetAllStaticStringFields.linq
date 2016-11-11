<Query Kind="Program" />

void Main()
{
	typeof(ApplicationSettingNames).GetFields(BindingFlags.Public | BindingFlags.Static)
			  .Where(f => f.FieldType == typeof(string))
			  .ToDictionary(f => f.Name,
							f => (string)f.GetValue(null)).Dump();


	ReflectionUtility.GetAllStaticStringFields(typeof(ApplicationSettingNames)).Dump();
}

public class ReflectionUtility
{
	public static IEnumerable<string> GetAllStaticStringFields(Type type)
	{
		return type.GetFields(BindingFlags.Public | BindingFlags.Static)
			  .Where(f => f.FieldType == typeof(string))
			  .Select(f => f.GetValue(null).ToString());
	}
}

public static class ApplicationSettingNames
{
	public readonly static string IntegrationStorageConnectionString = "sims8.integration.storage.storage-account-connection-string";
	public readonly static string SchoolInfoStorageTableName = "sims8.integration.storage.setting.table-name";
	public readonly static string ManagementServiceBusConnectionString = "capitasims.simslabs.management.servicebus.service-bus-connection-string";
}
