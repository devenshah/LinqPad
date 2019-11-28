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
    var model = new PersonModel 
    {
        Name = "Dev",
        Gender = Gender.Female,
        Salutation = Salutation.Mr,
        Age = 4
    };
    var validator = new PersonModelValidator();
    validator.Validate(model).Dump();
}


class PersonModel
{
    public string Name { get; set; }
    public Gender? Gender { get; set; }
    public Salutation? Salutation { get; set; }
    public int? Age { get; set; }
}

enum Salutation
{
    Mr,
    Mrs
}

class PersonModelValidator : AbstractValidator<PersonModel>
{    
    public PersonModelValidator()
    {
        Func<PersonModel, bool> IsCorrectSalutation = (model) =>
        {
            switch (model.Gender)
            {
                case Gender.Male:
                    return model.Salutation == Salutation.Mr;
                default:
                    return model.Salutation == Salutation.Mrs;
            }
        };
        RuleFor(m => m.Name)
            .NotNull();
        RuleFor(m => m.Gender)
            .NotNull();
        RuleFor(n => n.Salutation)
            .NotNull();
        RuleFor(m => m.Age)
            .NotNull()
            .GreaterThan(17)
            .WithMessage("Adults only");
        When(m => m.Gender != null && m.Salutation != null, () => {
            RuleFor(m => m.Salutation)
                .Must((model, salute) => IsCorrectSalutation(model))
                .WithMessage("Wrong salutation for selected gender");
        });
    }
}
