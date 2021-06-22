<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static EventWaitHandle first = new AutoResetEvent(false);
static EventWaitHandle second = new AutoResetEvent(false);
static object mylock = new object();
static string value = string.Empty;

void Main()
{
	Task.Factory.StartNew(WorkerThread);
	Console.WriteLine("Main thread is waiting");
	first.WaitOne();
	
	lock(mylock)
	{
		value = "Value in main thread";
		value.Dump();
	}
	Thread.Sleep(1000);
	second.Set();
	Console.WriteLine("Release worker thread");
}

void WorkerThread()
{
	Thread.Sleep(1000);
	lock(mylock)
	{
		value = "Updating the value inside worker thread";
		value.Dump();
	}
	first.Set();
	Console.WriteLine("Released main thread");
	Console.WriteLine("Worker thread is waiting");
	second.WaitOne();
}

