<Query Kind="Program" />

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
