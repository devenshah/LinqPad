<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <NuGetReference>JSON</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>Unity</NuGetReference>
  <NuGetReference>WindowsAzure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.ServiceBus</Namespace>
  <Namespace>Microsoft.ServiceBus.Channels</Namespace>
  <Namespace>Microsoft.ServiceBus.Common</Namespace>
  <Namespace>Microsoft.ServiceBus.Configuration</Namespace>
  <Namespace>Microsoft.ServiceBus.Description</Namespace>
  <Namespace>Microsoft.ServiceBus.Management</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Amqp</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Amqp.Serialization</Namespace>
  <Namespace>Microsoft.ServiceBus.Messaging.Configuration</Namespace>
  <Namespace>Microsoft.ServiceBus.Tracing</Namespace>
  <Namespace>Microsoft.ServiceBus.Web</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

const string Topic = "SendEmail";
const string Subscription = "CustomSubscription";

const string connectionString = "";


static CancellationTokenSource tokenSource = new CancellationTokenSource();

void Main()
{
    CreateTopicAndSubscriptions();
	SendSavedSearchAlertMessage();
}

void SendProviderContactUsMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.ProviderContactUsMessage,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.UserFullName,"Deven"),
            new CommunicationToken(CommunicationTokens.UserEmailAddress,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.UserEnquiry,"Unable to register with my email"),
            new CommunicationToken(CommunicationTokens.UserEnquiryDetails,"Hi, I am unable to register using my email, can you please help?"),
        }
    };
    SendMessage(message);
}

void SendDormantAccountReminderMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendDormantAccountReminder,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.AccountExpiryDate,"Sunday, December 30th, 2018"),
            new CommunicationToken(CommunicationTokens.LastLogin,"200 days"),
        }
    };
    SendMessage(message);
}

void SendActivationCodeReminderMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendActivationCodeReminder,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.ActivationCodeExpiryDays,"30th December 2018"),
            new CommunicationToken(CommunicationTokens.ActivationCode,"ABCDEFGH"),
        }
    };
    SendMessage(message);
}

void SendPendingUsernameCodeMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendPendingUsernameCode,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.UserPendingUsername,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.UserPendingUsernameCode,"ABCDEFGH"),
        }
    };
    SendMessage(message);
}

void SendCandidateFeedbackMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.CandidateFeedbackMessage,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.UserFullName,"Deven"),
            new CommunicationToken(CommunicationTokens.UserEmailAddress,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.UserEnquiryDetails,"Hi, I am unable to register using my email, can you please help?"),
        }
    };
    SendMessage(message);
}

void SendCandidateContactUsMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.CandidateContactUsMessage,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.UserFullName,"Deven"),
            new CommunicationToken(CommunicationTokens.UserEmailAddress,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.UserEnquiry,"Unable to register with my email"),
            new CommunicationToken(CommunicationTokens.UserEnquiryDetails,"Hi, I am unable to register using my email, can you please help?"),
        }
    };
    SendMessage(message);
}

void SendTraineeshipApplicationSubmittedMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.TraineeshipApplicationSubmitted,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.ApplicationVacancyTitle,"Accounts Assistant Apprentice"),
            new CommunicationToken(CommunicationTokens.ApplicationVacancyReference,"VAC001481183"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.ProviderContact,"012345567890")
        }
    };
    SendMessage(message);
}

void SendApprenticeshipApplicationSubmittedMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.ApprenticeshipApplicationSubmitted,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.ApplicationVacancyTitle,"Accounts Assistant Apprentice"),
            new CommunicationToken(CommunicationTokens.ApplicationVacancyReference,"VAC001481183"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk")
        }
    };
    SendMessage(message);
}

void SendPaswordChangedMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.PasswordChanged,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.Username,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk")
        }
    };
    SendMessage(message);
}

void SendPaswordResetCodeMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendPasswordResetCode,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.Username,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.PasswordResetCode,"ABCDEFGH"),
            new CommunicationToken(CommunicationTokens.PasswordResetCodeExpiryDays,"1 day")
        }
    };
    SendMessage(message);
}

void SendActivationCodeMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendActivationCode,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.Username,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.ActivationCode,"ABCDEFGH"),
            new CommunicationToken(CommunicationTokens.ActivationCodeExpiryDays,"10 day")
        }
    };
    SendMessage(message);
}

void SendAcccountUnlockMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendAccountUnlockCode,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.Username,"deven.shah@valtech.com"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.AccountUnlockCode,"ABCDEFGH"),
            new CommunicationToken(CommunicationTokens.AccountUnlockCodeExpiryDays,"10 day")
        }
    };
    SendMessage(message);
}

void SendEmployerApplicationLinks()
{
    var links = new Dictionary<string, string> {
        {"DFS85F9D","www.findapprenticeship.service.gov.uk"},
        {"H5DGHD4N","www.findapprenticeship.service.gov.uk"}
    };
    
    var message = new EmailRequest
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SendEmployerApplicationLinks,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.ProviderName, "Deven"),
            new CommunicationToken(CommunicationTokens.ApplicationVacancyTitle, "Apprenticeship for child care assistant"),
            new CommunicationToken(CommunicationTokens.EmployerApplicationLinks,JsonConvert.SerializeObject(links)),
            new CommunicationToken(CommunicationTokens.EmployerApplicationLinksExpiry, "31st December 2018")
        }
    };
    SendMessage(message);

}

void SendDailyDigestMessage()
{
    var message = new EmailRequest{
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.DailyDigest,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName, "Deven"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.ApplicationStatusAlert, GetApplicationStatusAlerts()),
            new CommunicationToken(CommunicationTokens.ExpiringDrafts, GetExpiringVacancyAlerts())
        }
    };
    SendMessage(message);
}
public string GetExpiringVacancyAlerts()
{
    return JsonConvert.SerializeObject(new[] {
        new ExpiringApprenticeshipApplicationDraft{
            VacancyId = 1001001,
            Title = "Title of vacancy one",
            EmployerName = "Argos ",
            ClosingDate = DateTime.Today
        },
        new ExpiringApprenticeshipApplicationDraft{
            VacancyId = 1001002,
            Title = "Title of vacancy two",
            EmployerName = "Homebase",
            ClosingDate = DateTime.Today
        },
    });
}
public class ExpiringApprenticeshipApplicationDraft
{
    public Guid CandidateId { get; set; }

    public int VacancyId { get; set; }

    public string Title { get; set; }

    public string EmployerName { get; set; }

    public DateTime ClosingDate { get; set; }

    public Guid? BatchId { get; set; }

    public DateTime? SentDateTime { get; set; }
}
public string  GetApplicationStatusAlerts()
{
    return JsonConvert.SerializeObject(
        new[]{
            new ApplicationStatusAlert{ 
                Title = "Successful vacancy title",
                Status = ApplicationStatuses.Successful,
                EmployerName = "Channel4",
                VacancyId = 100101,
                UnsuccessfulReason = ""
            },
            new ApplicationStatusAlert{
                Title = "Successful application two",
                Status = ApplicationStatuses.Successful,
                EmployerName = "BBC One",
                VacancyId = 100102,
                UnsuccessfulReason = ""
            },
            new ApplicationStatusAlert{
                Title = "Has reason for not being Successful",
                Status = ApplicationStatuses.Unsuccessful,
                EmployerName = "Sky Atlantic",
                VacancyId = 100103,
                UnsuccessfulReason = "You were rubbish in your interview"
            },
            new ApplicationStatusAlert{
                Title = "Application Has reason for not being Successful",
                Status = ApplicationStatuses.Unsuccessful,
                EmployerName = "Comedy Central",
                VacancyId = 100104
            },
        }
    );
    
}
public class ApplicationStatusAlert 
{
    public Guid CandidateId { get; set; }

    public Guid ApplicationId { get; set; }

    public int VacancyId { get; set; }

    public string Title { get; set; }

    public string EmployerName { get; set; }

    public ApplicationStatuses Status { get; set; }

    public string UnsuccessfulReason { get; set; }

    public DateTime DateApplied { get; set; }

    public Guid? BatchId { get; set; }

    public DateTime? SentDateTime { get; set; }
    public DateTime UnSuccessfulDateTime { get; set; }
}
public enum ApplicationStatuses
{
    Unknown = 0,
    Saved = 5,
    Draft = 10,
    ExpiredOrWithdrawn = 15,
    Submitting = 20,
    Submitted = 30,
    InProgress = 40,
    Successful = 80,
    Unsuccessful = 90,
    CandidateWithdrew = 100,
}

