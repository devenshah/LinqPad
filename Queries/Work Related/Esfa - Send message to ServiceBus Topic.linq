<Query Kind="Program">
  <NuGetReference>Microsoft.Azure.ServiceBus</NuGetReference>
  <Namespace>Microsoft.Azure.ServiceBus</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
    var connStr = @"Endpoint=sb://dstest20180807.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=iqxoaDIEQZXaZ7E0vLsHtbPRitao2cI0X5uF+VjrD14=";
    var topic = "apprenticeshipapplicationstatusupdated";
    var message = new ApplicationStatusChanged();
    var topicClient = new TopicClient(connStr, topic);
    topicClient.SendAsync(GetMessage(message));
}

private static Message GetMessage<T>(T msg) where T : class
{
    string json = JsonConvert.SerializeObject(msg, Newtonsoft.Json.Formatting.None);
    var message = new Message(Encoding.UTF8.GetBytes(json))
    {
        ContentType = "application/json"
    };
    return message;
}
    
public class ApplicationStatusChanged
{
    public int LegacyApplicationId { get; set; } = 1;
    //public ApplicationStatuses ApplicationStatus { get; set; }
    public string UnsuccessfulReason { get; set; } = "Hello world";
    public bool IsRecruitVacancy { get; set; } = true;
    public int? VacancyReference { get; set; } = 1234;
    public Guid? CandidateId { get; set; } = Guid.NewGuid();
}