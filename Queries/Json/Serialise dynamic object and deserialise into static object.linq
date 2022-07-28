<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    //var serialised = JsonConvert.SerializeObject(new {NaMe = "Deven", gender = "female"});
    
    var NaMe = "Deven"; var gender = "female";
    var serialised = JsonConvert.SerializeObject(new {NaMe , gender});
    //serialised.Dump();
    JsonConvert.DeserializeObject<Person>(serialised).Dump();
    
}

void Main1()
{
	//OBJECT serialisation works for generic purpose
	object person = new Person() {Name="Gandhi", Gender="male"};
	JsonConvert.SerializeObject(person).Dump();	
}

class Person
{
	public string Name { get; set; }
	public string Gender { get; set; }
}