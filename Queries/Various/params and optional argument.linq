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
	Console.WriteLine(format("d{0}v{0}n", " shah", "e"));
	Console.WriteLine(format("d{0}v{0}n", "e"));
}

string format(string str1, string str2 = "", params string[] args)
{
	Console.WriteLine(str1 + str2);
	
	Console.WriteLine((args == null).ToString() + "--" + args.Length.ToString() + "--");
	var msg = args.Length > 0 ? string.Format(str1, args) : str1;
	return msg + str2;
}

// Define other methods and classes here
