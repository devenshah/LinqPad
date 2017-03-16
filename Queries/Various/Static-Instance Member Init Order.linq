<Query Kind="Program" />

public class Vehicle
{ 
	public int MaxSpeed;
	
	public static string Country;

	public Vehicle(int maxSpeed)
	{
		this.MaxSpeed = maxSpeed;
		Country = "UK";
	}
}

public class Car : Vehicle
{ 
	public string Transmission;

	public Car(int maxSpeed, string transmission) : base(maxSpeed)
	{
		this.MaxSpeed = 100;
		this.Transmission = transmission;
	}

	static Car()
	{
		Country = "USA";
	}
}

void Main()
{
	var car = new Car(200, "Manual");
	$"Max speed is {car.MaxSpeed}, Country is {Vehicle.Country}".WL();
}

// Define other methods and classes here
