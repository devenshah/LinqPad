<Query Kind="Program" />

abstract class Animal
{
	internal string Name { get; set; }
}

class Cat : Animal
{
	public Cat()
	{
		Name = "Cat";
	}
}

class Dog : Animal
{
	public Dog()
	{
		Name = "Dog";
	}
}


void Main()
{
	var covariance = new List<Cat> { new Cat() };
	PrintNames(covariance);
}

void PrintNames(IEnumerable<Animal> animals)
{
	foreach (var animal in animals) animal.Name.Log();
}

