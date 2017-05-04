<Query Kind="Program" />

void Main()
{
	$"String interpolation using lambda expression {((Func<string>) (() => "Hello World")).Invoke()}".Dump();

	$@"Hello { ((Func<string>)(() => { "What's your name?".Log(); return Console.ReadLine(); }))()}!".Dump();
	
	
}

// Define other methods and classes here
