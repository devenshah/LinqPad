<Query Kind="Program">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Namespace>System</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	var people = new List<Person>()
	{
		new Person (1, Guid.NewGuid(), "Deven", new DateTime(1974,4,20), "Male"),
		new Person (2, Guid.NewGuid(), "Suman", new DateTime(1973,11,16), "Female"),
	};
	var x = new XmlSerializer(people.GetType());
	x.Serialize(Console.Out, people);
}


public class Person
{ 	
	public int Id { get; set; }
	
	public Guid ExternalId { get; set; }
	
	public string FullName { get; set; }
	
	public DateTime DateOfBirth { get; set; }
	
	public string Gender { get; set; }
	
	public Person()
	{
		
	}
	
	public Person(int id, Guid externalId, string name, DateTime dob, string sex)
	{
		Id = Id;
		ExternalId = externalId;
		FullName = name;
		DateOfBirth = dob;
		Gender = sex;
	}
}

