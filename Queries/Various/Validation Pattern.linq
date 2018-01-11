<Query Kind="Program">
  <Namespace>Esfa.Vacancy.Domain.Repositories</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
}

public class CreateApprenticeshipRequest
{
	public string LongDescription { get; set; }
	public int StandardId { get; set; }
}

public interface IAsyncValidator<in T>
{
	Task<List<ValidationResponse>> ValidateAsync(T objectToValidate);
}

public interface IValidator<in T>
{
	List<ValidationResponse> Validate(T objectToValidate);
}

public struct ValidationResponse
{
	public ValidationResponse(string errorCode, string errorMessage)
	{
		ErrorCode = errorCode;
		ErrorMessage = errorMessage;
	}

	public string ErrorCode { get; set; }
	public string ErrorMessage { get; set; }
}

public class LongDescValidator : IValidator<CreateApprenticeshipRequest>
{
	public List<ValidationResponse> Validate(CreateApprenticeshipRequest request)
	{
		var result = new List<ValidationResponse>();

		if (!request.LongDescription.IsHtmlFreeTextBlacklist())
		{
			result.Add(new ValidationResponse("31001", $"{nameof(request.LongDescription)} has invalid characters"));
		}
		return result;
	}
}

public interface IStandardRepository
{
	Task<int[]> GetStandardIdsAsync();
}

public class StandardValidator : IAsyncValidator<CreateApprenticeshipRequest>
{
	private readonly IStandardRepository _standardRepository;

	public StandardValidator(IStandardRepository standardRepository)
	{
		_standardRepository = standardRepository;
	}

	public async Task<List<ValidationResponse>> ValidateAsync(CreateApprenticeshipRequest request)
	{
		var result = new List<ValidationResponse>();

		var ids = await _standardRepository.GetStandardIdsAsync();

		if (!ids.Contains(request.StandardId))
		{
			result.Add(new ValidationResponse("31002", $"Invalid StandardId {request.StandardId}"));
		}
		return result;
	}
}


public abstract class ValidatorBase<T>
{
	private readonly List<IAsyncValidator<T>> _asyncValidators;
	private readonly List<IValidator<T>> _validators;

	protected ValidatorBase(List<IAsyncValidator<T>> asyncValidators, List<IValidator<T>> validators)
	{
		_asyncValidators = asyncValidators;
		_validators = validators;
	}

	public virtual async Task<List<ValidationResponse>> Validate(T request)
	{
		var result = new List<ValidationResponse>();

		foreach (var validator in _validators)
		{
			result.AddRange(validator.Validate(request));
		}

		foreach (var asyncValidator in _asyncValidators)
		{
			result.AddRange(await asyncValidator.ValidateAsync(request).ConfigureAwait(false));
		}

		return result;
	}
}

public class CreateVacancyValidator : ValidatorBase<CreateApprenticeshipRequest>
{
	public CreateVacancyValidator(
		List<IAsyncValidator<CreateApprenticeshipRequest>> asyncValidators,
		List<IValidator<CreateApprenticeshipRequest>> validators)
		: base(asyncValidators, validators)
	{

	}
}

public static class Extensions
{
	private const string RegexScriptsBlacklist = @"<\s*s\s*c\s*r\s*i\s*p\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";
	private const string RegexInputsBlacklist = @"<\s*i\s*n\s*p\s*u\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";
	private const string RegexObjectsBlacklist = @"<\s*o\s*b\s*j\s*e\s*c\s*t\s*[^>]*\s*[^>]*\s*[^>]*>";


	public static bool IsHtmlFreeTextBlacklist(this string text)
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