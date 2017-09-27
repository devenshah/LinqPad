<Query Kind="Program">
  <Connection>
    <ID>47055575-be2a-4d08-9dd6-f8313e56edf8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <NuGetReference>Dapper</NuGetReference>
  <Namespace>Dapper</Namespace>
</Query>

void Main()
{
	string query = @"select O.OrderId, O.EmployeeId, E.FirstName, E.LastName
	from Orders as O
	inner join Employees as E  on O.EmployeeID = E.EmployeeID
	where O.OrderId = 10248";

	using (var sqlConn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=northwind;Trusted_Connection=True;"))
	{
		sqlConn.Open();
		var results = sqlConn.Query<Order, Person, Order>(query, (o, p) => { o.Person = p; return o; }, splitOn:"FirstName").First();
		results.Dump();
	}
}

public class Order
{ 
	public int OrderId { get; set; }
	public Person Person { get; set; }
	
}

public class Person
{ 
	public string FirstName { get; set; }
	public string LastName { get; set; }
}


