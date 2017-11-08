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
	var query = @"
	SELECT 
		EmployeeID, OrderID
	FROM 
		Orders
	WHERE 
		EmployeeID in @employeeIds";

	var employeeIds = new[] {4,6};

	using (var sqlConn = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=northwind;Trusted_Connection=True;"))
	{
		sqlConn.Open();
		var results = sqlConn.Query<Order>(query, new { EmployeeIds = employeeIds }).ToList();
		results.Dump();
	}
}


public class Order
{
	public int EmployeeID { get; set; }
	public int OrderId { get; set; }

}

