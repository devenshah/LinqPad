<Query Kind="Expression">
  <Connection>
    <ID>9d163a45-8c54-4ee3-8417-d1a85b87cc50</ID>
    <Persist>true</Persist>
    <Server>localsql</Server>
    <Database>SmartPropertyHubEC.Database</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Core.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Interfaces.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.Linq.dll</Reference>
  <Reference>&lt;CommonApplicationData&gt;\LINQPad\References\System.Reactive.PlatformServices.dll</Reference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
</Query>

from measureImportRow in MeasureImportRows
join scoringTool in LookupRdSAPApprovedSoftwareVersions 
on measureImportRow.NameAndVersionOfScoringToolUsed equals scoringTool.ItemDescription
into scoringToolJoin
from scoringTool1 in scoringToolJoin
select new 
{ 
	measureImportRow.MeasureImportRowId, 
	measureImportRow.NameAndVersionOfScoringToolUsed,
	scoringTool1.PkItemId }
	
	