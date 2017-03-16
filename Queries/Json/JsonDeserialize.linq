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
	Console.Write(jsonData);
	var data = JsonConvert.DeserializeObject<List<WallUValue>>(jsonData);
	data.Dump();
}

// Define other methods and classes here

public class WallUValue
{
   public int Id { get; set; }
   public string Country { get; set; }
   public char AgeBand { get; set; }
   public string ConstructionType { get; set; }
   public string InsulationType { get; set; }
   public string InsulationThickness { get; set; }
   public string Action { get; set; }
   public decimal? UValue { get; set; }
}
	
string jsonData = "[" + 
  "{ " + 
"'Id':1, " + 
"'Country':'E&W', " + 
"'AgeBand':'A', " + 
"'ConstructionType':'Granite & Whinstone', " + 
"'InsulationType':'As Built', " + 
"'Thickness':'', " + 
"'Use':'A Formula', " + 
"'Value':null, " + 
"'ReferenceId':null " + 
  "}, " + 
"{ " + 
"'Id':2, " + 
"'Country':'E&W', " + 
"'AgeBand':'B', " + 
"'ConstructionType':'Granite & Whinstone', " + 
"'InsulationType':'As Built', " + 
"'Thickness':'', " + 
"'Use':'A Formula', " + 
"'Value':null, " + 
"'ReferenceId':null " + 
  "}, " + 
"{ " + 
"'Id':3, " + 
"'Country':'E&W', " + 
"'AgeBand':'C', " + 
"'ConstructionType':'Granite & Whinstone', " + 
"'InsulationType':'As Built', " + 
"'Thickness':'', " + 
"'Use':'A Formula', " + 
"'Value':null, " + 
"'ReferenceId':null " + 
  "}, " + 
"{ " + 
"'Id':4, " + 
"'Country':'E&W', " + 
"'AgeBand':'D', " + 
"'ConstructionType':'Granite & Whinstone', " + 
"'InsulationType':'As Built', " + 
"'Thickness':'', " + 
"'Use':'A Formula', " + 
"'Value':null, " + 
"'ReferenceId':null " + 
  "}" + 
"]";