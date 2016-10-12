<Query Kind="Expression" />

Enumerable.Range('a', 8)
	.SelectMany(e => Enumerable.Range('1', 8),
		(f, r) => new { File = (char)f, Rank = (char)r })
	.Where(e => Math.Abs(e.File - 'c') == Math.Abs(e.Rank - '6'))
	.Where(x => x.File != 'c')
	.Select(x => $"{x.File}{x.Rank}")