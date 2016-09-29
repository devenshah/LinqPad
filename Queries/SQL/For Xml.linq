<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

select *
From Employee
for xml auto
/*
<Employee Id="1000000010" FirstName="Deven" LastName="Shah"/>
<Employee Id="1000000020" FirstName="Suman" LastName="Shah"/>
*/

select *
From Employee
for xml path
/*
<row>
	<Id>1000000010</Id><FirstName>Deven</FirstName><LastName>Shah</LastName>
</row>
<row>
	<Id>1000000020</Id><FirstName>Suman</FirstName><LastName>Shah</LastName>
</row>
*/

select Id as "@id" --Creates attribute to tag element
		, * 
From Employee
for xml path ('Employee') -- creates element for each row
	, Type
	, ROOT('Employees') -- creates root element
/*
<Employees> ---- ROOT('Employees')
	<Employee id="1000000010">  --- path ('Employee')
		<Id>1000000010</Id><FirstName>Deven</FirstName><LastName>Shah</LastName>
	</Employee>
	<Employee id="1000000020"> --- id as '@id'
		<Id>1000000020</Id><FirstName>Suman</FirstName><LastName>Shah</LastName>
	</Employee>
</Employees>
*/


