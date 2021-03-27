<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    GetDocumentById().Wait();
}

private async Task GetDocumentById()
{
    var settings = new MongoClientSettings
    {
        Server = new MongoServerAddress("", 10255),
        UseSsl = true,
        SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 },
        ConnectionMode = ConnectionMode.Direct,
        Credential = MongoCredential.CreateCredential("admin", "", "")
    };

    var client = new MongoClient(settings);
    var database = client.GetDatabase("findapprenticeship");
    var collection = database.GetCollection<ApplicationInfo>("apprenticeships");

    var applicationGuid = Guid.Parse("c14c1bf0-c0e8-4d9d-b784-076ac426d056"); 

    var filterBuilder = Builders<ApplicationInfo>.Filter;
    var filter = filterBuilder.Eq(x => x.Id, applicationGuid);

    var result = await collection.Find(filter).SingleAsync();
    
    result.Log();
}

[BsonIgnoreExtraElements]
public class ApplicationInfo
{
    public Guid Id { get; set; }

    public string Notes { get; set; }
}