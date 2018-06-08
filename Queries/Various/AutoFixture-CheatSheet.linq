<Query Kind="Program">
  <NuGetReference>AutoFixture.AutoMoq.AutoSetup</NuGetReference>
  <Namespace>Ploeh.AutoFixture</Namespace>
</Query>

Fixture fixture = new Fixture();
void Main()
{
	
//	fixture.Create<int>().Log();
//	fixture.Create<string>().Log();
//	fixture.Create<Guid>().Log();

	//fixture.Build<MyClass>().With(x => x.MyProperty, 10).With(x => x.Person.Name, "Deven").Create().Log();
	
//	fixture.Create<MyClass>().Log(); //Create One instance
//	
//	fixture.CreateMany<MyClass>(5).Log(); //Create many instance
	
    fixture.CreateMany<Byte>(10).Log();
}

void AddToList()
{
    var list = new List<string>();
    fixture.AddManyTo(list);
    list.Log();
}

public class MyClass
{
	public int MyProperty { get; set; }
	public Person Person { get; set; }
}