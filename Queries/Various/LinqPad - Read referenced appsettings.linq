<Query Kind="Program">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
  </Connection>
  <Reference Relative="..\Work Related\appsettings.json">C:\Deven\Git\LinqPad\Queries\Work Related\appsettings.json</Reference>
  <Reference Relative="..\Tests\CommitmentsClientApiConfiguration.json">C:\Deven\Git\LinqPad\Queries\Tests\CommitmentsClientApiConfiguration.json</Reference>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

private static readonly IConfigurationRoot configuration =
    new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("CommitmentsClientApiConfiguration.json", true, true)
        .AddEnvironmentVariables().Build();

void Main()
{
    configuration.GetValue<string>("gello").Dump();
}

// Define other methods, classes and namespaces here
