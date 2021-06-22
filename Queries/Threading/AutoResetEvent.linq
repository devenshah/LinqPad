<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Baffle gate
void Main()
{
	Task.Factory.StartNew (WorkerThread);
	Thread.Sleep(2500);
	eventWaitHandle.Set(); //releases the lock
}

// static EventWaitHandle autoResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset); // Same as below

static AutoResetEvent eventWaitHandle = new AutoResetEvent(false); //false means the lock is on by default or is signaled 

void WorkerThread()
{
	Console.WriteLine("Waiting to enter the gate");
	eventWaitHandle.WaitOne(); //acquires the lock
	Console.WriteLine("Gate entered");
}


void Main1()
{
	//WhenAutoResetIsInititalisedWithFalse_ThenLockCannotBeAcquiredUntilSetIsCalled
	var first = new AutoResetEvent(false);
	Task.Delay(3000).ContinueWith(t => first.Set());
	Console.WriteLine("Getting lock");
	first.WaitOne(); //This will wait for 3 seconds
	Console.WriteLine("lock acquired");
}

void Main2()
{
	//WhenAutoResetIsInititalisedWithTrue_ThenLockWillBeAcquiredImmediately
	var first = new AutoResetEvent(true);
	Task.Delay(3000).ContinueWith(t => first.Set());
	Console.WriteLine("Getting lock");
	first.WaitOne(); //This will be acquired immediately
	Console.WriteLine("First lock acquired lock");
	first.WaitOne(); //This will wait for 3 seconds
	Console.WriteLine("second lock acquired");
}

