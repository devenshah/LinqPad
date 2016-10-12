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

	Mapper.CreateMap<Employees, EmployeeDto>()
			.ForMember(e => e.Id, o => o.MapFrom(s => s.EmployeeID))
			.ForMember(e => e.Name, o => o.MapFrom(s => string.Join(" ", s.FirstName, s.LastName)))
			.ForMember(e => e.Phone, o => o.MapFrom(s => s.HomePhone))
			.ForMember(e => e.ContactEmail, o => o.Ignore())
			.ForMember(e => e.IsManager, o => { o.MapFrom(s => s.ReportsTo); o.NullSubstitute("Yes");})
			.ForMember(dest => dest.Age, opt => opt.ResolveUsing<AgeResolver>());

	var employee = Employees.First(e => e.BirthDate.HasValue);
	Mapper.Map<EmployeeDto>(employee).Dump();

	var employee1 = Employees.First(e => e.ReportsTo == null);
	employee1.BirthDate = null;
	Mapper.Map<EmployeeDto>(employee1).Dump();
}

public class AgeResolver : ValueResolver<Employees, int>
{
	protected override int ResolveCore(Employees source)
	{
		if (source.BirthDate.HasValue == false) return 1;
		return DateTime.Today.Year - source.BirthDate.Value.Year;
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