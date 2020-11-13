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
	MyValue mv = "232345445";
	string i = mv;
	Console.WriteLine(i.ToString());
}


public class MyValue
{
	private static readonly byte[] EmptyByteArr = new byte[0];
	
	private readonly byte[] _value;
	
	private readonly long numericValue;
	
	public byte[] Value => _value;
	
	public MyValue(byte[] value)
	{
//		var b = Convert.ToByte(value);
//		if (b > 9) throw new ArgumentNullException();
//		_value = b;
		_value = value;
	}

	public MyValue(long value)
	{
		//		var b = Convert.ToByte(value);
		//		if (b > 9) throw new ArgumentNullException();
		//		_value = b;
		numericValue = value;
		_value = EmptyByteArr;
	}


	public static implicit operator MyValue(string value)
	{
		byte[] blob;

		if (value == null) blob = null;
		else if (value.Length == 0) blob = EmptyByteArr;
		else blob = Encoding.UTF8.GetBytes(value);

		return new MyValue(blob);
	}
	public static implicit operator string (MyValue m)
	{
		return Encoding.UTF8.GetString(m.Value);
	}
	
//	public static implicit operator MyValue(int value)
//    {
//        return new MyValue(value);
//    }
//
	public static explicit operator int (MyValue value)
	{
		checked
		{
			return (int)(long)value;
		}
	}
}
