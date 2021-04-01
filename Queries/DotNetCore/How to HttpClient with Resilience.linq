<Query Kind="Program">
  <Reference Relative="..\Work Related\appsettings.json">C:\Deven\Git\LinqPad\Queries\Work Related\appsettings.json</Reference>
  <NuGetReference>Microsoft.Extensions.Http.Polly</NuGetReference>
  <NuGetReference>Polly</NuGetReference>
  <NuGetReference>Polly.Extensions.Http</NuGetReference>
  <NuGetReference>System.Net.Http.Json</NuGetReference>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Polly</Namespace>
  <Namespace>Polly.Extensions.Http</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

//https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-circuit-breaker-pattern
async Task Main()
{
    var appSettings = MyExtensions.GetAppSettings();
    var baseAddress = "https://www.instituteforapprenticeships.org/api/";
    var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        // Register a class which will be injected with a HttpClient
        services
            .AddHttpClient<StandardsService>("StandardsService", c => c.BaseAddress = new Uri(baseAddress))
            .SetHandlerLifetime(TimeSpan.FromMinutes(1))
            .AddPolicyHandler(GetRetryPolicy());
            //.AddPolicyHandler(GetCircuitBreakerPolicy());
    }).Build();

    var svc = builder.Services.GetService<StandardsService>();
    var allStandards = await svc.GetAll();
    Console.WriteLine($"Total Standards: {allStandards.Count()}");
    
    //with out tolist the tasks get executed twice
    var tasks = allStandards.Select(s => svc.Get(s.ReferenceNumber)).ToList(); 
    
    await Task.WhenAll(tasks);
    tasks.Select(t => t.Result).Count().Dump();
}

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}
static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}

public class StandardsService
{
    private readonly HttpClient _client; 
    //HttpClient dependency is required 
    public StandardsService(HttpClient httpClient)
    {
        _client = httpClient;
    }
    
    public async Task<IEnumerable<Standard>> GetAll()
    {
        var response = await _client.GetAsync("apprenticeshipstandards");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Standard>>();
    }
    
    public Task<Standard> Get(string refNum)
    {
        return _client.GetFromJsonAsync<Standard>($"apprenticeshipstandards/{refNum}");
    }
}

public class Standard
{
    public int LarsCode { get; set; }
    public string ReferenceNumber { get; set; }
    public string Version { get; set; }
    public string Title { get; set; }
}

