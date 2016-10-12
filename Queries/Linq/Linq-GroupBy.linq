<Query Kind="Program" />

void Main()
{
	var people = GetPeople();
	var mainGroups = people.GroupBy (p => new {p.Gender, p.Order.OrderType});
	//mainGroups.Dump();
	
	people.GroupBy (p => new {p.Gender, p.Country})
		.Select (p => new 
		{
			Gender = p.Key.Gender,
			Country = p.Key.Country,
			Count = p.Count(),
			TotalWeight = p.Sum (y => y.Weight)
		} )
		.Dump();
	
}

public List<Person> GetPeople()
{
	return new List<Person>()
	{
		new Person(1,  1, 2, 90m),
		new Person(2,  2, 1, 6m),
		new Person(3,  2, 3, 30m),
		new Person(4,  1, 3, 20m),
		new Person(5,  1, 2, 40m),
		new Person(6,  2, 2, 70m),
		new Person(7,  1, 1, 60m),
		new Person(8,  2, 1, 40m),
		new Person(9,  2, 1, 40m),
		new Person(10, 1, 2, 20m),
		new Person(11, 2, 2, 90m),
		new Person(12, 1, 2, 70m),
		new Person(13, 1, 2, 80m),
		
	};
}

public class Person
{
	public int PersonId { get; set; }
	public string Name { get; set; }
	public Country Country { get; set; }
	public Gender Gender { get; set; }
	public decimal Weight { get; set; }
	public Order Order {get; set;}
	public Person(int id, int gender, int country, decimal weight)
	{
			PersonId = id;
			var s = gender == 1 ? "F" : "M";
			Name = string.Concat(s, id);
			Country = (Country)country;
			Gender = (Gender)gender;
			Weight = weight;
			Order = new Order(country);
	}
}

public enum Country
{
	India = 1,
	England = 2,
	Welsh = 3,
	Scotland = 4
}

public enum Gender
{
	Female = 1,
	Male = 2
}

public class Order
{	
	public int OrderType { get; set; }
	public Order(int type)
	{
		OrderType = type;
	}
}