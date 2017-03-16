<Query Kind="Program">
  <NuGetReference>Autofac</NuGetReference>
  <Namespace>Autofac.Core</Namespace>
  <Namespace>Autofac</Namespace>
</Query>

void Main()
{
	var builder = new ContainerBuilder();
	builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();
	builder.RegisterType<ServiceService>().As<IServiceService>();
	builder.RegisterType<Temp>().As<ITemp>();
	var container = builder.Build();
	
	
	container.Resolve<ILogger>().Id.Dump();
	
	var childScope = container.BeginLifetimeScope();
	childScope.Resolve<ILogger>().Id.Dump();
	childScope.Resolve<IServiceService>();
	
	container.Resolve<ILogger>().Id.Dump();
}


public interface ILogger
{
	Guid Id { get; }
}
public class Logger : ILogger
{
	public Guid Id { get; } = Guid.NewGuid();
}

public interface IServiceService {  }
public class ServiceService : IServiceService
{
	private readonly ILogger _logger;
	public ServiceService(ILogger logger, ITemp temp)
	{
		logger.Id.Dump();
		_logger = logger;
	}

}

public interface ITemp { }

public class Temp : ITemp 
{
	public Temp(ILogger logger)
	{
			logger.Id.Dump();
	}
}
