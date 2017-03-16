<Query Kind="Program">
  <NuGetReference>Unity</NuGetReference>
  <Namespace>Unity</Namespace>
</Query>

void Main()
{
	var container = new UnityContainer();
	container.RegisterInstance<IApp>(new App());
	
	var scope1 = container.CreateChildContainer();
	scope1.RegisterType<ITemp, Temp>(new ContainerControlledLifetimeManager());	
	var temp1_1 = scope1.Resolve<ITemp>();
	var temp1_2 = scope1.Resolve<ITemp>();
	scope1.Resolve<IApp>().Id.Log();
	object.ReferenceEquals(temp1_1, temp1_2).Dump($"Temp1{temp1_1.Id}");

	var scope2 = container.CreateChildContainer();
	scope2.RegisterType<ITemp, Temp>(new ContainerControlledLifetimeManager());	
	var temp2_1 = scope2.Resolve<ITemp>();
	var temp2_2 = scope2.Resolve<ITemp>();
	scope2.Resolve<IApp>().Id.Log();
	object.ReferenceEquals(temp2_1, temp2_2).Dump($"Temp2{temp1_1.Id}");

	scope1 = container.CreateChildContainer();
	scope1.RegisterType<ITemp, Temp>(new ContainerControlledLifetimeManager());
	temp1_1 = scope1.Resolve<ITemp>();
	temp1_2 = scope1.Resolve<ITemp>();
	scope1.Resolve<IApp>().Id.Log();
	object.ReferenceEquals(temp1_1, temp1_2).Dump($"Temp1{temp1_1.Id}");


}


public interface ITemp
{
	Guid Id { get;}
}

public class Temp : ITemp
{ 
	public Guid Id { get; } = Guid.NewGuid();
}

public interface IApp
{
	Guid Id { get; }
}

public class App : IApp
{
	public Guid Id { get; } = Guid.NewGuid();
}

