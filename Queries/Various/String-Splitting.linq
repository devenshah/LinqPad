<Query Kind="Program" />

void Main()
{
	var sb = new StringBuilder();
	"1, 2, , 3".Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(s => $"abc.{s.Trim()}").Log();
	//sb.ToString().TrimEnd(',').Log();
}

// Define other methods and classes here
