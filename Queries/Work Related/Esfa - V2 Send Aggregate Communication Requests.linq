<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="UseDevelopmentStorage=true" />
          <!--add key="ConfigurationStorageConnectionString" value="UseDevelopmentStorage=true" /-->
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

const string TestConnString = "DefaultEndpointsProtocol=https;AccountName=dastestrcrtstr;AccountKey=B2rLvVVP6a7yT3y+LfQE5n5wAEokaNC54bssNPNQkz5DkvPNos+LpwqLm1vqYKHdtdIB8BULHNf0dbldCYQzQQ==;EndpointSuffix=core.windows.net";
const string LocalConnString = "UseDevelopmentStorage=true";

const string AggregateCommunicationRequestsQueueName = "aggregate-communication-requests-queue";
const string ApplicationSubmitted = nameof(ApplicationSubmitted);

void Main()
{
    var connString = LocalConnString;
    var frequency = DeliveryFrequency.Daily;
    
    var fromDate = DateTime.UtcNow.Date;
    var toDate = DateTime.UtcNow;
    
    var message = new AggregateCommunicationRequest(Guid.NewGuid(), ApplicationSubmitted, frequency, DateTime.Now, fromDate, toDate);

    var storageAccount = CloudStorageAccount.Parse(connString);
    var queueClient = storageAccount.CreateCloudQueueClient();

    Console.WriteLine("Connecting");
    var queue = queueClient.GetQueueReference(AggregateCommunicationRequestsQueueName);
    queue.CreateIfNotExists();

    var cloudMessage = new CloudQueueMessage(JsonConvert.SerializeObject(message, Newtonsoft.Json.Formatting.Indented));
    Console.WriteLine("Queuing message");
    
    queue.AddMessage(cloudMessage);
    Console.Write("Done");
}

public class AggregateCommunicationRequest
{
    public Guid RequestId { get; }
    public DateTime RequestDateTime { get; }
    public DeliveryFrequency Frequency { get; }
    public string RequestType { get; }
    public DateTime FromDateTime { get; }
    public DateTime ToDateTime { get; }

    public AggregateCommunicationRequest() {}

    public AggregateCommunicationRequest(Guid requestId, string requestType, DeliveryFrequency frequency, DateTime requestDateTime, DateTime fromDateTime, DateTime toDateTime) // end time
    {
        RequestId = requestId;
        RequestType = requestType;
        Frequency = frequency;
        RequestDateTime = requestDateTime;
        FromDateTime = fromDateTime;
        ToDateTime = toDateTime;
    }
}

public enum DeliveryFrequency
{
    Default,
    Immediate,
    Daily,
    Weekly
}