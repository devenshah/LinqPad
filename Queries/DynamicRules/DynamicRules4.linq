<Query Kind="Program" />

void Main()
{
	
	var person = new Person();
	var br = person.Rule.AddRule<LengthRule>().AddRule<RangeRule>();
	person.IsEntityValid().Dump();
}

public static class PizzaMaker
{
	public static BusinessRules AddRule<T>(this BusinessRules rule) where T : BusinessRule
	{
		var rules = new BusinessRules();
		var br = Activator.CreateInstance<T>();
		rules.Rule = rule;
		return rules;
	}

}

public class Person : EntityBase
{
	public Person()
	{	
	}	
	
}

public class LengthRule : BusinessRule
{
	public LengthRule()
	{
	}
	
	public override bool IsValid()
	{
		return Rule.IsValid() && true;
	}

}

public class RangeRule : BusinessRule
{

	public RangeRule()
	{
	}
	
	public override bool IsValid()
	{
		return Rule.IsValid() && true;
	}

}

public class BusinessRules : BusinessRule
{

	public BusinessRule Rule {get; set;}
	
	public override bool IsValid()
	{
		return true;
	}

}

public abstract class BusinessRule
{
	public abstract bool IsValid();
}

public abstract class EntityBase
{
	public BusinessRules Rule { get; set; }
	
	public EntityBase()
	{
		Rule = new BusinessRules();
	}
	
	public bool IsEntityValid()
	{
		return Rule.IsValid();
	}
	
}

