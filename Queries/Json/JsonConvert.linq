<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	//to avoid self referencing loop
	var jsonSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
	
	var stream = new MemoryStream();
	var property1 = GetProperty();
	var property2 = JsonConvert.DeserializeObject<Property>(JsonConvert.SerializeObject(property1, jsonSettings));
	property1.Equals(property2).Dump();
	property2.Dump();
}

void Main1()
{
	var date = $"{{'orderDate':'2021-06-21T09:56:16.4249998+01:00'}}";

	var order = JsonConvert.DeserializeObject<Order>(date);

	order.OrderDate.ToString("o").Dump($"with timezone, expect same {order.OrderDate.Kind}");

	date = $"{{'orderDate':'2021-06-21T09:56:16.4249998'}}";

	order = JsonConvert.DeserializeObject<Order>(date);

	order.OrderDate.ToString("o").Dump($"No timezone, expect local {order.OrderDate.Kind}");

	date = $"{{'orderDate':'2021-06-21T09:56:16.4249998Z'}}";

	order = JsonConvert.DeserializeObject<Order>(date);

	order.OrderDate.ToString("o").Dump($"No timezone, expect local {order.OrderDate.Kind}");


	//2021-06-21T09:56:16.4249998+01:00
}

class Order
{
	public DateTime OrderDate { get; set; }
}

Property GetProperty()
{
	var p = new Property{ PropertyId = 1, Address="Solihul"};
	p.Measures = new HashSet<Measure>
	{
		new Measure{MeasureId = 1, 	 RefNum = "okm1"},
		new Measure{MeasureId = 2, 	 RefNum = "okm2"},
		new Measure{MeasureId = 3, 	 RefNum = "okm3"}
	};
	return p;
}

public class Property
{
	public int PropertyId { get; set; }
	public string Address { get; set; }
	public HashSet<Measure> Measures { get; set; }
}


public class Measure
{
	public int MeasureId { get; set; }
	public string RefNum { get; set; }
}