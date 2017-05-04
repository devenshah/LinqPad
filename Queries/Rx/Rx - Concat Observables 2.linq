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

void Main()
{
	
	var o1 = Observable.Create<string>(o => { o.OnCompleted(); return Disposable.Empty; });
	//Synchronised concat
	//	var o2 = (new Generator()).GetObservable(1, 25);
	//	var o3 = (new Generator()).GetObservable(101, 15);
	//	o1.Concat(o2).Concat(o3).Buffer(10).Subscribe(Console.WriteLine, () => "Completed".Log());

	var gens = new[] { new Generator(), new Generator()};

	foreach (var gen in gens)
	{
		o1 = o1.Concat(gen.GetObservable(1,15));
	}
	
	var cancellationTokenSource = new CancellationTokenSource();
	o1.Buffer(10).Subscribe(Console.WriteLine, () => cancellationTokenSource.Cancel());

	while (!cancellationTokenSource.Token.IsCancellationRequested) {}
	
	"End of".Log();
}

public class Generator
{
	public IObservable<string> GetObservable(int start, int count)
	{
		return Observable.Create<string>(async (observer) =>
		{
			var list = await Get(start, count);
			list.ForEach(i =>
			{
				observer.OnNext(i);
			});
			observer.OnCompleted();
			return Disposable.Empty;
		});
	}

	async Task<List<string>> Get(int start, int count)
	{
		return await Task.Run(() =>
		{
			var list = new List<string>();
			for (var i = start; i < start + count; i++)
			{
				list.Add($"Returning request for {i}");
			}
			return list;
		});
	}
}

