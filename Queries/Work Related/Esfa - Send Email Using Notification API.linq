<Query Kind="Program">
  <NuGetReference>SFA.DAS.Notifications.Api.Client</NuGetReference>
  <Namespace>SFA.DAS.Http</Namespace>
  <Namespace>SFA.DAS.Http.TokenGenerators</Namespace>
  <Namespace>SFA.DAS.Notifications.Api.Client</Namespace>
  <Namespace>SFA.DAS.Notifications.Api.Client.Configuration</Namespace>
  <Namespace>SFA.DAS.Notifications.Api.Types</Namespace>
</Query>

void Main()
{

    var apiBaseUrl = "https://at-notifications.apprenticeships.sfa.bis.gov.uk/";
    var token = "";

    var config = new NotificationsApiClientConfiguration{
        ApiBaseUrl = apiBaseUrl, 
        ClientToken = token
    };

    IGenerateBearerToken jwtToken = new JwtBearerTokenGenerator(config);

    var httpClient = new HttpClientBuilder()
        .WithBearerAuthorisationHeader(jwtToken)
        .WithDefaultHeaders()
        .Build();
    
    var apiClient = new NotificationsApi(httpClient, config);
        
    var customFields = new Dictionary<string, string>();
    customFields.Add("UserEmailAddress","Deven.sHAH@valtech.com");
    customFields.Add("UserFullName","DEveN ShaH");
    customFields.Add("UserEnquiry", "I have a question");
    customFields.Add("UserEnquiryDetails", "Wanted to have different appSettings for debug and release when building your app ? ");

    var c = new Email() {
        Tokens = customFields,
        RecipientsAddress = "deven.shah@valtech.co.uk",
        ReplyToAddress = "dev4valtech@gmail.com",
        SystemId = "xyz",
        TemplateId = "VacancyService_CandidateContactUsMessage",
        Subject = "hello"
    };

    apiClient.SendEmail(c).Wait();

}