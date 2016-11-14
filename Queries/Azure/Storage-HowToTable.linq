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

TableStorageServiceBase<SchoolInfo> svc;
void Main()
{
	var connectionString  = CloudConfigurationManager.GetSetting("StorageConnectionString");
	connectionString.Dump();
	
	svc = new TableStorageServiceBase<SchoolInfo>();
	svc.Initialize(connectionString);
	
	
	InsertDataAndUpdate();
	
	
	var data = svc.GetAll();	
	data.Dump();
}

void CycleData()
{
	var data = svc.GetAll();
}

void InsertDataAndUpdate()
{
	var id = InsertRecord("New Bradwell School");
	InsertRecord("Gifford Park");
	InsertRecord("Sir Henry Floyd");

	UpdateSyncDate();
}

Guid InsertRecord(string name)
{
	var id = Guid.NewGuid();
	var school1 = new SchoolInfo(id, name);
	svc.InsertOrUpdate(school1);
	return id;
}

void UpdateSyncDate()
{
	var interval = 1;
	var data = svc.GetAll().ToList();
	data.ForEach(s =>
	{		
		s.LastSyncTimeStamp = DateTimeOffset.UtcNow.AddSeconds(interval * 10);
		interval++;
		svc.InsertOrUpdate(s);
	});
	
}


public class TableStorageServiceBase<T> where T : TableEntity, new()
{
	private CloudTable _tableStorage;

	public void Initialize(string connectionString)
	{
		var tableName = typeof(T).Name;
		_tableStorage = GetCloudTable(connectionString, tableName);
		DeleteAll();
	}

	public void InsertOrUpdate(T entity)
	{
		var operation = TableOperation.InsertOrReplace(entity);
		_tableStorage.Execute(operation);
	}

	public void DeleteAll()
	{		
		var entities = GetAll().ToList();
		if (entities.Any())
		{
			var batchOperation = new TableBatchOperation();
			entities.ForEach(entity => batchOperation.Delete(entity));
			_tableStorage.ExecuteBatch(batchOperation);
		}
	}
	
	public List<T> GetAll()
	{
		return _tableStorage.CreateQuery<T>().ToList();
	}
	
	public TableQuery<T> Queryable()
	{
		return _tableStorage.CreateQuery<T>();
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

public class SchoolInfo : TableEntity
{
    public SchoolInfo()
    { }

    public SchoolInfo(Guid schoolId, string name)
    {
        RowKey = schoolId.ToString();
        PartitionKey = this.GetType().FullName;
		Name = name;
	}

	public string Name { get; set; }

	public DateTimeOffset? LastSyncTimeStamp { get; set; }

}