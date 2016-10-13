<Query Kind="Program">
  <Connection>
    <ID>5a35dae8-02c2-4fc7-8739-661b8f548e4f</ID>
    <Persist>true</Persist>
    <Driver Assembly="OData4DynamicDriver" PublicKeyToken="ac4f2d9e4b31c376">OData4.OData4DynamicDriver</Driver>
    <DriverData>
      <Uri>http://services.odata.org/TripPinWebApiService</Uri>
    </DriverData>
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
		cfg.CreateMap<Person, Student>()
			.ForMember(t => t.Forename, opt => opt.MapFrom(s => s.FirstName))
			.ForMember(t => t.Surname, opt => opt.MapFrom(s => s.LastName))
	);

	var students = People.ProjectTo<Student>();
	
	students.Dump();
}

public class Student
{
	public string Forename { get; set; }
	public string Surname { get; set; }
	public string Gender { get; set; }
}
