<Query Kind="Program">
  <Connection>
    <ID>d3f5ed61-a713-4847-9620-aa74f61622cc</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
  </Connection>
  <NuGetReference Version="10.0.0">AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.Configuration</Namespace>
  <Namespace>AutoMapper.Configuration.Conventions</Namespace>
  <Namespace>AutoMapper.Execution</Namespace>
  <Namespace>AutoMapper.Mappers</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
  <Namespace>AutoMapper.QueryableExtensions.Impl</Namespace>
</Query>

void Main()
{
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, EmployeeDto>());
    var mapper = config.CreateMapper();
    
    var p = new Person{Id=1,Name="Deven",DateOfBirth=new DateTime(1974,4,20)};
    
    mapper.Map<EmployeeDto>(p).Dump();    
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}


public class EmployeeDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string ContactEmail { get; set; }

	public string Phone { get; set; }

	public int? Age { get; set; }

	public string IsManager { get; set; }
}