<Query Kind="SQL">
  <Connection>
    <ID>671596e1-ed4e-4fb4-8637-8731fe3aaf37</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>MyDatabase</Database>
  </Connection>
</Query>


create table Category
(
	Id int not null primary key,
	Name varchar(100) not null
)

create table Product
(
	Id int not null primary key,
	Name varchar(100) not null,
	CategoryId int references Category (Id)
)

create table [Order]
(
	Id int not null primary key,
	CreateDate DateTime,
	ShipCountry varchar(100) not null
)

create table OrderDetail
(
	Id int not null primary key,
	OrderId int not null references [Order] (Id),
	ProductId int not null references Product (Id),
	UnitPrice decimal,
	Quantity int
)

insert Category values (1, 'Seafood')
insert Category values (2, 'Beverages')
insert Category values (3, 'Confections')
insert Category values (4, 'Meat/Poultry')
insert Category values (5, 'Dairy Products')

insert Product values (1, 'Boston Crab Meat', 1)
insert Product values (2, 'Chai', 2)
insert Product values (3, 'Teatime Chocolate Biscuits', 3)
insert Product values (4, 'Amazon Coffee', 2)
insert Product values (5, 'Arabian Tea', 2)

insert [Order] values (1, '2007-1-1', 'Spain');
insert [Order] values (2, '2007-2-2', 'Spain');
insert [Order] values (3, '2007-3-3', 'Spain');

insert OrderDetail values (1, 1, 1, 23.5, 2)
insert OrderDetail values (2, 2, 2, 143, 5)
insert OrderDetail values (3, 3, 3, 77, 1)
insert OrderDetail values (4, 3, 2, 70, 3)


//------------------------------------------------

drop table Appointment
drop table Job
drop table Person
drop table Address

Create table Address
(
	Id int not null primary key, 
	Line1 varchar(200) not null,
	Postcode varchar(10) not null
)

Create table Person 
(
	Id int not null primary key, 
	Name varchar(20) not null,
	AddressId int not null references Address (Id)	
)

Create table Job
(
	Id int not null primary key, 
	AddressId int not null references Address(Id)
	
)

Create Table Appointment
(
	Id int not null primary key, 
	JobId int not null references Job (Id),
	PersonId int not null references Person (Id),
	AddressId int not null references Address (Id)
)

insert into Address values(1001, '4 Street Road','12344')
insert into Address values(1002, '5 Street Road','12345')
insert into Address values(1003, '6 Street Road','12346')
insert into Address values(1004, '7 Street Road','12347')
insert into Address values(1011, '4 Street Road','11341')
insert into Address values(1012, '5 Street Road','11342')
insert into Address values(1013, '6 Street Road','11343')
insert into Address values(1014, '7 Street Road','11344')

insert into Person values(1, 'Pumba', 1001);
insert into Person values(2, 'Timon', 1002);
insert into Person values(3, 'Mufasa', 1003);
insert into Person values(4, 'Simba', 1004);

insert into Job values(2001, 1001)
insert into Job values(2002, 1002)

insert into Appointment values(3001, 2001, 1, 1011)
insert into Appointment values(3002, 2001, 3, 1012)
insert into Appointment values(3003, 2001, 4, 1013)
insert into Appointment values(3004, 2002, 2, 1014)
insert into Appointment values(3005, 2002, 3, 1011)


