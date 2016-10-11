<Query Kind="Expression">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

AttributeGroups.SelectMany(ag => ag.AttributeValues.Select(av => new { ag.Name, av.Value }))

