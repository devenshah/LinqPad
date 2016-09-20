<Query Kind="Program" />

void Main()
{
	Logger logger = null; 
	logger?.Log("Hello World!");
	
	logger = new Logger();
	logger?.Log("Hello again!");
}

public class Logger
{ 
	public void Log(string message)
	{
		Console.WriteLine(message);
	}
}
