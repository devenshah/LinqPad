<Query Kind="SQL">
  <Connection>
    <ID>9fda2364-1388-43c3-afa8-e978ee24bf2c</ID>
    <Persist>true</Persist>
    <Server>tcp:he0ifp6r12.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>AvmsPlus-SIT</Database>
    <UserName>sqladmin@he0ifp6r12</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAWx3N3MuYNEy0uTk0+2QJOwAAAAACAAAAAAAQZgAAAAEAACAAAAD3W0AdfThOMWyIlDnBI7p0v2Xqrxj0YgAwGg9cnRYLnAAAAAAOgAAAAAIAACAAAAAPzXBvDbDG5b0jS1Gtrzu0S6LWgtVGyKY7RM+FGTdQPhAAAAAwKSjcMPKA82P4nHGK0oSXQAAAAA2FJmVnjNy1wpUBDlj/xcYstfRG3HbWFQFfWs7STQ6QM4TY/w/whLHw97KQMlddpCgCN6Wma0Mjo6bD2J69wGI=</Password>
    <DbVersion>Azure</DbVersion>
  </Connection>
</Query>

select count(s.VacancyId) from (
select VacancyId , min(HistoryDate)
from VacancyHistory
where VacancyHistoryEventTypeId = 1 and VacancyHistoryEventSubTypeId = 2
group by VacancyId 
) as s

select VacancyId , HistoryDate
from VacancyHistory
where VacancyHistoryEventTypeId = 1 
and VacancyHistoryEventSubTypeId = 2
and VacancyId= 579930
order by HistoryDate


select top 10 * 
from vacancy v
inner join vacancyhistory vh on v.vacancyid = vh.vacancyid
where vh.historydate is null


SELECT  V.VacancyReferenceNumber AS Reference
,       V.Title
,       V.ShortDescription
,       V.[Description]
,       V.VacancyTypeId
,       V.WageUnitId
,       V.WeeklyWage
,       V.WorkingWeek
,       V.WageText
,       V.HoursPerWeek
,       V.DurationValue AS ExpectedDuration
,       V.ExpectedStartDate
,		VH.HistoryDate AS DatePosted
,       V.ApplicationClosingDate
,       V.NumberofPositions 
,       V.EmployerDescription
,       V.EmployersWebsite
,       V.TrainingTypeId
,       RS.LarsCode AS StandardCode
,       AF.ShortName AS FrameworkCode
FROM[dbo].[Vacancy]        V
INNER JOIN (SELECT TOP 1 VacancyId, HistoryDate
            FROM [dbo].[VacancyHistory]
            WHERE VacancyHistoryEventTypeId = 1
            AND VacancyHistoryEventSubTypeId = 2
            AND VacancyId = V.VacancyId
            ORDER BY HistoryDate
           ) VH
	ON V.VacancyId = VH.VacancyId 
LEFT JOIN   [Reference].[Standard] RS 
    ON V.StandardId = RS.StandardId
LEFT JOIN   [Reference].[StandardSector] RSS
    ON RS.StandardSectorId = RSS.StandardSectorId
LEFT JOIN   [dbo].[ApprenticeshipFramework] AF
    ON      V.ApprenticeshipFrameworkId = AF.ApprenticeshipFrameworkId
WHERE V.VacancyStatusId = 2
AND V.VacancyReferenceNumber = 