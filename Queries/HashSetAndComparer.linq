<Query Kind="Program" />

void Main()
{
	//Hashset works well with value type
	var pSet = new HashSet<Person>();
	pSet.Add(new Person("Dev",40));
	pSet.Add(new Person("Su", 40));
	pSet.Add(new Person("Di", 10));
	pSet.Add(new Person("Dev", 40));
	pSet.Add(new Person("Dev", 41));
	pSet.Add(new Person("Su", 40));
	pSet.Add(new Person("Su", 30));	
	pSet.Dump();
	
	//To make hashset work correctly with objects a comparer is required 
	
	var cSet = new HashSet<Customer>(new CustomerComparer());
	cSet.Add(new Customer(1,"Dev",40));
	cSet.Add(new Customer(2,"Dev",40));
	cSet.Add(new Customer(1,"Dev",40));
	cSet.Add(new Customer(1,"Dev",40));
	cSet.Add(new Customer(1,"Dev",40));
	cSet.Dump();
	
	//or override of Equals is required	
	var eSet = new HashSet<Employee>();
	eSet.Add(new Employee(1,"Dev",40));
	eSet.Add(new Employee(2,"Dev",40));
	eSet.Add(new Employee(1,"Dev",40));
	eSet.Add(new Employee(1,"Dev",40));
	eSet.Add(new Employee(1,"Dev",40));
	eSet.Dump();
	
}

public struct Person
{
	public string Name ;
	public int Age ;
	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}
}

public class Employee
{
	public int Id { get; set;}	
	public string Name { get; set; }
	public int Age { get; set; }
	public Employee(){ }
	public Employee(int id, string name, int age)
	{
		this.Id = id;
		this.Name = name;
		this.Age = age;
	}
	public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object obj)
    { 
        return Equals(obj as Employee);
    }

    public bool Equals(Employee employee)
    {
        return employee != null && employee.Id.Equals(Id);
    }	
}

public class Customer
{
	public int Id { get; set;}	
	public string Name { get; set; }
	public int Age { get; set; }
	public Customer(){ }
	public Customer(int id, string name, int age)
	{
		this.Id = id;
		this.Name = name;
		this.Age = age;
	}
}

public class CustomerComparer : IEqualityComparer<Customer>
{
	public int GetHashCode(Customer customer)
    {
        return customer.Id.GetHashCode();
    }

    public bool Equals(Customer c1, Customer c2)
    {
        return c1.Id.Equals(c2.Id);
    }	

}