<Query Kind="Program">
  <Connection>
    <ID>3dfa1e2c-515c-4d32-8b8b-4fe1d2235ba0</ID>
    <Persist>true</Persist>
    <Database>Northwind</Database>
    <Server>.\SQLEXPRESS</Server>
  </Connection>
</Query>

void Main()
{
	var beverages = (from p in Products
	.Where(GetBeverages())
	select p);	
	
	beverages.Dump();
	
	var verifyIfSupplierIsExotic = GetVerifySupplierDelegate(2);
	verifyIfSupplierIsExotic(beverages.First()).Dump();
}

Expression<Func<Products, bool>> GetBeverages()
{
	return p => p.CategoryID == 1;
}

Func<Products, bool> GetVerifySupplierDelegate(int supplierId)
{ 
	return p => p.SupplierID == supplierId;
}