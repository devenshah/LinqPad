<Query Kind="Program">
  <Connection>
    <ID>3dfa1e2c-515c-4d32-8b8b-4fe1d2235ba0</ID>
    <Persist>true</Persist>
    <Database>Northwind</Database>
    <Server>.\SQLEXPRESS</Server>
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
	Mapper.CreateMap<Employee, EmployeeDto>();
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

