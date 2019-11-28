<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    String.Compare(" s   1 ", "s 1", CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols).Dump();
}

// Define other methods and classes here
