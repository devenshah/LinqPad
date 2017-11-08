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
	var config = new Configuration(Environment.Sit);
	var parameters = new Parameters()
	{
		//Days = 10,
		PageNumber = 1,
		PageSize = 1000,
		//Codes = new[] {"FW.539"},
		//Codes = new[] {"FW.539|FW.540"},
		//Codes = new [] {"FW.445", "STDSEC.41", "STDSEC.9", "FW.490"},
		//Title = "ds1409",
	};
	
	
	var searchParams = new SearchDescriptor<ApprenticeshipSummary>();
	searchParams.Index("sit_apprenticeships").Type("apprenticeship");
	searchParams.Skip(parameters.Skip).Take(parameters.PageSize);
	//searchParams.Query(q => q.Term(p => p.SubCategoryCode, "STDSEC.41"));
	searchParams.Query(q => 
		q.Terms(p => p.SubCategoryCode, parameters.Codes)
		&& q.Term(p => p.Title, parameters.Title)
		&& q.Range(p => p.OnField(r => r.PostedDate).GreaterOrEquals(parameters.FromDate))
	);
	searchParams.Sort(s => s.OnField(sum => sum.PostedDate).Ascending());

	var client = GetElasticSearchClient(config.BaseUri);

	var result = client.Search<ApprenticeshipSummary>(searchParams);
	result.Total.Log();
	result.Documents.Log();
}

private ElasticClient GetElasticSearchClient(Uri node)
{
	var settings = new ConnectionSettings(node);

	return new ElasticClient(settings);
}

public class Parameters
{
	public int Days { get; set; }
	public string Description { get; set; }
	public IEnumerable<string> Codes { get; set; } = new List<string>();
	public int PageSize { get; set; }
	public int PageNumber { get; set; }
	public string Title { get; set; }
	public int Skip => (PageNumber - 1) * PageSize;
	public DateTime? FromDate => Days > 0 ? DateTime.Today.AddDays(-Days) : (DateTime?)null;
}

public class ApprenticeshipSummary
{
	public int Id { get; set; }

    public string Title { get; set; }

	public DateTime StartDate { get; set; }

	public DateTime ClosingDate { get; set; }

	public DateTime PostedDate { get; set; }

	public string EmployerName { get; set; }

	public string ProviderName { get; set; }

	public string Description { get; set; }

	public int NumberOfPositions { get; set; }

	public bool IsPositiveAboutDisability { get; set; }

	public bool IsEmployerAnonymous { get; set; }

	public string AnonymousEmployerName { get; set; }

	public string Category { get; set; }

	public string CategoryCode { get; set; }

	public string SubCategory { get; set; }

	public string SubCategoryCode { get; set; }

	public string WorkingWeek { get; set; }

	public int WageType { get; set; }
	
	public string FrameworkCode { get; set; }
	
	public int? StandardId { get; set; }
}

public class Configuration
{
	public Uri BaseUri { get; set; }

	public string IndexName { get; }	
	
	public Configuration(Environment env)
	{
		switch (env)
		{
			case Environment.Sit:
				BaseUri = new Uri("http://10.1.2.10:9200/");
				IndexName = "sit_apprenticeships";
				break;
			case Environment.Prod:
				BaseUri = new Uri("http://10.0.2.10:9200/");
				IndexName = "apprenticeships";
				break;
		}
	}
}

public enum Environment
{
	Dev,
	Sit,
	Prod
}