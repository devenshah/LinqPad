<Query Kind="Program" />

void Main()
{
	var lazyPerson = new Lazy<Person>();
	var functionalPerson = new Func<Person>(() => new Person());
	Console.WriteLine("Functional Person 1 Id: {0}", functionalPerson().Id.ToString());
	Console.WriteLine("Lazy Person 1 Id: {0}", lazyPerson.Value.Id.ToString());
	Console.WriteLine("Lazy Person 2 has the same Id: {0}", lazyPerson.Value.Id.ToString());
	Console.WriteLine("Functional Person 2 has different Id: {0}", functionalPerson().Id.ToString());


	var x = 1;
	var lazyCheck = new Lazy<bool>(() => x > 1);
	var funcCheck = new Func<bool>(() => x > 1);
	Console.WriteLine("Lazy returns {0}", lazyCheck.Value);
	Console.WriteLine("Func returns {0}", funcCheck());
	x = 2;
	Console.WriteLine("Lazy still returns {0}", lazyCheck.Value);
	Console.WriteLine("Func re-evaluates to {0}", funcCheck());
}

public class Person
{
	public Person()
	{
		Id = Guid.NewGuid();
		Console.WriteLine("Person created with ID: {0}", Id.ToString());
	}

	public Guid Id
	{
		get;
		private set;
	}

	public string Name
	{
		get;
		set;
	}
}