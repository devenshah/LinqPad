<Query Kind="Program">
  <Connection>
    <ID>3dfa1e2c-515c-4d32-8b8b-4fe1d2235ba0</ID>
    <Persist>true</Persist>
    <Database>Northwind</Database>
    <Server>.\SQLEXPRESS</Server>
  </Connection>
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
	var json = "[{\"Name\":\"Adam\",\"No1\":2,\"No2\":9,\"No3\":13},{\"Name\":\"Ajpal\",\"No1\":2,\"No2\":9,\"No3\":14},{\"Name\":\"Alex\",\"No1\":5,\"No2\":10,\"No3\":15},{\"Name\":\"Amin\",\"No1\":3,\"No2\":13,\"No3\":14},{\"Name\":\"Ashley\",\"No1\":4,\"No2\":8,\"No3\":12},{\"Name\":\"Bakerman\",\"No1\":7,\"No2\":10,\"No3\":15},{\"Name\":\"Becky\",\"No1\":3,\"No2\":7,\"No3\":9},{\"Name\":\"Carol\",\"No1\":3,\"No2\":4,\"No3\":7},{\"Name\":\"Chris\",\"No1\":4,\"No2\":7,\"No3\":9},{\"Name\":\"Clare\",\"No1\":4,\"No2\":5,\"No3\":7},{\"Name\":\"Craig\",\"No1\":1,\"No2\":11,\"No3\":14},{\"Name\":\"Dan -laaaar\",\"No1\":3,\"No2\":8,\"No3\":10},{\"Name\":\"Dave Somen\",\"No1\":2,\"No2\":5,\"No3\":6},{\"Name\":\"Dawn\",\"No1\":3,\"No2\":9,\"No3\":13},{\"Name\":\"Des\",\"No1\":2,\"No2\":7,\"No3\":10},{\"Name\":\"Deven\",\"No1\":1,\"No2\":4,\"No3\":5},{\"Name\":\"Emma Mc\",\"No1\":7,\"No2\":8,\"No3\":13},{\"Name\":\"Emma B H\",\"No1\":6,\"No2\":11,\"No3\":15},{\"Name\":\"Gavin\",\"No1\":6,\"No2\":9,\"No3\":14},{\"Name\":\"Gordon\",\"No1\":3,\"No2\":7,\"No3\":15},{\"Name\":\"HR\",\"No1\":3,\"No2\":4,\"No3\":5},{\"Name\":\"Ian\",\"No1\":3,\"No2\":8,\"No3\":9},{\"Name\":\"Jack\",\"No1\":3,\"No2\":7,\"No3\":14},{\"Name\":\"James\",\"No1\":2,\"No2\":8,\"No3\":11},{\"Name\":\"Jim\",\"No1\":3,\"No2\":5,\"No3\":8},{\"Name\":\"Joe\",\"No1\":3,\"No2\":11,\"No3\":12},{\"Name\":\"Joe Jnr\",\"No1\":1,\"No2\":11,\"No3\":12},{\"Name\":\"Josie\",\"No1\":5,\"No2\":7,\"No3\":11},{\"Name\":\"Katie\",\"No1\":6,\"No2\":7,\"No3\":9},{\"Name\":\"Kibibi\",\"No1\":3,\"No2\":5,\"No3\":7},{\"Name\":\"Lee\",\"No1\":7,\"No2\":8,\"No3\":14},{\"Name\":\"Leona\",\"No1\":4,\"No2\":5,\"No3\":12},{\"Name\":\"Lorna\",\"No1\":5,\"No2\":7,\"No3\":13},{\"Name\":\"Lowri\",\"No1\":3,\"No2\":7,\"No3\":13},{\"Name\":\"Mark Baker\",\"No1\":4,\"No2\":9,\"No3\":11},{\"Name\":\"Mark Blackwell\",\"No1\":4,\"No2\":8,\"No3\":11},{\"Name\":\"Marky Mark\",\"No1\":2,\"No2\":7,\"No3\":13},{\"Name\":\"Matt Baylon\",\"No1\":2,\"No2\":4,\"No3\":5},{\"Name\":\"Matt Lau\",\"No1\":1,\"No2\":4,\"No3\":14},{\"Name\":\"Michael (Accts)\",\"No1\":3,\"No2\":7,\"No3\":11},{\"Name\":\"MG\",\"No1\":1,\"No2\":5,\"No3\":9},{\"Name\":\"Oli\",\"No1\":1,\"No2\":10,\"No3\":13},{\"Name\":\"Parr Parr\",\"No1\":1,\"No2\":6,\"No3\":12},{\"Name\":\"Pat\",\"No1\":3,\"No2\":6,\"No3\":9},{\"Name\":\"Paul H\",\"No1\":3,\"No2\":9,\"No3\":13},{\"Name\":\"Peter\",\"No1\":null,\"No2\":null,\"No3\":null},{\"Name\":\"Rakesh\",\"No1\":6,\"No2\":9,\"No3\":11},{\"Name\":\"Rebecca\",\"No1\":1,\"No2\":8,\"No3\":12},{\"Name\":\"Ricardo\",\"No1\":1,\"No2\":7,\"No3\":13},{\"Name\":\"Rob C\",\"No1\":5,\"No2\":10,\"No3\":12},{\"Name\":\"Samantha\",\"No1\":7,\"No2\":13,\"No3\":15},{\"Name\":\"Sarah D\",\"No1\":2,\"No2\":5,\"No3\":15},{\"Name\":\"Sergei\",\"No1\":4,\"No2\":8,\"No3\":14},{\"Name\":\"Smiffy\",\"No1\":4,\"No2\":5,\"No3\":8},{\"Name\":\"Sophie\",\"No1\":1,\"No2\":4,\"No3\":9},{\"Name\":\"Swaroopa\",\"No1\":5,\"No2\":7,\"No3\":12},{\"Name\":\"Twinny\",\"No1\":3,\"No2\":9,\"No3\":11},{\"Name\":\"Vi\",\"No1\":7,\"No2\":8,\"No3\":12},{\"Name\":\"Vineet\",\"No1\":6,\"No2\":7,\"No3\":8}]";
	
	var lotNumbers = JsonConvert.DeserializeObject<IList<LotNumbers>>(json);
	
	var unifiedData = lotNumbers.Where (n => n.No1 != null)	
		.Select (l => new { Name = l.Name, Number = l.No1 })
	.Union(lotNumbers.Where (n => n.No1 != null)
			.Select (l => new { Name = l.Name, Number = l.No2 }))
	.Union(lotNumbers.Where (n => n.No1 != null)
			.Select (l => new { Name = l.Name, Number = l.No3 }));
			
	unifiedData.GroupBy (d => d.Number)
		.Select(d => new { Number = d.Key, ItemCount = d.Count()})		
		.OrderBy (d => d.Number)
		//.OrderByDescending (d => d.ItemCount)
		.Dump();
}

public class LotNumbers
{
	public string Name { get; set; }
	public int? No1 { get; set; }
	public int? No2 { get; set; }
	public int? No3 { get; set; }
}
// Define other methods and classes here