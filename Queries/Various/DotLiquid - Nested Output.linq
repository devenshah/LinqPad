<Query Kind="Program">
  <NuGetReference>DotLiquid</NuGetReference>
  <Namespace>System.Security.Policy</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>DotLiquid</Namespace>
</Query>

string emailTemplate = @"
{% for search in searchResults -%}
Top 5 result(s) matching your search:

Apprenticeship level: {{search.level}}

{% for result in search.results -%}
{{ result.Title }}    
^{{ result.Description }}
{% endfor -%}
{% endfor -%}
";


void Main()
{
    var data = GetData();
    var template = Template.Parse(emailTemplate);
    template.Render(DotLiquid.Hash.FromAnonymousObject(data)).Dump();
}

public class Candidate : Drop
{
    public string FirstName { get; set; }
    public string SearchUrl { get; set; }
    public List<Search> SearchResults { get; set; }
}

public class Search : Drop
{
    public string Level { get; set; }
    public bool DisabilityConfidentOnly { get; set; }
    public IEnumerable<Vacancy> Results { get; set; }
}

public class Vacancy : Drop
{
    public string Title { get; set; }
    public string EmployerName { get; set; }
    public string Description { get; set; }
    public int NumberOfPositions { get; set; }
    public decimal Distance { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime StartDate { get; set; }
}

private Candidate GetData()
{
    return new Candidate
    {
        SearchResults = new List<Search> {
            new Search {
                DisabilityConfidentOnly = true,
                Level = "Higher",
                Results = new List<Vacancy>{
                    new Vacancy{
                        Title  = "Test vacancy 1",
                        EmployerName = "Employer 1",
                        Description = "This XSL Transformer (XSLT) let's you transform an XML file using an XSL (EXtensible Stylesheet Language) file. You can also chose your indentation level if the result is an XML file.",
                        NumberOfPositions = 1,
                        Distance = 4.56m,
                        ClosingDate = DateTime.Now.AddDays(1),
                        StartDate = DateTime.Now.AddMonths(1)
                    },
                    new Vacancy{
                        Title  = "Test vacancy 2",
                        EmployerName = "Employer 2",
                        Description = "The XSL Transformer fully supports XML namespaces, but the declarations MUST be explicit and MUST be on the root XML element of both your XML file and your XSL file. See the XSLT Examples section for details.",
                        NumberOfPositions = 2,
                        Distance = 7.89m,
                        ClosingDate = DateTime.Now.AddDays(2),
                        StartDate = DateTime.Now.AddMonths(2)
                    },
                }
            },
            new Search{
                DisabilityConfidentOnly = true,
                Level = "Intermediate",
                Results = new List<Vacancy>{
                    new Vacancy{
                        Title  = "Test vacancy 3",
                        EmployerName = "Employer 3",
                        Description = "This XSL Transformer (XSLT) let's you transform an XML file using an XSL (EXtensible Stylesheet Language) file. You can also chose your indentation level if the result is an XML file.",
                        NumberOfPositions = 3,
                        Distance = 45.6m,
                        ClosingDate = DateTime.Now.AddDays(3),
                        StartDate = DateTime.Now.AddMonths(1)
                    },
                    new Vacancy{
                        Title  = "Test vacancy 4",
                        EmployerName = "Employer 4",
                        Description = "The XSL Transformer fully supports XML namespaces, but the declarations MUST be explicit and MUST be on the root XML element of both your XML file and your XSL file. See the XSLT Examples section for details.",
                        NumberOfPositions = 4,
                        Distance = 78.9m,
                        ClosingDate = DateTime.Now.AddDays(4),
                        StartDate = DateTime.Now.AddMonths(2)
                    },
                }
            },
        }
    };
}






public class VacancySummary
{
    public string Title { get; set; }
    public string EmployerName { get; set; }
    public string MyProperty { get; set; }
}
//
//public static class Extension
//{
//    public static Url SearchUrl(this SavedSearch savedSearch)
//    {
//        var propertyDictionary = savedSearch.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToDictionary
//        (
//            propInfo => propInfo.Name,
//            propInfo => propInfo.GetValue(savedSearch, null)
//        );
//
//        propertyDictionary["SearchAction"] = "Search";
//        propertyDictionary["LocationType"] = "NonNational";
//
//        var urlSb = new StringBuilder("/apprenticeships");
//        urlSb.Append("?");
//
//        var excludedKeys = new[]
//        {
//                "CandidateId", "AlertsEnabled", "CategoryFullName", "SubCategories", "SubCategoriesFullName",
//                "LastResultsHash", "DateProcessed"
//            };
//
//        foreach (var kvp in propertyDictionary.Where(kvp => !excludedKeys.Contains(kvp.Key)))
//        {
//            if (kvp.Value != null && !string.IsNullOrEmpty(kvp.Value.ToString()))
//            {
//                urlSb.AppendFormat("{0}={1}&", kvp.Key, WebUtility.UrlEncode(kvp.Value.ToString()));
//            }
//        }
//
//        urlSb.Remove(urlSb.Length - 1, 1);
//
//        urlSb.Append(savedSearch.SubCategories.ToQueryString("SubCategories"));
//
//        return new Url(urlSb.ToString());
//    }
//    
//    public static string ToQueryString(this string[] collection, string parameterName)
//    {
//        if (string.IsNullOrWhiteSpace(parameterName))
//        {
//            throw new ArgumentNullException("parameterName");
//        }
//
//        if (collection == null || collection.Length == 0)
//            return string.Empty;
//
//        string queryStringSeparator = string.Format("&{0}=", parameterName);
//
//        string queryString = string.Join(queryStringSeparator, collection);
//
//        return queryStringSeparator + queryString;
//    }
//
//    public static string FormatSearchUrl(this SavedSearchAlert savedSearchAlert, string siteDomainName)
//    {
//        return $"https://{siteDomainName}/{savedSearchAlert.Parameters.SearchUrl().Value}";
//    }
//}

public class SavedSearch
{
    public SavedSearch()
    {
        AlertsEnabled = true;
        ApprenticeshipLevel = "All";
        SearchField = "All";
        DisplaySubCategory = true;
        DisplayDescription = true;
        DisplayDistance = true;
        DisplayClosingDate = true;
        DisplayStartDate = true;
    }

    public Guid CandidateId { get; set; }

    public bool AlertsEnabled { get; set; }

    public ApprenticeshipSearchMode SearchMode { get; set; }

    public string Location { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public int Hash { get; set; }

    public string Keywords { get; set; }

    public int WithinDistance { get; set; }

    public string ApprenticeshipLevel { get; set; }

    public string Category { get; set; }

    public string CategoryFullName { get; set; }

    public string[] SubCategories { get; set; }

    public string SubCategoriesFullName { get; set; }

    public string SearchField { get; set; }

    public string LastResultsHash { get; set; }

    public DateTime? DateProcessed { get; set; }

    public bool DisplaySubCategory { get; set; }

    public bool DisplayDescription { get; set; }

    public bool DisplayDistance { get; set; }

    public bool DisplayClosingDate { get; set; }

    public bool DisplayStartDate { get; set; }

    public bool DisplayApprenticeshipLevel { get; set; }

    public bool DisplayWage { get; set; }

    public bool DisabilityConfidentOnly { get; set; }
}

public class SavedSearchAlert
{
    public SavedSearch Parameters { get; set; }

    public IList<VacancySummary> Results { get; set; }

    public Guid? BatchId { get; set; }

    public DateTime? SentDateTime { get; set; }
}

public enum ApprenticeshipSearchMode
{
    Keyword,
    Category,
    SavedSearches
}
