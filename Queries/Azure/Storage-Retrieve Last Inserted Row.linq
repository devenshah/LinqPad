<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=azurefunctions43847863;AccountKey=GcQyATBvZj73tA22b/UNFa034+fJk/lvtABw+8u1LSnP0Fms8++lAyRKXDg8F6BrwfJObol6bTQ/tvaZx+4zug==;EndpointSuffix=core.windows.net" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

TableStorageServiceBase<SchoolInfo> svc;

void Main()
{
	var connectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");

	svc = new TableStorageServiceBase<SchoolInfo>(connectionString);
	var id1 = "1";
	var id2 = "2";
	///http://www.azurefromthetrenches.com/welcome-and-a-table-storage-date-sorting-tip/
	svc.InsertOrUpdate(new SchoolInfo(id1, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "New Bradwell School", true));
	svc.InsertOrUpdate(new SchoolInfo(id2, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "New Bradwell School", true));
	svc.InsertOrUpdate(new SchoolInfo(id2, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "Gifford Park", false));
	svc.InsertOrUpdate(new SchoolInfo(id1, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "Gifford Park", false));
	svc.InsertOrUpdate(new SchoolInfo(id1, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "Sir Henry Floyd", false));	
	svc.InsertOrUpdate(new SchoolInfo(id2, $"{DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks:D19}", "Sir Henry Floyd", false));


	//last insterted row
	svc.Queryable().FirstOrDefault().Dump();
	
	//last successfull row
	svc.Queryable().Where(s => s.PartitionKey==id2 && s.IsCompleted).FirstOrDefault().Dump();
	//should match the first row in below list
	svc.Queryable().ToList().OrderBy(s => s.RowKey).Where(s => s.PartitionKey == id2 && s.IsCompleted).Dump();
}

public class SchoolInfo : TableEntity
{
	public SchoolInfo()
	{ }

	public SchoolInfo(string partitionKey, string rowKey, string name, bool isCompleted)
	{
		RowKey = rowKey;
		PartitionKey = partitionKey;
		Name = name;
		IsCompleted = isCompleted;
	}

	public string Name { get; set; }

	public DateTimeOffset? LastSyncTimeStamp { get; set; }

	public bool IsCompleted { get; set; }
}

public class TableStorageServiceBase<T> where T : TableEntity, new()
{
	private CloudTable _tableStorage;

	public TableStorageServiceBase(string connectionString)
	{
		var tableName = typeof(T).Name;
		_tableStorage = GetCloudTable(connectionString, tableName);
	}

	public TableQuery<T> Queryable()
	{
		return _tableStorage.CreateQuery<T>();
	}

	public void InsertOrUpdate(T entity)
	{
		var operation = TableOperation.InsertOrReplace(entity);
		_tableStorage.Execute(operation);
	}

	public void Delete(T entity)
	{		
		var operation = TableOperation.Delete(entity);
		_tableStorage.Execute(operation);
	}

	private CloudTable GetCloudTable(string connectionString, string tableName)
	{
		var storageAccount = CloudStorageAccount.Parse(connectionString);
		var tableClient = storageAccount.CreateCloudTableClient();
		var tableStorage = tableClient.GetTableReference(tableName);
		tableStorage.CreateIfNotExists();		
		return tableStorage;
	}
}