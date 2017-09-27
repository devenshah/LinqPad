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
,		E.FullName AS EmployerName
,		V.EmployerDescription
,		E.AddressLine1 AS EmployerAddressLine1
,		E.AddressLine2 AS EmployerAddressLine2
,		E.Town AS EmployerAddressTown
,		E.PostCode AS EmployerAddressPostCode
FROM[dbo].[Vacancy]        V
INNER JOIN (SELECT VacancyId, Min(HistoryDate) HistoryDate
            FROM [dbo].[VacancyHistory]
            WHERE VacancyHistoryEventTypeId = 1
            AND VacancyHistoryEventSubTypeId = 2
            GROUP BY VacancyId
           ) VH
	ON V.VacancyId = VH.VacancyId 
LEFT JOIN   [Reference].[Standard] RS 
    ON V.StandardId = RS.StandardId
LEFT JOIN   [dbo].[ApprenticeshipFramework] AF
    ON      V.ApprenticeshipFrameworkId = AF.ApprenticeshipFrameworkId
INNER JOIN [dbo].[VacancyOwnerRelationship] VO
	ON		V.VacancyOwnerRelationshipId = VO.VacancyOwnerRelationshipId
INNER JOIN [dbo].[Employer] E
	ON		VO.EmployerId = E.EmployerId
WHERE V.VacancyStatusId = 2
and V.VacancyId = 672423

select * from Vacancy where VacancyId = 672423

select F.Field, V.FullName, F.[Value]
from VacancyTextField F
inner join VacancyTextFieldValue V ON F.Field = V.VacancyTextFieldValueId
where F.VacancyId = 672423


select e.* 
from VacancyOwnerRelationship o
inner join Vacancy v  on v.VacancyOwnerRelationshipId = o.VacancyOwnerRelationshipId
inner join Employer e on o.EmployerId = e.EmployerId
where V.VacancyId = 672423




