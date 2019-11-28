<Query Kind="Program" />

void Main()
{
    //https://www.codewars.com/kata/unique-in-order/csharp
    Kata.UniqueInOrder("AAAABBBCCDAABBB").Dump();

    Kata.UniqueInOrder("").Dump();

    Kata.UniqueInOrder(new [] { 0,1,1,2,1,3,3,4,4}).Dump();
    
    Kata.UniqueInOrder(new int[] {}).Dump();
}

// Define other methods and classes here
public static class Kata
{
    public static IEnumerable<T> UniqueInOrder1<T>(IEnumerable<T> iterable)
    {
        if(iterable.Any() == false) return iterable;
                
        return iterable.Take(1).Concat(iterable.Skip(1).Where((e, i) => e.Equals(iterable.ElementAt(i)) == false));
    }

    public static string UniqueInOrder(string text)
    {
        return string.Join("", UniqueInOrder(text.ToArray()));
    }

    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        var lastValue = default(T);
        
        foreach (var element in iterable)
        {
            if (lastValue.Equals(element) == false)
            {
                lastValue = element;
                yield return element;
            }
        }        
    }
}