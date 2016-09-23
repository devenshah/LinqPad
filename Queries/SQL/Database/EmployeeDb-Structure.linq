<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>master</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/*
 alter database EmployeeDb set single_user with rollback immediate
 drop database EmployeeDb
*/
go

create database EmployeeDb;
go

use EmployeeDb;
go


create table Employee (
	Id int primary key,
	FirstName varchar(50) not null,
	LastName varchar(50) not null
)
go

create table AttributeGroup (
	Id int primary key,
	Name varchar(100) not null unique
)
go

create table AttributeType (
	Id int primary key,
	Name varchar(100) not null unique,
)
go

create table AttributeGroupType (
	Id int identity(1,1) primary key,
	AttributeGroupId int not null,
	AttributeTypeId int not null,
	
	constraint FK_AttributeGroupType_AttributeGroup 
		foreign key (AttributeGroupId)  
		references AttributeGroup (Id),
		
	constraint FK_AttributeGroupType_AttributeType 
		foreign key (AttributeTypeId)  
		references AttributeType (Id)
)
go

create table AttributeValue (
	Id int identity(1,1) primary key,
	ReferenceKey int not null,
	AttributeGroupId int not null,
	AttributeTypeId int not null,
	Value varchar(max) not null,
	
	constraint fk_AttributeValue_AttributeGroup
		foreign key (AttributeGroupId)
		references AttributeGroup (Id),

	constraint fk_AttributeValue_AttributeType
		foreign key (AttributeTypeId)
		references AttributeType (Id),

)
go






