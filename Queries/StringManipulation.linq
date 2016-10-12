<Query Kind="Program" />

void Main()
{
	GetStringPostLastInstanceOf("ABC DEF GHI", " ").Dump();
	GetStringPreFirstInstanceOf("ABC DEF GHI", " ").Dump();
	
	decimal d = 0.1m;	
	d.ToString("0.##").Dump();
}

private string GetStringPostLastInstanceOf(string sourceString, string instanceMatch)
{ 
	var lastIndex = sourceString.LastIndexOf(instanceMatch);
	return sourceString.Substring(lastIndex);
}

private string GetStringPreFirstInstanceOf(string sourceString, string instanceMatch)
{
	var firstIndex = sourceString.IndexOf(instanceMatch);
	return sourceString.Substring(0, firstIndex);
}
// Define other methods and classes here
