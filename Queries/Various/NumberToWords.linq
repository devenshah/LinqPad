<Query Kind="Program" />

void Main()
{
	//ForEachDigit(1234, i => i.Log());
	
	ToWords(5678).Dump();
}

string ToWords(int number)
{
	return string.Join(" ", number.ToString().ToCharArray().Select((n,i) => GetWord(n)));	
}

string GetWord(char i)
{
	switch (i)
	{
		case '0':
			return "zero";
		case '1':
			return "one";
		case '2':
			return "two";
		case '3':
			return "three";			
		case '4':
			return "four";
		case '5':
			return "five";
		case '6':
			return "six";
		case '7':
			return "seven";
		case '8':
			return "eight";
		case '9':
			return "nine";
		default:
			return string.Empty;
	}
}

void ForEachDigit(int i, Action<int> action)
{
	var number = i;
	while (number > 0)
	{
		var digit = (number % 10);
		action(digit);
		number = (number - digit) / 10;
	}
}

