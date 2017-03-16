<Query Kind="Program">
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

void Main()
{
	UseForLoopToModifyCollection();
}

void ReturnInForLoopExitsMethod()
{
	for (var i = 0; i < 10; i++)
	{
		Console.WriteLine(i);
		return;
	}
	Console.WriteLine("test");
}

void CannotModifyLoopVariableInForEach()
{
	var list = new List<int> { 1, 2, 3, 4, 5, 6};
	foreach (var item in list)
	{
		Console.WriteLine(item);
		//// item = 10; compile time error
	}
}

void UseForLoopToModifyCollection()
{
	var list = new List<int> { 1, 2, 3, 4, 5, 6};
	
	for (var i = 0; i < list.Count; i++)
	{
		Console.WriteLine(list[i]);
		if (list[i] % 2 == 0) list.Remove(i);
	}

	list.ForEach(i => Console.WriteLine($"Count: {i}"));
}