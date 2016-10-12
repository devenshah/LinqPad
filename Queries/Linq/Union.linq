<Query Kind="Program" />

void Main()
{
	var list1 = new List<baseMonth>();
	list1.Add(new baseMonth() { Number = 1});
	list1.Add(new baseMonth() { Number = 2 });
	var list2 = new year();
	list2.Month.Add(new month() { Number = 3 });
	list2.Month.Add(new month() { Number = 4 });
	var list3 = new year();
	list3.Month.Add(new month() { Number = 5 });
	list3.Month.Add(new month() { Number = 6 });

	list1.Union(list2.Month).Union(list3.Month).ToList().Dump();

}

public class baseMonth
{
	public int Number { get; set; }
}
public class month : baseMonth { }
public class year
{
	public year()
	{
		Month = new List<UserQuery.month>();
	}
	public List<month> Month { get; set; }
}