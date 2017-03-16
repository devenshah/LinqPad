<Query Kind="Program" />

void Main()
{
	Pizza largePizza = new LargePizza();
	largePizza = new Cheese(largePizza);
	largePizza = new Pepper(largePizza);
	largePizza.GetDescription().Dump();
	largePizza.CalculateCost().Dump();
	
	Pizza myPizza = new LargePizza();
	myPizza.AddToppings<Cheese>().AddToppings<Pepper>().CalculateCost().Dump();
}

public abstract class Pizza
{
	public string Description { get; set; }
	
	public abstract string GetDescription(); 
	
	public abstract double CalculateCost();
	
}


public class LargePizza : Pizza
{
	public LargePizza()
	{
		Description = "Large Pizza";
	}
	
	public override string GetDescription()
	{
		return Description;
	}
	
	public override double CalculateCost()
	{
		return 10.00;
	}
}

public class PizzaDecorator : Pizza
{
	protected Pizza _pizza;
	public Pizza Pizza 
	{
		get { return _pizza;}  
		set { _pizza = value;}
	}
	
	public PizzaDecorator()
	{
		
	}
	
	public PizzaDecorator(Pizza pizza)
	{
		_pizza = pizza;
	}
	
	public override string GetDescription()
	{
		return _pizza.Description;
	}
	
	public override double CalculateCost()
	{
		return _pizza.CalculateCost();
	}

}

public static class PizzaMaker
{
	public static Pizza AddToppings<T>(this Pizza pizza) where T : PizzaDecorator
	{
		var pd = Activator.CreateInstance<T>();
		pd.Pizza = pizza;
		return pd;
	}

}

public class Cheese : PizzaDecorator
{
	public Cheese()
	{
		
	}
	
	public Cheese(Pizza pizza) : base(pizza)
	{
		Description = "cheese";
	}
	
	public override string GetDescription()
	{
		return _pizza.GetDescription() + "," + Description;
	}
	
	public override double CalculateCost()
	{
		return _pizza.CalculateCost() + 1.50;
	}

}

public class Pepper : PizzaDecorator
{

	public Pepper()
	{
			
	}
	public Pepper(Pizza pizza) : base(pizza)
	{
		Description = "pepper";
	}
	
	public override string GetDescription()
	{
		return _pizza.GetDescription() + "," + Description;
	}
	
	public override double CalculateCost()
	{
		return _pizza.CalculateCost() + 1.00;
	}

}


