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
</Query>

void Main()
{
	GetData();

}

void GetData()
{
	var client = new RestClient("http://localhost:2525/api/values/1");
	var request = new RestRequest("",Method.GET);
	var response = client.Execute(request);
	response.Content.Dump();
}