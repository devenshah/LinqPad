<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>NEST</NuGetReference>
  <NuGetReference>NEST.JsonNetSerializer</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Nest.JsonNetSerializer</Namespace>
</Query>

private ElasticClient client;
private Fixture fixture = new Fixture();
private string aliasName = "local-deven-shah-people";
// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
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
        .BasicAuthentication("DevenShah","p123=0413>-$cJ/PG~");
        
    client = new ElasticClient(connectionSettings);
    //Create();
    //DeleteAlias();
}

private void DeleteAlias()
{
    var indices = client.GetIndicesPointingToAlias(aliasName).Dump();
    foreach(var index in indices)
        client.Indices.DeleteAlias(index, aliasName);
}

private void Create()
{
    for (var indexNumber = 1; indexNumber < 4; indexNumber++)
    {
        var indexName = $"{aliasName}-{indexNumber}";
        CreateIndex<Person>(indexName);
        client.Indices.PutAlias(indexName, aliasName);
    }

    client.GetIndicesPointingToAlias(aliasName).Dump();

    Thread.Sleep(1000);

    client.Search<Person>(c => c.Index(aliasName).Size(50)).Documents.Log();
}

private void CreateIndex<T>(string indexName) where T : class
{
    if (IndexExists(indexName)) DeleteIndex(indexName);
    client.Indices.Create(indexName, c => c
        .Map(m => m.AutoMap<T>())        
        .Settings(s => 
            s.NumberOfShards(1).NumberOfReplicas(1)));
        
    AddDocuments(indexName);
}

private void AddDocuments(string indexName)
{
    for (var i = 0; i < 10; i++)
    {
        var person = fixture.Build<Person>().With(p => p.DateOfBirth, DateTime.Now).With(p => p.IndexName, indexName).Create();
        var res = client.Index(person, j => j.Index(indexName));
    }
}

private void GetDocuments() => client.Search<Person>(c => c.Size(100)).Documents.Log();

private bool IndexExists(string indexName) => client.Indices.Exists(indexName).Exists;

private void DeleteIndex(string indexName)
{
    if (IndexExists(indexName))
        client.Indices.Delete(indexName);
}

private void AddToAlias(string indexName, string aliasName)
{
    //get any existing association to alias and remove
    var indexes = client.GetIndicesPointingToAlias(aliasName);    
    foreach (var index in indexes)
    {
        client.Indices.DeleteAlias(index, aliasName);
    }
    //add new association to alias
    client.Indices.PutAlias( indexName, aliasName);
}

[ElasticsearchType(RelationName="person")]
public class Person
{
    public Guid PersonId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Elasticsearch.Net.StringEnum] 
    public Gender Gender { get; set; }
    public string IndexName { get; set; }
}