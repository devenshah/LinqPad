<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

delete from AttributeValue;
delete from Employee;
delete from AttributeGroupType;
delete from AttributeGroup;
delete from AttributeType;

/*
select count(*) from AttributeGroup
select count(*) from AttributeValue
select count(*) from Employee
select count(*) from AttributeGroupType
select count(*) from AttributeType
*/
go
	

begin tran;

declare 
	@AttGrp_PersonalDetailsId int = 1010,
	@AttGrp_SkillsId int = 1020,
	@AttTyp_DOBId int = 10101001,
	@AttTyp_GenderId int = 10101002,
	@AtType_MSOfficeId int = 10201001,
	@AtType_CSharpId int = 10201002,
	@Emp_DevenId int = 1000000010,
	@Emp_SumanId int = 1000000020;

insert into AttributeGroup(Id, Name) 
values (@AttGrp_PersonalDetailsId, 'PersonalDetails');

	insert into AttributeType(Id, Name) 
	values (@AttTyp_DOBId, 'DateOfBirth');
		insert into AttributeGroupType	(AttributeGroupId, AttributeTypeId)
		values(@AttGrp_PersonalDetailsId, @AttTyp_DOBId);
		
	insert into AttributeType(Id, Name) 
	values (@AttTyp_GenderId, 'Gender');
		insert into AttributeGroupType	(AttributeGroupId, AttributeTypeId)
	    values(@AttGrp_PersonalDetailsId, @AttTyp_GenderId);
	
insert into AttributeGroup(Id, Name) 
values (@AttGrp_SkillsId, 'Skills');

	insert into AttributeType(Id, Name) 
	values(@AtType_MSOfficeId, 'MS Office');
		insert into AttributeGroupType	(AttributeGroupId, AttributeTypeId)
    	values(@AttGrp_SkillsId, @AtType_MSOfficeId);
		
	insert into AttributeType(Id, Name) 
	values(@AtType_CSharpId, 'C#');
		insert into AttributeGroupType 	(AttributeGroupId, AttributeTypeId)
	    values(@AttGrp_SkillsId, @AtType_CSharpId);

insert into Employee(Id, FirstName, LastName) 
values(@Emp_DevenId, 'Deven', 'Shah');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_DevenId, @AttGrp_PersonalDetailsId, @AttTyp_DOBId, '1974-04-20');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_DevenId, @AttGrp_PersonalDetailsId, @AttTyp_GenderId, 'M');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_DevenId, @AttGrp_SkillsId, @AtType_MSOfficeId, 'Expert');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_DevenId, @AttGrp_SkillsId, @AtType_CSharpId, 'Genius');

insert into Employee(Id, FirstName, LastName) 
values(@Emp_SumanId, 'Suman', 'Shah');
	insert into AttributeValue(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_SumanId, @AttGrp_PersonalDetailsId, @AttTyp_DOBId, '1973-11-16');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_SumanId, @AttGrp_PersonalDetailsId, @AttTyp_GenderId, 'F');
	insert into AttributeValue	(ReferenceKey, AttributeGroupId, AttributeTypeId, value)
		values (@Emp_SumanId, @AttGrp_SkillsId, @AtType_MSOfficeId, 'Intermediate');

commit tran;