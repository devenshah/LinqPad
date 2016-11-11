<Query Kind="Program">
  <NuGetReference>Unity.Interception</NuGetReference>
  <Namespace>Microsoft.Practices.ObjectBuilder2</Namespace>
  <Namespace>Microsoft.Practices.ServiceLocation</Namespace>
  <Namespace>Microsoft.Practices.Unity</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration</Namespace>
  <Namespace>Microsoft.Practices.Unity.Configuration.ConfigurationHelpers</Namespace>
  <Namespace>Microsoft.Practices.Unity.InterceptionExtension</Namespace>
  <Namespace>Microsoft.Practices.Unity.InterceptionExtension.Configuration</Namespace>
  <Namespace>Microsoft.Practices.Unity.ObjectBuilder</Namespace>
  <Namespace>Microsoft.Practices.Unity.StaticFactory</Namespace>
  <Namespace>Microsoft.Practices.Unity.Utility</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType<IPersonService, EmployeeService>();
	//container.IsRegistered(typeof(IPersonService)).Dump();
	var svc = container.Resolve<IPersonService>();
	svc.GetName().Dump();
	
	var emp = new EmployeeService("ganta");
	container.RegisterInstance<IPersonService>(emp);
	
	var svc1 = container.Resolve<IPersonService>();
	
	svc1.GetName().Dump();
	
}

public class Person { }

public interface IPersonService
{ 
	string GetName();
}

public class EmployeeService : IPersonService
{
	private readonly string _name;
	
	[InjectionConstructor]
	public EmployeeService()
	{
		_name = "Employee Service";
	}
	
	public EmployeeService(string name)
	{
		_name = name;
	}
	
	public string GetName() 
	{
		return _name;
	}
}

