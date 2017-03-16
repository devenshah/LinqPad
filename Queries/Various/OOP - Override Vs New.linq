<Query Kind="Program" />

void Main()
{
	Pet myCat = new Cat();
	Cat JonhsCat = new Cat();
	Shape shape = new Ball();

	$"My {myCat.GetName()} is plaing with a {shape.GetName()}. John's {JonhsCat.GetName()} is sleeping".WL();
}

public class Shape
{
	public string GetName() => "Shape";
}

public class Ball: Shape
{
	public new string GetName() => "ball";
}


public class Pet
{
	public virtual string GetName() => "pet";
}

public class Cat : Pet
{
	public override string GetName() => "cat";
}
