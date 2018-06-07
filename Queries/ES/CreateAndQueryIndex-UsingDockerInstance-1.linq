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

void Main()
{
    var ESnode = new Uri("http://192.168.99.100:9200/");
    var Nodesettings = new ConnectionSettings(ESnode).DefaultIndex("people").BasicAuthentication("elastic","changeme");
    client = new ElasticClient(Nodesettings);
    
    //AddToIndex();
    
    var request = new SearchRequest<Person>{
        Query = new TermQuery{
         Field = "name",
         Value = "deven"
        }
    };
    
    client.Search<Person>(request).Documents.Log();
}

private void CreateIndex()
{
    var indexName = new IndexName() { Name = "people" };
    client.CreateIndex(indexName, c => c.Mappings(m => m.Map<Person>(d => d.AutoMap())));
}

private void AddToIndex()
{
    var person = fixture.Create<Person>();

    client.Index(person).Log();

}
