<Query Kind="Program">
  <Reference Relative="..\..\Queries\Work Related\CommitmentsClientApiConfiguration.json">C:\Deven\Git\LinqPad\Queries\Work Related\CommitmentsClientApiConfiguration.json</Reference>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{	
}

public static class MyExtensions
{
    public static T GetConfiguration<T>()
    {
        //Directory.GetCurrentDirectory().Dump();
        var typeName = typeof(T).Name;
        var config = Activator.CreateInstance(typeof(T));
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"{typeName}.json")
            .Build();
        //configuration.GetSection(typeName).GetChildren().Dump();
        return configuration.GetSection(typeName).Get<T>();
    }
    
    public static IConfigurationRoot GetAppSettings()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json")
            .Build();
    }
    
    public static void Log(this object value)
    {
        value.Dump();
    }
}


#region Advanced - How to multi-target

// The NET5 symbol can be useful when you want to run some queries under .NET 5 and others under .NET Core 3:

#if NET5
// Code that requires .NET 5 or later
#endif

#endregion