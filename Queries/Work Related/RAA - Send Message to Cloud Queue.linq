<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=functionpocstore;AccountKey=Fj7zTdqOyQBteBzbhMX6KYmbsRExyLPb21r5BIrSJU9EMd7w/B7C8LtsRUbFhxPSyW9wgrO7gN/ZsWvspGksHg==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

void Main()
{
	var sitConnString = "DefaultEndpointsProtocol=https;AccountName=5sit;AccountKey=96muMALJQmaDMFnXrcOLLrm+D9T8oCqAqukQ/55D7MsdQL1pUIckjWqQ54nnwrB1ggedHt+Xxpg0vU31rPZdvA==;EndpointSuffix=core.windows.net";
	var devConnString = "DefaultEndpointsProtocol=https;AccountName=2dev;AccountKey=ChogkZ0DFs3Bq697ypD+EQ9n+emELazh4rX987+2fbJQxGzE5qrdw+XHjD2ljd1s3vgjr1KtCb3fTxmw67S4tQ==";
	
	var storageAccount = CloudStorageAccount.Parse(sitConnString);
		
	var queueClient = storageAccount.CreateCloudQueueClient();
	
	var queue = queueClient.GetQueueReference("vacancyindexscheduler");
	
	//queue.CreateIfNotExists();

	var msg = new StorageQueueMessage();
	var message = AzureMessageHelper.SerialiseQueueMessage(msg);
	queue.AddMessage(message);

}

public class AzureMessageHelper
    {
        public static T DeserialiseQueueMessage<T>(CloudQueueMessage queueMessage)
        {
            T scheduledQueueMessage;

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

	public Guid ClientRequestId { get; set; }

	public DateTime ExpectedExecutionTime { get; set; } = DateTime.UtcNow;

	public string SchedulerJobId { get; set; }
}