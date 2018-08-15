<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference>Humanizer.Core</NuGetReference>
  <NuGetReference Version="5.6.2">NEST</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>Elasticsearch.Net</Namespace>
  <Namespace>Nest</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>Purify</Namespace>
  <Namespace>Humanizer</Namespace>
</Query>

private ElasticClient client;
private Fixture fixture = new Fixture();
private string aliasName = "dev_apprenticeships";

void Main()
{
    var myUri = new Uri("http://192.168.99.100:9200/");
    var connectionPool = new SingleNodeConnectionPool(myUri);
    var connection = new HttpConnection();
    var serializers = new SerializerFactory((s, v) => s.Converters.Add(new StringEnumConverter()));

    var Nodesettings = new ConnectionSettings(connectionPool, connection, serializers)
        .EnableHttpCompression()
        .InferMappingFor<ApprenticeshipSummary>(m => m.IndexName(aliasName))
        //.DefaultFieldNameInferrer(p => p.ToLowerInvariant()) //Change the way fields names are randered 
        .DisableDirectStreaming()
        .EnableDebugMode()        
        .BasicAuthentication("elastic", "changeme");

    client = new ElasticClient(Nodesettings);
    
    
    PerformSearch();
    //MatchQuery();    
}

private void PerformSearch()
{
    var parameters = new ApprenticeshipSearchParameters()
    {
        Keywords = "test",
        SortType = VacancySearchSortType.RecentlyAdded,
        SearchRadius = 4,
        Location = new Location { GeoPoint = new GeoPoint { lat = 52.069001, lon = -0.775836 }}
    };

    var searchResponse = client.Search<ApprenticeshipSummary>(s =>
    {
        s.Index(aliasName);
        //s.Type(typeof(ApprenticeshipSummary).Name);
        s.Skip((parameters.PageNumber - 1) * parameters.PageSize);
        s.Take(parameters.PageSize);
        s.Source();


        s.Query(q =>
        {
            QueryContainer query = null;

            //            var queryClause = q.Match(m => m.Field(f => f.Title).Query(parameters.Keywords));
            //            query = queryClause;
            //
            //            queryClause = q.Match(m => m.Field(f => f.Description).Query(parameters.Keywords));            
            //            query |= queryClause;
            //
            //            queryClause = q.Match(m => m.Field(f => f.EmployerName).Query(parameters.Keywords));
            //            query |= queryClause;
            //
            //            queryClause = q.Match(m => m.Field(f => f.ProviderName).Query(parameters.Keywords));
            //            query |= queryClause;
            //
            var queryClause = q.Bool(b => b.Filter(f => f.GeoDistance(vs => vs                     
                    .Location(parameters.Location.GeoPoint.lat, parameters.Location.GeoPoint.lon)
                    .Distance(parameters.SearchRadius, DistanceUnit.Miles))));
            query = queryClause;

            return query;
        });

//        s.Sort(q => q
//            .Ascending(a => a.PostedDate)
//            .GeoDistance(g =>
//            {
//                g.Field(f => f.Location)
//                .PinTo(new GeoLocation(parameters.Location.GeoPoint.lat,
//                        parameters.Location.GeoPoint.lon))
//                .Unit(DistanceUnit.Miles);
//                return g;
//            }));
        
        return s;
    });
    searchResponse.DebugInformation.Log();
    
    //searchResponse.Log();
    searchResponse.Total.Log();
}

private void MatchQuery()
{
    var req = new SearchRequest<ApprenticeshipSummary>()
    {
        Query = new MatchQuery
        {
            Field = Infer.Field<ApprenticeshipSummary>(f => f.Title),
            Query = "test"
        }
    };

    var response = client.Search<ApprenticeshipSummary>(req);
    response.Documents.Log();
    response.DebugInformation.Log();
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

    //[Keyword]
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

public class ApprenticeshipSearchParameters : VacancySearchParametersBase
{
    public string Keywords { get; set; }

    public string ApprenticeshipLevel { get; set; }

    public string CategoryCode { get; set; }

    public string[] SubCategoryCodes { get; set; }

    public VacancyLocationType VacancyLocationType { get; set; }

    public ApprenticeshipSearchField SearchField { get; set; }

    public bool DisabilityConfidentOnly { get; set; }

    public enum ApprenticeshipSearchField
    {
        All,
        JobTitle,
        Description,
        Employer,
        Provider,
        ReferenceNumber,
    }
}

public abstract class VacancySearchParametersBase : SearchParametersBase
{
    public Location Location { get; set; }

    public int SearchRadius { get; set; }

    public VacancySearchSortType SortType { get; set; }

    public string VacancyReference { get; set; }

    public override string ToString()
    {
        return string.Format(
            "Location:{0}, PageNumber:{1}, PageSize:{2}, SearchRadius:{3}, SortType:{4}, VacancyReference:{5} ExcludeVacancyIds: {6}",
            Location, PageNumber, PageSize, SearchRadius, SortType, VacancyReference,
            string.Join(",", ExcludeVacancyIds ?? new List<int>()));
    }
}

public abstract class SearchParametersBase
{
    public IEnumerable<int> ExcludeVacancyIds { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}

public class Location
{
    public string Name { get; set; }
    public GeoPoint GeoPoint { get; set; }
    public string County { get; set; }
    public string District { get; set; }
    public string DistrictCode { get; set; }
}

public enum VacancySearchSortType
{
    Relevancy,
    Distance,
    ClosingDate,
    RecentlyAdded,
}