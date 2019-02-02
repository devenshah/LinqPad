<Query Kind="Program" />

void Main()
{
	PrintStairCase(20);
}

void PrintStairCase(int n)
{
	if(n < 1 || n > 100) return;
	for (var i = 1; i <= n; i++, n--)
	{
		var str = string.Empty;
		for (var j = 1; j < n; j++)
		{
			str += " ";
		}
		for (var x = 0; x < i; x++)
		{
			str += "#";
		}
		Console.WriteLine(str);
	}

}

string GetString(string input, int times)
{
	var str = string.Empty;
	for (var j = 0; j < times; j++)
	{
		str += input;
	}
	return str;
}