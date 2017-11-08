<Query Kind="Program">
  <NuGetReference>AutoFixture.AutoMoq.AutoSetup</NuGetReference>
  <Namespace>Ploeh.AutoFixture</Namespace>
</Query>

void Main()
{
	var fixture = new Fixture();

	//fixture.Build<MyClass>().With(x => x.MyProperty, 10).With(x => x.Person.Name, "Deven").Create().Log();
	
	fixture.Create<MyClass>().Log();
	
	fixture.CreateMany<MyClass>(5).Log();
	
	var list = new List<string>();	
	fixture.AddManyTo(list);
	list.Log();
}

public class MyClass
{
	public int MyProperty { get; set; }
	public Person Person { get; set; }
}
