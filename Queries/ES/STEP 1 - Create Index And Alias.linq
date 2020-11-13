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
private string aliasName = "people";
// https://stackoverflow.com/questions/34538204/elasticsearch-how-to-correctly-point-an-alias-to-an-index
void Main()
{
    var ESnode = new Uri("http://192.168.99.100:9200/");
    var Nodesettings = new ConnectionSettings(ESnode)
        .DefaultIndex(aliasName)
        .EnableHttpCompression()
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic","changeme");
        
    client = new ElasticClient(Nodesettings);

    CreateIndexAndAlias();
}

private void CreateIndexAndAlias()
{
    var indexName = $"{aliasName}_{DateTime.Now.ToString("yyyyMMdd-HHmm")}";
    
    if (IndexExists(indexName)) DeleteIndex(indexName);
    
    CreateIndex(indexName);
    
    AddToAlias(indexName);
}

private void DeleteIndex(string indexName)
{
    client.DeleteIndex(indexName);
}

private bool IndexExists(string indexName)
{
    return client.IndexExists(indexName).Exists;
}

private void CreateIndex(string indexName)
{
    var res = client.CreateIndex(indexName, c => c.Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
    res.Log();
}

private void AddToAlias(string indexName)
{
    //get any existing association to alias and remove
    var indexes = client.GetIndicesPointingToAlias(aliasName);    
    foreach (var index in indexes)
    {
        client.Alias(a => a.Remove(remove => remove.Index(index).Alias(aliasName)));
    }
    //add new association to alias
    client.Alias(a => a.Add(add => add.Alias(aliasName).Index(indexName)));
}