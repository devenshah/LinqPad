<Query Kind="Statements">
  <Connection>
    <ID>47c223bd-e79c-4583-9ef6-d763938432b6</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

"2,5,7-10,11,17-18, 16-20"
	.Split(',')
	.Select(x => x.Contains("-") ? x : string.Format("{0}-{0}", x))
	.Select(x => new { From = int.Parse(x.Split('-')[0]), To = int.Parse(x.Split('-')[1])})
	.SelectMany(x => Enumerable.Range(x.From, x.To - x.From + 1))
	.Distinct()
	.OrderBy(x => x)
//	.Aggregate(new List<int>(), (x, y) =>
//	{
//		for (var i = y.From; i <= y.To; i++)
//		{
//			x.Add(i);
//		}
//		return x;
//	})	
	.Dump();
	
	//Enumerable.Range(1, 10).Dump();

