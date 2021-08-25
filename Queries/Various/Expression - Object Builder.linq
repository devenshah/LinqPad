<Query Kind="Program" />

void Main()
{
	var p = new Person();
	p.WithPropertyValue(a => a.FirstName, "Deven").WithPropertyValue(a => a.LastName, "Shah").ToString().Dump();
	p.WithPropertyValue(a => a.FirstName, "Suman").ToString().Dump();
	p.WithPropertyValue(a => a.Id, long.MaxValue).ToString().Dump();
}


public static class Extensions
{
	public static T WithPropertyValue<T, TProperty>(this T obj, Expression<Func<T, TProperty>> expression, TProperty value) where T : class
	{
		if (expression == null) throw new ArgumentNullException(nameof(expression));
		var propertyInfo = ((expression.Body as MemberExpression).Member as PropertyInfo);
		propertyInfo.SetValue(obj, value);
		return obj;
	}
}


public class Person
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public override string ToString()
	{
		return $"{FirstName} {LastName}";
	}
}