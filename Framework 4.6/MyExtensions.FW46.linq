<Query Kind="Program" />

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries.
	public static void Log(this object obj)
	{
		Console.WriteLine(obj);
	}

}

// You can also define non-static classes, enums, etc.