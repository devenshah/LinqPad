<Query Kind="Program">
  <NuGetReference Version="0.2.1">SFA.DAS.ProviderRelationships.Api.Client</NuGetReference>
  <NuGetReference>StructureMap</NuGetReference>
  <Namespace>SFA.DAS.ProviderRelationships.Types.Dtos</Namespace>
  <Namespace>SFA.DAS.ProviderRelationships.Types.Models</Namespace>
  <Namespace>StructureMap</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>SFA.DAS.ProviderRelationships.Api.Client.DependencyResolution</Namespace>
  <Namespace>SFA.DAS.ProviderRelationships.Api.Client</Namespace>
</Query>

void Main()
{
    // var azureADConfig = 
    UseStructureMap();    
}

void UseStructureMap()
{
    using (var container = new Container(c => c.AddRegistry<ProviderRelationshipsApiClientRegistry>()))
    {
        try
        {
            var test = container.GetInstance<GetAccountProviderLegalEntitiesWithPermissionScenario>();
            test.Run().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}


// Define other methods and classes here
internal class GetAccountProviderLegalEntitiesWithPermissionScenario
{
    private readonly IProviderRelationshipsApiClient _providerRelationshipsApiClient;

    public GetAccountProviderLegalEntitiesWithPermissionScenario(IProviderRelationshipsApiClient providerRelationshipsApiClient)
    {
        _providerRelationshipsApiClient = providerRelationshipsApiClient;
    }

    public async Task Run()
    {
        const long ukprn = 10000020;

        var relationshipsRequest = new GetAccountProviderLegalEntitiesWithPermissionRequest { Ukprn = ukprn, Operation = Operation.CreateCohort };
        var response = await _providerRelationshipsApiClient.GetAccountProviderLegalEntitiesWithPermission(relationshipsRequest);

        response.AccountProviderLegalEntities.Dump();
        
        if (response.AccountProviderLegalEntities.Any())
        {
            Console.WriteLine($"Provider with UKPRN {relationshipsRequest.Ukprn} has AccountProviderLegalEntities with {relationshipsRequest.Operation} permission");
        }
    }
}