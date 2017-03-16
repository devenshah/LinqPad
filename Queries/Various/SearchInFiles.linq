<Query Kind="Statements">
  <Connection>
    <ID>47c223bd-e79c-4583-9ef6-d763938432b6</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>FileWatcher</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var outputPath = @"D:\Temp\";
var searchTerm = "internet";
Directory
	.EnumerateFiles(outputPath, "*.csv")
	.SelectMany(filePath => System.IO.File.ReadAllLines(filePath)
		.Skip(1) //header Row
		.Select(line => line.Split(','))
		.Where(parts => parts.Length > 5)) //List of array
	.Where(parts => Regex.IsMatch(parts[1], searchTerm))	
	.Select(parts => new 
		{
			DateStamp = parts[0],
			Description = parts[1],
			Cost = decimal.Parse(parts[5], System.Globalization.NumberStyles.Currency)
		})
	.Where(row => row.Cost > 0)
	.Dump();
	
/* Sample Data

Date,Type,Number,In tariff?,Used,Cost
05 Jul 17:10,Using the internet,,Yes,1.84MB,£0.10
05 Jul 16:10,Using the internet,,Yes,1.26MB,£0.00
05 Jul 15:10,Using the internet,,Yes,519KB,£0.00
05 Jul 14:10,Using the internet,,Yes,491KB,£0.00
05 Jul 13:29,Using the internet,,Yes,3.80MB,£0.20
05 Jul 12:29,Using the internet,,Yes,606KB,£0.00


*/
