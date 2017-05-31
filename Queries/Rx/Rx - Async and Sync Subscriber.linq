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
	
	//o1.Subscribe(Console.WriteLine, ()=>"complete".Log());
	
	var o2 = GetObservable(101, 20);
	var o3 = GetObservable(201, 5);
	
	o1.Concat(o2).Concat(o3)
	.Buffer(10)
	.Subscribe(
		async l => { $"start {Thread.CurrentThread.ManagedThreadId}".Log(); l.Log(); await Task.Delay(5000); $"end {Thread.CurrentThread.ManagedThreadId}".Log();},
		() => "Completed".Log());

	o1.Concat(o2).Concat(o3)
	.Buffer(10)
	.Subscribe(
		l => { $"start {Thread.CurrentThread.ManagedThreadId}".Log(); l.Log(); Task.Delay(5000).Wait(); $"end {Thread.CurrentThread.ManagedThreadId}".Log(); },
		() => "Completed".Log());
}



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


public async Task<List<string>> Get(int start, int count)
{
	return await Task.Run(() => 
	{
		var list = new List<string>();
		for (var i = start; i < start + count; i++)
		{
			list.Add($"Returning request for {i}");
		}
		return list;
	} ) ;
}

public void ConcatExample()
{
	var s1 = Observable.Create<int>((o) => { "empty".Log(); o.OnCompleted(); return Disposable.Empty; });
	var s2 = Observable.Range(1, 35);
	var s3 = Observable.Range(1001, 15);


	s1.Concat(s2).Concat(s3)
	.Buffer(20)
	.Subscribe(
	Console.WriteLine,
	() => Console.WriteLine("Completed"));
}