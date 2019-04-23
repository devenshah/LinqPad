<Query Kind="Program">
  <NuGetReference Version="1.2.4">SFA.DAS.Http</NuGetReference>
  <Namespace>SFA.DAS.Http</Namespace>
  <Namespace>SFA.DAS.Http.MessageHandlers</Namespace>
  <Namespace>SFA.DAS.Http.TokenGenerators</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
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

void Main()
{
    //ConfigurationManager.AppSettings.Dump();
    var config = GetConfig();
    var httpClient = CreateHttpClient(config);

    var queryData = new []{ new KeyValuePair<string, string>("Ukprn", "10001191"), new KeyValuePair<string, string>( "Operation", "Recruitment") };
    
    var uri = new Uri(AddQueryString($"{config.ApiBaseUrl}/accountproviderlegalentities", queryData));

    var response = httpClient.GetAsync(uri).Result;
    
    var content = response.Content.ReadAsStringAsync().Result;
    JsonConvert.DeserializeObject<ProviderPermissions>(content).AccountProviderLegalEntities.Dump();

}

class ProviderPermissions
{
    public IEnumerable<LegalEntityDto> AccountProviderLegalEntities { get; set; }
}

class LegalEntityDto
{
    public long AccountId { get; set; }
    public string AccountPublicHashedId { get; set; }
    public string AccountName { get; set; }
    public long AccountLegalEntityId { get; set; }
    public string AccountLegalEntityPublicHashedId { get; set; }
    public string AccountLegalEntityName { get; set; }
    public long AccountProviderId { get; set; }
}

private static string AddQueryString(
    string uri,
    IEnumerable<KeyValuePair<string, string>> queryString)
{
    if (uri == null)
    {
        throw new ArgumentNullException(nameof(uri));
    }

    if (queryString == null)
    {
        throw new ArgumentNullException(nameof(queryString));
    }

    var anchorIndex = uri.IndexOf('#');
    var uriToBeAppended = uri;
    var anchorText = "";
    // If there is an anchor, then the query string must be inserted before its first occurence.
    if (anchorIndex != -1)
    {
        anchorText = uri.Substring(anchorIndex);
        uriToBeAppended = uri.Substring(0, anchorIndex);
    }

    var queryIndex = uriToBeAppended.IndexOf('?');
    var hasQuery = queryIndex != -1;

    var sb = new StringBuilder();
    sb.Append(uriToBeAppended);
    foreach (var parameter in queryString)
    {
        sb.Append(hasQuery ? '&' : '?');
        sb.Append(WebUtility.UrlEncode(parameter.Key));
        sb.Append('=');
        sb.Append(WebUtility.UrlEncode(parameter.Value));
        hasQuery = true;
    }

    sb.Append(anchorText);
    return sb.ToString();
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

public class ProviderRelationshipApiConfiguration : IAzureADClientConfiguration
{
    public string ApiBaseUrl { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string IdentifierUri { get; set; }
    public string Tenant { get; set; }
}