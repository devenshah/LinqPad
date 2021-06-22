<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static CountdownEvent myCountdown = new CountdownEvent(5);
void Main()
{
	Task.Factory.StartNew (DoSomething);
	Task.Factory.StartNew (DoSomething);
	Task.Factory.StartNew (DoSomething);
	Task.Factory.StartNew (DoSomething);
	Task.Factory.StartNew (DoSomething);
	
	myCountdown.Wait();
	
	Console.WriteLine("Signal has been called 5 times");
}
void DoSomething()
{
	Thread.Sleep(250);
	Console.WriteLine($"{Task.CurrentId} is calling signal");
	myCountdown.Signal();
}

