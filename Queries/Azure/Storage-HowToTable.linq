<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=azurefunctions124e824a;AccountKey=vhS+If0yHqAYnVRVpOVaV21f11aUNaamrc+FdIaWpcP3zEmC6/1kiigRtS+xNAIXAh3E68zVDWN1qRpSeQd2pQ==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

void Main()
{
	var connectionString  = CloudConfigurationManager.GetSetting("StorageConnectionString");
	connectionString.Dump();
	
	var storage = CloudStorageAccount.Parse(connectionString);
	
	var tableClient = storage.CreateCloudTableClient();
	
	var table = tableClient.GetTableReference("School");
	
	table.CreateIfNotExists();
	
	var id = Guid.NewGuid();
	var school1 = new School(id);
	school1.Name = "New Bradwell";
	school1.NextSyncTime = DateTimeOffset.UtcNow.AddHours(1);
	
	var insertOperation = TableOperation.Insert(school1);
	table.Execute(insertOperation);
	
	
	var query = new TableQuery<School>();
	var data = table.ExecuteQuery(query);
	
	data.Dump();
}


public class School : TableEntity
{ 
	public School(Guid schoolId)
	{
		this.RowKey = schoolId.ToString();		
		this.PartitionKey = schoolId.ToString();
	}
	public School()
	{
			
	}
	public string Name { get; set; }
	
	public DateTimeOffset NextSyncTime { get; set; }
}