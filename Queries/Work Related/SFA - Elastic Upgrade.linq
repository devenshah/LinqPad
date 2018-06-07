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
private string indexName = "apprenticeship";

void Main()
{
    var myUri = new Uri("http://192.168.99.100:9200/");
    var connectionPool = new SingleNodeConnectionPool(myUri);
    var connection = new HttpConnection();
    var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()));

    var Nodesettings = new ConnectionSettings(connectionPool, connection, serializers)
        .DefaultIndex("people")
        .EnableHttpCompression()
        .InferMappingFor<ApprenticeshipSummary>(m => m.IndexName(indexName))
        .DefaultFieldNameInferrer(p => p.ToLowerInvariant())
        .BasicAuthentication("elastic", "changeme");

    client = new ElasticClient(Nodesettings);
    
    CreateIndex();

    for(var i = 0; i < 10; i++) AddToApprenticeshipIndex();
    
    Thread.Sleep(500);
    
    client.Search<ApprenticeshipSummary>().Documents.Log();
}

private void CreateIndex()
{
    if(client.IndexExists(indexName).Exists)
        client.DeleteIndex(indexName);

    var indexSettings = new IndexSettings();

    var snowballTokenFilter = new SnowballTokenFilter { Language = SnowballLanguage.English };

    var synonym = new SynonymTokenFilter() { Synonyms = new[] {"this","that"}  };
    var baseStopwords = new[] { "and", "to" };
    var extendedStopwords = baseStopwords.Concat(new[] {"here", "there"});
    var stopwordsBaseFilter = new StopTokenFilter { StopWords = baseStopwords };
    var stopwordsExtendedFilter = new StopTokenFilter { StopWords = extendedStopwords.ToList() };

    var snowballStopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsBaseFilter", "synonym", "snowball" } };
    var snowballStopwordsExtended = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsExtendedFilter", "synonym", "snowball" } };
    var stopwordsBase = new CustomAnalyzer { Tokenizer = "standard", Filter = new[] { "standard", "lowercase", "stopwordsBaseFilter", "synonym" } };

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

    var req = new SearchRequest<ApprenticeshipSummary>(){
      Query = new MatchPhraseQuery{
       Field = Infer.Field<ApprenticeshipSummary>(f => f.Title),
       Query = "37 Apprenticeship"
      }  
    };
    
    var response = client.Search<ApprenticeshipSummary>(req);
    response.Documents.Log();
}

private void AddToApprenticeshipIndex()
{
    var location = fixture.Build<GeoPoint>()
        .With(gp => gp.lat, GetRandomLatitude())
        .With(gp => gp.lon, 2)
        .Create();
    var person = fixture.Build<ApprenticeshipSummary>()
        .With(a => a.Location, location)
        .Create();
    var title = (person.Id % 2) == 1 ? "Apprenticeship" : "Traineeship";

    person.Title = $"{person.Id} {title}";

    client.Index(person).Log();
}

private double GetRandomLatitude()
{
    var min = -90d;
    var max = 90d;
    var random = new Random();
    return random.NextDouble() * (max - min) + min;
}

private double GetRandomLongitude()
{
    var min = -180d;
    var max = 180d;
    var random = new Random();
    return random.NextDouble() * (max - min) + min;
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