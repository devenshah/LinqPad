<Query Kind="SQL">
  <Connection>
    <ID>60408c34-3117-44f3-909d-bba77b66afde</ID>
    <Persist>true</Persist>
    <Server>etech-dev01</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8JEdqNgoLEKFrbDwxk5wUgAAAAACAAAAAAADZgAAwAAAABAAAADRyYe4ia2HQxFuFkTq62t5AAAAAASAAACgAAAAEAAAAF2N0QU/OLRKMrr9YS/jJt4QAAAAykMZSyropwoSpYbjs6AqAxQAAAD+zUzq6Vt/7kizl6VoEEzya5DU8Q==</Password>
    <Database>SPHEC_DS_28</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

-- Clear database
exec spDatabase_ClearDown

--reset job
select * from jobqueue
update JobQueue set fkJobStatus =1 
where pkJobQueueID = 147557
update MeasureImportFile set Status = 2
where fkJobQueueId = 147557


SELECT        Property.pkPropertyId, Measure.pkMeasureId, Measure.ReferenceNumber, 
EPCData.pkEPCDataId, MeasureError.pkMeasureErrorId, MeasureImportHistory.pkMeasureImportHistoryId, wall.MeasureWallInsulationId
FROM            
Property INNER JOIN
Measure On Property.pkPropertyId = Measure.fkProperty LEFT OUTER JOIN
                         EPCData ON Measure.pkMeasureId = EPCData.fkMeasure LEFT OUTER JOIN
                         MeasureImportHistory ON Measure.pkMeasureId = MeasureImportHistory.fkMeasure LEFT OUTER JOIN
                         MeasureError ON Measure.pkMeasureId = MeasureError.fkMeasure LEFT OUTER JOIN
						 [Measure.WallInsulation] as wall on Measure.pkMeasureId = wall.fkMeasure
WHERE        
--Measure.fkProperty = 22912
(Measure.ReferenceNumber = '3820a')

select Property.pkPropertyId, Measure.pkMeasureId, Measure.ReferenceNumber
FROM            
Property INNER JOIN
Measure On Property.pkPropertyId = Measure.fkProperty
order by Measure.ReferenceNumber


select * from Measure

select * from Property

select * from MeasureImportFile

select * from MeasureImportFileBytes

select * from MeasureImportFileSummary

select * from MeasureImportFileError



--BG Backlog
update MeasureImportFile 
set fkMeasureImportFileSource = 4

  --update EcoHub
  --set source = 'Regression Test Company'
  --where source = 'PD Advice and Services Ltd' -- TEST THIS

--update JobQueueType set JobQueueProcessorId = 2 where JobQueueTypeId = 2

-- To Retry the job
Delete from [Measure.WallInsulation.WallExternal]
Delete from [Measure.WallInsulation]
Delete from EPCData
Delete from Measure
Delete from Property

--Permissions
select * from permission -- 61 UploadBacklogMeasureImportFile
select * from permissiongroup -- 7 Measures
select * from SecurityRole -- 1 Developer
select * from RolePermission where fkRole = 1


select * from [Lookup.MeasureSubType]

---------- JOB QUEUE
select q.pkJobQueueID, q.QueueName, st.StatusDescription, t.JobQueueProcessorId, f.Status, f.pkMeasureImportFileId
 from JobQueue q
 inner join JobStatus st on q.fkJobStatus = st.pkJobStatusID
 inner join JobQueueType t on q.JobQueueTypeId = t.JobQueueTypeId
 inner join MeasureImportFile f on f.fkJobQueueId = q.pkJobQueueID
where pkJobQueueID = 145704

select q.pkJobQueueID, q.QueueName, st.StatusDescription, t.JobQueueProcessorId, o.fkResponseFileStatusId
 from JobQueue q
 inner join JobStatus st on q.fkJobStatus = st.pkJobStatusID
 inner join JobQueueType t on q.JobQueueTypeId = t.JobQueueTypeId
 inner join OfgemResponseImport o on o.fkJobQueueId = q.pkJobQueueID

update OfgemResponseImport set fkResponseFileStatusId = 2


select m.pkMeasureId, m.OfgemMeasureReferenceNumber, e.*
from Measure m
inner join EPCData e on m.fkProperty = e.fkProperty

select ic.CompanyName, l.pkLotId, l.LotName, pbm.fkPriceBook as PriceBookId, pb.Name as PriceBook, pbm.*, grp.ItemDescription 
from lot l
inner join PriceBook pb on pb.pkPriceBookId = l.fkPriceBook
inner join PriceBookMeasure pbm on pb.pkPriceBookId = pbm.fkPriceBook
inner join InstallationCompany ic on ic.pkInstallationCompanyId = l.fkInstallationCompany
inner join [Lookup.MeasureGroup] grp on grp.pkItemId = pbm.fkMeasureGroup
where l.LotName = 'LOTCERO1'
--where l.pkLotId = 107 and pbm.fkMeasureGroup = 6 
	
select mst.pkItemID SubTypeId, mst.ItemCode SubTypeCode, grp.pkItemId GroupId, grp.ItemDescription GroupName 
from [Lookup.MeasureSubType] mst
inner join [Lookup.MeasureGroup] grp on grp.pkItemId = mst.fkMeasureGroup
order by mst.ItemDescription

select * from OfgemResponseImport



select * from [Lookup.Extended.FloorInsulationType]

select * from [Measure.WallInsulation.WallExternal]

select * from EPCData order by InstallDate

select * from ErrorInfo




 select * from JobStatus
 
 select * from MeasureImportFileColumn

 select * from OfgemResponseImportError

select * from JobQueueType



 ---------- JOB QUEUE

 select *  from MeasureImportFile 

 update MeasureImportFile set Status = 2 where pkMeasureImportFileId = 5024

 select * from MeasureImportFileVersion
 
 
 ----- OFGEM MEASURE REFERENCE
update measure
set ofgemmeasurereferencenumber = 'VAN'+ RIGHT('0000000'+ CONVERT(VARCHAR,o.OfgemMEasureReferenceNumberID),7) 
from measure m
inner join OfgemMeasureReferenceNumber o on m.pkMeasureId = o.MeasureId

select m.ofgemmeasurereferencenumber, o.ofgemmeasurereferencenumberid
from Measure m
inner join OfgemMEasureReferenceNumber o on m.pkmeasureid = o.measureid