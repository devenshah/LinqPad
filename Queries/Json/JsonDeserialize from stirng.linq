<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	JsonConvert.SerializeObject(new MyClass()).Dump();
	
	JsonConvert.DeserializeObject<MyClass>("{'MyProperty':1,'Name':'Deven'}").Dump();
}

public class MyClass
{
	public int MyProperty { get;  set; }
	public string Name { get; set; } = "Deven";
}
