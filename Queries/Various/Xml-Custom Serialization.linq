<Query Kind="Program">
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

	var ctx = new SerializableContext {	People = people };
	
	var x = new XmlSerializer(ctx.GetType()); 
	
	//remove the namespace next to root element	
	var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

	var settings = new XmlWriterSettings
	{
		//remove xml  declaration tab
		OmitXmlDeclaration = true, 
		Indent = true
	};

	using (var writer = XmlWriter.Create(Console.Out, settings))
    {
		x.Serialize(writer, ctx, emptyNamepsaces);
	}
}

[XmlRoot("HumanResource")]
public class SerializableContext
{ 
	[XmlAttribute]
	public int Version { get; set; } = 1;
	
	[XmlArray("Employees")]
	[XmlArrayItem("Employee")]
	public List<Person> People { get; set; }
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