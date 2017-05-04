<Query Kind="Program">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.PlatformServices</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public class DataService
{
	private async Task<string> GetDataAsync(int id)
	{
		await Task.Delay(10);
		return $"Result for {id}";
	}

	public async Task<List<string>> GetDataAsync(long count)
	{
		var list = new List<string>();
		for (var i = 1; i <= count; i++)
		{
			var data = await GetDataAsync(i);
			list.Add(data);
		}
		return list;
	}
}

public class DataPacket
    {
	public int SequenceNumber { get; set; }
	public string Data { get; }
	public DataPacket(string data)
	{
		Data = data;
	}

	public override string ToString()
	{
		return $"{SequenceNumber}: {Data}";
	}
}


public static class Logger
{ 
	public static List<string> Logs = new List<string>();
}

public class DataGenerator
{
	public string Name { get; set; }
	public int Count { get; set; }
	public DataGenerator(string name, int count)
	{
		Name = name;
		Count = count;
	}
	public DataService _dataService = new DataService();

	public IObservable<DataPacket> DataPackets()
	{
		return Observable.Create<DataPacket>(async o =>
		{
			Logger.Logs.Add($"{Name} Invoked on threadId:{Thread.CurrentThread.ManagedThreadId}");
			var data = await _dataService.GetDataAsync(Count);
			foreach (var str in data)
			{
				var packet = new DataPacket($"{Name}-{str}");
				Logger.Logs.Add($"{Thread.CurrentThread.ManagedThreadId}:Gen-{packet.Data}");
				o.OnNext(packet);
			}
			o.OnCompleted();
			return Disposable.Empty;
		});
	}
}

public class RxAllTheWay
{
	private readonly DataGenerator[] _generators = 
	{ 
		new DataGenerator("Parent", 60), 
		new DataGenerator("Student", 295), 
		new DataGenerator("Address", 75), 
		new DataGenerator("Contact", 80) 
	};
	DataService _dataService = new DataService();
	
	public CancellationToken Main()
	{
		var cancellationTokenSource = new CancellationTokenSource();
		IObservable<DataPacket> observable = Observable.Create<DataPacket>(o => { o.OnCompleted(); return Disposable.Empty; });

		foreach (var generator in _generators)
		{
			observable = observable.Concat(generator.DataPackets());
		}

		var counter = 0;
		
		var targetList = new List<DataPacket>();
		
		observable
			.Do((cv) =>
				{
					var sequence = Interlocked.Increment(ref counter);
					cv.SequenceNumber = sequence;
				})
			.Buffer(100)
			.Subscribe(async (l) =>
			{
				if (!l.Any())
				{
					Log("wtf");
				}
				await Task.Run(() => {targetList.AddRange(l);});
				foreach (var a in l)
				{
					Log($"{Thread.CurrentThread.ManagedThreadId}:sub-{a.Data}");
					
				}
				//Console.WriteLine($"Subscription on threadId:{Thread.CurrentThread.ManagedThreadId}");
				Log($"count: {l.Count}");
			},
			async (ex) => await Task.Run(()=>Log(ex.Message)),
			async () =>
			{
				await Task.Run(() => {});
				Log($"Final counter : {counter}");
				cancellationTokenSource.Cancel();
				targetList.Dump();
				Logger.Logs.Dump();
			});

		
		return cancellationTokenSource.Token;

	}

//	public IObservable<DataPacket> Main1()
//	{
//		IObservable<DataPacket> observable = Observable.Create<DataPacket>(o => { o.OnCompleted(); return Disposable.Empty; });
//
//		foreach (var generator in _generators)
//		{
//			observable = observable.Concat(generator.DataPackets());
//		}
//
//		observable
//			.Buffer(100)
//			.Subscribe(async (l) =>
//			{
//				await Task.Delay(10);
//				Console.WriteLine($"Subscription on threadId:{Thread.CurrentThread.ManagedThreadId}");
//				Log($"count: {l.Count}");
//			});
//
//		return observable;
//		
//
//	}

	void Log(string msg)
	{
		Logger.Logs.Add(msg);
	}

}

void Main()
{
	//new RxAllTheWay().Main1().Wait();
	var cancellationToken = (new RxAllTheWay()).Main();

	while (!cancellationToken.IsCancellationRequested) { }

	Logger.Logs.Add("############# End of #################");
}