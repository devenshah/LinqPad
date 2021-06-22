<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static EventWaitHandle myEvent = new ManualResetEvent(false);
// static EventWaitHandle myEvent = new EventWaitHandle(false, EventResetMode.ManualReset); //same as above

void Main()
{
	//set few threads to wait on the handle
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	
	// wait for sometime and release the handle, all threads will end immediately
	Task.Delay(3000).ContinueWith(t => myEvent.Set());
	
	//following will not wait on anything as the signal is removed and requires manual resetting
	Console.WriteLine("Wait for another input");
	Thread.Sleep(5000);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);

	//following will wait on anything as the signal is removed and requires manual resetting
	Console.WriteLine("Wait for one more input");
	Thread.Sleep(3000);
	myEvent.Reset(); //lock it again
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Task.Factory.StartNew(CallWaitOne);
	Thread.Sleep(2000);
	myEvent.Set();
}

void CallWaitOne()
{
	Console.WriteLine($"{Task.CurrentId} has called waitone");
	myEvent.WaitOne();
	Console.WriteLine($"{Task.CurrentId} finally ended");
}


