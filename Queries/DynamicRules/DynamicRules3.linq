<Query Kind="Program" />

void Main()
{
	
	var person = new Person();
	person.AddRule<LengthRule>().AddRule<RangeRule>().IsValid().Dump();
}

public static class PizzaMaker
{
	public static EntityBase AddRule<T>(this EntityBase entity) where T : BusinessRule
	{
		var br = Activator.CreateInstance<T>();
		br.Entity = entity;
		return br;
	}

}

public class Person : EntityBase
{
	public Person()
	{
	}
	
	public override bool IsValid()
	{
		return true;
	}
}

public class LengthRule : BusinessRule
{
	public LengthRule()
	{
	}
	
	public override bool IsValid()
	{
		return _entity.IsValid() && true;
	}

}

public class RangeRule : BusinessRule
{

	public RangeRule()
	{
	}
	
	public override bool IsValid()
	{
		return _entity.IsValid() && true;
	}

}

public class BusinessRule : EntityBase
{
	protected EntityBase _entity;
	public EntityBase Entity 
	{
		get { return _entity;}  
		set { _entity = value;}
	}
	
	public override bool IsValid()
	{
		return Entity.IsValid();
	}

}

public abstract class EntityBase
{
	public abstract bool IsValid();
	
}

