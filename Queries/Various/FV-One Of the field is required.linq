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

public class CreateApprenticeshipRequest
{
	public string Title { get; set; }
	public string Title1 { get; set; }
	public string Title2 { get; set; }
}

void Main()
{
	var c = new CreateApprenticeshipRequest{ Title2 = "afg"};
	var v = new AppValidator();
		
	var result = v.Validate(c);
	
	result.Log();
}

public class AppValidator : AbstractValidator<CreateApprenticeshipRequest>
{
	public AppValidator()
	{
		RuleFor(r => r.Title).NotEmpty().When(r => string.IsNullOrEmpty(r.Title1)).NotEmpty().WithMessage("either title or title1 is required");
	}
}

