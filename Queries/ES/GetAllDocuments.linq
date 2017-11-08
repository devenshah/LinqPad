<Query Kind="Program">
  <NuGetReference Version="1.9.2">NEST</NuGetReference>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Elasticsearch.Net.Connection</Namespace>
  <Namespace>Elasticsearch.Net.Connection.Configuration</Namespace>
  <Namespace>Elasticsearch.Net.Connection.RequestState</Namespace>
  <Namespace>Elasticsearch.Net.Connection.Security</Namespace>
  <Namespace>Elasticsearch.Net.ConnectionPool</Namespace>
  <Namespace>Elasticsearch.Net.Exceptions</Namespace>
  <Namespace>Elasticsearch.Net.Providers</Namespace>
  <Namespace>Elasticsearch.Net.Serialization</Namespace>
  <Namespace>Nest</Namespace>
  <Namespace>Nest.Domain</Namespace>
  <Namespace>Nest.DSL.Descriptors</Namespace>
  <Namespace>Nest.DSL.Query</Namespace>
  <Namespace>Nest.DSL.Query.Behaviour</Namespace>
  <Namespace>Nest.DSL.Visitor</Namespace>
  <Namespace>Nest.Resolvers</Namespace>
  <Namespace>Nest.Resolvers.Converters</Namespace>
  <Namespace>Nest.Resolvers.Converters.Aggregations</Namespace>
  <Namespace>Nest.Resolvers.Converters.Filters</Namespace>
  <Namespace>Nest.Resolvers.Converters.Queries</Namespace>
  <Namespace>Nest.Resolvers.Writers</Namespace>
  <Namespace>Nest.SerializationExtensions</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Purify</Namespace>
</Query>

void Main()
{
	var query = new QueryDescriptor<ApprenticeshipSummary>();
	query.Filtered(sl => sl.Filter(fs => fs.Terms(f => f.SubCategoryCode, new [] {"STDSEC.40", "STDSEC.41", "STDSEC.9"})));
	
	var searchParams = new SearchDescriptor<ApprenticeshipSummary>();
	searchParams.Index("apprenticeships").Type("apprenticeship");
	searchParams.From(0).Size(5);
	//searchParams.Query( q => q.Filtered(sl => sl.Filter(fs => fs.Terms(f => f.SubCategoryCode, new [] {"STDSEC.40", "STDSEC.41", "STDSEC.9"}))));
	searchParams.Query( q => query);
		
	var client = GetElasticSearchClient();
	
	var result = client.Search<ApprenticeshipSummary>(searchParams);

	result.Log();
}

private void ApplyFilter(FilteredQueryDescriptor<ApprenticeshipSummary> filtereQuery)
{
	
}

private ElasticClient GetElasticSearchClient()
{
	var node = new Uri("http://10.1.2.10:9200/");

	var settings = new ConnectionSettings(node);

	return new ElasticClient(settings);
}

public class ApprenticeshipSummary
{
	public string Title { get; set; }
	public string SubCategoryCode { get; set; }
}