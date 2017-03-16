<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static string message;

void Main()
{

	var tasks = new Task[3];
	tasks[0] = Task.Run(ListenToAllMessages);
	tasks[1] = Task.Run(ListenToFilteredMessages);

	tasks[2] = Task.Run(() => {
		Thread.Sleep(TimeSpan.FromSeconds(3));
		message = "Hello there!";
	});
	
	Task.WaitAll(tasks);
	Console.WriteLine("Thread has ended!");	
}


Task ListenToAllMessages()
{
	var i = 0;
	while (true)
	{
		i++;
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"All Message Subscription received message '{message}' after {i} pings");
			return Task.CompletedTask;
		}
	}
}

Task ListenToFilteredMessages()
{
	var i = 0;
	while (true)
	{
		i++;
		if (!string.IsNullOrWhiteSpace(message))
		{
			Console.WriteLine($"Filtered Message Subscription received message '{message}' after {i} pings");
			return Task.CompletedTask;
		}
	}

}