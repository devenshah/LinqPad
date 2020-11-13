<Query Kind="Program">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
  </Connection>
  <Reference Relative="CommitmentsClientApiConfiguration.json">C:\Deven\Git\LinqPad\Queries\Tests\CommitmentsClientApiConfiguration.json</Reference>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    MyExtensions.GetConfiguration<CommitmentsClientApiConfiguration>().Dump();
}

public class CommitmentsClientApiConfiguration
{
    public string ApiBaseUrl { get; set; }

    public string Tenant { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string IdentifierUri { get; set; }
}
