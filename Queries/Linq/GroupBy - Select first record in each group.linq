<Query Kind="Statements">
  <Connection>
    <ID>d966e7cd-c67b-4523-bac1-0ab83f0e2f76</ID>
    <Persist>true</Persist>
    <Server>LocalSql</Server>
    <Database>CentralIntegration</Database>
  </Connection>
  <Output>DataGrids</Output>
</Query>

/*
public class Milestone
{
	public Guid Id { get; set; }
	public Guid JobId { get; set; }
	public DateTime CreatedUtc { get; set; }
}
*/



Milestones
	.Where(ms => ms.MilestoneStatusId == new Guid("56521EA9-DF93-4AF9-9AF7-D9DA2DA78FE2"))
	.GroupBy(ms => ms.JobId)	
	.Select(ms => ms.OrderBy(m => m.CreatedUtc).First())
