<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>master</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

WITH months(MonthNumber) AS
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

