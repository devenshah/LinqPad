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
	Mapper.Initialize(cfg =>
	   cfg.CreateMap<Employees, EmployeeDto>().ConvertUsing<EmployeeTypeConverter>());

	var employee = Employees.First(e => e.BirthDate.HasValue);
	Mapper.Map<EmployeeDto>(employee).Dump();
}

public class EmployeeTypeConverter : ITypeConverter<Employees, EmployeeDto>
{
	public EmployeeDto Convert(Employees source, EmployeeDto employeeDto, ResolutionContext context)
	{
		if (context == null || source == null) return null;

		return new EmployeeDto
		{
			Id = source.EmployeeID,
			Name = string.Join(" ", source.FirstName, source.LastName),
			Phone = source.HomePhone
		};
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