void SendSavedSearchAlertMessage()
{
    var message = new EmailRequest()
    {
        ToEmail = "deven.shah@valtech.com",
        MessageType = MessageTypes.SavedSearchAlert,
        Tokens = new[] {
            new CommunicationToken(CommunicationTokens.CandidateFirstName,"Deven"),
            new CommunicationToken(CommunicationTokens.CandidateSiteDomainName,"www.findapprenticeship.service.gov.uk"),
            new CommunicationToken(CommunicationTokens.SavedSearchAlerts, GetSaveSearchAlert())
        }
    };
    SendMessage(message);
}
string GetSaveSearchAlert()
{
    var wage = new Wage { Type = WageType.ApprenticeshipMinimum, HoursPerWeek=35, Unit=WageUnit.Weekly};
    var data = new List<SavedSearchAlert>() {
        new SavedSearchAlert(){
            Parameters = new SavedSearch(){
                ApprenticeshipLevel = "Higher",
                Category = "Some category",
                CategoryFullName = "Category full name list",
                DisabilityConfidentOnly = false,
                DisplayApprenticeshipLevel = true,
                DisplayClosingDate = true,
                DisplayDescription = true,
                DisplayDistance = true,
                DisplayStartDate = true,
                DisplaySubCategory = true,
                DisplayWage = true,
                Keywords = "keywords looked for",
                Location = "MK14",
                SearchField = "All",
                SubCategories = new string[] {"categoryA, categoryB"},
                SubCategoriesFullName = "sub cat full name",
                WithinDistance = 10
            },
            Results = new List<ApprenticeshipSearchResponse>(){
                new ApprenticeshipSearchResponse(){
                    Id = 10000001,
                    Category = "categoryA",
                    ClosingDate = DateTime.Now.AddDays(1),
                    Description = "Our client, Diligenta, is a UK-based FCA regulated subsidiary of Tata Consultancy Services and a leading provider of business process services for the life and pension industry, administering over 18 million policies on behalf of its clients.",
                    Distance = 1.5,
                    EmployerName = "DILIGENTA LIMITED",
                    IsDisabilityConfident = false,
                    NumberOfPositions = 4,
                    PostedDate = DateTime.Now.AddDays(-10),
                    StartDate = DateTime.Today.AddMonths(1),
                    SubCategory = "categoryA - sub cat",
                    Title = "Apprentice in Project Management Grad Programme",
                    VacancyReference = "VAC10010010",
                    Wage = wage
                },
                new ApprenticeshipSearchResponse(){
                    Id = 10000002,
                    Category = "categoryB",
                    ClosingDate = DateTime.Now.AddDays(10),
                    Description = "Charles Henry & Sons are looking for an Apprentice Estimator/Surveyor to join their long - established family run firm.",
                    Distance = 2.5,
                    EmployerName = "Charles Henry & Sons ",
                    IsDisabilityConfident = true,
                    NumberOfPositions = 1,
                    PostedDate = DateTime.Now.AddDays(-20),
                    StartDate = DateTime.Today.AddMonths(2),
                    SubCategory = "this is sub category",
                    Title = "Apprentice Estimator/Surveyor ",
                    VacancyReference = "VAC10010012",
                    Wage = wage
                },
            }
        },
        new SavedSearchAlert(){
            Parameters = new SavedSearch(){
                ApprenticeshipLevel = "Intermediate",
                Category = "",
                CategoryFullName = "",
                DisabilityConfidentOnly = false,
                DisplayApprenticeshipLevel = true,
                DisplayClosingDate = true,
                DisplayDescription = true,
                DisplayDistance = true,
                DisplayStartDate = true,
                DisplaySubCategory = true,
                DisplayWage = true,
                Keywords = "",
                Location = "CV11",
                SearchField = "All",
                SubCategories = new string[] {"categoryA, categoryB"},
                SubCategoriesFullName = "sub cat full name",
                WithinDistance = 10
            },
            Results = new List<ApprenticeshipSearchResponse>(){
                new ApprenticeshipSearchResponse(){
                    Id = 10000003,
                    Category = "categoryA",
                    ClosingDate = DateTime.Now.AddDays(1),
                    Description = "Do you want to gain technical skills alongside academic studies? Are you looking for a career path with continuous training and development? Our Leadership, Education and Development (LEAD) higher apprenticeship programme is designed to develop future supervisors and managers in a hands-on environment.",
                    Distance = 1.5,
                    EmployerName = "HANSON LIMITED",
                    IsDisabilityConfident = false,
                    NumberOfPositions = 1,
                    PostedDate = DateTime.Now.AddDays(-10),
                    StartDate = DateTime.Today.AddMonths(1),
                    SubCategory = "categoryA - sub cat",
                    Title = "Supervisor Mineral Products Technology Apprenticeship ",
                    VacancyReference = "VAC10010013",
                    Wage = wage
                },
                new ApprenticeshipSearchResponse(){
                    Id = 10000004,
                    Category = "categoryB",
                    ClosingDate = DateTime.Now.AddDays(10),
                    Description = "Be part of something exciting at CGI and earn while you learn on our Software Development Higher Apprenticeship. We’re a company that each day enables the transfer of £3 trillion, protects against 43 million cyber-attacks, helps secure Europe’s major satellites and who employs 74,000 professionals from hundreds of locations worldwide",
                    Distance = 2.5,
                    EmployerName = "CGI IT UK LIMITED",
                    IsDisabilityConfident = true,
                    NumberOfPositions = 2,
                    PostedDate = DateTime.Now.AddDays(-20),
                    StartDate = DateTime.Today.AddMonths(2),
                    SubCategory = "this is sub category",
                    Title = "Higher Apprenticeship - Software Development",
                    VacancyReference = "VAC10010014",
                    Wage = wage
                },
            }
        }
    };
    return JsonConvert.SerializeObject(data);
}
public class SavedSearchAlert 
{
    public SavedSearch Parameters { get; set; }

