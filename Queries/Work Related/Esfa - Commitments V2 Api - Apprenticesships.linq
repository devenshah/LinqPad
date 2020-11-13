<Query Kind="Program">
  <Reference Relative="Configuration\CommitmentsClientApiConfiguration.json">C:\Deven\Git\LinqPad\Queries\Work Related\Configuration\CommitmentsClientApiConfiguration.json</Reference>
  <NuGetReference>SFA.DAS.CommitmentsV2.Api.Client</NuGetReference>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>SFA.DAS.CommitmentsV2.Api.Client</Namespace>
  <Namespace>SFA.DAS.CommitmentsV2.Api.Client.Configuration</Namespace>
  <Namespace>SFA.DAS.CommitmentsV2.Api.Client.Http</Namespace>
  <Namespace>SFA.DAS.CommitmentsV2.Api.Types.Requests</Namespace>
  <Namespace>SFA.DAS.Http</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

/*
  SELECT TOP 10 App.[Id],[CommitmentId],[FirstName],[LastName]
      ,[ULN], c.EmployerAccountId, EndDate
  FROM Apprenticeship app
  inner join Commitment c on c.Id = App.CommitmentId
  order by EndDate desc
*/

void Main()
{
    var request = new GetApprenticeshipsRequest();
    request.SearchTerm = "2595088903";
    request.AccountId = 29112;
    var client = CreateClient();
    client.GetApprenticeships(request).Result.Dump();
}

public ICommitmentsApiClient CreateClient()
{
    ILoggerFactory lf = new LoggerFactory();
    var configuration = MyExtensions.GetConfiguration<CommitmentsClientApiConfiguration>();
    
    var httpClientFactory = new AzureActiveDirectoryHttpClientFactory(configuration, lf);
    var httpClient = httpClientFactory.CreateHttpClient();
    var restHttpClient = new CommitmentsRestHttpClient(httpClient, lf);
    var apiClient = new CommitmentsApiClient(restHttpClient);

    return apiClient;
}

