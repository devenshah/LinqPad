<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>DotLiquid</NuGetReference>
  <Namespace>DotLiquid</Namespace>
  <Namespace>DotLiquid.Exceptions</Namespace>
  <Namespace>DotLiquid.FileSystems</Namespace>
  <Namespace>DotLiquid.NamingConventions</Namespace>
  <Namespace>DotLiquid.Tags</Namespace>
  <Namespace>DotLiquid.Tags.Html</Namespace>
  <Namespace>DotLiquid.Util</Namespace>
</Query>

void Main()
{
	Template.NamingConvention = new CSharpNamingConvention();
	Template template =
	Template.Parse(		
@"{% assign isCustomerPaying = false -%}
{% assign isClientPaying = false -%}
{% for item in Products -%}
	{{ forloop.index }}:{{ item.PayableBy -}}
	{{ forloop.index }}:{{ item.Name -}} 
    {% if item.PayableBy == 1 -%}
      {% assign isCustomerPaying = true -%}	  
    {% else -%}
      {% assign isClientPaying = true -%}
    {% endif -%}
{% endfor -%}
{% if isCustomerPaying and isClientPaying -%}
  {% assign payBy = 'Split' -%}	
{% elseif isCustomerPaying -%}
  {% assign payBy = 'Customer' -%}	
{% elseif isClientPaying -%}
  {%assign payBy = 'Client'-%}	
{%endif-%}
JobId: {{ JobId -}}
, IsCustomerPaying: {{ isCustomerPaying }}
, IsClientPaying: {{ isClientPaying }}
, IsPayableBy: {{ payBy -}}
");

	var job = new Job() { JobId = 1234 };
	job.Products.Add(new Product() { Name = "Prod1", PayableBy = (int)Payee.Customer});
	job.Products.Add(new Product() { Name = "Prod2", PayableBy = (int)Payee.Customer});
	template.Render(Hash.FromAnonymousObject(job)).Dump();
}

public class Job 
{
	public Job()
	{
		Products = new List<Product>();
	}
	public int JobId { get; set; }
	public IList<Product> Products { get; set; }
	public int[] Numbers = new int[] {101, 102};
}

public class Product : Drop
{
	public string Name { get; set; }
	public int PayableBy { get; set; }
}

public enum Payee
{
	Customer = 1,
	Client = 2
}