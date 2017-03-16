<Query Kind="Program">
  <Connection>
    <ID>60408c34-3117-44f3-909d-bba77b66afde</ID>
    <Server>etech-dev01</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8JEdqNgoLEKFrbDwxk5wUgAAAAACAAAAAAADZgAAwAAAABAAAADRyYe4ia2HQxFuFkTq62t5AAAAAASAAACgAAAAEAAAAF2N0QU/OLRKMrr9YS/jJt4QAAAAykMZSyropwoSpYbjs6AqAxQAAAD+zUzq6Vt/7kizl6VoEEzya5DU8Q==</Password>
    <Database>SPHEC_DS_Dev</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <NuGetReference>Rx-Main</NuGetReference>
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
	Console.WriteLine("xcfgfds");
	GetData().Select(lot => {
		if (lot != null)
		{
			Console.WriteLine(lot.ToString());
			Console.WriteLine(lot.LotName);
		}
		return Observable.Return(lot);
	}).Subscribe();
}

private IObservable<Lot> GetData()
{
	return (from x in Lots
				where x.PkLotId == 87
				select x)
				.ToObservable()
				.Do(m => 
				{ 
					//only comes to this point if the query gets back any results
					Console.WriteLine("dsdddd");
				}).Select(l => l);
}