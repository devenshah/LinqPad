<Query Kind="Statements" />

long number = 4675;

number.ToBase36().Dump();

Base36Converter.ConvertTo((int)number).Dump();

public static class Base36Converter
{
	private const int Base = 36;
	private const string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public static string ConvertTo(int value)
	{
		string result = "";

		while (value > 0)
		{
			result = Chars[value % Base] + result; // use StringBuilder for better performance
			value /= Base;
		}

		return result;
	}
}

public static class LongExtensions
{
	private static readonly char[] Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

	public static string ToBase36(this long value)
	{
		if (value < 0)
			throw new ArgumentOutOfRangeException(nameof(value));

		const long base36 = 36;

		char[] buffer = new char[Math.Max((int)Math.Ceiling(Math.Log(value + 1, base36)), 1)];
		int i = buffer.Length;
		do
		{
			buffer[--i] = Characters[value % base36];
			value /= base36;
		}
		while (value > 0);

		return new string(buffer, i, buffer.Length - i);
	}
}