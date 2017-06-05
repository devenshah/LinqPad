<Query Kind="Program" />

void Main()
{
	Compress("aabbccccdd").Log();
}


string Compress(string str)
{
	var output = string.Empty;
	var arr = str.ToCharArray();
	var previousChar = arr[0];
	var charCount = 0;
	for (var i = 0; i < arr.Length; i++)
	{
		var currentChar = arr[i];
		if (previousChar == currentChar)
		{
			charCount++;
		}
		else
		{
			output += previousChar;
			output += charCount > 1 ? charCount.ToString() : string.Empty;
			previousChar = currentChar;
			charCount = 1;
		}
	}
	output += previousChar;
	output += charCount > 1 ? charCount.ToString() : string.Empty;
	return output;
}