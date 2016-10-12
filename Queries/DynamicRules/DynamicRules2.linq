<Query Kind="Program" />

void Main()
{

	var entity = new MyEntity() { Foo = "ab"};
	var rule = entity.AddRule<LengthRule, MyEntity>(e => e.Foo);
	rule.IsValid().Dump();
	

}

public abstract class BaseEntity 
{
	public BusinessRule Rule { get; set; }
	
}

public class MyEntity : BaseEntity
{
	public string Foo { get; set; }
}

public static class Rulez
{
	
	public static TRule AddRule<TRule, T>(this BaseEntity entity, Expression<Func<T, object>> lambda) where TRule : BusinessRule where T : BaseEntity
	{
		var rule = Activator.CreateInstance<TRule>();
		rule.Entity = entity;
		rule.TargetProperty = GetPropertyName<T>(lambda);
		return rule;
	}
	
	public static PropertyInfo GetPropertyName<T>(Expression<Func<T, object>> lambda)
	{
		var member = lambda.Body as MemberExpression;
		return member.Member as PropertyInfo;
	}
}

public abstract class BusinessRule 
{
	public BusinessRule()
	{
		
	}	
	
	public BaseEntity Entity {get; set;}
	
	public PropertyInfo TargetProperty { get; set; }
	
	public abstract bool IsValid();
	
}

public class LengthRule : BusinessRule
{
	int _maxLength;
	int _minLength;
	string targetString;
	
	public LengthRule(int maxLength, int minLength)
	{
		_minLength = minLength;
		_maxLength = maxLength;		
	}
	
	public LengthRule()
	{
		
	}
	
	public override bool IsValid()
	{
		targetString = TargetProperty.GetValue(Entity) as string;
	
		return targetString.Length >= 1 && targetString.Length <= 2;
	}
}