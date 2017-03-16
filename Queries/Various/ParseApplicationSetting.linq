<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Configuration</Namespace>
</Query>

void Main()
{
	var key = "EnableWindowsFormsHighDpiAutoResizing1";
	ConfigurationManager.AppSettings[key].Dump();
	GetSettingOrDefault<bool>(key).Dump("Setting is");
}

public T GetSettingOrDefault<T>(string key, T defaultValue = default(T))
{
	var value = ConfigurationManager.AppSettings[key];
	
	if (value == null) return defaultValue;

	if (typeof(T) == typeof(bool))
    {
		try
		{
			var result = ChangeType<T>(value);
			return result;
		}
		catch (InvalidCastException)
		{
			return defaultValue;
		}		
	}
	return defaultValue;
}

private static T ChangeType<T>(object value)
{
	return (T)Convert.ChangeType(value, typeof(T));
}
