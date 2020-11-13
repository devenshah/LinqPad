<Query Kind="Program">
  <NuGetReference>AutoFixture.AutoMoq</NuGetReference>
  <Namespace>AutoFixture</Namespace>
  <Namespace>AutoFixture.AutoMoq</Namespace>
  <Namespace>Moq</Namespace>
</Query>

void Main()
{
    
    var fixture = new Fixture().Customize(new AutoMoqCustomization());
    var personServiceMock = fixture.Freeze<Mock<IPersonService>>();
    personServiceMock.Setup(sm => sm.GetFullName(It.IsAny<Person>()))
    .Returns((Person person) => 
    { 
        return $"{person.FirstName} {person.LastName}"; 
    });
    var p = fixture.Create<EmployeeService>();
    p.GetEmployeeName(new Person("Dev","Sha")).Dump();
}

public class EmployeeService
{
    IPersonService _personService;
    public EmployeeService(IPersonService personService)
    {
        _personService = personService;
    }
    
    public string GetEmployeeName(Person p)
    {
        return _personService.GetFullName(p);   
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public Person(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }
}

public interface IPersonService
{
    string GetFullName(Person p);
}


