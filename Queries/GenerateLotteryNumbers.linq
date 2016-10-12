<Query Kind="Program" />

void Main()
{
	var results = generateRandomUniqueNumbers(1, 15, 3);
	
	WL("And the numbers are ...");
	WL(string.Empty);
	WL(string.Empty);
	foreach (var number in results)
	{
		Thread.Sleep(2000);
		Console.Write(string.Format("{0}    ", number));
	}
}

private IList<int> generateRandomUniqueNumbers(int min, int max, int numbersToGenerate)
{
	var result = new List<int>();
	if (numbersToGenerate > max || max <= min)
	{
		throw new ArgumentException("Invalid arguments. Max value should be greater than min value and Numbers to Generate must not exceed Max Value");
	}
	
	var listOfNumbers = Enumerable.Range(min,max).ToList();
	
	var rangeCount = listOfNumbers.Count;
	var numberGenerator = new Random();
	for (var i=0; i<numbersToGenerate; i++)
	{
		var minValue = 1;
		var maxValue = listOfNumbers.Count();
		var randomIndex = numberGenerator.Next(minValue, maxValue);
		var numberAtIndex = listOfNumbers[randomIndex-1];
		//WL(string.Format("Randomly Generated Index: {0}", randomIndex));
		//WL(string.Format("Actual number on the Index: {0}", numberAtIndex));
		result.Add(numberAtIndex);
		listOfNumbers.RemoveAt(randomIndex-1);		
		//listOfNumbers.Dump();
	}
	return result;
}

void WL(object obj)
{
	Console.WriteLine(obj);
}


// Define other methods and classes here