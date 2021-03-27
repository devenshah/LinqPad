<Query Kind="Statements">
  <Connection>
    <ID>e704156e-aba5-4bf8-8aec-4c1fef8c4d9a</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>SFA.DAS.Courses.Database</Database>
  </Connection>
</Query>

var x = new[] { 5, 10, 15, 20 };
var y = new[] { 1, 5, 10 };

x.ToList().TrueForAll(i => i % 5 == 0).Dump("Should be true");

y.ToList().TrueForAll(i => i % 5 == 0).Dump("Should be false as `1` fails the validation");