<Query Kind="Program">
  <NuGetReference>SFA.DAS.Providers.Api.Client</NuGetReference>
  <Namespace>SFA.DAS.Providers.Api.Client</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
    var client = new ProviderApiClient("https://findapprenticeshiptraining-api.apprenticeships.education.gov.uk/");
    
    client.Get(10083920).Dump();
}

// Define other methods, classes and namespaces here
