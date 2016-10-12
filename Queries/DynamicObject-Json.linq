<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Dynamic</Namespace>
</Query>

void Main()
{
	var str = "{\"CertificateUrl\":null,\"Rrn\":\"8903-7944-5229-7926-3753\"}";
	
	dynamic sampleObject = new ExpandoObject();
	sampleObject.CertificateUrl = "sadfdef";
	
	var x = JsonConvert.SerializeObject(sampleObject);
	
	Console.WriteLine(x);
	
	var res = JsonConvert.DeserializeObject<MyResponse>(str);
	
	res.Dump();
	
}

public class MyResponse
{
	public string Certificate { get; set; }
	
	public string Rrn { get; set; }
	
	public string Foo { get; set; }
	
}