    public IList<ApprenticeshipSearchResponse> Results { get; set; }
}
public class ApprenticeshipSearchResponse 
{
    public double Distance { get; set; }
    public double Score { get; set; }
    public int Id { get; set; }
    public string VacancyReference { get; set; }
    public string Title { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public string Description { get; set; }
    public int? NumberOfPositions { get; set; }
    public string EmployerName { get; set; }
    public string ProviderName { get; set; }
    public bool IsPositiveAboutDisability { get; set; }
    public bool IsEmployerAnonymous { get; set; }
    public string AnonymousEmployerName { get; set; }
    public GeoPoint Location { get; set; }
    public string Category { get; set; }
    public string CategoryCode { get; set; }
    public string SubCategory { get; set; }
    public string SubCategoryCode { get; set; }
    public bool IsDisabilityConfident { get; set; }
    public Wage Wage { get; set; }    
}
public class GeoPoint
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public int Easting { get; set; }
    public int Northing { get; set; }

    public override string ToString()
    {
        return string.Format("Latitude:{0}, Longitude:{1}, Easting: {2}, Northing:{3}", (object)this.Latitude, (object)this.Longitude, (object)this.Easting, (object)this.Northing);
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (this == obj)
            return true;
        if (obj.GetType() != this.GetType())
            return false;
        return this.Equals((GeoPoint)obj);
    }

    protected bool Equals(GeoPoint other)
    {
        if (this.Longitude.Equals(other.Longitude) && (this.Latitude.Equals(other.Latitude) && this.Easting == other.Easting))
            return this.Northing == other.Northing;
        return false;
    }

    public override int GetHashCode()
    {
        double num1 = this.Longitude;
        int num2 = num1.GetHashCode() * 397;
        num1 = this.Latitude;
        int hashCode = num1.GetHashCode();
        return ((num2 ^ hashCode) * 397 ^ this.Easting) * 397 ^ this.Northing;
    }
}
public class SavedSearch
{
    public SavedSearch()
    {
        AlertsEnabled = true;
        ApprenticeshipLevel = "All";
        SearchField = "All";
        DisplaySubCategory = true;
        DisplayDescription = true;
        DisplayDistance = true;
        DisplayClosingDate = true;
        DisplayStartDate = true;
    }

    public Guid CandidateId { get; set; }

    public bool AlertsEnabled { get; set; }

    public string Location { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public int Hash { get; set; }

    public string Keywords { get; set; }

    public int WithinDistance { get; set; }

    public string ApprenticeshipLevel { get; set; }

    public string Category { get; set; }

    public string CategoryFullName { get; set; }

    public string[] SubCategories { get; set; }

    public string SubCategoriesFullName { get; set; }

    public string SearchField { get; set; }

    public string LastResultsHash { get; set; }

    public DateTime? DateProcessed { get; set; }

    public bool DisplaySubCategory { get; set; }

    public bool DisplayDescription { get; set; }

    public bool DisplayDistance { get; set; }

    public bool DisplayClosingDate { get; set; }

    public bool DisplayStartDate { get; set; }

    public bool DisplayApprenticeshipLevel { get; set; }

    public bool DisplayWage { get; set; }

    public bool DisabilityConfidentOnly { get; set; }
}
public class Wage
{
    public Wage()
    {
    }

