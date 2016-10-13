<Query Kind="Program">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <NuGetReference>AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
</Query>

void Main() 
{
	
	//TestDtoToString();
	
	TestEmployeeMapToDto();
	
	
}

private void TestDtoToString()
{
	new EmployeeDto() { PersonName = "Dev", ContactEmail="d.s@y.c", ContactPhone="1234"}.ToString().Dump();
}

private void TestEmployeeMapToDto()
{
	Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
	var e = new Employee()
	{
		Id = 33,
		Contact = new Contact { Email = "a.b@c.d", Id = 11, Phone = "112233" },
		Person = new Person { Id = 22, Name = "Su"}
	};
	var d = Mapper.Map<EmployeeDto>(e);
	d.ToString().Dump();
}

public class Contact
{
	public int Id { get; set; }

	public string Email { get; set; }

	public string Phone { get; set; }
}

public class Employee
{
	public int Id { get; set;}
	public Person Person { get; set; }
	public Contact Contact { get; set; }	
}

public class Person
{ 
	public int Id { get; set; }
	public string Name { get; set; }
}


public class EmployeeDto
{ 
	public string Id { get; set; }
	
	public string PersonName { get; set; }
	
	public string ContactEmail { get; set; }
	
	public string ContactPhone { get; set; }

	public override string ToString()
	{
		return string.Format($"Id: {Id}, Name: {PersonName}, Email: {ContactEmail}, Phone: {ContactPhone}");
	}
}