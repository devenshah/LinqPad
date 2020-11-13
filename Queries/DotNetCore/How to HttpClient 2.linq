<Query Kind="Program">
  <Reference Relative="..\Work Related\appsettings.json">C:\Deven\Git\LinqPad\Queries\Work Related\appsettings.json</Reference>
  <NuGetReference>System.Net.Http.Json</NuGetReference>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http.Json</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    var appSettings = MyExtensions.GetAppSettings();
    var baseAddress = appSettings.GetValue<string>("core:httpClient:apiBaseAddress");
    ///https://age-of-empires-2-api.herokuapp.com/docs/#/resources/get_civilizations
    ///https://age-of-empires-2-api.herokuapp.com/api/v1
    var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        // Register a class which will be injected with a HttpClient
        services.AddHttpClient<AgeOfEmpireService>("ageofempire", c => c.BaseAddress = new Uri(baseAddress));
    }).Build();

    var svc = builder.Services.GetService<AgeOfEmpireService>();
    svc.GetAllCivilizations().Result.Dump();
}

public class GameController
{
    // Dependency injection where it is needed rather than on constructors
    public Task<CivilizationList> GetAOECivilizations([FromServices] AgeOfEmpireService client)
    {
        return client.GetAllCivilizations();
    }
}

public class AgeOfEmpireService
{
    private readonly HttpClient _client; 
    //HttpClient dependency is required 
    public AgeOfEmpireService(HttpClient httpClient)
    {
        _client = httpClient;
    }
    
    public async Task<CivilizationList> GetAllCivilizations()
    {
        var response = await _client.GetAsync("civilizations");
        return await response.Content.ReadFromJsonAsync<CivilizationList>();
    }
    
    public async Task GetCivilizations()
    {
        var result = await _client.GetFromJsonAsync<CivilizationList>("civilizations");
        result.Dump();
    }
}

public class CivilizationList
{
    public IEnumerable<Civilization> Civilizations {get; set;}
}

public class Civilization
{
    public int Id { get; set; }
    public string Name { get; set; }
}