    public WageType Type { get; set; }

    public string ReasonForType { get; set; }

    public Decimal? Amount { get; set; }

    public Decimal? AmountLowerBound { get; set; }

    public Decimal? AmountUpperBound { get; set; }

    public string Text { get; set; }

    public WageUnit Unit { get; set; }

    public Decimal? HoursPerWeek { get; set; }
}
public enum WageType
{
    LegacyText,
    LegacyWeekly,
    ApprenticeshipMinimum,
    NationalMinimum,
    Custom,
    CustomRange,
    CompetitiveSalary,
    ToBeAgreedUponAppointment,
    Unwaged,
}
public enum WageUnit
{
    NotApplicable = 1,
    Weekly = 2,
    Monthly = 3,
    Annually = 4,
}

void SendMessage(EmailRequest message)
{
    var client = TopicClient.CreateFromConnectionString(connectionString, Topic);

    string messageTypeName = message.GetType().FullName;

    BrokeredMessage brokeredMessage = GetBrokeredMessage(message);

    client.Send(brokeredMessage);

    Console.WriteLine("Finished sending message");
}
void CreateTopicAndSubscriptions()
{
    var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

    //Create topic
    if (!namespaceManager.TopicExists(Topic))
    {
        namespaceManager.CreateTopic(Topic);
    }

    //Create subscription for all the messages
    if (!namespaceManager.SubscriptionExists(Topic, Subscription))
    {
        namespaceManager.CreateSubscription(Topic, Subscription);
    }
}
private static BrokeredMessage GetBrokeredMessage<T>(T message) where T : class
{
    string json = JsonConvert.SerializeObject(message);
    var brokeredMessage = new BrokeredMessage(json)
    {
        ContentType = "application/json"
    };
    return brokeredMessage;
}
public class EmailRequest
{
    public string ToEmail { get; set; }

    public MessageTypes MessageType { get; set; }

    public IEnumerable<CommunicationToken> Tokens { get; set; }
}
public enum MessageTypes
{
    SendActivationCode,
    SendPasswordResetCode,
    SendAccountUnlockCode,
    SendMobileVerificationCode,
    ApprenticeshipApplicationSubmitted,
    TraineeshipApplicationSubmitted,
    PasswordChanged,
    DailyDigest,
    CandidateContactUsMessage,
    SavedSearchAlert,
    ApprenticeshipApplicationSuccessful,
    ApprenticeshipApplicationUnsuccessful,
    ApprenticeshipApplicationsUnsuccessfulSummary,
    ApprenticeshipApplicationExpiringDraft,
    ApprenticeshipApplicationExpiringDraftsSummary,
    SendPendingUsernameCode,
    SendEmailReminder,
    SendActivationCodeReminder,
    SendMobileVerificationCodeReminder,
    SendDormantAccountReminder,
    CandidateFeedbackMessage,
    SendProviderUserEmailVerificationCode,
    ProviderContactUsMessage,
    SendEmployerApplicationLinks,
}
public class CommunicationToken
{
    public CommunicationTokens Key { get; set; }

    public string Value { get; set; }

    public CommunicationToken(CommunicationTokens key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
}
public enum CommunicationTokens
{
    CandidateFirstName,
    CandidateLastName,
    Username,
    ActivationCode,
    ActivationCodeExpiryDays,
    PasswordResetCode,
    PasswordResetCodeExpiryDays,
    AccountUnlockCode,
    AccountUnlockCodeExpiryDays,
    MobileVerificationCode,
    ApplicationVacancyTitle,
    ApplicationVacancyReference,
    ApplicationVacancyEmployerName,
    ApplicationId,
    ProviderContact,
    RecipientEmailAddress,
    CandidateMobileNumber,
    ExpiringDraft,
    ExpiringDrafts,
    UserFullName,
    UserEnquiry,
    UserEnquiryDetails,
    UserEmailAddress,
    ApplicationStatusAlert,
    ApplicationStatusAlerts,
    SavedSearchAlerts,
    UserPendingUsername,
    UserPendingUsernameCode,
    CandidateSiteDomainName,
    CandidateSubscriberId,
    CandidateSubscriptionType,
    LastLogin,
    AccountExpiryDate,
    ProviderUserEmailVerificationCode,
    ProviderUserFullName,
    ProviderUserUsername,
    EmployerApplicationLinks,
    ProviderName,
    EmployerApplicationLinksExpiry,
    OptionalMessage,
}