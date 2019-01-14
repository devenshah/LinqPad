<Query Kind="Program" />

void Main()
{    
    var data = @"Dolore school leavers “school"" 
    leaver 5pm, shifts, may work evenings and weekends 
    school";
    data.Dump();
    ReplaceNonAlphaNumericCharacters(data).Dump();
}

public static string ReplaceNonAlphaNumericCharacters(string value)
{
    var regex = new Regex("[^a-zA-Z0-9]");
    return RemoveContiguousWhitespace(regex.Replace(value, " "));
}

private static string RemoveContiguousWhitespace(string value)
{
    return Regex.Replace(value, @"\s+", " ");
}


