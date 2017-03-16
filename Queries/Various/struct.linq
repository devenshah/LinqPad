<Query Kind="Program" />

void Main()
{
	MyType m = new MyType();
	m.Name = "dfgbh";
	
	new Test<MyType>().Print(m);
}

public class Test<T> where T : struct
{
	public Test(){}
	
	public void Print(T value)
	{
		Console.WriteLine(value.ToString());
	}
}

public struct MyType
{
	public MyType(string name)
	{
		Name =  name;
	}
	
	public string Name {get; set;}
	
	public override string ToString()
	{
		return Name.ToUpper();
	}
}