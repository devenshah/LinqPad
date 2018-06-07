<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

void Main()
{
	RunTasks();

	Task.Delay(TimeSpan.FromMilliseconds(300)).ContinueWith((t) =>
	{
		"About to cancel".Log();
		cancellationTokenSource.Cancel();
	}).Wait();
	
	"End of Main".Log();
}

private void RunTasks()
{
	Task.Run(() =>
	{
		int j = 0;
		while (!cancellationTokenSource.Token.IsCancellationRequested)
		{			
			j++;
			Task.Delay(100).ContinueWith((t) =>
			{
				//				Task.Run(() => {
				//					if (j == 5) cancellationTokenSource.Cancel();
				//				});
				cancellationTokenSource.Token.IsCancellationRequested.Log();
				Task.Delay(TimeSpan.FromMilliseconds(100)).ContinueWith((tt) => {
					cancellationTokenSource.Token.IsCancellationRequested.Log();
					j.Log();
					"Sub task was completed".Log();
				}).Wait();
			}, cancellationTokenSource.Token).Wait();
		}
	}, cancellationTokenSource.Token);
}
