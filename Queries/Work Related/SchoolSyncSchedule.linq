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
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=scifstoragepreview;AccountKey=QiWBTOJvVf13+jS9gyKXTBOz83eM3TAI48cNp9+7jPjuyTbJRAtN+WBpd73qooUk/j2f6xlzSFy0CfQLirFfEQ==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

public abstract class StorageTableBase
{
	internal readonly CloudTable _tableStorage;
	internal readonly string _tableName;
	public StorageTableBase(string connectionString, string tableName)
	{
		_tableName = tableName;
		_tableStorage = GetCloudTable(connectionString, tableName);
	}

	internal CloudTable GetCloudTable(string connectionString, string tableName)
	{
		var storageAccount = CloudStorageAccount.Parse(connectionString);
		var tableClient = storageAccount.CreateCloudTableClient();
		var tableStorage = tableClient.GetTableReference(tableName);
		tableStorage.CreateIfNotExists();
		return tableStorage;
	}
}

public class StorageTableRepository<T> : StorageTableBase  where T : TableEntity, new()
{
	internal StorageTableRepository(string connectionString)
		: base(connectionString, typeof(T).Name)
	{
	}

	public IQueryable<T> GetQueryable()
	{
		return _tableStorage.CreateQuery<T>();
	}

	public async Task<T> GetByIdAsync(string rowKey, string partitionKey = "")
	{
		if (string.IsNullOrWhiteSpace(partitionKey))
		{
			partitionKey = _tableName;
		}
		var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
		var tableResult = await _tableStorage.ExecuteAsync(operation);
		return tableResult.Result == null ? null : tableResult.Result as T;
	}

	public async Task InsertOrUpdateAsync(T entity)
	{
		var operation = TableOperation.InsertOrReplace(entity);
		await _tableStorage.ExecuteAsync(operation);
	}

	public async Task InsertAsync(T entity)
	{
		var operation = TableOperation.Insert(entity);
		await _tableStorage.ExecuteAsync(operation);
	}

	public async Task DeleteAsync(T entity)
	{
		var operation = TableOperation.Delete(entity);
		await _tableStorage.ExecuteAsync(operation);
	}
}

StorageTableRepository<SchoolSyncSchedule> svc;

void Main()
{
	var connectionString  = CloudConfigurationManager.GetSetting("StorageConnectionString");
	connectionString.Dump();
	
	svc = new StorageTableRepository<SchoolSyncSchedule>(connectionString);
	var data = new SchoolSyncSchedule(Guid.NewGuid(), "TestProcess", 10, "TestQueue");
	data.LastSyncTime=  DateTime.UtcNow;
	
	svc.InsertAsync(data).Wait();
	
	svc.GetQueryable().Dump();	
}

public class SchoolSyncSchedule : TableEntity
    {
        public SchoolSyncSchedule()
        {

        }

        public SchoolSyncSchedule(Guid schoolId, string processName, int intervalInMinutes, string outputQueueName)
        {
            PartitionKey = processName;
		SchoolId = schoolId;
		RowKey = $"{processName}-{schoolId.ToString()}";
		IntervalInMinutes = intervalInMinutes;
		OutputQueueName = outputQueueName;
	}

	public string ProcessName
	{
		get { return PartitionKey; }
		set { PartitionKey = value; }
	}

	public Guid SchoolId { get; set; }

	public int IntervalInMinutes { get; set; }

	public string OutputQueueName { get; set; }

	public DateTime LastSyncTime { get; set; }
}