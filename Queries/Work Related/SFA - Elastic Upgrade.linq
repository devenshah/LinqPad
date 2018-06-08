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
        .InferMappingFor<ApprenticeshipSummary>(m => m.IndexName(aliasName))
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic", "changeme");

    client = new ElasticClient(Nodesettings);
    
    var indexName = $"{aliasName}_{DateTime.Now.ToString("yyyyMMdd-HHmm")}";

    CreateIndexV2(indexName);
    
    if (IsIndexCorrectlyCreated(indexName)) SwapIndex(indexName);
    
    AddToApprenticeshipIndex();

    GetAllVacancyIds();

    
    
    //client.Search<ApprenticeshipSummary>().Documents.Log();
}

private void CreateIndex()
{
    var snowballTokenFilter = new SnowballTokenFilter { Language = SnowballLanguage.English };
    var synonym = new SynonymTokenFilter() { Synonyms = new[] {"this","that"}  };
    var baseStopwords = new[] { "and", "to" };
    var extendedStopwords = baseStopwords.Concat(new[] {"here", "there"});
    var stopwordsBaseFilter = new StopTokenFilter { StopWords = baseStopwords };
    var stopwordsExtendedFilter = new StopTokenFilter { StopWords = extendedStopwords.ToList() };

    var snowballStopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsBaseFilter", "synonym", "snowball" } };
    var snowballStopwordsExtended = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsExtendedFilter", "synonym", "snowball" } };
    var stopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsBaseFilter", "synonym" } };

    var indexName = $"{aliasName}_{DateTime.Now.ToString("yyyyMMdd-HHmm")}";
    
    client.CreateIndex(indexName, c => c
        .Settings(s => s
            .NumberOfShards(1)
            .NumberOfReplicas(1)
            .Analysis(a => a
                .TokenFilters(t => t
                    .Stop(nameof(stopwordsBaseFilter), (x) => stopwordsBaseFilter)
                    .Stop(nameof(stopwordsExtendedFilter), (x) => stopwordsExtendedFilter)
                    .Snowball("snowball", (x) => snowballTokenFilter)
                    .Synonym(nameof(synonym), (x) => synonym)) 
                .Analyzers(an => an
                    .Custom(nameof(snowballStopwordsBase), (x) => snowballStopwordsBase )
                    .Custom(nameof(snowballStopwordsExtended), (x) => snowballStopwordsExtended)
                    .Custom(nameof(stopwordsBase), (x) => stopwordsBase)
                )
            )
        )            
        .Mappings(ms => ms.Map<ApprenticeshipSummary>(m => m.AutoMap()))).Log();
}

private void CreateIndexV2(string indexName)
{
    if (client.IndexExists(indexName).Exists) client.DeleteIndex(indexName);
    
    var searchConfiguration = new SearchConfiguration();

    var tokenFilters = new TokenFiltersDescriptor();

    var synonymFilter = new SynonymTokenFilter() { Synonyms = searchConfiguration.Synonyms };
    tokenFilters.Synonym(nameof(synonymFilter), x => synonymFilter);

    var snowballFilter = new SnowballTokenFilter { Language = SnowballLanguage.English };
    tokenFilters.Snowball(nameof(snowballFilter), (x) => snowballFilter);
    
    var stopwordsBaseFilter = new StopTokenFilter { StopWords = searchConfiguration.StopwordsBase.ToArray() };
    tokenFilters.Stop(nameof(stopwordsBaseFilter), (x) => stopwordsBaseFilter);

    var stopwordsExtendedFilter = new StopTokenFilter { StopWords = searchConfiguration.StopwordsExtended.ToArray() };
    tokenFilters.Stop(nameof(stopwordsExtendedFilter), (x) => stopwordsExtendedFilter);

    var analyzers = new AnalyzersDescriptor();
    
    var basicFilters = new[] { "standard", "lowercase", nameof(synonymFilter), nameof(stopwordsBaseFilter) };

    var snowballStopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = basicFilters.Append(nameof(snowballFilter))};
    analyzers.Custom(nameof(snowballStopwordsBase), (x) => snowballStopwordsBase);
    
    var snowballStopwordsExtended = new CustomAnalyzer { Tokenizer = "standard", Filter = basicFilters.Concat(new[] { nameof(stopwordsExtendedFilter), nameof(snowballFilter) })};
    analyzers.Custom(nameof(snowballStopwordsExtended), (x) => snowballStopwordsExtended);
    
    var stopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = basicFilters };
    analyzers.Custom(nameof(stopwordsBase), (x) => stopwordsBase);
    
    client.CreateIndex(indexName, c => c
        .Settings(s => s
            .Analysis(a => a
                .TokenFilters(t => tokenFilters)
                .Analyzers(an => analyzers)
            )
        )
        .Mappings(ms => ms.Map<ApprenticeshipSummary>(m => m.AutoMap()))).Log();
    
}

