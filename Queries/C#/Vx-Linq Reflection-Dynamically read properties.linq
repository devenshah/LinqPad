<Query Kind="Program">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	ReadFromDbContext();
}

void ReadFromDbContext()
{
	//not working yet.
	var propertyName = "FirstName";

	var value =
		Employees
			.Select(p => new { Name = p.FirstName }
				).First();
	value.Dump();

}

void ReadFromStaticCollection()
{
	var propertyName = "Name";

	var person = new List<Person>()
	{
		new Person{Id = 1,  Name = "Akira"}
	};

	var value = person.Select(p => p.GetType().GetProperty(propertyName)?.GetValue(p)).First();
	value.Dump();

}

public class Person
{ 
	public int Id { get; set; }
	public string Name { get; set; }
}
