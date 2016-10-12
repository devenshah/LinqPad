<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var i = 0; 
	
	Parallel.For(1, 10, (x) => 
	{
		//Thread.Sleep(5000);
		Interlocked.Increment(ref i);
		Console.WriteLine(string.Format("i={0} x={1}",i,x));
	});
	Console.WriteLine(string.Format("i={0}",i));
}

// Define other methods and classes here
