<Query Kind="Program">
  <NuGetReference>NEST</NuGetReference>
  <Namespace>Nest</Namespace>
</Query>

ElasticClient client = null;
void Main()
{
    InitializeClient();

    var results = client.Search<Person>(s => s
        .From(0)
        .Size(10)
        .Query(q => q
                .Match(m => m
                    .Field(f => f.Name)
                    .Query("deven")
            )
        )
    );
    
    results.Log();
}

private void AddWorkExperience()
{
    var workEx = new WorkExperience{
        UserName = "Deven",
        CompanyName = "Indiwiz",
        JoinedOn = new DateTime(2013, 10, 1)
    };
    
    var indexResponse = client.IndexDocument(workEx);
    indexResponse.Log();
}

public class WorkExperience
{
    public string UserName { get; set; }
    public string CompanyName { get; set; }
    public DateTime JoinedOn { get; set; }
    public DateTime? LeftOn { get; set; }
}

private void AddPersonToIndex()
{
    var person = new Person
    {
        Name = "Deven",
        Gender = Gender.Male,
        DOB = new DateTime(1990, 1, 1)
    };

    var indexResponse = client.IndexDocument(person);

    if (!indexResponse.ApiCall.Success) indexResponse.Log();

}

private void InitializeClient()
{
    var settings = 
        new ConnectionSettings(new Uri("http://localhost:32769"))
            .BasicAuthentication("elastic", "changeme")
            .DefaultIndex("people");

    client = new ElasticClient(settings);
}
