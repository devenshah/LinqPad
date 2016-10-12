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
		.ConvertUsing<EmployeeTypeConverter>();
	
	var employee = Employees.First(e => e.BirthDate.HasValue);
	Mapper.Map<EmployeeDto>(employee).Dump();
}


public class EmployeeTypeConverter : ITypeConverter<Employees, EmployeeDto>
{
	public EmployeeDto Convert(ResolutionContext context)
	{
		if (context == null || context.IsSourceValueNull) return null;
		
		var source = (Employees)context.SourceValue;

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