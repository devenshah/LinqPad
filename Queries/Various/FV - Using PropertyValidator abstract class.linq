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
	public string Ukprn { get; set; }
}

void Main()
{
    var v = new AppValidator();
    var c = new CreateApprenticeshipRequest() { Ukprn = ""};
	var result = v.Validate(c);
	
	result.Log();
}

public class AppValidator : AbstractValidator<CreateApprenticeshipRequest>
{
	public AppValidator()
	{
		RuleFor(r => r.Ukprn)
            //.Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage("F O")
            .SetValidator(new UkprnValidator())
            .When(r => string.IsNullOrWhiteSpace(r.Ukprn) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("LOL");
	}
}

public class UkprnValidator : PropertyValidator
{
    public static Regex UkprnRegex => new Regex(@"^((?!(0))[0-9]{8})$");

    public UkprnValidator() : base("'{PropertyValue}' is not a valid ukprn.") {}
    
    protected override bool IsValid(PropertyValidatorContext context)
    {
        var ukprn = (string)context.PropertyValue;
        
        if (string.IsNullOrWhiteSpace(ukprn)) return true;
        
        return UkprnRegex.IsMatch(ukprn);
    }
}

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> MustBeValidUkprn<T>(this IRuleBuilder<T, string> rule)
    {
        return rule.SetValidator(new UkprnValidator());
    }
}