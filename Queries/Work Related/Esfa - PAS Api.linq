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
          <add key="ClientId" value="16cb6309-e173-41e4-97db-54cc1d02735e" />
          <add key="ClientSecret" value="xrZ9qe1+6/dv+z0HxM.b.ztnt3gMpF=o" />
          <add key="IdentifierUri" value="https://citizenazuresfabisgov.onmicrosoft.com/prap-api" />
          <add key="ApiBaseUrl" value="https://test-provideraccounts.apprenticeships.education.gov.uk//" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

void Main()
{
    long ukprn = 10001191;
    var config = GetConfig();
    using (var httpClient = CreateHttpClient(config))
    {
        var requestUri = Path.Combine(config.ApiBaseUrl, $"api/account/{ukprn}/agreement");
        var response = httpClient.GetStringAsync(requestUri).Result;

        var agreement = JsonConvert.DeserializeObject<Agreement>(response);

        agreement.Dump();
    }
}

public class Agreement
{
    public string Status { get; set; }
}

public PasAccountApiConfiguration GetConfig()
{
    return new PasAccountApiConfiguration
    {
        Tenant = ConfigurationManager.AppSettings["Tenant"],
        ClientId = ConfigurationManager.AppSettings["ClientId"],
        ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
        IdentifierUri = ConfigurationManager.AppSettings["IdentifierUri"],
        ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]
    };
}

private HttpClient CreateHttpClient(PasAccountApiConfiguration configuration)
{
    var httpClient = new HttpClientBuilder()
        .WithDefaultHeaders()
        .WithBearerAuthorisationHeader(new AzureADBearerTokenGenerator(configuration))
        .Build();

    httpClient.BaseAddress = new Uri(configuration.ApiBaseUrl);

    return httpClient;
}

public class PasAccountApiConfiguration : IAzureADClientConfiguration
{
    public string ApiBaseUrl { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string IdentifierUri { get; set; }
    public string Tenant { get; set; }
}