private bool IsIndexCorrectlyCreated(string indexName)
{
    const string locationPropertyName = "location";
    const string locationFieldTypeName = "geo_point";

    var indexMapping = client.GetMapping<ApprenticeshipSummary>(p => p.Index(indexName));

    var actualMappings = indexMapping.Mappings[indexName].FirstOrDefault();

    var key = actualMappings.Value.Properties.Keys.Single(k => k.Name == locationPropertyName);

    var property = actualMappings.Value.Properties[key];

    var result = property?.Type.Name == locationFieldTypeName;

    $"Is Index valid: {result}".Log();
    return result;
}

public string SwapIndex(string newIndexName)
{       
    var existingIndexesOnAlias = client.GetIndicesPointingToAlias(aliasName);
    var aliasRequest = new BulkAliasRequest { Actions = new List<IAliasAction>() };

    foreach (var existingIndexOnAlias in existingIndexesOnAlias)
    {
        aliasRequest.Actions.Add(new AliasRemoveAction { Remove = new AliasRemoveOperation { Alias = aliasName, Index = existingIndexOnAlias } });
    }

    aliasRequest.Actions.Add(new AliasAddAction { Add = new AliasAddOperation { Alias = aliasName, Index = newIndexName } });
    client.Alias(aliasRequest).Log();

    return newIndexName;
}

private void GetAllVacancyIds()
{
    const string ScrollTimeout = "5s";
    var scanResults = client.Search<ApprenticeshipSummary>(search => search
                .Index(aliasName)
                .Type("apprenticeship")
                .From(0)
                .Size(10)
                .MatchAll()
                .Scroll(ScrollTimeout));

    var vacancies = new List<int>();

    var scrollRequest = new ScrollRequest(scanResults.ScrollId, ScrollTimeout);
    var scrollCount = 0;
    while (scanResults.Documents.Any())
    {
        scrollCount++;

        vacancies.AddRange(scanResults.Documents.Select(each => each.Id));

        scanResults = client.Scroll<ApprenticeshipSummary>(scrollRequest);
    }

    //scrollCount.Log();
    vacancies.Log();
}

private void AddToApprenticeshipIndex()
{    
    var count = fixture.Create<byte>();
    $"Created {count} documents".Log();
    
    var apprenticeships = fixture.Build<ApprenticeshipSummary>()
        .With(a => a.Location, new GeoPoint())
        .Without(a => a.Title)        
        .Do(a => {
            Func<int, string> GetTitle = i => (i % 2) == 1 ? "Apprenticeship" : "Traineeship";
            a.Title = a.Id + GetTitle(a.Id);           
        })
        .CreateMany(count);
        
    apprenticeships.ToList().ForEach(a => client.Index(a));
    
    Thread.Sleep(1000);
}

[ElasticsearchType(Name = "apprenticeship")]
public class ApprenticeshipSummary 
{
    public int Id { get; set; }

