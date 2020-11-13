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
	const string LocalConnString = "DefaultEndpointsProtocol=https;AccountName=dastestfaastr;AccountKey=2EXPZP8hqTNyznS//slzi8jgkYftkdQKoOFdZhwsISVGLPpCwH671OkjGhOL5BHTud6TFqe2Z8qMvUQlsKPPPw==;EndpointSuffix=core.windows.net";
	const string DevConnString = "DefaultEndpointsProtocol=https;AccountName=2dev;AccountKey=ChogkZ0DFs3Bq697ypD+EQ9n+emELazh4rX987+2fbJQxGzE5qrdw+XHjD2ljd1s3vgjr1KtCb3fTxmw67S4tQ==;"; //DEV
	const string SitConnString = "DefaultEndpointsProtocol=https;AccountName=5sit;AccountKey=96muMALJQmaDMFnXrcOLLrm+D9T8oCqAqukQ/55D7MsdQL1pUIckjWqQ54nnwrB1ggedHt+Xxpg0vU31rPZdvA=="; // SIT
	const string PreConnString = "DefaultEndpointsProtocol=https;AccountName=1pre;AccountKey=n4suo0+q94bq4Lf3dbmtGSQeUXI7rKw+70i0hNvmtYUMBGICOGTQUwlJWmFlSBpI+COpAHdrmcpOsDVNdlI/HA=="; // PRE
	const string ProdConnString = "DefaultEndpointsProtocol=https;AccountName=nasprod;AccountKey=1Q2o/bMf0GrejFOifNRoavBC0woGbcB9JD7k2smBCeQadIDX3ZREQLxpCz7rNrQ5i7hZOA72KkIxR4WJ4KqdQQ=="; //PROD


	const string SavedSearch = "savedsearchscheduler";
	const string ApplicationEtl = "applicationstatusscheduler";
	const string VacancyEtl = "vacancyindexscheduler";
	const string Monitor = "monitorscheduler";
	const string DailyDigest = "dailydigestscheduler";
	const string DailyMetrics = "dailymetricsscheduler";
	const string Housekeeping = "housekeepingscheduler";
	const string VacancyStatus = "vacancystatusscheduler";
	const string Geocode = "geocodescheduler";
	const string ReferenceData = "referencedatascheduler";
	const string MigrateApplicationNotes = "application-notes";


	// =======================
	// CHANGE THESE TWO VALUES
	const string ConnString = LocalConnString;
	const string QueueName = DailyDigest;
	// =======================

	var storageAccount = CloudStorageAccount.Parse(ConnString);
	var queueClient = storageAccount.CreateCloudQueueClient();

	Console.WriteLine("Connecting");
	var queue = queueClient.GetQueueReference(QueueName);
//	Console.WriteLine("Creating queue");
//	queue.CreateIfNotExists();
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