<Query Kind="Program" />

void Main()
{
//	IsPalindrome("abab").Log();
//	IsPalindrome("ababa").Log();
//	IsPalindrome("aaaa").Log();
//	IsPalindrome("aaaabb").Log();
//	IsPalindrome("aabbbbaa").Log();
//	IsPalindrome("aa").Log();
//	IsPalindrome("aba").Log();
//	IsPalindrome("a").Log();

	Take("abcdefedc");

}

void Take(string s)
{
	var count = 0;
	var x = s;
	var r = string.Join("", s.ToCharArray().Reverse());
	while (true)
	{
		if (IsPalindrome(x))
		{
			count.Log();
			break;
		}
		count++;
		x = s.Substring(0,count) + r;
		x.Log();
	}	
}

bool IsPalindrome(string s)
{
	var r = string.Join("", s.ToCharArray().Reverse());
	var mid = s.Length / 2;
	var left = s.Substring(0, mid);
	var right = r.Substring(0, mid);
	return left == right;
}




