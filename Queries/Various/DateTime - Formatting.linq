<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	var invalidDate = "text";
	$"{invalidDate:yyMMdd}".Dump(); //dumps text
	
	var validDate = DateTime.Now;
	$"{validDate:yy-MM-dd}".Dump(); //dumps date
	
	$"{validDate:o}".Dump("round trip"); 
	
	$"{validDate:d}".Dump("round trip");
	
	
	DateTime.TryParseExact("20210502", "yyyyMMdd", null, DateTimeStyles.AssumeUniversal, out var result);
	result.Dump();
	
	
}

void Main1()
{
	string Date = "20200709";
	string Time = "125000";

	DateTime.ParseExact(Date + Time, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal).Dump();
}

void Main2()
{
	var d = DateTime.Now;
	var e = DateTime.UtcNow;
	$"{d:s} and {e:s}".Dump();

	//d = new DateTime(2021, 10, 27, 23, 59, 59, DateTimeKind.)

	var o = new DateTimeOffset(2021, 10, 27, 23, 59, 59, 0, TimeSpan.FromHours(-5));
	o.UtcDateTime.Dump();
}


