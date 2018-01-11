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

void Main()
{
	var c = new CreateApprenticeshipRequest{ Title = "afg"};
	
	var v = new AppValidator(new AsyncValidator(new Repository()));
	
	var result = v.Validate(c);
	
	result.Log();
}

public class AppValidator : AbstractValidator<CreateApprenticeshipRequest>
{
	public AppValidator(AsyncValidator asyncValidator)
	{
		//sync
//		RuleFor(req => req.Title).BeAValidStandard();
//
//		StandardValidator.BeAValidStandard(RuleFor(req => req.Title));
		
		//async
		asyncValidator.BeValidCode(RuleFor(req => req.Title));
	}
}


public class TestValidator
{
	public void Test()
	{
		var sut = new AppValidator(new AsyncValidator(new Repository()));
		
		
	}
}


public static class StandardValidator 
{
	public static IRuleBuilderOptions<T, string> BeAValidStandard<T>(this IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder.Length(0, 5).WithMessage("length of string must be 5 or less");
	}
}

public class AsyncValidator 
{
	IRepository _repo;
	public AsyncValidator(IRepository repo)
	{
		_repo = repo;
	}
	
	public IRuleBuilderOptions<T, string> BeValidCode<T>(IRuleBuilder<T, string> ruleBuilder)
	{
		return ruleBuilder.MustAsync(Validate).WithMessage("first character should be 'a'");
	}
	
	private async Task<bool> Validate(string value, CancellationToken token)
	{
		var data = await _repo.GetData(value);
		return data[0] == 'a';
	}
}

public interface IRepository
{
	Task<string> GetData(string input);
}

public class Repository : IRepository
{
	public async Task<string> GetData(string input)
	{
		return await Task.FromResult(input.ToLower());
	}
}


public class CreateApprenticeshipRequest
{
	public string Title { get; set; }
}

// Define other methods and classes here
