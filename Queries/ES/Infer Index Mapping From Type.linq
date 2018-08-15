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
private string aliasName = "apprenticeship";

void Main()
{
    var myUri = new Uri("http://192.168.99.100:9200/");
    var connectionPool = new SingleNodeConnectionPool(myUri);
    var connection = new HttpConnection();
    var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()));

    var Nodesettings = new ConnectionSettings(connectionPool, connection, serializers)
        .EnableHttpCompression()
        .EnableDebugMode()
        .InferMappingFor<Movie>(m => m.IndexName("movies"))
        .InferMappingFor<Actor>(m => m.IndexName("actors"))
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic", "changeme");

    client = new ElasticClient(Nodesettings);
    
    var indexName = $"{aliasName}_{DateTime.Now.ToString("yyyyMMdd-HHmm")}";

    CreateIndex("movies");
    PopulateMoviesIndex();
    CreateIndex("actors");
    PopulateActorsIndex();
    
    var response = client.Search<Movie>(s => s.Query(q => q.MatchAll()));
    response.Documents.Log();
}

void CreateIndex(string indexName)
{
    if (client.IndexExists(indexName).Exists) client.DeleteIndex(indexName);
    
    client.CreateIndex(indexName);
}



private void PopulateMoviesIndex()
{    
    var count = fixture.Create<byte>();
    $"Created {count} documents".Log();

    

    Func<string> getName = () =>
    {
        var names = new[] {"one", "two", "three", "four"};
        var name = string.Empty;
        var r = new Random();

        return $"{names[r.Next(0,3)]} {names[r.Next(0,3)]}";
    };

    var docs = fixture.Build<Movie>()
        .With(m => m.Title, getName())
        .CreateMany(count);
        
    docs.ToList().ForEach(a => client.Index(a));
    
    Thread.Sleep(1000);
}

public class Movie
{
    public int Id { get; set; }
    public int YearOfRelease { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }    
    public string Genre { get; set; }
}


private void PopulateActorsIndex()
{
    var count = fixture.Create<byte>();
    $"Created {count} documents".Log();

    var docs = fixture.Build<Actor>()
        .CreateMany(count);

    docs.ToList().ForEach(a => client.Index(a));

    Thread.Sleep(1000);
}

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Accolades { get; set; }
}




