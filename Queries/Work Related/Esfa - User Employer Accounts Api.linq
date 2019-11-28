<Query Kind="Program">
  <NuGetReference>SFA.DAS.Account.Api.Client</NuGetReference>
  <NuGetReference Version="1.2.4">SFA.DAS.Http</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>SFA.DAS.EAS.Account.Api.Client</Namespace>
  <Namespace>SFA.DAS.EAS.Account.Api.Types</Namespace>
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
          <add key="ClientId" value="0a25a495-140e-4f9f-807b-11e2fa115375" />
          <add key="ClientSecret" value="4P1BXocY29?._gKW:GV.2pHAYrVBz=KI" />
          <add key="IdentifierUri" value="https://citizenazuresfabisgov.onmicrosoft.com/eas-api" />
          <add key="ApiBaseUrl" value="https://test-accounts.apprenticeships.education.gov.uk/" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>


void Main()
{
    var config = GetConfig();
    var client = new AccountApiClient(config);

    var userId = "4bcfe590-3b1f-418c-b71d-a6778916bbdd";
    
    client.GetUserAccounts(userId).Result.Dump();
}

public AccountApiConfiguration GetConfig()
{
    return new AccountApiConfiguration
    { 
        Tenant = ConfigurationManager.AppSettings["Tenant"],
        ClientId = ConfigurationManager.AppSettings["ClientId"],
        ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
        IdentifierUri = ConfigurationManager.AppSettings["IdentifierUri"],
        ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"]
    };
}