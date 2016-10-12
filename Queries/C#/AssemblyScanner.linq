<Query Kind="Program" />

void Main()
{
	var assemblyScanner = new AssemblyScanner(typeof(ISeedData).Assembly.FullName);
	assemblyScanner.ForEach<ISeedData>(seeder => seeder.Seed());
}

public interface ISeedData { void Seed(); }

public class AssemblyScanner
{
	private readonly List<Type> _types;

	public AssemblyScanner(params string[] assemblyNames)
	{
		_types = new List<Type>();
		foreach (var assemblyName in assemblyNames)
		{
			var assembly = Assembly.Load(assemblyName);
			_types.AddRange(assembly.ExportedTypes);
		}
	}

	public void ForEach<T>(Action<T> action)
	{
		var types = _types.Where(IsAssignableTo<T>).Where(type => !type.IsInterface && !type.IsAbstract).ToList();
		foreach (var type in types)
		{
			var instance = Activator.CreateInstance(type);
			action((T)instance);
		}
	}

	private static bool IsAssignableTo<T>(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}

		return typeof(T).IsAssignableFrom(type);
	}
}
