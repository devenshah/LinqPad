<Query Kind="Program">
  <NuGetReference>Unity.Interception</NuGetReference>
  <Namespace>Microsoft.Practices.ObjectBuilder2</Namespace>
  <Namespace>Microsoft.Practices.ServiceLocation</Namespace>
  <Namespace>Microsoft.Practices.Unity</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration.ConfigurationHelpers</Namespace>
  <Namespace>Microsoft.Practices.Unity.InterceptionExtension</Namespace>
  <Namespace>Microsoft.Practices.Unity.InterceptionExtension.Configuration</Namespace>
  <Namespace>Microsoft.Practices.Unity.ObjectBuilder</Namespace>
  <Namespace>Microsoft.Practices.Unity.StaticFactory</Namespace>
  <Namespace>Microsoft.Practices.Unity.Utility</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());
	container.RegisterType<IServiceService, ServiceService>();	
	
	var svc = container.Resolve<IServiceService>();
	svc.CreateChildContainer();
	container.Resolve<ILogger>().Id.Dump();
//	svc = container.Resolve<IServiceService>();
//	svc.CreateChildContainer();
}

public interface ILogger
{ 
	Guid Id { get; }
}
public class Logger : ILogger
{ 
	public Guid Id { get; } = Guid.NewGuid();
}

public interface IServiceService { void CreateChildContainer(); }
public class ServiceService : IServiceService
{ 
	private readonly IUnityContainer _container;
	private readonly ILogger _logger;
	public ServiceService(ILogger logger, IUnityContainer container)
	{
		logger.Id.Dump();
		_logger = logger;
		_container = container;
	}

	public void CreateChildContainer()
	{
		var childContainer = _container.CreateChildContainer();
		//childContainer.RegisterInstance<ILogger>(_logger);
		
		var svc = childContainer.Resolve<IServiceService>();
		childContainer.Resolve<ILogger>().Id.Dump();
		childContainer.Dispose();
	}
}

