<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Unity</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterType<IApp, App>();
	container.RegisterType<ITemp, Temp>();
	
	var app = container.Resolve<IApp>();
	
	app.Do();
	
	app.Do();
}


public interface ITemp
{
	Guid Id { get;}
}

public class Temp : ITemp
{ 
	public Guid Id { get; } 
	public Temp()
	{
		Id = Guid.NewGuid();
	}
}

public interface IApp
{	
	Guid Id { get; }
	void Do();
}

public class App : IApp
{
	public Guid Id { get; } = Guid.NewGuid();
	readonly Lazy<ITemp> _temp;
	
	public App(Lazy<ITemp> temp)
	{
		_temp = temp;
	}
	
	public void Do()
	{
		_temp.Value.Id.Dump();
	}
}