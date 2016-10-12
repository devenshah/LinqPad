<Query Kind="Program" />

void Main()
{

	var entity = new MyEntity() { Name = "abcd", Age = 40};
	entity.Rule = entity.AddRule<LengthRule, MyEntity>(e => e.Name);
	
	entity.IsEntityValid().Dump();
	

}

public abstract class BaseEntity 
{
	public BusinessRule Rule { get; set; }
	
	public bool IsEntityValid()
	{
		return Rule.IsValid();
	}
	
}

public class MyEntity : BaseEntity
{
	public string Name { get; set; }
	
	public int Age { get; set; }
}

public static class Rulez
{
	
	public static TRule AddRule<TRule, T>(
		this BaseEntity entity, Expression<Func<T, object>> lambda) 
			where TRule : BusinessRule where T : BaseEntity
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
		var isValid = targetString.Length >= 1 && targetString.Length <= 5;
		return isValid;
	}
}

public class RangeRule : BusinessRule
{
	int _maxLength;
	int _minLength;
	int targetValue;
	
	public RangeRule(int maxLength, int minLength)
	{
		_minLength = minLength;
		_maxLength = maxLength;		
	}
	
	public RangeRule()
	{
		
	}
	
	public override bool IsValid()
	{
		targetValue = int.Parse(TargetProperty.GetValue(Entity) as string);
	
		return targetValue >= 10 && targetValue <= 100;
	}
}