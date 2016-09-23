<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>



declare 
	@AttGrp_PersonalDetailsId int = 1010,
	@AttGrp_SkillsId int = 1020,
	@AttTyp_DOBId int = 10101001,
	@AttTyp_GenderId int = 10101002,
	@AtType_MSOfficeId int = 10201001,
	@AtType_CSharpId int = 10201002,
	@Emp_DevenId int = 1000000010,
	@Emp_SumanId int = 1000000020;

select 
	 e.firstname
	,DOB = DateOfBirth.Value -- alias = selector is required pattern
	,Gender = Gender.Value
	,MsOffice = MsOffice.Value
	,CSharp = CSharp.Value
from 
	employee e
outer apply (
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AttTyp_DOBId
	) DateOfBirth
outer apply (
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AttTyp_GenderId
	) Gender
outer apply (
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AtType_MSOfficeId
	) MsOffice
outer apply ( 
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AtType_CSharpId
	) CSharp;


select 
	 e.firstname
	,DOB = DateOfBirth.Value -- alias = selector is required pattern
	,CSharp = CSharp.Value
from 
	employee e
outer apply (
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AttTyp_DOBId
	) DateOfBirth
cross apply ( 
	select value
	from AttributeValue v 
	where v.ReferenceKey = e.Id
	  and v.AttributeTypeId = @AtType_CSharpId
	) CSharp;
	
select e.FirstName, dob.Value  DOB, CSharp.value CSharp
from employee e
cross join AttributeValue dob
cross join AttributeValue CSharp
where  (e.Id = dob.ReferenceKey and dob.AttributeTypeId = @AttTyp_DOBId)
and (e.Id = CSharp.ReferenceKey and CSharp.AttributeTypeId = @AtType_CSharpId);
