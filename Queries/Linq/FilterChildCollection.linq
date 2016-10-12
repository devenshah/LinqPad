<Query Kind="Expression">
  <Connection>
    <ID>3dfa1e2c-515c-4d32-8b8b-4fe1d2235ba0</ID>
    <Persist>true</Persist>
    <Database>Northwind</Database>
    <Server>.\SQLEXPRESS</Server>
  </Connection>
</Query>

//using northwind connection

Customers
	.Where(c => c.CustomerID == "ALFKI")
	.Select(c => new { Customer = c, Orders = c.Orders.Where(o => o.OrderDate.Value.Year == 1997) })
	.Select(c => new {Name = c.Customer.CompanyName, })
