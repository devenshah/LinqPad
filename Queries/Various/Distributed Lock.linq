<Query Kind="Program">
  <NuGetReference>DistributedLock.SqlServer</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Medallion.Threading.SqlServer</Namespace>
</Query>

async Task Main()
{
	await RunTest(new TestService(new SqlServerLockService())).ConfigureAwait(false);
}

private static async Task RunTest(TestService testService)
{
	await Task.Yield(); //For WaitHandle to work we need the rest of the code running async as LinqPad is running on STA (single threaded apartment model)
	const int TotalNumberOfClients = 10;
	var mainSignal = new ManualResetEvent(false); //This is the main event signal which sets only after user input
	ManualResetEvent[] readySignals = Enumerable
		.Range(1, TotalNumberOfClients)
		.Select(x => new ManualResetEvent(false))
		.ToArray(); // Signals for multiple sub events 

	Task[] tasks = readySignals
		.Select(x => testService.DoStuffAsync(mainSignal, x))
		.ToArray(); //kick off the Sub events 

	WaitHandle.WaitAll(readySignals); //wait till all the sub events signals are set 
	Console.WriteLine("Press enter to start");
	Util.ReadLine();
	var sw = Stopwatch.StartNew();
	mainSignal.Set(); //release so all the sub events can carry on
	await Task.WhenAll(tasks).ConfigureAwait(false);
	long elapsed = sw.ElapsedMilliseconds;

	Console.WriteLine($"PerLock={elapsed / TotalNumberOfClients}, Total={elapsed}");

}

public class TestService
{
	static int LastSerialNumber;
	int SerialNumber = Interlocked.Increment(ref LastSerialNumber);
	private readonly ILockService LockService;

	public TestService(ILockService lockService)
	{
		LockService = lockService;
	}

	public async Task DoStuffAsync(WaitHandle trigger, ManualResetEvent readySignal)
	{
		await Task.Yield(); //executes reset of the code in async
		readySignal.Set(); // release the task signal
		trigger.WaitOne(); // wait on the main signal
		Log("Attempting to lock");
		using (await LockService.LockAsync("MyKey").ConfigureAwait(false))
		{
			Log("Locked");
			await Task.Delay(500).ConfigureAwait(false);
			Log("Unlocked");
		}
	}
	public void Log(string message)
	{
		Console.WriteLine($"{SerialNumber} {DateTime.Now.ToString("HH:mm:ss.fff")} - {message}");
	}
}

public class SqlServerLockService : ILockService
{
	//const string DbConnectionString = "Data Source=.\\Dev;Integrated Security=SSPI;Initial Catalog=SwitchStream;Max Pool Size=200";
	const string DbConnectionString = "Server=tcp:xos-ss-shared-sql1-uks.database.windows.net,1433;Initial Catalog = xos-ss-shared-dev1-db; Persist Security Info=False;User ID = xosssserverspn; Password=cR0WZJHVh50H62I3ym4c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

	public async Task<IDisposable> LockAsync(string key)
	{
		var @lock = new SqlDistributedLock(name: key, connectionString: DbConnectionString);
		return await @lock.AcquireAsync().ConfigureAwait(false);
	}
}

public interface ILockService
{
	Task<IDisposable> LockAsync(string key);
}

public class BlobTester
{
	//var client = new BlobContainerClient("UseDevelopmentStorage=true","one-day-storage-pm");

	//BlobContainerClient Client;

	//public BlobTester(BlobContainerClient client)
	//{
	//	Client = client;
	//}

	//protected override IDistributedLock GetLockStrategy(string key)
	//{
	//	return new AzureBlobLeaseDistributedLock(Client, key);
	//}
}
