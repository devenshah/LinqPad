<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Unity</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType(typeof(IStorageService<>), typeof(StorageService<>), );
	
}


public class SchoolInfoStorageService : ISchoolInfoStorageService
{
	public readonly IStorageService<SchoolInfo> _storageService;
	public SchoolInfoStorageService(IStorageService<SchoolInfo> storageService)
	{
		_storageService = storageService;
	}
	
	public void AddOrUpdate(SchoolInfo schoolInfo)
	{
		_storageService.InsertOrUpdate(schoolInfo);
	}
}

public interface ISchoolInfoStorageService
{
	void AddOrUpdate(SchoolInfo schoolInfo);
}

public class SchoolInfo : TableEntity { }

public class StorageService<T> : IStorageService<T> where T : TableEntity
{	
	public StorageService(string connectionString, string tableName)
	{
		
	}
	
	public void InsertOrUpdate(T entity)
    {            
    }
}

public interface IStorageService<T> where T : TableEntity
{ 
	void InsertOrUpdate(T entity);
}

public abstract class TableEntity
{ 
	public Guid RawId { get; set; }
}
