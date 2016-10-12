<Query Kind="Expression" />

"Deven Shah, 20/04/1974; Suman Shah, 16/11/1973; Diya Shah, 23/11/2004; Minal Shah, 23/08/1971"
	.Split(';')
	.Select(d => d.Split(','))
	.Select(parts => new {Name = parts[0].Trim(), Age= Convert.ToInt16(((DateTime.Today - DateTime.Parse(parts[1])).TotalDays / 365)) })