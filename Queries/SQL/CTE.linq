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

WITH months(MonthNumber) AS --Recursive Common Table Expression
(
    SELECT 0
    UNION ALL
    SELECT MonthNumber+1 
    FROM months
    WHERE MonthNumber < 12
)

select * from months

SELECT 
	LEFT(DATENAME(MONTH,DATEADD(MONTH,-MonthNumber,GETDATE())),3) AS [month], 
	DATEPART(YEAR, DATEADD(MONTH,-MonthNumber,GETDATE())) as [year]
FROM months

select datename(month, getdate())

select datename(month, dateadd(month, -1,  getdate()))




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
,       DatePosted = (
                        SELECT 
                        TOP        1
                                HistoryDate
                        FROM    [dbo].[VacancyHistory]
                        WHERE    VacancyHistoryEventSubTypeId = 2
                        AND        VacancyHistoryEventTypeId = 1
                        AND        VacancyId = V.VacancyId
                    )
,       V.ApplicationClosingDate
,       V.NumberofPositions 
,       V.EmployerDescription
,       V.EmployersWebsite
,       V.TrainingTypeId
,       RS.LarsCode AS LarsStandardId
,       AF.ShortName AS FrameworkCode
FROM [dbo].[Vacancy]        V
LEFT JOIN   [Reference].[Standard] RS
    ON V.StandardId = RS.StandardId
LEFT JOIN   [Reference].[StandardSector] RSS
    ON RS.StandardSectorId = RSS.StandardSectorId
LEFT JOIN   [dbo].[ApprenticeshipOccupation] AO
    ON RSS.ApprenticeshipOccupationId = AO.ApprenticeshipOccupationId
LEFT JOIN   [dbo].[ApprenticeshipFramework] AF
    ON      V.ApprenticeshipFrameworkId = AF.ApprenticeshipFrameworkId
WHERE V.VacancyStatusId = 2


with history_cte (VacancyId, HistoryDate) as 
(
select VacancyId , min(HistoryDate) as HistoryDate
from VacancyHistory
where VacancyHistoryEventTypeId = 1 and VacancyHistoryEventSubTypeId = 2
group by VacancyId 
)

--select count(*) from vacancy

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
,       RS.LarsCode AS LarsStandardId
,       AF.ShortName AS FrameworkCode
FROM[dbo].[Vacancy]        V
INNER JOIN history_cte VH
	ON V.VacancyId = VH.VacancyId 
LEFT JOIN   [Reference].[Standard] RS 
    ON V.StandardId = RS.StandardId
LEFT JOIN   [Reference].[StandardSector] RSS
    ON RS.StandardSectorId = RSS.StandardSectorId
LEFT JOIN   [dbo].[ApprenticeshipOccupation] AO
    ON RSS.ApprenticeshipOccupationId = AO.ApprenticeshipOccupationId
LEFT JOIN   [dbo].[ApprenticeshipFramework] AF
    ON      V.ApprenticeshipFrameworkId = AF.ApprenticeshipFrameworkId
--WHERE V.VacancyStatusId = 2
--AND V.VacancyReferenceNumber = @ReferenceNumber";
