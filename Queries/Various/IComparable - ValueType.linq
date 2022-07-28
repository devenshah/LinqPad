<Query Kind="Program">
  <NuGetReference>FluentValidation</NuGetReference>
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
  <Namespace>FluentValidation</Namespace>
  <Namespace>FluentValidation.TestHelper</Namespace>
</Query>

void Main()
{
	var validator = new UkprnValidator();
	validator.Validate(100000001).IsValid.Dump();
	
	Ukprn ukprn = 10;
	int x = 10; 
	
	(ukprn != x).Dump();
	
	ukprn.ToString().Dump();
	
	var result = new ProviderValidator().Validate(new Provider(-1, 1));
	result.Errors.Dump();
}

public class Provider
{ 
	public int Id { get; set; }
	public Ukprn Ukprn { get; set; }
	public Provider(int id, int ukprn)
	{
		Id=id; Ukprn = ukprn;
	}
}

public class ProviderValidator : AbstractValidator<Provider>
{
	public ProviderValidator()
	{
		RuleFor(x => x.Id).SetValidator(x => new IntValidator());
			//.GreaterThan(0);
		RuleFor(x => x.Ukprn).SetValidator(x => new UkprnValidator());
	}
}

public struct Ukprn : IComparable, IComparable<Ukprn>
{
	private int _ukprn;

	private Ukprn(int ukprn)
	{
		_ukprn = ukprn;
	}

	public int CompareTo(object obj) => obj is Ukprn other ? CompareTo(other) : throw new ArgumentException($"Object is not a type of {nameof(Ukprn)}");

	public int CompareTo([AllowNull] Ukprn other)
	{
		return _ukprn.CompareTo(other._ukprn);
	}
	
	public static implicit operator Ukprn(int ukprn) => new Ukprn(ukprn);

	public static implicit operator int(Ukprn ukprn) => ukprn._ukprn;

	public override string ToString()
	{
		return _ukprn.ToString();
	}
}

public class IntValidator : AbstractValidator<int>
{
	public IntValidator()
	{
		RuleFor(i => i).GreaterThan(0);
	}
}

public class UkprnValidator : AbstractValidator<Ukprn>
{
	public const string InvalidUkprnErrorMessage = "Invalid ukprn";
	public const string ProviderNotFoundErrorMessage = "No provider found with given ukprn";
	public UkprnValidator()
	{
		RuleFor(x => x)
			.Cascade(CascadeMode.Stop)
			.GreaterThan(10000000).WithMessage(InvalidUkprnErrorMessage)
			.LessThan(99999999).WithMessage(InvalidUkprnErrorMessage);
	}
}