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
private string _indexName = "local-ds-person22";
void Main()
{
    
    var credentials = new  BasicAuthenticationCredentials("DevenShah","p123=0413>-$cJ/PG~"); 
    var cloudId = @"das-dev-search:ZXUtd2VzdC0xLmF3cy5mb3VuZC5pbyQxZjFlZDUxNzljNjU0ZGY2YTE1MTM0MjU2MDMzMzU1MyRkMmI0MzQwMDFjMmU0ZDM2OTAwMTdiZTM0MWE4MGY1OQ==";
    
    var connectionPool = new CloudConnectionPool(cloudId, credentials);
    
    var connectionSettings = 
        new ConnectionSettings(connectionPool)
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant());

    client = new ElasticClient(connectionSettings);
    
    CreateIndex<Person>();
    
    AddDocuments();
}

private void CreateIndex<T>() where T : class
{
    if (IndexExists()) DeleteIndex();
    client.Indices.Create(_indexName, c => c
        .Map(m => m.AutoMap<T>())
        .Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
}

private void AddDocuments()
{
    for (var i = 0; i < 10; i++)
    {
        var person = fixture.Build<Person>().With(p => p.DateOfBirth, DateTime.Now).Create();
        var res = client.Index(person, idx => idx.Index(_indexName));
    }

    Thread.Sleep(1000); //There is a delay before the count can be called, perhaps due to docker 
    client.Count<Person>(i => i.Index(_indexName)).Count.Log();
    GetDocuments();
}

private void GetDocuments() => client.Search<Person>(c => c.Size(50).Index(_indexName)).Documents.Log();

private bool IndexExists() => client.Indices.Exists(_indexName).Exists;

private void DeleteIndex()
{
    if (IndexExists())
        client.Indices.Delete(_indexName);
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