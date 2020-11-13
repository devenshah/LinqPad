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
// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
void Main()
{
    var indexName = "local-ds-person11";
    var hostUri = new Uri("https://1f1ed5179c654df6a151342560333553.eu-west-1.aws.found.io:9243");
    var connectionPool = new SingleNodeConnectionPool(hostUri);
    //var connection = new HttpConnection();
    var connectionSettings = 
        new ConnectionSettings(connectionPool)//,
            //(builtin, settings) => new JsonNetSerializer(builtin, settings, contractJsonConverters: new JsonConverter[] { new StringEnumConverter() }))
        .DefaultIndex(indexName)
        .EnableHttpCompression()
        //.DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("DevenShah","p123=0413>-$cJ/PG~");
        
    client = new ElasticClient(connectionSettings);
    
    CreateIndex<Person>(indexName);

    AddDocuments();    
}

private void CreateIndex<T>(string indexName) where T : class
{
    if (IndexExists(indexName)) DeleteIndex(indexName);
    client.Indices.Create(indexName, c => c
        .Map(m => m.AutoMap<T>())
        .Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
}

private void AddDocuments()
{
    for (var i = 0; i < 10; i++)
    {
        var person = fixture.Build<Person>().With(p => p.DateOfBirth, DateTime.Now).Create();
        var res = client.IndexDocument(person);
    }

    Thread.Sleep(1000); //There is a delay before the count can be called, perhaps due to docker 
    client.Count<Person>().Count.Log();
    GetDocuments();
}

private void GetDocuments() => client.Search<Person>(c => c.Size(50)).Documents.Log();

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

public class Person
{
    public Guid PersonId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Address Address { get; set; }
    [Elasticsearch.Net.StringEnum] //required if global converter is not applied in the connection settings
    public Gender Gender { get; set; }
    public double SecretPin { get; set; }
}

public class Address
{
    [Keyword]
    public string AddressLine1 { get; set; }

    [Keyword]
    public string AddressLine2 { get; set; }

    [Keyword]
    public string AddressLine3 { get; set; }

    [Keyword]
    public string AddressLine4 { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string Uprn { get; set; }

    public string Postcode { get; set; }

    public string PostcodeSearch { get; set; }
}