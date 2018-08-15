<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

void Main()
{
    var c = new Collection<Person>();
    
    var m = new LoremIpsumBuilder();
    m.GetWords(10).Log();
}

public class LoremIpsumBuilder
{
    static readonly Regex WordSplitter = new Regex(@"\w", RegexOptions.Compiled);

    private const string Original = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    readonly List<string> _arrOriginal = new List<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="LoremIpsumBuilder"/> class.
    /// </summary>
    public LoremIpsumBuilder()
    {
        _arrOriginal = Original.Split(' ').ToList();
    }

    /// <summary>
    /// Gets a loremipsum string of the given lenght.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>a lorem ipsum string </returns>
    public string GetLetters()
    {
        return GetLetters(Original.Length);
    }

    /// <summary>
    /// Gets a loremipsum string with length of given lenght of letters.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>A lorem ipsum string with a given length.</returns>
    public string GetLetters(int length)
    {
        var output = new StringBuilder();

        if (length == 0)
        { length = Original.Length; }

        for (var i = 0; i < length; i++)
            output.Append(Original[i]);

        return output.ToString();
    }

    /// <summary>
    /// Gets a loremipsum string of given lenght of words.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>a lorem ipsum string</returns>
    public string GetWords(int length)
    {
        var output = new StringBuilder();
        //var pattern = @"[\w\!\.\?\;\,\:]+/g";

        int arrCounter = 0;
        for (int i = 0; i <= length; i++)
        {
            output.Append(_arrOriginal[arrCounter]);
            if (++arrCounter > _arrOriginal.Count)
                arrCounter = 0;
        }

        return output.ToString();
    }

    /// <summary>
    /// Gets a loremipsum string of given lenght of paragraphs.
    /// </summary>
    /// <returns>a lorem ipsum string</returns>
    public string GetParagraphs(int count)
    {
        var output = new StringBuilder();
        for (int i = 0; i <= count; i++)
        {
            if (i == count)
                output.Append(Original);
            else
                output.Append(Original + "\n\n");
        }
        return output.ToString();
    }
}
