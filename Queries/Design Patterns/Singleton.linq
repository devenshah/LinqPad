<Query Kind="Program" />

//http://csharpindepth.com/Articles/General/Singleton.aspx
void Main()
{
	
}

public class SimpleSingleton
{
	private static readonly SimpleSingleton _instance = new SimpleSingleton();		

	private SimpleSingleton() { }

	public static SimpleSingleton Instance
	{
		get
		{
			return _instance;
		}
	}
}

public class LazySingleton
{ 
	private static readonly Lazy<LazySingleton> _lazyInstance = 
		new Lazy<LazySingleton>(() => new LazySingleton(), true);
	
	private LazySingleton() {}
	
	public static LazySingleton Instance
	{
		get 
		{
			return _lazyInstance.Value;
		}
	}
}

