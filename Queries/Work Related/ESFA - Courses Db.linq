<Query Kind="SQL">
  <Connection>
    <ID>e704156e-aba5-4bf8-8aec-4c1fef8c4d9a</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>SFA.DAS.Courses.Database</Database>
  </Connection>
</Query>


drop table Standard
drop table Standard_Import
drop table LarsStandard
drop table LarsStandard_Import
drop table ApprenticeshipFunding
drop table ApprenticeshipFunding_Import

alter database [SFA.DAS.Courses.Database] set single_user with rollback immediate
drop database [SFA.DAS.Courses.Database]


delete from Standard
delete from Standard_Import
delete from LarsStandard
delete from LarsStandard_Import
delete from ApprenticeshipFunding
delete from ApprenticeshipFunding_Import
delete from Framework
delete from Framework_Import
delete from FrameworkFundingPeriod
delete from FrameworkFundingPeriod_Import
delete from ImportAudit
  
select count(*) from ApprenticeshipFunding
select count(*) from LarsStandard
select count(*) from Framework
select count(*) from FrameworkFundingPeriod
select count(*) from Standard


--982/1254, 615, 600, 1105, 613/856

select count(*) from ApprenticeshipFunding_Import --982

select count(*)
from Standard s
inner join ApprenticeshipFunding_Import I on s.larscode = i.larscode --1254

select count(*)
from Standard s
left join ApprenticeshipFunding_Import I on s.larscode = i.larscode  -- 1387

select s.StandardUId, s.Status, s.LarsCode, I.Id
from Standard s
left join ApprenticeshipFunding_Import I on s.larscode = i.larscode 
where I.Id is null
Order by s.StandardUId, s.LarsCode

select s.StandardUId, s.Status, s.LarsCode, f.Id
from Standard s
join ApprenticeshipFunding f on s.StandardUId = f.StandardUId


select * from ApprenticeshipFunding

select * from ApprenticeshipFunding_Import where EffectiveFrom is null order by EffectiveFrom desc



  select * from Standard where status='Retired' and LarsCode = 0
  
--  select count(*) from Versioning.Standard_Staging
--  select count(*) from Versioning.Standard
--  select count(*) from Versioning.StandardAdditionalInformation
--  delete from Versioning.StandardAdditionalInformation

  select Version, count(*) from Standard group by Version
  
  select * from Standard where version = 1.1
  
  
select Larscode, Version, * 
from Versioning.Standard s
where s.LarsCode > 0
and s.Status = 'Approved for Delivery'
order by s.LarsCode asc, s.Version desc

select Larscode, Version, * 
from Versioning.Standard s
where larscode = 6

select distinct status from [Versioning].[Standard_Staging] where larscode in (
  select LarsCode
  from [Versioning].[Standard_Staging]
  group by LarsCode
  Having count(1) > 1)

select Larscode, Status 
from Versioning.Standard s
  group by LarsCode, sTatus
  Having count(1) > 1
  
where s.LarsCode > 0
and s.Status = 'Approved for Delivery'
order by s.LarsCode asc, s.Version desc




  
  
select  count(*) --Options, OptionsUnstructuredTemplate, *
from [Versioning].[Standard_Staging]
where  len(Options) > 2 and len(OptionsUnstructuredTemplate) = 2

select  distinct OptionsUnstructuredTemplate
from [Versioning].[Standard_Staging]
where  group by Options, OptionsUnstructuredTemplate


select StandardUId, options, OptionsUnstructuredTemplate 
from [Versioning].[Standard_Staging]
where StandardUId in ('ST0003_1.0', 'ST0096_2.0')


select StandardUId, options
from [Versioning].[StandardAdditionalInformation]
where StandardUId in ('ST0003_1.0', 'ST0096_2.0')


select * from Versioning.Standard where LarsCode in (
select LarsCode
From Versioning.Standard
where LarsCode > 0
Group by LarsCode
Having Count(*) > 2)

select status, count(*)
From Versioning.Standard
where LarsCode > 0
group by status


select * from Versioning.Standard where StandardUId like '%_xx%'

select count(*) from Versioning.Standard 

132 has OpionsTemplate ST0003_1.0 
686 has no options
30 has Options ST0096_2.0
848 

select * from Versioning.StandardAdditionalInformation 
where len(Options) > 2

select distinct(ReferenceNumber) from Versioning.Standard

select count(ReferenceNumber) from Versioning.Standard

Select LarsCode,ReferenceNumber,Status,Version  from [Versioning].[Standard_Staging] where ReferenceNumber in (
select ReferenceNumber
from [Versioning].[Standard_Staging]
  group by ReferenceNumber
  Having count(1) > 1)
  

  
 
  
  
select LarsCode, count(*) from Standard group by LarsCode Having count(*) > 1

select ReferenceNumber, LarsCode, Version, Status from Standard where LarsCode = 18

select IfateReferenceNumber, Version, Title from Standard  where IfateReferenceNumber in 
(select IfateReferenceNumber from Standard  
Group by IfateReferenceNumber Having count(*) > 1)

select Max(LarsCode) from Versioning.Standard


select * from LarsStandard where

select StandardUId, options, optionsunstructuredtemplate from standard_import where len(options) > 2 or len(optionsunstructuredtemplate) > 2


select standarduid, options from standard where len(options) > 2

select * from LarsStandard where larscode = 133

select * from Standard where larscode = 133

select * from Standard where CoreDuties is not null



select count(*) from Standard s 
inner join LarsStandard l on s.larscode = l.larscode
where status = 'Approved for delivery'
  
  
select top 5 * from Standard where LarsCode > 0 and status = 'Approved for delivery'
select StandardUId, LarsCode, Status, TypicalDuration, MaxFunding from Standard where LarsCode = 0 and status like '%in development'


select distinct s.LarsCode
from standard s
join LarsStandard l on l.LarsCode = s.LarsCode
where status in ('approved for delivery', 'retired')
order by s.LarsCode

select distinct s.IfateReferenceNumber
from standard s
join LarsStandard l on l.LarsCode = s.LarsCode
where status in ('approved for delivery', 'retired')
order by s.IfateReferenceNumber

select * from Standard where status in ('approved for delivery', 'retired') and larscode in (
select s.LarsCode from Standard s
join LarsStandard l on l.LarsCode = s.LarsCode
where s.status in ('approved for delivery', 'retired')
group by s.LarsCode
having count(*) > 2)

select * from Standard where IfateReferenceNumber in (
select IfateReferenceNumber from (
select distinct IfateReferenceNumber, LarsCode
from Standard) s
group by IfateReferenceNumber
having COUNT(*) > 1)
