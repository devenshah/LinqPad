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
  <Namespace>AutoMapper.Configuration</Namespace>
  <Namespace>AutoMapper.Configuration.Conventions</Namespace>
  <Namespace>AutoMapper.Execution</Namespace>
  <Namespace>AutoMapper.Mappers</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
  <Namespace>AutoMapper.QueryableExtensions.Impl</Namespace>
</Query>

void Main()
{
	Mapper.Initialize(cfg => cfg.CreateMap<Employees, EmployeeDto>()
			.ForMember(e => e.Id, o => o.MapFrom(s => s.EmployeeID))
			.ForMember(e => e.Name, o => o.MapFrom(s => string.Join(" ", s.FirstName, s.LastName)))
			.ForMember(e => e.Phone, o => o.MapFrom(s => s.HomePhone))
			.ForMember(e => e.ContactEmail, o => o.Ignore())
			.ForMember(e => e.IsManager, o => { o.MapFrom(s => s.ReportsTo); o.NullSubstitute("Yes"); })
			.ForMember(dest => dest.Age, opt => opt.ResolveUsing<AgeResolver>()));

	var emps = Employees.Where(e => e.Country != "USA").ToList();
	Mapper.Map<List<Employees>, IEnumerable<EmployeeDto>>(emps).Dump();
}

public class AgeResolver : IValueResolver<Employees, EmployeeDto, int?>
{
	public int? Resolve(Employees source, EmployeeDto destination, int? member, ResolutionContext context)
	{
		if (source.BirthDate.HasValue == false) return 1;
		return DateTime.Today.Year - source.BirthDate.Value.Year;
	}
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

	public int? Age { get; set; }

	public string IsManager { get; set; }

	public override string ToString()
	{
		return string.Format($"Id: {Id}, Name: {Name}, Email: {ContactEmail}, Phone: {Phone}, Age: {Age}");
	}
}