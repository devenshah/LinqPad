<Query Kind="Program" />

public interface IOperation<T>
{
	IEnumerable<T> Execute(IEnumerable<T> input);
}

// Define other methods and classes here
public class Pipeline<T>
{
	private readonly List<IOperation<T>> operations = new List<IOperation<T>>();

	public Pipeline<T> Register(IOperation<T> operation)
	{
		operations.Add(operation);
		return this;
	}

	public void Execute()
	{
		IEnumerable<T> current = new List<T>();
		foreach (IOperation<T> operation in operations)
		{
			current = operation.Execute(current);
		}
		IEnumerator<T> enumerator = current.GetEnumerator();
		while (enumerator.MoveNext()) ;
	}
}


void Main()
{
	//https://ayende.com/blog/3082/pipes-and-filters-the-ienumerable-appraoch
	(new TrivialProcessesPipeline()).Execute();
}

public class TrivialProcessesPipeline : Pipeline<Process>
{
	public TrivialProcessesPipeline()
	{
		Register(new GetAllProcesses());
		Register(new LimitByWorkingSetSize());
		Register(new PrintProcessName());
	}
}


public class GetAllProcesses : IOperation<Process>
{
	public IEnumerable<Process> Execute(IEnumerable<Process> input)
	{
		return Process.GetProcesses();
	}
}

public class LimitByWorkingSetSize : IOperation<Process>
{
	public IEnumerable<Process> Execute(IEnumerable<Process> input)
	{
		int maxSizeBytes = 50 * 1024 * 1024;
		int i = 0;
		foreach (Process process in input)
		{
			i++;
			if (process.WorkingSet64 > maxSizeBytes)
				yield return process;
		}
	}
}

public class PrintProcessName : IOperation<Process>
{
	public IEnumerable<Process> Execute(IEnumerable<Process> input)
	{
		foreach (Process process in input)
		{
			System.Console.WriteLine(process.ProcessName);
		}
		yield break;
	}
}


