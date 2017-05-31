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
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=scifstoragelocal;AccountKey=WdnMPUbZW/AfJiCAN2ej84D80NLEqszCFvBARcdLayF7QhIAfI362HQ5ydIxJDXy3U1/X321VovT0p/hHFTtSw==" />
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
	
	svc.Queryable().Dump();
	
	CycleData();	
}

void CycleData()
{
	var counter = 5;
	while (counter > 0)
	{
		var data =
			svc.Queryable()
				.Where(s => s.LastSyncTimeStamp < DateTimeOffset.UtcNow)
				.ToList();

		if (data.Any())
		{
			svc.StartBatchOperation();
			data.ForEach(s =>
			{
				s.LastSyncTimeStamp = DateTimeOffset.UtcNow.AddMinutes(1);
				svc.InsertOrUpdate(s);
			});
			svc.EndBatchOperation();
			data.Dump(counter.ToString());
			counter--;
		}
	}
	Console.WriteLine("End of Cycle");
}

void InsertDataAndUpdate()
{
	svc.StartBatchOperation();	
	var entities = svc.Queryable().ToList();
	if (entities.Any())
	{
		entities.ForEach(entity => svc.Delete(entity));
	}
	
	svc.InsertOrUpdate(new SchoolInfo(Guid.NewGuid(), "New Bradwell School"));
	svc.InsertOrUpdate(new SchoolInfo(Guid.NewGuid(), "Gifford Park"));
	svc.InsertOrUpdate(new SchoolInfo(Guid.NewGuid(), "Sir Henry Floyd"));
	svc.EndBatchOperation();
	
	svc.StartBatchOperation();
	var interval = 1;
	var data = svc.Queryable().ToList();
	data.ForEach(s =>
	{
		s.LastSyncTimeStamp = DateTimeOffset.UtcNow.AddSeconds(interval * 10);
		interval++;
		svc.InsertOrUpdate(s);
	});
	svc.EndBatchOperation();
}


public class TableStorageServiceBase<T> where T : TableEntity, new()
{
	private CloudTable _tableStorage;
	
	private bool _hasOnGoingBatchOperation = false;
	
	private TableBatchOperation batchOperation;

	public void Initialize(string connectionString)
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
		if (_hasOnGoingBatchOperation)
		{
			batchOperation.InsertOrReplace(entity);
		}
		else
		{
			var operation = TableOperation.InsertOrReplace(entity);
			_tableStorage.Execute(operation);
		}
	}

	public void Delete(T entity)
	{		
		if (_hasOnGoingBatchOperation)
		{
			batchOperation.Delete(entity);
		}
		else
		{
			var operation = TableOperation.Delete(entity);
			_tableStorage.Execute(operation);
		}
	}

	public void StartBatchOperation()
	{
		if (_hasOnGoingBatchOperation) throw new BatchOperationIsAlreadyOnException();
		
		batchOperation = new TableBatchOperation();
		_hasOnGoingBatchOperation = true;
	}
	
	public void EndBatchOperation()
	{
		if (!_hasOnGoingBatchOperation) throw new BatchOperationIsMissingException();

		if (batchOperation.Any())
		{
			_tableStorage.ExecuteBatch(batchOperation);			
		}
		
		_hasOnGoingBatchOperation = false;
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

public class BatchOperationIsAlreadyOnException : Exception
{ 
	public BatchOperationIsAlreadyOnException()
		: base("A batch operation is already on. End the current batch operation before starting a new one.")
	{
		
	}
}

public class BatchOperationIsMissingException : Exception
{
	public BatchOperationIsMissingException()
		: base("A batch operation is not turned on. Start a batch operation first.")
	{

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