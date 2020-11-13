<Query Kind="Program">
  <Reference Relative="Configuration\AccountApiConfiguration.json">C:\Deven\Git\LinqPad\Queries\Work Related\Configuration\AccountApiConfiguration.json</Reference>
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
          <!--
    <add key="Tenant" value="3aacc835-4b83-483d-841d-cd787f6f1486" />
    <add key="IdentifierUri" value="https://fcsazuresfabisgov.onmicrosoft.com/eas-api" />
    <add key="ClientId" value="b01a6039-c860-4f46-bdf1-f9c4469439ce" />
    <add key="ClientSecret" value="7uq?0YE[77UAb/BGaBmLZPQOWqGpSOT@" />
    <add key="ApiBaseUrl" value="https://pp-accounts.apprenticeships.education.gov.uk/" />
    -->
          <add key="Tenant" value="citizenazuresfabisgov.onmicrosoft.com" />
          <add key="ClientId" value="0a25a495-140e-4f9f-807b-11e2fa115375" />
          <add key="ClientSecret" value="4P1BXocY29?._gKW:GV.2pHAYrVBz=KI" />
          <add key="IdentifierUri" value="https://citizenazuresfabisgov.onmicrosoft.com/eas-api" />
          <add key="ApiBaseUrl" value="https://test-accounts.apprenticeships.education.gov.uk/" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    var config = MyExtensions.GetConfiguration<AccountApiConfiguration>();
    var client = new AccountApiClient(config);

    var accountId = 27446;
    var result = client.GetAccount(accountId).Result;
    result.Dump();
}