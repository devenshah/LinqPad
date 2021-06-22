<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var task1 = Task.Factory.StartNew (AddItem);
	var task2 = Task.Factory.StartNew (AddItem);
	var task3 = Task.Factory.StartNew (AddItem);
	var task4 = Task.Factory.StartNew (AddItem);
	var task5 = Task.Factory.StartNew (AddItem);
	Task.WaitAll(task4,task3,task2,task5,task1);
	items.Dump();
}

Dictionary<int, string> items = new Dictionary<int, string>();
void AddItem()
{
	lock (items)
	{
		Console.WriteLine($"Lock acquired by {Task.CurrentId}");
		items.Add(items.Count, $"Value {items.Count}");
	}
	Dictionary<int, string> dictionary;
	lock (items)
	{
		Console.WriteLine($"Lock 2 acquired by {Task.CurrentId}");
		dictionary = items;
	}
}
