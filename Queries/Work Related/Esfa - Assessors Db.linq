<Query Kind="SQL">
  <Connection>
    <ID>cc8ba543-7b85-4971-8a96-2a72a398d976</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>INDI-MACPRO-WIN</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>SFA.DAS.AssessorService.Database</Database>
  </Connection>
</Query>

delete from Standards
delete from StandardCollation
delete from StandardNonApprovedCollation
delete from Options

select count(*) from Standards

select count(*) from StandardCollation

select count(*) from StandardNonApprovedCollation

select count(*) from Options

select * from Standards