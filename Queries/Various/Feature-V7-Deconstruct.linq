<Query Kind="Program" />

void Main()
{
	var today = DateTime.Today;

	var (x, y, z) = today;
	$"{x}-{y}-{z}".Dump();
}

static class Extension
{ 
	public static void Deconstruct(this DateTime value, out int month, out int day, out int year)
	{
		day = value.Day;
		month = value.Month;
		year = value.Year;
	}
}
// Define other methods and classes here
