<Query Kind="Program">
  <Connection>
    <ID>536b2f1b-b7dd-4c78-9913-d8d6fbf7e9e6</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DCOL-DAS-SqlServer-WEU.database.windows.net</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>DASPayments</Database>
    <SqlSecurity>true</SqlSecurity>
    <UserName>DASPaymentROUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAeIJ8+4/2jUyCQ0tlOZ9uSgAAAAACAAAAAAAQZgAAAAEAACAAAAAEXOy3/3k/sseiFurxL9p3GfNS39CBHhZf1fV+lJSuPAAAAAAOgAAAAAIAACAAAADdz+WXej0+vvymyRhR1ytqRWNjHMwxSsF+YODiAEaxD1AAAADUefvmBO3sv4RNDE/fTg0gRLz/PQNcPq2wzbtPu2ak6G5MTZcmLvIo5Mkj0cZZoQhk7r8zbipeCjDjAMGUa5CV7HwVWNcDjktIpFpPapEvJUAAAADgW33hw4lBC6PDJHmQ5IDQqsRfXtMXNp8+3ZBUGLPbJ1Wo/r9+/PRRGzOqGLMKQNsXJK1O28DPaCSrSWsvKrjg</Password>
    <DbVersion>Azure</DbVersion>
  </Connection>
</Query>

void Main()
{
	// Display powers of 2 up to the exponent of 8:
	foreach (int i in Power(2, 8))
	{
		i.Dump();
	}
    
    foreach (string name in Names())
    {
        name.Dump();
    }
}

public static IEnumerable<int> Power(int number, int exponent)
{
	int result = 1;

	for (int i = 0; i < exponent; i++)
	{
		result = result * number;
		yield return result;
	}
}

public static IEnumerable<string> Names()
{
    yield return "Deven";
    yield return "Suman";
    yield return "Diya";
}