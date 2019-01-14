<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.Azure.KeyVault.Core</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Analytics</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Auth</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Auth.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Core</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Core.Auth</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Core.Util</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.File</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.File.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Queue.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.RetryPolicies</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Shared.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table.Protocol</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table.Queryable</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
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
	var connString = "UseDevelopmentStorage=true";
    
	var storageAccount = CloudStorageAccount.Parse(connString);
		
	var queueClient = storageAccount.CreateCloudQueueClient();
	
	var queue = queueClient.GetQueueReference("application-notes");

    var x = new {ApplicationId=Guid.Parse("2de05a47-5304-4e53-b237-1d653547bd05"), VacancyTypeId=2};
    //var x = new {ApplicationId=Guid.Parse("0e7a3ece-f6d0-438e-b2bc-22153f0e696e"), VacancyTypeId=1};
    
    var s = JsonConvert.SerializeObject(x);
    

	var msg = new CloudQueueMessage(Encoding.UTF8.GetBytes(s));
    
	queue.AddMessage(msg);

}