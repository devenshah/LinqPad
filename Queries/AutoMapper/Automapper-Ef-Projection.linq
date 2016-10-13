<Query Kind="Program">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <NuGetReference>AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
</Query>

void Main()
{
	Mapper.Initialize(cfg => 
		cfg.CreateMap<Products, ProductDto>()
			.ForMember(p => p.Name, o => o.MapFrom(s =>  s.ProductName))
			.ForMember(p => p.CategoryName, o => o.MapFrom(s => s.Category.CategoryName)));
	Products.Where(p => p.ProductName.StartsWith("A")).ProjectTo<ProductDto>().Dump();
	
}

public class ProductDto
{
	public string Name { get; set; }
	
	public string CategoryName { get; set; }
	
}