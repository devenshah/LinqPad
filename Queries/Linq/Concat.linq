<Query Kind="Program" />

void Main()
{
        var data = SetA();
        data = data.Concat(SetB());
        data = data.Distinct().Take(5);
        foreach (string value in data)
            Console.WriteLine("-----" + value);
        Console.WriteLine("Done");
        Console.ReadLine();    
}
static IEnumerable<string> SetA()
{
    Console.WriteLine("Consuming SetA!");

    Console.WriteLine("A");
    yield return "A";
    Console.WriteLine("B");
    yield return "B";
    Console.WriteLine("C");
    yield return "C";
    Console.WriteLine("dup A");
    yield return "A";
    Console.WriteLine("dup B");
    yield return "B";
    Console.WriteLine("dup C");
    yield return "C";
}

static IEnumerable<string> SetB()
{
    Console.WriteLine("Consuming SetB!");

    Console.WriteLine("1");
    yield return "1";
    Console.WriteLine("2");
    yield return "2";
    Console.WriteLine("3");
    yield return "3";
}
