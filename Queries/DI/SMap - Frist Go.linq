<Query Kind="Program">
  <NuGetReference>structuremap</NuGetReference>
  <Namespace>StructureMap</Namespace>
  <Namespace>StructureMap.Attributes</Namespace>
  <Namespace>StructureMap.AutoMocking</Namespace>
  <Namespace>StructureMap.Building</Namespace>
  <Namespace>StructureMap.Building.Interception</Namespace>
  <Namespace>StructureMap.Configuration</Namespace>
  <Namespace>StructureMap.Configuration.DSL</Namespace>
  <Namespace>StructureMap.Configuration.DSL.Expressions</Namespace>
  <Namespace>StructureMap.Diagnostics</Namespace>
  <Namespace>StructureMap.Diagnostics.TreeView</Namespace>
  <Namespace>StructureMap.Graph</Namespace>
  <Namespace>StructureMap.Graph.Scanning</Namespace>
  <Namespace>StructureMap.Pipeline</Namespace>
  <Namespace>StructureMap.Pipeline.Lazy</Namespace>
  <Namespace>StructureMap.Query</Namespace>
  <Namespace>StructureMap.TypeRules</Namespace>
  <Namespace>StructureMap.Util</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var container = new Container(cfg =>
	{
		cfg.Scan(x =>
		{
			x.TheCallingAssembly();
			x.WithDefaultConventions();
		});
		cfg.For<IPersonRepository>().Use<CachedPersonRepository>().Ctor<IPersonRepository>().Is<SqlPersonRepository>();
		cfg.For(typeof(ICacheService<>)).Use(typeof(CacheService<>));
	});
	
	container.GetInstance<DependencyTest>();
}

public class DependencyTest
{ 
	public DependencyTest(IPersonRepository personRepository)
	{
		personRepository.GetType().FullName.Log();
	}
}

public interface ICacheService
{ 
	Task<T> CacheAside<T>(string key, Func<Task<T>> sourceActionAsync, TimeSpan timeSpan);
}

public class CacheService : ICacheService
{ 
	public async Task<T> CacheAside<T>(string key, Func<Task<T>> sourceActionAsync, TimeSpan timeSpan)
	{
		return await sourceActionAsync();
	}
}

public interface IPersonRepository
{
	Person GetPerson(int id);
}

public class SqlPersonRepository : IPersonRepository
{ 
	public Person GetPerson(int id)
	{
		return new Person();
	}
}

public class CachedPersonRepository : IPersonRepository
{
	private readonly ICacheService _cacheService;
	private readonly IPersonRepository _personRepository;
	public CachedPersonRepository(ICacheService cacheService, IPersonRepository personRepository)
	{
		_cacheService = cacheService;
		_personRepository = personRepository;		
		
		_personRepository.GetType().FullName.Log();
	}
	
	public Person GetPerson(int id)
	{
		return new Person();
	}
}