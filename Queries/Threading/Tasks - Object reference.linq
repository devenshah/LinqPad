<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var people = new[]
	{
		new Person {Name = "Deven"},
		new Person {Name = "Suman"}
	};
	
	var tasks = new List<Task>();
	int i=0;
	foreach (var person in people)
	{
		i++;
		tasks.Add(UpdateAsync(person, $"shah{i}"));
	}
	await Task.WhenAll(tasks);
	
	people.Dump();
}

async Task UpdateAsync(Person person, string name)
{
	await Task.Delay(100);
	person.Name += $" {name}";	
}

class Person
{
	public string Name { get; set; }
}
