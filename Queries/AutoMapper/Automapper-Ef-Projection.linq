<Query Kind="Program">
  <Connection>
    <ID>671596e1-ed4e-4fb4-8637-8731fe3aaf37</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>MyDatabase</Database>
  </Connection>
  <NuGetReference>AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
</Query>

void Main()
{
	//NOT WORKING AS EXPECTED
	
	Mapper.CreateMap<Product, ProductDto>();
		//.ForMember(p => p.ProductName, o => o.MapFrom(s =>  s.Name))
		//.ForMember(p => p.CategoryName, o => o.MapFrom(s => s.Category.Name));
	Products.Where(p => p.Name.StartsWith("A")).Project().To<ProductDto>().Dump();
	
}

public class ProductDto
{
	public string Name { get; set; }
	
	public string CategoryName { get; set; }
	
}