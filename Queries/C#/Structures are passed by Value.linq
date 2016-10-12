<Query Kind="Program" />

public static void ChangeTheString(string weather) { weather = "Sunny"; }
public static void ChangeTheArray(string[] rainDays) { rainDays[1] = "Sunday"; }
public static void ChangeTheStructure(Forecast forecast) { forecast.Temperature = 35; }

static void Main(string[] args)
{
	string weather = "rainy";
	ChangeTheString(weather);
	$"The weather is {weather}".WL();
	

	string[] rainyDays = new[] {"Monday", "Friday"};
	ChangeTheArray(rainyDays);
	$"The rainy days  were on {string.Join(",", rainyDays)}".WL();

	var forecast = new Forecast {Pressure=700, Temperature=20};
	ChangeTheStructure(forecast);
	$"The temperature is {forecast.Temperature}".WL();
}

public struct Forecast
{
	public int Temperature { get; set; }

	public int Pressure { get; set; }
}