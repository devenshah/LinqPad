<Query Kind="Program">
  <Connection>
    <ID>9d163a45-8c54-4ee3-8417-d1a85b87cc50</ID>
    <Persist>true</Persist>
    <Server>localsql</Server>
    <Database>SmartPropertyHubEC.Database</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Core.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Interfaces.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Linq.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.PlatformServices.dll</Reference>
  <Namespace>System</Namespace>
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
	//
	//Observable.Create<string>(observer => 
	//{
	//   (from x in Lots
	//   select x.LotName).ToList().ForEach(s => observer.OnNext(s));
	//   observer.OnCompleted();
	//   return Disposable.Empty;
	//})
	//.Do(y => Console.WriteLine(y))
	//.Concat( Observable.Create<string>(obs => {return Disposable.Empty;}).Do(y => Console.WriteLine(y));
	
	
//	Observable.Create<string>(observer => 
//	{
//	   (from x in JobStatuses
//	   select x.StatusDescription).ToList().ForEach(s => observer.OnNext(s));
//	   observer.OnCompleted();
//	   return Disposable.Empty;
//	})
//	.Concat(Observable.Create<string>(obs => {obs.OnNext("dd"); obs.OnCompleted(); return Disposable.Empty;}))
//	.Do(y => Console.WriteLine(y)).Subscribe();
	
	var mystring = new MyClass("dev");
	Observable.Create<MyClass>(observer => { mystring.name = mystring.name + "en"; observer.OnCompleted(); return mystring;})
	.Concat(Observable.Create<MyClass>(oo => {mystring.surname=" shah"; oo.OnNext(mystring); oo.OnCompleted(); return mystring;}))
	.Do(y => Console.WriteLine(y.name+ mystring.surname))
	.Subscribe();
	//x => {Console.WriteLine(mystring.name);},  z => {Console.WriteLine(mystring.name);}

Console.WriteLine(mystring.name + mystring.surname);
	
}

public class MyClass : IDisposable
{
	public MyClass(string name)
	{
		this.name = name;
	}
	public string name {get; set;}
	public string surname {get; set;}
	
	public void Dispose(){}
}

// Define other methods and classes here
