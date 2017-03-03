<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Unity</Namespace>
</Query>

void Main()
{
	var container = UnityFactory.CreateInstance().AddConsoleLogger().AddMemoryLogger();
	
	TransientObjectsShouldHaveSameId(container);
	NonTransientObjectsShouldHaveDifferentId(container);
}

void TransientObjectsShouldHaveSameId(IUnityContainer container)
{
	var logger1 = container.Resolve<ILogger>("ConsoleLogger");
	var logger2 = container.Resolve<ILogger>("ConsoleLogger");
	if (logger1.Id == logger2.Id)
	{
		logger1.Info("Success");
    }
    else
	{
		logger2.Error("failed");
	}
}

void NonTransientObjectsShouldHaveDifferentId(IUnityContainer container)
{
	var logger1 = container.Resolve<ILogger>("MemoryLogger");
	var logger2 = container.Resolve<ILogger>("MemoryLogger");
	if (logger1.Id == logger2.Id)
	{
		logger2.Error("failed");		
	}
	else
	{
		logger1.Info("Success");
	}
}

public static class UnityFactory
{
	public static IUnityContainer CreateInstance()
	{
		var unityContainer = new UnityContainer();

//		var assemblies =
//			ReflectionUtility.GetMatchingReferencedAssemblies("SCI.");
//		assemblies.Add(Assembly.GetEntryAssembly());
//
//		unityContainer.RegisterTypes(
//			AllClasses.FromAssemblies(assemblies),
//			WithMappings.FromMatchingInterface,
//			WithName.Default,
//			WithLifetime.Transient);
		return unityContainer;
	}

//	public static IUnityContainer AddCoreApplicationSettings(this IUnityContainer container)
//	{
//		var appSettings = new ApplicationSettings();
//		container.RegisterInstance<IApplicationSettings>(appSettings);
//		appSettings.AddSettings(typeof(CoreSettingNames).GetAllStaticStringFields());
//		return container;
//	}

	public static IUnityContainer AddConsoleLogger(this IUnityContainer container)
	{
		container.RegisterType<ILogger, ConsoleLogger>("ConsoleLogger", new ContainerControlledLifetimeManager());
		return container;
	}
	
	public static IUnityContainer AddMemoryLogger(this IUnityContainer container)
	{
		container.RegisterType<ILogger, MemoryLogger>("MemoryLogger");
		return container;
	}
}

public interface ILogger
{
	Guid Id { get; }
	void Info(string message);

	void Error(string message);
}

public class ConsoleLogger : ILogger
{
	private readonly TextWriter _infoLogger;
	private readonly TextWriter _errorLogger;

	public Guid Id { get; } = Guid.NewGuid();

	public ConsoleLogger()
	{
		_infoLogger = Console.Out;

		_errorLogger = Console.Error;
	}


	public void Info(string message)
	{
		_infoLogger.WriteLine(FormatMessage(message));
	}

	public void Error(string message)
	{
		_errorLogger.WriteLine(FormatMessage(message));
	}

	private string FormatMessage(string message)
	{
		return $"{Id}:{message}";
	}
}

public class MemoryLogger : ILogger
{
	private readonly StringBuilder _logger = new StringBuilder();
	
	public Guid Id { get; } = Guid.NewGuid();
	
	public void Info(string message)
	{
		_logger.Append(message + Environment.NewLine);
	}

	public void Error(string message)
	{
		_logger.Append(message + Environment.NewLine);
	}
}
