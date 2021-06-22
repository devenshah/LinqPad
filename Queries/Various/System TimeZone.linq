<Query Kind="Program" />

void Main()
{
	TimeZoneInfo.Local.Id.Dump("Before");
	SetSystemTimeZone("GMT Standard Time");	
	//SetSystemTimeZone("UTC");	
	TimeZoneInfo.Local.Id.Dump("After");
}

private void SetSystemTimeZone(string timeZoneId)
{
	var process = Process.Start(new ProcessStartInfo 
	{
		FileName = "tzutil.exe",
		Arguments = @$"/s ""{timeZoneId}"" ", 
		UseShellExecute = false,
		CreateNoWindow = true
	});
	if (process != null)
	{
		process.WaitForExit();
		TimeZoneInfo.ClearCachedData();
	}
}
