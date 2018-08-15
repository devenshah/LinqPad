<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Bson.Serialization.Attributes</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>System.Security.Authentication</Namespace>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
</Query>

void Main()
{
    using (var textReader = new StreamReader(File.Open(@"C:\SFA\RAA\Candidate Traineeship.csv", FileMode.Open)))
    {
        var csv = new CsvReader(textReader, new Configuration() { MissingFieldFound = null, HeaderValidated = null });
        var records = csv.GetRecords<MyClass>();
        records.Dump();
    }
}

public class MyClass
{       
    public string CandidateId { get; set; }
    public string VacancyId { get; set; }
    public string AttemptedOn { get; set; }
    public Candidate MyProperty { get; set; }
}

public class Candidate
{
    public Guid Id { get; set; }
}
