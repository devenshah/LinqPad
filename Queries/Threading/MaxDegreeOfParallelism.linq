<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var locker = new Object();
    int count = 0;
    var maxDegree = Environment.ProcessorCount * 10; //limits number of threads that can spawn at any given point in time
    maxDegree.Dump();
    Parallel.For
        (0
         , 1000
         , new ParallelOptions { MaxDegreeOfParallelism = maxDegree }
         , (i) =>
               {
                   Interlocked.Increment(ref count);
                   lock (locker)
                   {
                       Console.WriteLine("Number of active threads:" + count);
                       Thread.Sleep(10);
                   }
                   Interlocked.Decrement(ref count);
               }
        );
}

void Main1()
{
	var list = Enumerable.Range(0, 100).ToArray();
	var cancellationTokenSource = new CancellationTokenSource();
	var parallelOptions = new ParallelOptions() 
	{ 
		CancellationToken = cancellationTokenSource.Token,
		MaxDegreeOfParallelism = System.Environment.ProcessorCount
	};
	Console.WriteLine("Press X to cancel");

	Task.Factory.StartNew(() => 
	{
		Thread.Sleep(200);
		cancellationTokenSource.Cancel();
		//if (Util.ReadLine() == "x")
		//{
		//	cancellationTokenSource.Cancel();
		//}
	});
	
	long total = 0;
	try
	{
		Parallel.For<long>(0, list.Length, parallelOptions, () => 0, (count, parallelLoopState, subtotal) => 
		{
			parallelOptions.CancellationToken.ThrowIfCancellationRequested();
			
			subtotal += list[count];
			
			return subtotal;
		},
		(x) => Console.WriteLine($"{System.Threading.Interlocked.Add(ref total, x)}")); 
	}
	catch (OperationCanceledException ex)
	{
		Console.WriteLine($"Cancelled: {ex.Message}");
		throw;
	}
	finally
	{
		cancellationTokenSource.Dispose();
	}
	Console.WriteLine($"The final sum is {total}");
}
