<Query Kind="Program">
  <Reference Relative="appsettings.json">C:\Deven\Git\LinqPad\Queries\Work Related\appsettings.json</Reference>
  <NuGetReference>System.Net.Http.Json</NuGetReference>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http.Json</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        services.AddHttpClient("ifate", c => c.BaseAddress = new Uri("https://www.instituteforapprenticeships.org/api/apprenticeshipstandards"));
        services.AddTransient<ApprenticeshipStandardsService>();
    }).Build();

    var svc = builder.Services.GetService<ApprenticeshipStandardsService>();
    svc.GetAllStandards().Wait();
}

public class ApprenticeshipStandardsService
{
    private readonly HttpClient _client;
    public ApprenticeshipStandardsService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ifate");
    }

    public async Task GetAllStandards()
    {
        var response = await _client.GetAsync("");
        var result = await response.Content.ReadAsStringAsync();
        var rootElement = JsonDocument.Parse(result).RootElement;
        var documents = new Dictionary<string, string>();
        
        //for (var i = 0; i < documents.GetArrayLength(); i++)
        for (var i = 0; i < 10; i++)
        {
            var content = GetFormattedDocument(rootElement[i]);
            var standardReference = rootElement[i].GetProperty("referenceNumber").GetString();
            var version = rootElement[i].GetProperty("version").GetString();
            documents.Add($"{standardReference} - {version}", content);
        }
        
        documents.Dump();
    }

    private static string GetFormattedDocument(JsonElement element)
    {
        return JsonSerializer.Serialize(element, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
