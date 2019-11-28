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
	const string LocalConnString = "UseDevelopmentStorage=true";
	const string AtConnString = "DefaultEndpointsProtocol=https;AccountName=dasatrcrtstr;AccountKey=Ha67t0MdxJXrOYCMXGXyoyr6RMFwfzAPTKVwamUUnXPL48UNKsjcnxoehXe4tjCyF/RM7Gb1ky2faaTS37Y+9w==;EndpointSuffix=core.windows.net"; 
	const string TestConnString = "DefaultEndpointsProtocol=https;AccountName=dastestrcrtstr;AccountKey=B2rLvVVP6a7yT3y+LfQE5n5wAEokaNC54bssNPNQkz5DkvPNos+LpwqLm1vqYKHdtdIB8BULHNf0dbldCYQzQQ==;EndpointSuffix=core.windows.net"; 


    const string BlockedOrganisationsQueue = "generate-all-blocked-organisations-queue";
    const string EmployerDashboardsQueue = "generate-all-employer-dashboards-queue";
    const string ProviderDashboardsQueue = "generate-all-provider-dashboards-queue";
    const string VacancyAnalyticsSummariesQueue = "generate-all-vacancy-analytics-summaries-queue";
    const string VacancyApplicationsQueue = "generate-all-vacancy-applications-queue";
    const string BlockedEmployersDataQueue = "generate-blocked-employers-data-queue";
    const string EmployerDashboardQueue = "generate-employer-dashboard-queue";
    const string LiveVacanciesQueue = "generate-live-vacancies-queue";
    const string ProviderDashboardQueue = "generate-provider-dashboard-queue";
    const string PublishedVacanciesQueue = "generate-published-vacancies-queue";
    

	// =======================
	// CHANGE THESE TWO VALUES
	const string ConnString = LocalConnString;
	const string QueueName = PublishedVacanciesQueue;
	// =======================

	var storageAccount = CloudStorageAccount.Parse(ConnString);
	var queueClient = storageAccount.CreateCloudQueueClient();

	Console.WriteLine("Connecting");
	var queue = queueClient.GetQueueReference(QueueName);
	Console.WriteLine("Creating queue");
	queue.CreateIfNotExists();
	var msg = new StorageQueueMessage();
	var message = AzureMessageHelper.SerialiseQueueMessage(msg);
	Console.WriteLine("Queuing message");
	queue.AddMessage(message);
	Console.Write("Done");
}

public class AzureMessageHelper
{
	public static T DeserialiseQueueMessage<T>(CloudQueueMessage queueMessage)
	{
		T scheduledQueueMessage;

		// Should this be JSON?
		var dcs = new XmlSerializer(typeof(T));

		using (var xmlstream = new MemoryStream(Encoding.Unicode.GetBytes(queueMessage.AsString)))
		{
			scheduledQueueMessage = (T)dcs.Deserialize(xmlstream);
		}

		return scheduledQueueMessage;
	}

	public static CloudQueueMessage SerialiseQueueMessage<T>(T queueMessage)
	{
		var serializer = new XmlSerializer(typeof(T));
		string message;

		using (var ms = new MemoryStream())
		{
			serializer.Serialize(ms, queueMessage);
			ms.Position = 0;
			var sr = new StreamReader(ms);
			message = sr.ReadToEnd();
		}

		var cloudMessage = new CloudQueueMessage(message);

		return cloudMessage;
	}
}

[Serializable]
public class StorageQueueMessage
{
	public string MessageId { get; set; }

	public string PopReceipt { get; set; }

	public Guid ClientRequestId { get; set; } = Guid.NewGuid();

	public DateTime ExpectedExecutionTime { get; set; } = DateTime.UtcNow;

	public string SchedulerJobId { get; set; }
}

[Serializable]
public class ApplicationInfoMessage
{
	public Guid ApplicationId { get; set; }
	public int VacancyTypeId { get; set; }
	public ApplicationInfoMessage() { }
	public ApplicationInfoMessage(Guid applicationId, int vacancyTypeId = 1)
	{
		ApplicationId = applicationId;
		VacancyTypeId = vacancyTypeId;
	}
}