<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>NEST</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
</Query>

private ElasticClient _client;
private Fixture fixture = new Fixture();
private string indexName = "local-deven-shah-address";

void Main()
{
    var hostUri = new Uri("https://1f1ed5179c654df6a151342560333553.eu-west-1.aws.found.io:9243");
    var connectionPool = new SingleNodeConnectionPool(hostUri);
    var connection = new HttpConnection();
    var connectionSettings =
        new ConnectionSettings(connectionPool, connection)//,
                                                          //(builtin, settings) => new JsonNetSerializer(builtin, settings, contractJsonConverters: new JsonConverter[] { new StringEnumConverter() }))
        .EnableHttpCompression()
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("DevenShah", "p123=0413>-$cJ/PG~");

    _client = new ElasticClient(connectionSettings);

    CreateIndex<Address>(indexName);
    
    AddDocuments();
    
}


private void AddDocuments()
{
    for (var i = 0; i < 10; i++)
    {
        var address = fixture.Build<Address>().Create();
        var res = _client.Index(address, index => index.Index(indexName) );
        
        if (res.IsValid == false) res.OriginalException.Dump();
    }

    Thread.Sleep(1000); //There is a delay before the count can be called, perhaps due to docker 
    _client.Count<Address>(index => index.Index(indexName)).Count.Log();
    GetDocuments();
}
private void GetDocuments() => _client.Search<Address>(c => c.Size(50).Index(indexName)).Documents.Log();

private void CreateIndex<T>(string indexName) where T : class
{
    if (IndexExists(indexName)) DeleteIndex(indexName);
    _client.Indices.Create(indexName, c => c
        .Map(m => m.AutoMap<T>())
        .Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
}

private bool IndexExists(string indexName) => _client.Indices.Exists(indexName).Exists;

private void DeleteIndex(string indexName)
{
    if (IndexExists(indexName))
        _client.Indices.Delete(indexName);
}


[ElasticsearchType(RelationName="Location")]
public class Address
{
    [Text]
    public string AddressLine1 { get; set; }
    [Text]
    public string AddressLine2 { get; set; }
    [Keyword]
    public string City { get; set; }
    [Keyword]
    public string Postcode { get; set; }
    [GeoPoint]
    public LatLon Position { get; set; }
    public GeoLocation Location { get; set; }
    [Date(Format=DateFormat.date_optional_time)]
    public DateTime UpdatedDate { get; set; }
}