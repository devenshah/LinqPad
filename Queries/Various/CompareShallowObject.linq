<Query Kind="Program" />

void Main()
{
//	IsValueEqualTo(null,123);
//	
//	IsValueEqualTo(null,null);
//	
//	IsValueEqualTo("kjhkj",123);
//	
//	IsValueEqualTo("daf","daf");
//	
//	IsValueEqualTo(123,123);	
//	
//	var d1 = DateTime.Now;
//	var d2 = DateTime.Now.AddMilliseconds(1);		
//	
//	IsValueEqualTo(d1, d2);
	
	//TargetException
	//CompareShallowObjects(new Person(){Name="Deven", Age=40}, new Car(){Name="Deven", Age=40});
	
	CompareShallowObjects(new Person(){Name="Deven", Age=40}, new Person(){Name="Deven", Age=null});
	
	
}

public class Person
{
	public string Name { get; set; }
	public int? Age { get; set; }
}

public class Employee : Person
{
	public int EmployeeId { get; set; }
	
	public decimal Salary { get; set; }
}

public class Car
{
	public string Name { get; set; }
	public int Age { get; set; }
}

public class ChangeLog
    {
        public ChangeLog()
        {

        }
        public ChangeLog(string propertyName, string oldValue, string newValue)
        {
            PropertyName = propertyName;
            NewValue = newValue;
            OldValue = oldValue;
        }

        public string PropertyName { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }

    }
	
 public static bool IsSimpleType(Type type)
        {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[] 
                { 
				    typeof(String),
				    typeof(Decimal),
				    typeof(DateTime),
				    typeof(DateTimeOffset),
				    typeof(TimeSpan),
				    typeof(Guid)
			    }.Contains(type);
        }
public static bool CompareShallowObjects(object oldObject, object newObject)
        {
            var result = true;
            if (oldObject == null || newObject == null)
            {
                throw new ArgumentNullException("Both the parameters are required for comparison");
            }


			if (oldObject.GetType().Equals(newObject.GetType()) == false)
			{
				throw new ArgumentException("Objects to compare, should be of the same type");
			}

            var Changes = new List<ChangeLog>();




            Type objectType;

            objectType = oldObject.GetType();

            var properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && IsSimpleType(p.PropertyType));
            foreach (PropertyInfo propertyInfo in properties)
            {

                var oldValue = propertyInfo.GetValue(oldObject, null) ?? "NULL";
                var newValue = propertyInfo.GetValue(newObject, null) ?? "NULL";

                if (IsValueEqualTo(oldValue, newValue) == false)
                {
                    result = false;
                    Changes.Add(new ChangeLog (propertyInfo.Name, oldValue.ToString(), newValue.ToString()));
                    Debug.WriteLine("Mismatch with property '{0}.{1}' found.", objectType.FullName, propertyInfo.Name);
                }
            }
            
			Changes.Dump();
            return result;
        }

public static bool IsValueEqualTo(object valueA, object valueB)
{
  bool result;
  IComparable selfValueComparer;

  selfValueComparer = valueA as IComparable; 

	if (valueA == null || valueB == null)  
	{
		Console.WriteLine("Failed null check");
		result = false; // one of the values is null		
	}	
	else if (valueA.GetType().IsAssignableFrom(valueB.GetType()) == false)
	{
		Console.WriteLine("Failed type check");
		result = false; 
	}
	else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
	{
		Console.WriteLine("Failed IComparable check");
		result = false; // the comparison using IComparable failed
	}
	else if (!object.Equals(valueA, valueB))
	{
		Console.WriteLine("Failed value check");
		result = false; // the comparison using Equals failed
	}
	else
	{
		Console.WriteLine("Values are equal");
		result = true; // match
	}

  return result;
}
		