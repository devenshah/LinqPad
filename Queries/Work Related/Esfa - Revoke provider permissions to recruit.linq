<Query Kind="Program">
  <NuGetReference Version="1.2.4">SFA.DAS.Http</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>SFA.DAS.Http</Namespace>
  <Namespace>SFA.DAS.Http.MessageHandlers</Namespace>
  <Namespace>SFA.DAS.Http.TokenGenerators</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="Tenant" value="citizenazuresfabisgov.onmicrosoft.com" />
          <add key="ClientId" value="85f054e9-df35-4646-abb6-7a2efb4a8d48" />
          <add key="ClientSecret" value="qqCuJGX7lUEODBI/qZS6aeMoZ9J5naEKq2Kl+mQnSpA=" />
          <add key="IdentifierUri" value="https://citizenazuresfabisgov.onmicrosoft.com/das-provider-relationships-api" />
          <add key="ApiBaseUrl" value="https://das-test-prelapi-as.azurewebsites.net/" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

ProviderRelationshipApiConfiguration _config;
HttpClient _httpClient;
void Main()
{
    _config = GetConfig();
    _httpClient = CreateHttpClient(_config);

    PostPermissionRevoke();
}

void PostPermissionRevoke()
{
    var data = new RevokePermissionsRequest(10004736, "X74Y8D", new[] { Operation.Recruitment});
    var serialisedData = JsonConvert.SerializeObject(data);
    serialisedData.Dump();
    var stringContent = new System.Net.Http.StringContent(serialisedData, Encoding.UTF8, "application/json");
    var uri = new Uri(new Uri(_config.ApiBaseUrl), "/permissions/revoke");
    uri.Dump();

    var response = _httpClient.PostAsync(uri, stringContent).Result;

    response.Dump();
}

public class RevokePermissionsRequest
{
    public long Ukprn { get; set; }
    public string AccountLegalEntityPublicHashedId { get; set; }
    public Operation[] OperationsToRevoke { get; set; }

    public RevokePermissionsRequest() { }

    public RevokePermissionsRequest(long ukprn, string accountLegalEntityPublicHashedId, Operation[] operationsToRevoke)
        : this()
    {
        Ukprn = ukprn;
        AccountLegalEntityPublicHashedId = accountLegalEntityPublicHashedId;
        OperationsToRevoke = operationsToRevoke;
    }
}

public enum Operation : short
{
    CreateCohort = 0,
    Recruitment = 1
}

public ProviderRelationshipApiConfiguration GetConfig()
{
    return new ProviderRelationshipApiConfiguration
    {
        Tenant = ConfigurationManager.AppSettings["Tenant"],
        ClientId = ConfigurationManager.AppSettings["ClientId"],
        ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
        IdentifierUri = ConfigurationManager.AppSettings["IdentifierUri"],
        ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]
    };
}

private HttpClient CreateHttpClient(ProviderRelationshipApiConfiguration configuration)
{
    var httpClient = new HttpClientBuilder()
        .WithDefaultHeaders()
        .WithBearerAuthorisationHeader(new AzureADBearerTokenGenerator(configuration))
        .Build();

    httpClient.BaseAddress = new Uri(configuration.ApiBaseUrl);

    return httpClient;
}

public class ProviderRelationshipApiConfiguration : IAzureADClientConfiguration
{
    public string ApiBaseUrl { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string IdentifierUri { get; set; }
    public string Tenant { get; set; }
}