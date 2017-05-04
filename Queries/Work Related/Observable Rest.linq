<Query Kind="Program">
  <NuGetReference>RestSharp</NuGetReference>
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>RestSharp</Namespace>
  <Namespace>RestSharp.Authenticators</Namespace>
  <Namespace>RestSharp.Authenticators.OAuth</Namespace>
  <Namespace>RestSharp.Deserializers</Namespace>
  <Namespace>RestSharp.Extensions</Namespace>
  <Namespace>RestSharp.Extensions.MonoHttp</Namespace>
  <Namespace>RestSharp.Serializers</Namespace>
  <Namespace>RestSharp.Validation</Namespace>
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
	var str = GetData().Result;

	
}

async Task Subscriber()
{
	await GetDataPackets()
		.Buffer(100)
		.ForEachAsync(l => l.Count.Dump())
}

async Task<string> GetData()
{
	var client = new RestClient("http://localhost:2525/api/values/1");
	var request = new RestRequest("",Method.GET);
	var response = await client.ExecuteGetTaskAsync(request);
	response.Content.Dump();
	return response.Content;
}

IObservable<string> GetDataPackets()
{
	return Observable.Create<string>(
	async o => 
	{
		var ms = 9999;
		for (var i = 1; i <= ms; i++)
		{
			var data = await GetData();
			o.OnNext(data);
		}
		o.OnCompleted();
		return Disposable.Empty;
	});
}