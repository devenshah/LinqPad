<Query Kind="Expression" />

//Cartasion join using Linq Expression
from row in Enumerable.Range('a', 8)
from col in Enumerable.Range('1', 8)
select $"{(char)row}{(char)col}"