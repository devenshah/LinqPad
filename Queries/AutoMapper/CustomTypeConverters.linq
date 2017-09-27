<Query Kind="Program">
  <NuGetReference>AutoMapper</NuGetReference>
  <Namespace>AutoMapper</Namespace>
  <Namespace>AutoMapper.Configuration</Namespace>
  <Namespace>AutoMapper.Configuration.Conventions</Namespace>
  <Namespace>AutoMapper.Execution</Namespace>
  <Namespace>AutoMapper.Mappers</Namespace>
  <Namespace>AutoMapper.QueryableExtensions</Namespace>
  <Namespace>AutoMapper.QueryableExtensions.Impl</Namespace>
</Query>

public class NullIntTypeConverter : ITypeConverter<string, int?>
{
	public int? Convert(string source, int? destination, ResolutionContext context)
	{
		int i;
		if ((string.IsNullOrWhiteSpace(source)) || (!int.TryParse(source, out i)))
			return null;
		return i;
	}
}

public class IntToEnumConverter<T> : ITypeConverter<int, T>
{
	public T Convert(int source, T destination, ResolutionContext context)
	{
		if (!typeof(T).IsEnum) throw new Exception("Only Enum types are allowed.");
		
		var name = Enum.GetName(typeof(T), source);
		if (name != null) return (T)Enum.Parse(typeof(T), name);
		
		var en = Enum.GetValues(typeof(T)).GetEnumerator();
		en.MoveNext();
		return (T)en.Current;
	}
}

void Main()
{
	TestMapping();
}

void TestMapping()
{
	Mapper.Initialize(cfg =>
	{
		cfg.CreateMap<string, int?>()
			.ConvertUsing(new NullIntTypeConverter());
		cfg.CreateMap<int, Gender>()
			.ConvertUsing(new IntToEnumConverter<Gender>());
		cfg.CreateMap<int, DayOfWeek>()
			.ConvertUsing(new IntToEnumConverter<DayOfWeek>());
		cfg.CreateMap<SourceObject, DestinationObject>();
	});

	var source = new SourceObject { Age = "1", Gender = 1, FirstDayOfWeek=5 };
	Mapper.Map<DestinationObject>(source).Dump();
	var source1 = new SourceObject { Age = "", Gender = 2, FirstDayOfWeek =10 };
	Mapper.Map<DestinationObject>(source1).Dump();
	var source2 = new SourceObject { Age = "", Gender = 5, FirstDayOfWeek =0 };
	Mapper.Map<DestinationObject>(source2).Dump();
}


public class SourceObject
{
	public string Age { get; set; }
	public int? Gender { get; set;}
	public int? FirstDayOfWeek { get; set; }
}

public class DestinationObject
{
	public int? Age { get; set;}
	public Gender Gender { get; set; }
	public DayOfWeek FirstDayOfWeek { get; set;}
}

public enum Gender
{ 
	Other = 0,
	Female = 1,
	Male = 2
}

public enum DayOfWeek
{ 
	NoneSpecified = 0,
	Sunday = 1,
	Monday = 2,
	Tuesday = 3,
	Wednesday = 4,
	Thursday = 5,
	Friday = 6,
	Saturday = 7 
}