<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
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
	var storageAccount = CloudStorageAccount.Parse(
		CloudConfigurationManager.GetSetting("StorageConnectionString"));
		
	var queueClient = storageAccount.CreateCloudQueueClient();
	
	var queue = queueClient.GetQueueReference("functionspocqueue");
	
	queue.CreateIfNotExists();

	var message = new CloudQueueMessage("Bazinga!!!");
	queue.AddMessage(message);

}

// Define other methods and classes here
