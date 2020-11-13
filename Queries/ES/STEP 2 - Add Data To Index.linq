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
</Query>

private ElasticClient client;
private Fixture fixture = new Fixture();
private string aliasName = "people";
// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
void Main()
{
    var connectionPool = new SingleNodeConnectionPool(new Uri("http://192.168.99.100:9200/"));
    var connection = new HttpConnection();
    //Add this to serialize enums as text
    var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()));
    
    var Nodesettings = new ConnectionSettings(connectionPool, connection, serializers)
        .DefaultIndex(aliasName)
        .EnableHttpCompression()
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic","changeme");
        
    client = new ElasticClient(Nodesettings);

    AddDocuments();

    Thread.Sleep(500); //There is a delay before the count can be called, perhaps due to docker 
    //client.Count<Person>(c => c.Index(aliasName)).Count.Log();
    GetDocuments();
}

private void AddDocuments()
{
    for(var i = 0; i < 10; i++)
    {
        var person = fixture.Create<Person>();
        client.Index(person);
    }    
}

private void GetDocuments()
{
    client.Search<Person>(c => c.Size(50)).Documents.Log();
}