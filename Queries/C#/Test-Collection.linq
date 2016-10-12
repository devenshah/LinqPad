<Query Kind="Program" />

void Main() 
{
	Method1();
	Method2();
	Method3();
	Method4();
	Method5();
}

void Method5()
{
	List<Person> people = new List<Person>()
	{
		new Person() { Name = "Mike"},
		new Person() { Name = "John"},
		new Person() { Name = "David"}
	};

	var team = people;
	team.RemoveAt(0);
	$"5: {string.Join(" and ", people.Select(t => t.Name)) }".WL();
}

void Method4()
{
	List<Person> people = new List<Person>()
	{
		new Person() { Name = "John"},
		new Person() { Name = "David"}
	};

	var somebody = people[0];
	somebody.Name = "Linda";
	$"4: {string.Join(" and ", people.Select(t => t.Name)) }".WL();
}

void Method3()
{
	List<Person> people = new List<Person>()
	{
		new Person() { Name = "Mike"},
		new Person() { Name = "John"},
		new Person() { Name = "David"}
	};

	var team = people.Select(p => p).ToList();
	people.RemoveAt(0);
	$"3: {string.Join(" and ", team.Select(t => t.Name)) }".WL();
}

void Method2()
{
	List<Person> people = new List<Person>()
	{
		new Person() { Name = "Mike"},
		new Person() { Name = "David"}
	};

	var team = people;
	people[0].Name = "John";
	$"2: {string.Join(" and ", team.Select(t => t.Name)) }".WL();
}


void Method1()
{
	List<Person> people = new List<Person>()
	{
		new Person() { Name = "John"},
		new Person() { Name = "David"}
	};

	var john = people[0];
	var david = people[1];
	$"1: {john.Name} and {david.Name}".WL();
}


