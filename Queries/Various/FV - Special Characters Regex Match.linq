<Query Kind="Program">
  <NuGetReference>FluentValidation</NuGetReference>
  <Namespace>FluentValidation</Namespace>
  <Namespace>FluentValidation.Attributes</Namespace>
  <Namespace>FluentValidation.Internal</Namespace>
  <Namespace>FluentValidation.Resources</Namespace>
  <Namespace>FluentValidation.Results</Namespace>
  <Namespace>FluentValidation.TestHelper</Namespace>
  <Namespace>FluentValidation.Validators</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public class Person
{
	public string Name { get; set; }
}

public class Validator : AbstractValidator<Person>
{
	public Validator()
	{
		RuleFor(p => p.Name).MatchesAllowedFreeTextCharacters().WithName("first name");
	}
}

void Main()
{
	var p = new Person() {Name = "  "};
	var validator = new Validator();
	validator.Validate(p).Errors.Dump();
	
	//@"^(((?:91|93|96)?\d{7})?)$"
	//"^(?:91|93|96)?\d{7}$"
}

// Define other methods and classes here
public static class FVExtensions
{
	private const string FreeTextWhitelistRegex = @"(^[a-zA-Z0-9\u0080-\uFFA7?$@#()""'!,+\-=_:;.&€£*%\s\/\[\]]*$)";
	public static IRuleBuilderOptions<T, string> MatchesAllowedFreeTextCharacters<T>(
		this IRuleBuilder<T, string> rule)
	{
		return rule.Matches(FreeTextWhitelistRegex)
			.WithMessage("{PropertyName} has invalid characters");
	}


	private const string RegexHtmlFreeTextWhitelist = @"^[a-zA-Z0-9\u0080-\uFFA7?$@#()""'!,+\-=_:;.&€£*%\s\/<>\[\]]+$";
	private const string RegexScriptsBlacklist = @"<\s*s\s*c\s*r\s*i\s*p\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";
	private const string RegexInputsBlacklist = @"<\s*i\s*n\s*p\s*u\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";
	private const string RegexObjectsBlacklist = @"<\s*o\s*b\s*j\s*e\s*c\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";

	private static bool CheckHtmlFreeTextBlacklist(string text)
	{
		if (Regex.IsMatch(text, RegexScriptsBlacklist) ||
			Regex.IsMatch(text, RegexInputsBlacklist) ||
			Regex.IsMatch(text, RegexObjectsBlacklist))
		{
			return false;
		}
		return true;
	}
}