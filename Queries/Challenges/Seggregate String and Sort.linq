<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

void Main()
{
	compute("banana");
}

static void compute(string s)
{
	var list = new List<string>();
	for (var l = 1; l <= s.Length; l++)
	{
		for (var x = 0; x < s.Length; x++)
		{
			if (x + l <= s.Length)
			{
//				Console.Write($"{x} - {l}:");
//				Console.WriteLine($"{s.Substring(x, l)}");
				list.Add(s.Substring(x, l));
			}
		}
	}
	list.Sort();
	list.Last().Dump();
	
}