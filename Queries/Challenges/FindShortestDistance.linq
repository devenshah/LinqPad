<Query Kind="Program" />

void Main()
{
	var arr = new int[] {4,4,1,3,2,58,57,56,32,31,34,35}; 
	var sortedArr = arr.Skip(1).OrderBy(a => a).ToArray();
	var shortestDistance = findShortestDistance(sortedArr);
	PrintNumbersWithShortestDistance(sortedArr, shortestDistance).Log();
}

static int findShortestDistance(int[] sortedArr)
{	
	var shortestDiff = sortedArr.OrderByDescending(a => a).First();
	var previous = sortedArr[0];
	for (var i = 1; i < sortedArr.Length; i++)
	{
		var next = sortedArr[i];
		var diff = next - previous;
		shortestDiff = diff < shortestDiff ? diff : shortestDiff;
		previous = next;
	}	
	return shortestDiff;
}

static string PrintNumbersWithShortestDistance(int[] arr, int distance)
{
	var output = string.Empty;
	var previous = arr[0];
	for (var i = 1; i < arr.Length; i++)
	{
		var next = arr[i];
		if (next - previous == distance)
		{
			output += $"{previous} {next} ";
		}
		previous = next;
	}
	return output;
}