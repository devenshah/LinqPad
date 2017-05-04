<Query Kind="Program" />

void Main()
{
	// Display powers of 2 up to the exponent of 8:
	foreach (int i in Power(2, 8))
	{
		Console.Write("{0} ", i);
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