    [Text(Analyzer = "snowballStopwordsBase")]
    public string Title { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ClosingDate { get; set; }

    [Date]
    public DateTime PostedDate { get; set; }

    [Text(Analyzer = "stopwordsBase")]
    public string EmployerName { get; set; }

    [Text(Analyzer = "stopwordsBase")]
    public string ProviderName { get; set; }

    [Text(Analyzer = "snowballStopwordsExtended")]
    public string Description { get; set; }

    public int NumberOfPositions { get; set; }

    public bool IsPositiveAboutDisability { get; set; }

    public bool IsEmployerAnonymous { get; set; }

    public string AnonymousEmployerName { get; set; }

    [Keyword]
    public VacancyLocationType VacancyLocationType { get; set; }

    [GeoPoint]
    public GeoPoint Location { get; set; }

    [Text]
    public ApprenticeshipLevel ApprenticeshipLevel { get; set; }

    public string VacancyReference { get; set; }

    public string Category { get; set; }

    public string CategoryCode { get; set; }

    public string SubCategory { get; set; }

    public string SubCategoryCode { get; set; }

    public string WorkingWeek { get; set; }

    #region Flattened Wage objetc

    public int WageType { get; set; }

    public decimal? WageAmount { get; set; }

    public decimal? WageAmountLowerBound { get; set; }

    public decimal? WageAmountUpperBound { get; set; }

    public string WageText { get; set; }

    public int WageUnit { get; set; }

    public decimal? HoursPerWeek { get; set; }

    #endregion

    public bool IsDisabilityConfident { get; set; }
}

public enum VacancyLocationType
{
    Unknown = 0,

    NonNational,

    National
}

public class GeoPoint
{
    public GeoPoint()
    {
        Func<double, double, double> GetRandomDoubleInRange
            = (min, max) => new Random().NextDouble() * (max - min) + min;
        
        lat = GetRandomDoubleInRange(-90, 90);
        lon = GetRandomDoubleInRange(-180, 180);
    }
    public double lon { get; set; }
    public double lat { get; set; }
}

public enum ApprenticeshipLevel
{
    Unknown = 0,
    Intermediate,
    Advanced,
    Higher,
    Degree,
    Foundation,
    Masters
}

public class SearchConfiguration
{
    public IEnumerable<string> Synonyms => new[] {
        "childcare, child-care, child care",
        "healthcare, health-care, health care",
        "admin, administration"
    };

    public IEnumerable<string> StopwordsBase => new[] {
        "apprenticeships",
        "apprenticeship",
        "traineeship",
        "traineeships",
        "apprentice",
        "trainee",
        "all",
        "any"
    };

    public IEnumerable<string> StopwordsExtended => new[]{
      "a",
      "an",
      "and",
      "are",
      "as",
      "at",
      "be",
      "but",
      "by",
      "for",
      "if",
      "in",
      "into",
      "is",
      "it",
      "no",
      "not",
      "of",
      "on",
      "or",
      "such",
      "that",
      "the",
      "their",
      "then",
      "there",
      "these",
      "they",
      "this",
      "to",
      "was",
      "will",
      "with"
    };
}


private void TermQuery()
{
    var request = new SearchRequest<ApprenticeshipSummary>
    {
        Query = new TermQuery
        {
            Field = "title",
            Value = "traineeship"
        }
    };

    client.Search<ApprenticeshipSummary>(request).Documents.Log();
}

private void MatchQuery()
{
    //    var response = client.Search<ApprenticeshipSummary>(s => s
    //        .Index("apprenticeship")
    //        .Query(q => q
    //            .MatchPhrase(m => m
    //                .Field(f => f.Title)
    //                .Query("97 Apprenticeship")
    //            )
    //        )
    //    );

    var req = new SearchRequest<ApprenticeshipSummary>()
    {
        Query = new MatchPhraseQuery
        {
            Field = Infer.Field<ApprenticeshipSummary>(f => f.Title),
            Query = "37 Apprenticeship"
        }
    };

    var response = client.Search<ApprenticeshipSummary>(req);
    response.Documents.Log();
}