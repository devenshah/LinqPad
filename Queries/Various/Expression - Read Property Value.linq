<Query Kind="Program" />

void Main()
{
	var people = new List<Person>
	{
		new Person{Name="Deven", Gender="Male"}, 
		new Person{Name="Suman", Gender="Female"} 
	};
	var person = new Person();
	ShowValue(people.Last(), () => person.Name);
	
	
}

private void ShowValue(Person person, Expression<Func<string>> property)
{
	var me = property.Body as MemberExpression;
	me.Member.Name.Dump();
	me.Member.DeclaringType.Dump();
	me.GetType().GetProperty(me.Member.Name).Dump();
	var name = me.Member.DeclaringType.GetProperty(me.Member.Name).GetValue(person);
	Console.WriteLine(name);
}



public class Person 
{
	public string Name { get; set; }		
	public string Gender { get; set; }
}
