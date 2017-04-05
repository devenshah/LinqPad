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
</Query>

void Main()
{
	GetDataPackets()
		.Buffer(100)		
		.Select(numbers =>
		{
			var str = $"Numbers from {numbers.Min()} - {numbers.Max()}";
			str.Log();
			return str;
		}).ToList().Dump();
}

// Define other methods and classes here
IObservable<int> GetDataPackets()
{
	return Observable.Create<int>(o =>
	{
		var ms = DateTime.Now.Millisecond;
		ms.Log();
		for (var i = 1; i <= ms; i++)
		{
			if((i % 80) == 0) i.Log();
			o.OnNext(i);
		}
		o.OnCompleted();
		return Disposable.Empty;
	});
}