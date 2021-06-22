<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var readySignals = Enumerable.Range(1, 5).Select(e => new ManualResetEvent(false)).ToArray();
	
	var allSignals = new List<ManualResetEvent>();
	var lateSignal = new ManualResetEvent(false);
	
	allSignals.AddRange(readySignals);
	allSignals.Add(lateSignal); 

	Task.Factory.StartNew(() =>
    {
	   WaitHandle.WaitAll(allSignals.ToArray());
	   Console.WriteLine("This message will print after the late signal is set");
    });

	Task.Factory.StartNew(() =>
	{
		WaitHandle.WaitAll(readySignals.ToArray()); //waits for all the events to set signal
		Console.WriteLine("This message will print first");
	});


	Thread.Sleep(2000);
	
	readySignals.Select(s => s.Set()).ToArray();
	
	Thread.Sleep(2000);
	lateSignal.Set();
}


