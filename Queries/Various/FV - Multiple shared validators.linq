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
  <Namespace>static UserQuery</Namespace>
</Query>

void Main()
{

	var req = new ApprenticeshipRequest() { Title = "fgsa "};
	
	var validator = new ApprenticeshipValidator(new TitleValidator(new WhiteTextValidator()), new StandardAsyncValidator(new StandardRepository()));
	
	validator.Validate(req).Errors.Dump();
}

public class ApprenticeshipValidator : AbstractValidator<ApprenticeshipRequest>
{		
	public ApprenticeshipValidator(TitleValidator titleValidator, StandardAsyncValidator standardAsyncValidator)
	{
		RuleFor(x => x.Title)
			.SetValidator(titleValidator);	
			
		RuleFor(x => x.StandardLarsCode)
			.NotEmpty()
			.SetValidator(standardAsyncValidator);
	}
}

public class TitleValidator : AbstractValidator<string>
{
	public TitleValidator(WhiteTextValidator whiteTextValidator)
	{
		RuleFor(x => x)
			.Cascade(CascadeMode.StopOnFirstFailure)
			.NotEmpty()			
			.MaximumLength(5)
			.SetValidator(whiteTextValidator);
	}
}

public class WhiteTextValidator : AbstractValidator<string>
{
	public WhiteTextValidator()
	{
		RuleFor(x => x)
			//.Must(x => string.IsNullOrWhiteSpace(x) || x[0] == 'a')
			.Matches(@"^$|[a-zA-Z0-9\u0080-\uFFA7?$@#()""'!,+\-=_:;.&€£*%\s\/\[\]]+$")
			.WithErrorCode("11111")
			.WithMessage("Must not contain special characters");
	}
}

public class ApprenticeshipRequest
{
	public string StandardLarsCode { get; set; }

	public string Title { get; set; }
}

public class StandardAsyncValidator : AbstractValidator<string>
{
	IStandardRepository _repo;
	public StandardAsyncValidator(IStandardRepository repo)
	{
		_repo = repo;
		RuleFor(x => x)
			.MustAsync(Validate)
			.WithMessage("first character should be 'a'");		
	}

	private async Task<bool> Validate(string value, CancellationToken token)
	{
		var data = await _repo.GetStandardId(value);
		return data[0] == 'a';
	}
}

public interface IStandardRepository
{
	Task<List<int>> GetStandardId(string larsCode);
}

public class StandardRepository : IStandardRepository
{
	public async Task<List<int>> GetStandardId(string larsCode)
	{
		return await Task.FromResult(new List<int> {1,2,3,4});
	}
}