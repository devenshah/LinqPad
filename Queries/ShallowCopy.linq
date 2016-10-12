<Query Kind="Program" />

void Main()
{
	var person = new Person(){ Id=1, Name="dev"};
	var c = person.GetShallowCopy();
	c.Dump();
	c.GetType().Dump();
	c.Equals(person).Dump();
}

public abstract class BaseEntity
{
	public int Id { get; set; }
	public Object GetShallowCopy()
	{
		return this.MemberwiseClone();
	}
}

public class Person : BaseEntity
{
	public string Name { get; set; }
}

