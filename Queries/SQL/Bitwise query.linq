<Query Kind="SQL">
  <Connection>
    <ID>d3f5ed61-a713-4847-9620-aa74f61622cc</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
  </Connection>
</Query>

BEGIN --clean up
    IF (NOT EXISTS (SELECT * 
                     FROM INFORMATION_SCHEMA.TABLES 
                     WHERE TABLE_NAME = 'Labels'))
        DROP TABLE Labels
    
    IF (NOT EXISTS (SELECT * 
                     FROM INFORMATION_SCHEMA.TABLES 
                     WHERE TABLE_NAME = 'Furniture'))
        DROP TABLE Furniture
END

BEGIN --build up
    CREATE TABLE Labels
    (
        Id INT NOT NULL PRIMARY KEY,
        Name VARCHAR(50) NOT NULL UNIQUE
    )
        
    insert into Labels values(1, 'Living');
    insert into Labels values(2, 'Kitchen');
    insert into Labels values(4, 'Outdoor');
    insert into Labels values(8, 'Bedroom');
    
    --insert into Labels values(18, 'Bedvvroom');
    
    create table Furniture
    (
        Id INT NOT NULL PRIMARY KEY,
        Name VARCHAR(50) NOT NULL UNIQUE,
        Labels INT NULL
    )
    
    insert into Furniture values(1, 'Tub chair', 9); --Living and Bedroom
    insert into Furniture values(2, 'High chair', 2); --Kitchen
    insert into Furniture values(3, 'Coffee table', 1); --Living 
    insert into Furniture values(4, 'Sun lounge', 4); --outdoor
    insert into Furniture values(5, 'Down lights', 11); --Living, Kitchen and Bedroom
    insert into Furniture values(6, 'Double bed', 8); -- Bedroom
    insert into Furniture values(7, 'Folding chair', -1); --all
    
END

/*
IF EXISTS (SELECT * from dbo.sysobjects WHERE Id = object_id(N'dbo.GetFurniture') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN 
	DROP PROCEDURE GetFurniture;
    
    CREATE PROCEDURE GetFurniture
        @belongsTo INT
    AS
    BEGIN
        SELECT * FROM Furniture
        WHERE Labels & @belongsTo <> 0
    END
END
*/


EXECUTE GetFurniture 10

--Queries

-- select furniture for living room
--select * from Furniture where Labels & 1 <> 0

--select outdoor furniture
--select * from Furniture where Labels & 4 = 4


--select * from Furniture where Labels | 9 = 9




