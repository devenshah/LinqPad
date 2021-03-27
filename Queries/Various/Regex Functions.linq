<Query Kind="Program" />

void Main()
{
    Main1();
    Main2();
    Main3();
}

void Main1()
{
    var data = @"Dolore school leavers “school"" 
    leaver  5pm, shifts, may   work evenings and weekends  
    school";
    var regex = new Regex("[^a-zA-Z0-9]");
    Func<string, string> RemoveContiguousWhitespace = (value) => Regex.Replace(value, @"\s+", " ");
    RemoveContiguousWhitespace(regex.Replace(data, " ")).Dump("Remove non alpha numeric characters and extra spaces");
}

void Main2()
{
    var input = "2-10 f: fffffqdfddergvf";
    var match = Regex.Match(input, @"(\d+)-(\d+)\s(\w):\s(\w+)");
    // \d+ one or many numbers
    $"from: {match.Groups[1].Value} to: {match.Groups[2].Value} look for: {match.Groups[3].Value} in: {match.Groups[4].Value}".Dump("GetCapturingGroups");
}

void Main3()
{
    var input = "123in ewf";
    var pattern = @"^(\d+)(in|cm)$";
    var matchResult = Regex.Match(input, pattern);
    
    matchResult.Success.Dump("True if an exact match");
    matchResult.Groups[1].Value.Dump("Value of first group");
}

void Main4()
{
    var inputs = new List<(string, string)> { ("#123d56", "true"), ("#123d56", "true"), ("#123d5", "false"), ("123d56", "false"), ("#12345g", "false") };
    inputs.ForEach((x) => Regex.IsMatch(x.Item1, @"^#[0-9a-f]{6}$").Dump($"{x.Item1} should be {x.Item2}"));
}

void Main5()
{
    var inputs = new List<(string, string)> { ("amb", "true"), ("blu", "true"), ("brn", "true"), ("gry", "true"), ("#123d5", "false"), ("hgf", "false") };
    inputs.ForEach((x) => Regex.IsMatch(x.Item1, @"^amb|blu|brn|gry$").Dump($"{x.Item1} should be {x.Item2}"));
}
