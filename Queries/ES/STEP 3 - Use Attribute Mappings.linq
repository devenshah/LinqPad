<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference Version="5.6.2">NEST</NuGetReference>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Purify</Namespace>
  <Namespace>AutoFixture</Namespace>
  <Namespace>AutoFixture.Kernel</Namespace>
</Query>

private ElasticClient client;
private Fixture fixture = new Fixture();
private string indexName = "phonetracker";
// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
void Main()
{
    fixture.Customizations.Add(new LatitudeBuilder());
    fixture.Customizations.Add(new LongitudeBuilder());
    
    var connectionPool = new SingleNodeConnectionPool(new Uri("http://192.168.99.100:9200/"));
    var connection = new HttpConnection();
    //Add this to serialize enums as text
    var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()));
    
    var Nodesettings = new ConnectionSettings(connectionPool, connection, serializers)
        .DefaultIndex(indexName)
        .EnableHttpCompression()
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic","changeme");
        
    client = new ElasticClient(Nodesettings);

    CreateIndex();
    AddDocuments();
    GetAllDocuments();
}

private void CreateIndex()
{
    if (client.IndexExists(indexName).Exists) client.DeleteIndex(indexName);

    client.CreateIndex(indexName, c => c.Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
}


private void AddDocuments()
{
    for(var i = 0; i < 10; i++)
    {
//        var latitudeGenerator = new RangedNumberRequest(typeof(double),-90,90); 
//        var longitudeGenerator = new RangedNumberRequest(typeof(double),-180,180);
//        var location = fixture.Build<GeoLocation>().With(x => x.Latitude, latitudeGenerator)
        
        var person = fixture.Create<PhoneTracker>();
        client.Index(person);
    }
    
    Thread.Sleep(500); //There is a delay before the count can be called, perhaps due to docker 
    client.Count<PhoneTracker>(c => c.Index(indexName)).Count.Log();
}

private void GetAllDocuments()
{
    client.Search<PhoneTracker>().Documents.Log();
}


private class PhoneTracker
{
    [Keyword]
    public Guid Id { get; set; }
    [Text]
    public string Name { get; set; }
    [Keyword]
    public string Make { get; set; }
    [Keyword]
    public string Model { get; set; }
    [Date]
    public DateTime DateRegistered { get; set; }
    [GeoPoint]
    public GeoLocation LastKnownLocation { get; set; }
    [Text]
    public Status Status { get; set; }
}

private enum Status
{
    UnVerified = 1,
    Active = 2,
    Suspended = 3,
    Deleted = 4
}

public class LatitudeBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var pi = request as PropertyInfo;
        if (pi == null ||
            pi.Name != "Diameter" ||
            pi.PropertyType != typeof(decimal))
            return new NoSpecimen();

        return context.Resolve(
            new RangedNumberRequest(typeof(double), -90d, 90d));
    }
}

public class LongitudeBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        var pi = request as PropertyInfo;
        if (pi == null ||
            pi.Name != "Diameter" ||
            pi.PropertyType != typeof(decimal))
            return new NoSpecimen();

        return context.Resolve(
            new RangedNumberRequest(typeof(double), -180d, 180d));
    }
}
