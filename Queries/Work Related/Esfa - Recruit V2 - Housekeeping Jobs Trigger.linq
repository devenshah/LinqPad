<Query Kind="Program">
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

void Main()
{
    const string DeleteStaleQueryStoreDocumentsQueueName = "delete-stale-query-store-documents-queue";
    const string DeleteStaleVacanciesQueueName = "delete-stale-vacancies-queue";

    // =======================
    // CHANGE THESE VALUES
    const string ConnString = "UseDevelopmentStorage=true";
    const string QueueName = DeleteStaleVacanciesQueueName;
    var timestamp = new DateTime(2019, 11, 4);
    // =======================


    Console.WriteLine("Connecting");
    var storageAccount = CloudStorageAccount.Parse(ConnString);
    var queueClient = storageAccount.CreateCloudQueueClient();
    var queue = queueClient.GetQueueReference(QueueName);
    
    Console.WriteLine("Queuing message");
    var message = SerialiseQueueMessage(timestamp);
    queue.AddMessage(message);
    
	Console.Write("Done");

}

public static CloudQueueMessage SerialiseQueueMessage(DateTime timestamp)
{
    var queueMessage = new StorageQueueMessage() { CreatedByScheduleDate = timestamp };
    return new CloudQueueMessage(JsonConvert.SerializeObject(queueMessage, Newtonsoft.Json.Formatting.Indented));
}

[Serializable]
public class StorageQueueMessage
{
	public DateTime? CreatedByScheduleDate { get; set; }
}

