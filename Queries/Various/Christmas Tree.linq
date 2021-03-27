<Query Kind="Statements">
  <Connection>
    <ID>47055575-be2a-4d08-9dd6-f8313e56edf8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>SFA.DAS.Courses.Database</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

int layers = 5;

Enumerable
    .Range(1, layers)
    // calculates padding and elements to go on the layer
    .Select(level => (new string(' ', layers - level), new string('-', level + level - 1)))
    // appends padding to the elements on both sides
    .Select(x => string.Concat(x.Item1, x.Item2, x.Item1))
    // converts to a list to allow foreach
    .ToList()
    .ForEach(Console.WriteLine);

/*        
  -   level 1 => Padding Layer - Level || Elements Level + (Level-1) 
 ---  2 + (2-1) 
----- 3 + (3-1)
*/