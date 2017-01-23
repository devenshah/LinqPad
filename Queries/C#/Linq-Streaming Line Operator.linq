<Query Kind="Program" />

void Main()
{
	Func<int, int, string> add = (x, y) => $"{x} + {y}";	
	Console.WriteLine(add);
	Expression<Func<int, int, string>> addExp = (x, y) => $"{x} + {y}";
	Console.WriteLine(addExp);
}
static class Extensions
{ 
	///LINQ like operator that defers execution
	///this is a streaming operator against non streaming or greedy operator
	internal static IEnumerable<T> Log<T>(this IEnumerable<T> source)
	{
		foreach (var item in source)
		{
			Console.WriteLine(item);
			yield return item;
		}
	}
	
	internal static T Random<T>(this IEnumerable<T> source)
	{
		var random = new Random();
		var current = default(T);
		double count = 1;
		foreach (var item in source)
		{
			if (random.NextDouble() < 1 / count)
			{
				current = item;
			}
		}
		return current;
	}
}