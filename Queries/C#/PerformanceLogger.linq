<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
</Query>

void Main()
{
	
}

public class PerformanceLogger : IDisposable
{ 
	private Stopwatch _sw;
	private string _name;
	private Action<string> _logWriter;
	
	public PerformanceLogger(string name, Action<string> logWriter)
	{
		_sw = new Stopwatch();
		_sw.Start();
	}

	public void Dispose()
	{
		if (!_sw.IsRunning) return; 
		
		_sw.Stop();
		
		Console.WriteLine($"
	}
}
