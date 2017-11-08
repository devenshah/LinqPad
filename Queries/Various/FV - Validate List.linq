<Query Kind="Program">
  <NuGetReference>FluentValidation</NuGetReference>
  <Namespace>FluentValidation</Namespace>
  <Namespace>FluentValidation.Attributes</Namespace>
  <Namespace>FluentValidation.Internal</Namespace>
  <Namespace>FluentValidation.Resources</Namespace>
  <Namespace>FluentValidation.Results</Namespace>
  <Namespace>FluentValidation.TestHelper</Namespace>
  <Namespace>FluentValidation.Validators</Namespace>
</Query>

void Main()
{
	var req = new Request();
	req.MyProperty = "1,2,3 , 4,4 6,5, 6 66e,6,f".Split(',');
	var val = new RequestValidator();
	val.Validate(req).Log();
}


public class RequestValidator : AbstractValidator<Request>
{ 
	public RequestValidator()
	{
		RuleForEach(r => r.MyProperty).Must(BeValidNumber).WithMessage("Invalid code, expected a number");
	}

	private bool BeValidNumber(string value)
	{
		int i;
		return int.TryParse(value, out i);
	}
}


public class Request
{ 
	public IEnumerable<string> MyProperty { get; set; }
}