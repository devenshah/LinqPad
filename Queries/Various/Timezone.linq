<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	//https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones

	SetSystemTimeZone("GMT Standard Time"); //UTC + 1 In Summertime
	//SetSystemTimeZone("Eastern Standard Time"); //UTC - 4
	//SetSystemTimeZone("Cape Verde Standard Time"); //UTC - 1	
	//SetSystemTimeZone("E. South America Standard Time"); //UTC -3
	//SetSystemTimeZone("Central America Standard Time"); //UTC - 6 This gives several failing tests
	//SetSystemTimeZone("Pacific Standard Time"); //UTC - 7
	//SetSystemTimeZone("Central Europe Standard Time"); //UTC + 2
    //SetSystemTimeZone("West Asia Standard Time"); //UTC + 4
    //SetSystemTimeZone("Iran Standard Time"); // UTC + 4.5
    //SetSystemTimeZone("Singapore Standard Time");	//UTC + 8	
    //SetSystemTimeZone("Tokyo Standard Time"); //UTC + 9		
    //SetSystemTimeZone("AUS Eastern Standard Time"); //UTC + 10
    //SetSystemTimeZone("New Zealand Standard Time");	//UTC + 12

	SetSystemTimeZone("UTC");
}

private void SetSystemTimeZone(string timeZoneId)
{
	var process = Process.Start(new ProcessStartInfo
	{
		FileName = "tzutil.exe",
		Arguments = $"/s '{timeZoneId}'",
		UseShellExecute = false,
		CreateNoWindow = true
	});

	if (process != null)
	{
		process.WaitForExit();
		TimeZoneInfo.ClearCachedData();
	}
}