<Query Kind="Program">
  <NuGetReference>xunit</NuGetReference>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//Enable Xunit from Query -> Add xUnit Test Support
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


#region private::Tests

[Theory]
[InlineData("q", 0)]
[InlineData("1", 1)]
void Test_Xunit(string x, long result)
{
	long.TryParse(x, out var y);
	Assert.True(y == result);
}

#endregion