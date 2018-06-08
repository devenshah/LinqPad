<Query Kind="Program">
  <NuGetReference>AutoFixture</NuGetReference>
  <NuGetReference Version="1.9.2">NEST</NuGetReference>
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
</Query>

void Main()
{
    //Elastic Nest 1.9.2
    const string ScrollTimeout = "5s";
    var settings = new ConnectionSettings(new Uri("http://10.0.2.10:9200"));
    var client = new ElasticClient(settings);
    client.AliasExists(c => c.Name("apprenticeships")).Exists.Log();

    var scanResults = client.Search<ApprenticeshipSummary>(search => search
                 .Index("apprenticeships")
                 .Type("apprenticeship")
                 .From(0)
                 .Size(1000)
                 .MatchAll()
                 .SearchType(SearchType.Scan)
                 .Scroll(ScrollTimeout));

    var vacancies = new List<int>();
    var scrollRequest = new ScrollRequest(scanResults.ScrollId, ScrollTimeout);
    var scrollCount = 0;

    while (true)
    {
        var results = client.Scroll<ApprenticeshipSummary>(scrollRequest);

        scrollCount++;

        if (!results.Documents.Any())
        {
            break;
        }

        vacancies.AddRange(results.Documents.Select(each => each.Id));
    }
    scrollCount.Log();
    vacancies.Count().Log();
}



[ElasticType(Name = "apprenticeship")]
public class ApprenticeshipSummary 
{
    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public int Id { get; set; }

    [ElasticProperty(Index = FieldIndexOption.Analyzed, Analyzer = "snowballStopwordsBase")]
    public string Title { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public DateTime StartDate { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public DateTime ClosingDate { get; set; }

    [ElasticProperty(Index = FieldIndexOption.Analyzed)]
    public DateTime PostedDate { get; set; }

    [ElasticProperty(Index = FieldIndexOption.Analyzed, Analyzer = "stopwordsBase")]
    public string EmployerName { get; set; }

    [ElasticProperty(Index = FieldIndexOption.Analyzed, Analyzer = "stopwordsBase")]
    public string ProviderName { get; set; }

    [ElasticProperty(Index = FieldIndexOption.Analyzed, Analyzer = "snowballStopwordsExtended")]
    public string Description { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public int NumberOfPositions { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public bool IsPositiveAboutDisability { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public bool IsEmployerAnonymous { get; set; }
    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string AnonymousEmployerName { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string VacancyReference { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string Category { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string CategoryCode { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string SubCategory { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string SubCategoryCode { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string WorkingWeek { get; set; }

    #region Flattened Wage objetc

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public int WageType { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public decimal? WageAmount { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public decimal? WageAmountLowerBound { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public decimal? WageAmountUpperBound { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public string WageText { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public int WageUnit { get; set; }

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public decimal? HoursPerWeek { get; set; }

    #endregion

    [ElasticProperty(Index = FieldIndexOption.NotAnalyzed)]
    public bool IsDisabilityConfident { get; set; }
}