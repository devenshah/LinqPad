<Query Kind="Program" />

public class MySingleton
{
	//only one thread can be in the static initializer 
	//hence an instance is created thread safely
	private static readonly Lazy<MySingleton> lazyInstance = new Lazy<MySingleton>(() => new MySingleton());
	
	//Empty static constructor - forces laziness!
	//forces CLR to create instance before the first use
	//without this the instace will already be created
	static MySingleton() {}
	
	//to override default public constructor
	private MySingleton() { Console.WriteLine("singleton constructor");}
	
	public static MySingleton Instance { get { return lazyInstance.Value; }}
	
	//Following method will be called without instanciation
	public static void DoSomething()
	{
		Console.WriteLine("doing something!!");
	}	
}

void Main()
{
	Console.WriteLine("start of test");
	MySingleton.DoSomething();
	var instance = MySingleton.Instance;
}