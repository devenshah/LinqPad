<Query Kind="Program" />

void Main()
{
	int i = 10;
	Interlocked.Exchange(ref i, 1).WL();
	i.WL();
	
	int j = 1;
	Interlocked.Increment(ref j).WL();
	j.WL();
}

// Define other methods and classes here
