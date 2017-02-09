<Query Kind="Program">
  <NuGetReference>Microsoft.WindowsAzure.ConfigurationManager</NuGetReference>
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.Azure</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Table</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="StorageConnectionString" value="DefaultEndpointsProtocol=https;AccountName=scifjobstoragelocal;AccountKey=Xz78u7lpuvwwiGYfP10AdyO9h7pLesNLzJpM88dG6v49AuSMSMzdZlIYHKFx9dqQYl3rupfF4pBVdtiEl+LDzA==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

public abstract class StorageTableBase
{
	internal readonly CloudTable _tableStorage;
	public StorageTableBase(string connectionString, string tableName)
	{
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

public class StorageTableRepository<T> : StorageTableBase where T : TableEntity, new()
{
	internal StorageTableRepository(string connectionString)
		: base(connectionString, typeof(T).Name)
	{
	}

	public IQueryable<T> GetQueryable()
	{
		return _tableStorage.CreateQuery<T>();
	}

	public async Task<T> GetByIdAsync(string rowKey)
	{
		var operation = TableOperation.Retrieve<T>(typeof(T).FullName, rowKey);
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

public class StorageTableBatchRepository<T> : StorageTableBase where T : TableEntity, new()
{
	private TableBatchOperation _batchOperation;

	internal StorageTableBatchRepository(string connectionString)
		: base(connectionString, typeof(T).Name)
	{
		_batchOperation = new TableBatchOperation();
	}
	
	public int TransactionCount => _batchOperation.Count();
	public bool HasReachedMaxTransactionLimit => _batchOperation.Count() == 100;

	public void InsertOrUpdate(T entity)
	{
		VerifyBatchCount();
		_batchOperation.InsertOrReplace(entity);
	}

	public void Delete(T entity)
	{
		VerifyBatchCount();
		_batchOperation.Delete(entity);
	}

	private void VerifyBatchCount()
	{
		if (HasReachedMaxTransactionLimit)
		{
			throw new MaximumTansactionLimit();
		}
	}

	public async Task SaveChangesAsync(bool createNewTransaction = false)
	{
		if (_batchOperation.Any())
		{
			try
			{
				await _tableStorage.ExecuteBatchAsync(_batchOperation);
			}
			catch (Exception ex)
			{
				ex.Log();
			}
		}
		if (createNewTransaction)
		{
			_batchOperation = new TableBatchOperation();
		}
	}

	public class MaximumTansactionLimit : Exception 
	{		
		public MaximumTansactionLimit()
			:base("Maximum transaction limit reached. Call SaveChangesAsync to commit the current transaction and start a new one.")
		{
			
		}	
	}
}

void TruncateTable(string connectionString)
{
	var repo = new StorageTableRepository<SchoolSyncSchedule>(connectionString);

	var entities = repo.GetQueryable().ToList();
	if (entities.Any())
	{
		entities.ForEach(entity => repo.DeleteAsync(entity).Wait());
	}
}

void Main()
{
	var connectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
	//TryDuplicateKey(connectionString);
	//TruncateTable(connectionString);
	GenerateData(connectionString);
}

void TryDuplicateKey(string  connectionString)
{
	var repo = new StorageTableRepository<SchoolSyncSchedule>(connectionString);
	repo.InsertAsync(new SchoolSyncSchedule(1, "processName", 2, "processName")).Wait();
	try
	{
		repo.InsertAsync(new SchoolSyncSchedule(1, "processName", 2, "processName")).Wait();
	}
	catch (Exception ex)
	{
		ex.Log();
	}
}


void GenerateData(string  connectionString)
{
	TruncateTable(connectionString);

	var repo = new StorageTableBatchRepository<SchoolSyncSchedule>(connectionString);

	for (var processId = 1; processId <= 2; processId++)
	{
		var processName = $"Proc-{processId}";
		processName.Log();
		
		for (var schoolId = 1; schoolId <= 200; schoolId++)
		{
			schoolId.Log();
			repo.InsertOrUpdate(new SchoolSyncSchedule(schoolId, processName, (schoolId % 10) + 2, processName));
			
			if (repo.TransactionCount == 100) 
			{
				repo.SaveChangesAsync(true).Wait();
			}
		}		
	}
}



public class SchoolSyncSchedule : TableEntity
{
	public static string GetRowId(string processName, int schoolId)
	{
		return $"{processName}-{schoolId.ToString()}";
	}

	public SchoolSyncSchedule()
	{

	}

	public SchoolSyncSchedule(int schoolId, string processName, int intervalInMinutes, string outputQueueName)
	{
		PartitionKey = processName;
		SchoolId = schoolId;
		RowKey = GetRowId(processName, schoolId);
		IntervalInMinutes = intervalInMinutes;
		OutputQueueName = outputQueueName;
		LastSyncTime = DateTime.UtcNow;
	}

	public string RowId => RowKey;
	public string ProcessName
	{
		get { return PartitionKey; }
		set { PartitionKey = value; }
	}

	public int SchoolId { get; set; }

	public int IntervalInMinutes { get; set; }

	public string OutputQueueName { get; set; }

	public DateTime LastSyncTime { get; set; }
}