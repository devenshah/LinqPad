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
		var obs1 = (from x in LookupCountries
		where x.ItemDescription.Contains("England11")
		select x.ItemDescription)
		.ToObservable();
		
		var obs2 = (from x in LookupCountries
					where x.ItemDescription.Contains("Scot11")
					select x.ItemDescription)
					.ToObservable();

		
		Observable.Amb(obs2, obs1).Subscribe(s => Console.WriteLine(s));
}

// Define other methods and classes here
