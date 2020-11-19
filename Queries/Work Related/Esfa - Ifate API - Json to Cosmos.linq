<Query Kind="Program">
  <Reference Relative="appsettings.json">C:\Deven\Git\LinqPad\Queries\Work Related\appsettings.json</Reference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <NuGetReference>System.Net.Http.Json</NuGetReference>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Json</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization</Namespace>
  <Namespace>MongoDB.Bson.IO</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        services.AddHttpClient("ifate", c => c.BaseAddress = new Uri("https://www.instituteforapprenticeships.org/api/apprenticeshipstandards"));
        services.AddTransient<ApprenticeshipStandardsService>();
    }).Build();

    var svc = builder.Services.GetService<ApprenticeshipStandardsService>();
    svc.GetAllStandards().Wait();
}


public class ApprenticeshipStandardsService
{
    private readonly HttpClient _client;
    public ApprenticeshipStandardsService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ifate");
    }

    public async Task GetAllStandards()
    {        
        var response = await _client.GetAsync("");
        var result = await response.Content.ReadAsStringAsync();
        var rootElement = JsonDocument.Parse(result).RootElement;
        var documents = new Dictionary<string, string>();
        
        var content = GetFormattedDocument(rootElement[0]);
        var standardReference = rootElement[0].GetProperty("referenceNumber").GetString();
        var version = rootElement[0].GetProperty("version").GetString();
        if (string.IsNullOrWhiteSpace(version)) version = "xx";
        var id = $"{standardReference}_{version}";
        var document = BsonDocument.Parse(content);
        document.Add(new BsonElement("_id", id ));
        //var doc = new BsonDocument { { "_id", id }, { "document", document }};
        SaveDocument(document);
    }

    private static void SaveDocument(BsonDocument standard)
    {
        var client = new MongoClient("mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true");
        var database = client.GetDatabase("Standards");
        var collection = database.GetCollection<BsonDocument>("Standards");
        collection.InsertOne(standard);
    }

    private static string GetFormattedDocument(JsonElement element)
    {
        return JsonSerializer.Serialize(element, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

//    private async Task SaveTypedDocument()
//    {
//        var response = await _client.GetAsync("");
//        var values = await JsonSerializer.DeserializeAsync<List<Standard>>(await response.Content.ReadAsStreamAsync());
//
//        var standardReference = values[0].ExtensionData["referenceNumber"].ToString();
//        var version = values[0].ExtensionData["version"].ToString();
//        if (string.IsNullOrWhiteSpace(version)) version = "xx";
//        values[0].Id = $"{standardReference}_{version}";
//
//        SaveDocument(values[0]);
//
//    }
//
//    private static void SaveDocument(Standard standard)
//    {
//        var client = new MongoClient("mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true");
//        var database = client.GetDatabase("Standards");
//        var collection = database.GetCollection<Standard>("Standards");
//        collection.InsertOne(standard);
//    }

}


public class Standard
{
    [JsonIgnore]
    public string Id { get; set; }
    [System.Text.Json.Serialization.JsonExtensionDataAttribute]
    public IDictionary<string, object> ExtensionData
    {
        get; set;
    }
}