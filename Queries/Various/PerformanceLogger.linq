<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
</Query>

void Main()
{
    var c = new MyClass();
    GetCount (c.ThreadWait);
//	using(var counter = new PerformanceLogger("Main", (s) => Console.WriteLine(s)))
//    {
//        Thread.Sleep(10);
//    }
    
}

private void GetCount(Func<int> action)
{
    using (var perfLogger = new PerformanceLogger($"{action.Method.Name}", Console.WriteLine))
    {
        action();
    }
}
public class MyClass
{
    public int ThreadWait()
    {
        Thread.Sleep(100);
        return 1;
    }
}

public class PerformanceLogger : IDisposable
{ 
	private Stopwatch _sw;
	private string _name;
	private Action<string> _logWriter;
	
	public PerformanceLogger(string name, Action<string> logWriter)
	{
        _name = name;
        _logWriter = logWriter;
		_sw = new Stopwatch();
		_sw.Start();
	}

    public long GetElapsedTimeInMilliseconds() => _sw.ElapsedMilliseconds;

    public void Stop() => _sw.Stop();

    public void Dispose()
	{
		if (!_sw.IsRunning) return; 
		
		_sw.Stop();

        _logWriter($"{_name} took {_sw.ElapsedMilliseconds} ms");
	}
}