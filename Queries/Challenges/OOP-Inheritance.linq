<Query Kind="Program" />

void Main()
{
	Pet p = new Cat();
	p.GetName().Dump();
}

public class Cat : Pet
{ 
	public new string GetName() => "Cat";
}
public class Pet
{ 
	public string GetName() => "pat";
}

// Define other methods and classes here