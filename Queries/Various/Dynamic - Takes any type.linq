<Query Kind="Program">
  <Namespace>System.Dynamic</Namespace>
</Query>

void Main()
{
	dynamic obj = new ExpandoObject();
	obj.City =1;
	obj.City = "New York";
	Console.WriteLine(obj.City);

	var obj2 = new {City = "London"};
	Console.WriteLine(obj2.City);

	dynamic obj3 = new {City = "PAris"};
	Console.WriteLine(obj3.City);
}


