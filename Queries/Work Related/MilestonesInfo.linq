<Query Kind="SQL">
  <Connection>
    <ID>c2a40155-e022-4078-8135-6ef470ee9e01</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>SurveyHub</Database>
  </Connection>
</Query>

select * from Domain.ApplicationSetting where DisplayName like 'Mil%ed'

select j.[ExternalReferenceNumber], js.[Code] as [JobStatus], m.[CreatedUtc] as [MilestoneCreated], mt.[Code] as [MilestoneType], ms.[Code] as [MilestoneStatus], l.[Name] as [Lender], 
CONCAT(CASE WHEN ja.[HouseNumber]!=0x THEN ja.[HouseNumber] END+N' ', CASE WHEN ja.[HouseName]!=0x THEN ja.[HouseName] END+N' ', ja.[Street]+N' ', ja.[Town]) as [Address], ja.[Postcode] 
from Domain.Job as j 
inner join domain.Milestone as m on j.[Id] = m.[JobId] 
inner join domain.lookupitem as mt on m.[MilestoneTypeId] = mt.[id] 
inner join domain.lookupitem as js on j.[StatusId] = js.[id] 
inner join domain.lookupitem as ms on m.[MilestoneStatusId] = ms.[id] 
left outer join Domain.Client as l on j.[LenderId] = l.[Id] 
left outer join Domain.JobAddress as ja on j.[JobPrimaryAddressId] = ja.[Id] 
where m.[MilestoneStatusId] = {guid'40F33469-9A13-4A55-9C5A-172345DD0F03'};