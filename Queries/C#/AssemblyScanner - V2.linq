<Query Kind="Program" />

void Main()
{
	foreach (var type in AssemblyScanner.LoadTypesFromAllReferencedAssemblies().FindImplementerOf<IEnumerable>())
	{
		type.Name.Log();
	}
	
//	Assembly
//		.GetExecutingAssembly()
//		.GetReferencedAssemblies()
//		.Where(a => a.Name == "System.Core")
//		.Select(a => Assembly.Load(a))
//		.First().ExportedTypes
//		.ForEach<IEnumerable>()
//		.Log();

	
	
}

// Define other methods and classes here
public static class AssemblyScanner
{
	public static IEnumerable<Type> LoadTypesFromAllReferencedAssemblies()
	{
		var types = Assembly
			.GetExecutingAssembly()
			.GetReferencedAssemblies()
			.Select(Assembly.Load)
			.SelectMany(a => a.ExportedTypes);
		return types;
	}


	public static List<Type> LoadTypes(params string[] assemblyNames)
	{
		var types = new List<Type>();
		foreach (var assemblyName in assemblyNames)
		{
			var assembly = Assembly.Load(assemblyName);
			types.AddRange(assembly.ExportedTypes);
		}
		return types;
	}

	public static IEnumerable<Type> FindImplementerOf<T>(this IEnumerable<Type> types)
	{
		var matchingTypes = types.Where(IsAssignableTo<T>).Where(type => !type.IsInterface && !type.IsAbstract).ToList();
		foreach (var type in matchingTypes)
		{
			yield return type;
		}
	}

	private static bool IsAssignableTo<T>(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException(nameof(type));
		}

		return typeof(T).IsAssignableFrom(type);
	}
}