<Query Kind="Program" />

void Main()
{
	//TIPS and TRICKS
	//FormatPositiveAndNegativeNumbers();
	
	//UseYield(Enumerable.Range(1,10)).ToList().ForEach((x) => x.Log());
	//ToList() forces the enumeration to complete
	//foreach(var x in UseYield(Enumerable.Range(1,10))) x.Log();
	//foreach will process one item at a time as it enumerates
	
	UsePathToGetParentDirectory();
}

void UsePathToGetParentDirectory()
{
	var path = Path.Combine(@"c:\windows\system32","..");
	path.Log();
	Path.GetFullPath(path).Log();
}


void FormatPositiveAndNegativeNumbers()
{
	var format = "#.##;(-)#.##;NA";
	12.23.ToString(format).Log();
	(-3.04).ToString(format).Log();
	0.ToString(format).Log();
}

IEnumerable<int> UseYield(IEnumerable<int> numbers)
{
	foreach (var number in numbers)
	{
		if (number % 2 == 0)
		{
			$"{number} returned".Log();
			yield return number;
		}
		if (number == 8) break;
	}
}