<Query Kind="SQL">
  <Connection>
    <ID>c8bb2290-88aa-4023-bad0-be874bb7e0ed</ID>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>EmployeeDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

WITH DirectReports (ManagerID, EmployeeID, Title, DeptID, Level)
AS
(
-- Anchor member definition 
-- only executes the first time
-- the result of this is fed in to recursive member 
-- the next time recursive member executes and its result is fed into next recursion
    SELECT e.ManagerID, e.EmployeeID, e.Title, e.DeptID, 
        0 AS Level
    FROM dbo.MyEmployees AS e
    WHERE ManagerID IS NULL
    UNION ALL
-- Recursive member definition
    SELECT e.ManagerID, e.EmployeeID, e.Title, e.DeptID,
        Level + 1 --Level has a value from previous record and it is being incremented here
    FROM dbo.MyEmployees AS e
    INNER JOIN DirectReports AS d --input from previous run 
        ON e.ManagerID = d.EmployeeID --join between previous and current record
)
-- Statement that executes the CTE
-- CTE can only be used in one statement
SELECT ManagerID, EmployeeID, Title, DeptID, Level
FROM DirectReports


/*

-- DROP TABLE dbo.MyEmployees;

CREATE TABLE dbo.MyEmployees
(
	EmployeeID smallint NOT NULL,
	FirstName nvarchar(30)  NOT NULL,
	LastName  nvarchar(40) NOT NULL,
	Title nvarchar(50) NOT NULL,
	DeptID smallint NOT NULL,
	ManagerID int NULL,
 CONSTRAINT PK_EmployeeID PRIMARY KEY CLUSTERED (EmployeeID ASC) 
);

-- Populate the table with values.
INSERT INTO dbo.MyEmployees VALUES 
 (1, N'Ken', N'Sánchez', N'Chief Executive Officer',16,NULL)
,(273, N'Brian', N'Welcker', N'Vice President of Sales',3,1)
,(274, N'Stephen', N'Jiang', N'North American Sales Manager',3,273)
,(275, N'Michael', N'Blythe', N'Sales Representative',3,274)
,(276, N'Linda', N'Mitchell', N'Sales Representative',3,274)
,(285, N'Syed', N'Abbas', N'Pacific Sales Manager',3,273)
,(286, N'Lynn', N'Tsoflias', N'Sales Representative',3,285)
,(16,  N'David',N'Bradley', N'Marketing Manager', 4, 273)
,(23,  N'Mary', N'Gibson', N'Marketing Specialist', 4, 16);


*/