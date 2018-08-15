<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <NuGetReference Version="1.9.2">NEST</NuGetReference>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
  <Namespace>CsvHelper.Configuration.Attributes</Namespace>
  <Namespace>CsvHelper.Expressions</Namespace>
  <Namespace>CsvHelper.TypeConversion</Namespace>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Purify</Namespace>
</Query>

void Main()
{
    var importRows = ReadData(importFile);
    WriteData(importRows, importFile);

    var exportedData = ExportIndexDataToCsv();
    WriteData(exportedData, exportFile);
}

string exportFile = @"C:\SFA\RAA\Elastic Upgrade\Location\export.csv";
string importFile = @"C:\SFA\RAA\Elastic Upgrade\Location\import.csv";

IEnumerable<LocationData> ReadData(string fileName)
{
    using (var reader = new StreamReader(exportFile))
    {
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.RegisterClassMap<LocationMapper>();
            
            return csv.GetRecords<LocationData>().OrderBy(ld => ld.Name).OrderBy(ld => ld.County).ToList();
        }
    }
}

void WriteData(IEnumerable<LocationData> data, string file)
{
    using (var writer = new StreamWriter(file))
    {
        using (var csv = new CsvWriter(writer))
        {
            csv.Configuration.RegisterClassMap<LocationMapper>();

            csv.WriteRecords(data.OrderBy(ld => ld.Name).OrderBy(ld => ld.County));
        }
    }
}

IEnumerable<LocationData> ExportIndexDataToCsv()
{
    var myUri = new Uri("http://10.0.2.10:9200/");

    var Nodesettings = new ConnectionSettings(myUri, "locations");

    var client = new ElasticClient(Nodesettings);

    var response = client.Search<LocationData>(x => x.Size(50000));

    return response.Documents;
}


internal class LocationMapper : ClassMap<LocationData>
{
    public LocationMapper()
    {
        Map(m => m.Name).Name("Town");
        Map(m => m.County).Name("County");
        Map(m => m.Latitude).Name("Latitude");
        Map(m => m.Longitude).Name("Longitude");
        Map(m => m.Type).Name("Type");
    }
}

[ElasticType(Name = "locationdatas")]
internal class LocationData
{
    [ElasticProperty(Name = "name", Type = FieldType.String, Store = true, Index = FieldIndexOption.Analyzed, Analyzer = "keywordlowercase")]
    public string Name { get; set; }

    [ElasticProperty(Name = "county", Type = FieldType.String, Store = true, Index = FieldIndexOption.Analyzed)]
    public string County { get; set; }

    [ElasticProperty(Name = "country", Type = FieldType.String, Store = true, Index = FieldIndexOption.NotAnalyzed)]
    public string Country { get; set; }

    [ElasticProperty(Name = "longitude", Type = FieldType.Double, Store = true, Index = FieldIndexOption.NotAnalyzed)]
    public double Longitude { get; set; }

    [ElasticProperty(Name = "latitude", Type = FieldType.Double, Store = true, Index = FieldIndexOption.NotAnalyzed)]
    public double Latitude { get; set; }

    [ElasticProperty(Name = "postcode", Type = FieldType.String, Store = true, Index = FieldIndexOption.Analyzed)]
    public string Postcode { get; set; }

    [ElasticProperty(Name = "type", Type = FieldType.String, Store = true, Index = FieldIndexOption.NotAnalyzed)]
    public string Type { get; set; }

    [ElasticProperty(Name = "size", Type = FieldType.Integer, Store = true, Index = FieldIndexOption.NotAnalyzed)]
    public int Size
    {
        get
        {
            switch (Type)
            {
                case "City":
                    return 5;
                case "Town":
                    return 3;
                case "Other":
                    return 1;
                default:
                    return 1;
            }
        }
    }
}