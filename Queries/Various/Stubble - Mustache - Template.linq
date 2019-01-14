<Query Kind="Program">
  <NuGetReference>Stubble.Core</NuGetReference>
  <Namespace>Stubble.Core.Builders</Namespace>
</Query>

string emailTemplate = @"
Dear {{Person.Name}},

{{#SearchResults}}
Top 5 result(s) matching your search:

Apprenticeship level: {{Level}}
{{#DisabilityConfidentOnly}}Disability confident vacancies only:: {{DisabilityConfidentOnly}}{{/DisabilityConfidentOnly}}

{{#Results}}
{{Title}}    
^{{Description}}
---
{{/Results}}
{{/SearchResults}}
";


void Main()
{
    var stubble = new StubbleBuilder().Build();
    
    stubble.Render(emailTemplate, GetData()).Dump();
}


public class Candidate
{
    public string FirstName { get; set; }
    public string SearchUrl { get; set; }
    public List<Search> SearchResults { get; set; }
    public Person Person { get; set; }
}

public class Search
{
    public string Level { get; set; }
    public bool DisabilityConfidentOnly { get; set; }
    public IEnumerable<Vacancy> Results { get; set; }
}

public class Vacancy
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
        Person = new Person{ Name = "Deven" },
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
                DisabilityConfidentOnly = false,
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
