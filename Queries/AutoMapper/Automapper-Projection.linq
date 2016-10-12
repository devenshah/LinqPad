<Query Kind="Program">
  <Connection>
    <ID>3dfa1e2c-515c-4d32-8b8b-4fe1d2235ba0</ID>
    <Persist>true</Persist>
    <Database>Northwind</Database>
    <Server>.\SQLEXPRESS</Server>
  </Connection>
  <NuGetReference>AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.Configuration</Namespace>
  <Namespace>AutoMapper.Impl</Namespace>
  <Namespace>AutoMapper.Internal</Namespace>
  <Namespace>AutoMapper.Mappers</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
  <Namespace>AutoMapper.QueryableExtensions.Impl</Namespace>
</Query>

void Main()
{
	TestProjection();
}

// Define other methods and classes here
private void TestProjection()
{
	//Employees.Where(e => e.ReportsTo == null).Dump();

	Mapper.CreateMap<Employees, EmployeeDto>()
		.IgnoreAllUnmapped()
		.ForMember(e => e.Id, o => o.MapFrom(s => s.EmployeeID))
		.ForMember(e => e.Name, o => o.MapFrom(s => string.Join(" ", s.FirstName, s.LastName)))
		.ForMember(e => e.Phone, o => o.MapFrom(s => s.HomePhone));
	
	
	Employees.Where(e => e.ReportsTo == null).Project().To<EmployeeDto>().Dump("See λ/SQL tab, only projected fields are retrieved");
}

public static class MappingExpressionExtensions
{
	public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
	{
		expression.ForAllMembers(opt => opt.Ignore());
		return expression;
	}
}

public class EmployeeDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string ContactEmail { get; set; }

	public string Phone { get; set; }

	public override string ToString()
	{
		return string.Format($"Id: {Id}, Name: {Name}, Email: {ContactEmail}, Phone: {Phone}");
	}
}