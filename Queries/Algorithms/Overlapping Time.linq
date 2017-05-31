<Query Kind="Program" />

// A.Start < B.End && B.Start < A.End
/*
0. ....S................E....
1. .........S.............E.. 
2. ..S........E..............
3. ..S.....................E.
4. .......S.....E............
*/

void Main()
{
	$"AreThereAnyOverLaps: {AreThereAnyOverLaps()}".Dump();
}

bool AreThereAnyOverLaps()
{
	/*
	Ordered List
	2. ..S........E..............
	3. ..S.....................E.
	0. ....S................E....
	4. .......S.....E............
	1. .........S.............E.. 

	*/

	var list = GetData().OrderBy(x => x.Start);

	DateRange rangeToCompare = null;
	foreach (var x in list)
	{
		x.Start.Log();
		if (rangeToCompare != null)
		{
			if (x.Start < rangeToCompare.End) 
				return true;
		}
		rangeToCompare = x;
	}
	return false;
}


IEnumerable<DateRange> GetData()
{
	return new[]
	{
		new DateRange{Start= new DateTime (2017, 5, 22, 5, 30, 0), End = new DateTime(2017, 5, 22, 6, 30, 0)},
		new DateRange{Start= new DateTime (2017, 5, 22, 6, 29, 0), End = new DateTime(2017, 5, 22, 7, 30, 0)},
		new DateRange{Start= new DateTime (2017, 5, 22, 5, 00, 0), End = new DateTime(2017, 5, 22, 6, 00, 0)},
	};
}

public class DateRange
{
	public DateTime Start { get; set; }
	public DateTime End { get; set; }	
}

