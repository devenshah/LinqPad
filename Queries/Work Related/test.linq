<Query Kind="Program">
  <Namespace>static UserQuery</Namespace>
</Query>

void Main()
{
    var v = new Vacancy();
    v.GetFormattedId("123").Dump();
//    var h = new QueryViewTypeHelper<Vacancy>();
//    h.GetId("1234").Dump();
}

public class QueryViewTypeHelper<T> where T : BaseClass
{
   public string GetId(string value)
   {
        return $"{typeof(T).Name}_{value}";
   }
   
   public string GetId()
   {
        return typeof(T).Name;    
   }
}

public abstract class BaseClass
{
    public string IdFormat { get; }
    
    const string DefaultIdFormat = "{0}_{1}";
    public BaseClass(string format = DefaultIdFormat)
    {
        IdFormat = format;
    }    
}

public class Vacancy : BaseClass
{
}

public static class BaseClassExtension
{
    public static string GetFormattedId(this BaseClass obj, string value)
    {
        return string.Format(obj.IdFormat, obj.GetType().Name, value);
    }
    
    public static string GetTypeId(this BaseClass obj)
    {
        return obj.GetType().Name;
    }
}