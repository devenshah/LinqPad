<Query Kind="Program">
  <NuGetReference>Moq</NuGetReference>
  <Namespace>Moq</Namespace>
</Query>

//http://www.blackwasp.co.uk/MoqCallbacks.aspx
void Main()
{
    Person person = new Person { FirstName = "Bob", LastName = "Smith", Age = 18 };

    Mock<IPersonNameCleaner> _mockCleaner = new Mock<IPersonNameCleaner>();
    _mockCleaner.Setup(m => m.Clean(It.IsAny<Person>()))
                //.Callback(() => person.FirstName = "B");
                .Callback<Person>(p => p.FirstName = p.FirstName[0].ToString());

    TicketGenerator generator = new TicketGenerator(_mockCleaner.Object);

    Ticket ticket = generator.GenerateTicket(person);

    "B Smith".Equals(ticket.Name).Dump();
}

public interface IPersonNameCleaner
{
    void Clean(Person person);
}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}


public class Ticket
{
    public string Name { get; set; }
}


public class TicketGenerator
{
    IPersonNameCleaner _cleaner;

    public TicketGenerator(IPersonNameCleaner cleaner)
    {
        _cleaner = cleaner;
    }

    public Ticket GenerateTicket(Person person)
    {
        _cleaner.Clean(person);
        return new Ticket
        {
            Name = string.Format("{0} {1}", person.FirstName, person.LastName)
        };
    }
}