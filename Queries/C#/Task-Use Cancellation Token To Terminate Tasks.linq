<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static string message;

void Main()
{
	var tokenSource = new CancellationTokenSource(); 
	
	var tasks = new Task[3];
	tasks[0] = Task.Run(() => ListenToAllMessages(tokenSource.Token));
	tasks[1] = Task.Run(() => ListenToFilteredMessages(tokenSource.Token));

	tasks[2] = Task.Run(() => {
		Thread.Sleep(TimeSpan.FromSeconds(3));
		message = "Hello there!";
		tokenSource.Cancel();		
	});
	
	Task.WaitAll(tasks);
	Console.WriteLine("Thread has ended!");	
}


void ListenToAllMessages(CancellationToken token)
{
	var i = 0;
	while (!token.IsCancellationRequested)
	{
		i++;
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"All Message Subscription received message '{message}' after {i} pings");
		}
	}
}

void ListenToFilteredMessages(CancellationToken token)
{
	var i = 0;
	while (!token.IsCancellationRequested)
	{
		i++;
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"Filtered Message Subscription received message '{message}' after {i} pings");			
		}
	}

}