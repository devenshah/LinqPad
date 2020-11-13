<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>NEST</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
</Query>

private ElasticClient client;
private Fixture fixture = new Fixture();

// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
void Main()
{
    var indexName = "local-deven-shah-person";
    var ESnode = new Uri("https://1f1ed5179c654df6a151342560333553.eu-west-1.aws.found.io:9243");
    var connectionSettings = new ConnectionSettings(ESnode)
        .DefaultIndex(indexName)
        .EnableHttpCompression()
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("DevenShah","p123=0413>-$cJ/PG~");
    client = new ElasticClient(connectionSettings);

    AddDocuments();

    //Thread.Sleep(500); //There is a delay before the count can be called, perhaps due to docker 
    //client.Count<Person>(c => c.Index(aliasName)).Count.Log();
    GetDocuments();
}

private void AddDocuments()
{
    for (var i = 0; i < 10; i++)
    {
        var person = fixture.Build<Person>().With(p => p.DateOfBirth, DateTime.Now).Create();
        client.IndexDocument(person);
    }
}

private void GetDocuments()
{
    client.Search<Person>(c => c.Size(50)).Documents.Log();
}

[ElasticsearchType(RelationName="person")]
public class Person
{
    public Guid PersonId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Address Address { get; set; }
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

    public string Uprn { get; set; }

    public string Postcode { get; set; }

    [GeoPoint]
    public LatLon Location { get; set; }
}