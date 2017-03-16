<Query Kind="Program" />

void Main()
{
	var expiry = CommonExtensions.ConvertToDateTime(1475849940);
	var now = DateTime.UtcNow;
	expiry.Dump();
	now.Dump();
	var hasExpired = expiry < now;
	
	hasExpired.Dump();
}

public static class CommonExtensions
{
	public static DateTime ConvertToDateTime(this long unixTime)
	{
		var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return epoch.AddSeconds(unixTime);
	}

	public static double DateTimeToUnixTimestamp(DateTime dateTime)
	{
		return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
			   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
	}
}
