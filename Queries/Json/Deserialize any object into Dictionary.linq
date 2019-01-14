<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var p = new Person {Name = "Deven", DOB = DateTime.Today, Gender = Gender.Male};
    
    var json = JsonConvert.SerializeObject(p);
    
    json.Dump();
    
    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    
    dict["Name"].Dump();
}


