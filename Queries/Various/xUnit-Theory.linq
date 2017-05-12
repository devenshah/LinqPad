<Query Kind="Program">
  <NuGetReference>xunit</NuGetReference>
  <NuGetReference>Xunit.Runner.LinqPad</NuGetReference>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>Xunit</Namespace>
  <Namespace>Xunit.Runner.LinqPad</Namespace>
  <CopyLocal>true</CopyLocal>
</Query>

void Main()
{
	XunitRunner.Run(Assembly.GetExecutingAssembly());
}

public class GetCompetitiveQuoteTest
{
	[Theory]
	[MemberData(nameof(QuotationDataSource.TestData), MemberType = typeof(QuotationDataSource))]
	public void Should(int[] input, int[] expectedOutput)
	{
		var sut = new EvenNumber();
		var output = sut.GetEvenNumbers(input);
		Assert.Equal(expectedOutput, output);
	}

	[Theory,
	InlineData("goodnight moon", "moon", true),
	InlineData("hello world", "hi", false)]
	public void Contains(string input, string sub, bool expected)
	{
		var actual = input.Contains(sub);
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void ShouldFail()
	{
		Assert.True(true);
	}
}

public static class QuotationDataSource
{
	public static List<Object[]> TestData => new List<object[]>
		{
			new object[] {new[]{1,2,3,4},new[]{2,4}},
			new object[] {new[]{1,21,33,4},new[]{4}},
			new object[] {new[]{1,21,33,41},Array.Empty<int>()},
		};
}

public class EvenNumber
{
	public int[] GetEvenNumbers(int[] numbers)
	{
		var evenNumbers = new Collection<int>();
		foreach (var number in numbers)
		{
			if (number % 2 == 0) evenNumbers.Add(number);
		}
		return evenNumbers.ToArray();
	}
}