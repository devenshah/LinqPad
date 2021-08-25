<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>TimeZoneConverter</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>TimeZoneConverter</Namespace>
</Query>

void Main1()
{
	DateTime.UtcNow.ToString("o").Dump();
	var dt = DateTime.Now.ToString("o");
	if (DateTimeOffset.TryParse(dt, out var os))
		os.ToString("o").Dump();
	
	var dd = new DateTime(os.DateTime.Ticks, DateTimeKind.Utc);
	
	dd.ToString("o").Dump();
}

void Main2()
{
	var date = DateTime.UtcNow;
	date.ToString("o").Dump();
	TimeZoneInfo tz = TZConvert.GetTimeZoneInfo("India Standard Time");
	tz.Dump();
	date -= tz.GetUtcOffset(date);
	date.ToString("o").Dump();
}


