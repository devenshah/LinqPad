<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Unity</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType<IProcessor,NameProvider>(typeof(NameProvider).Name);
	container.RegisterType<IProcessor,AgeProvider>(typeof(AgeProvider).Name);
	
	var procs = container.Resolve<ExecuteProcessors>();
	
}

public class ExecuteProcessors
{ 
	public ExecuteProcessors(IProcessor[] processors)
	{
		foreach (var processor in processors)
		{
			processor.Execute();
		}
	}
}

public interface IProcessor
{ 
	void Execute();
}

public class NameProvider : IProcessor
{ 
	public void Execute()
	{
		"Deven".Log(); 
	}
}

public class AgeProvider : IProcessor
{
	public void Execute()
	{
		"43".Log();
	}
}