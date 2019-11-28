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

// Define other methods and classes here