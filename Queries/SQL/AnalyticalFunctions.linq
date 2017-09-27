<Query Kind="SQL">
  <Connection>
    <ID>47055575-be2a-4d08-9dd6-f8313e56edf8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--USE NORTHWIND
--Analytic functions

--SYNTAX
-- function (...) 							//any aggregate function and some new functions
--		OVER (PARTITION BY col1, col2, ... 	// the aggregate function will be execute per partition 
--											// in other words each partition will be fed into function					
--		ORDER BY col3, col4, ...
--		...windowing-clause...) AS coumn-name




-- get no of times product has been ordered
select od.*,
		count(*) OVER (partition by od.ProductId) as productCount
from [Order Details] od

--incremental count 
select od.productid, od.quantity,
		sum(od.Quantity) OVER (partition by od.ProductId
								order by od.quantity
								) as productCount
from [Order Details] od
order by od.productid, od.quantity

-- count of distinct quantity ONLY WORKS IN ORACLE
--select od.productid, od.quantity,
--		count(distinct od.Quantity) OVER (partition by od.ProductId) as productCount
--from [Order Details] od


--			ROW_NUMBER
--================================
-- generate row numbers in the query
select 
	ROW_NUMBER() OVER (ORDER BY p.CategoryID) as RowNum,
	p.ProductName, p.CategoryID	
from Products p
order by p.categoryid

--generate row numbers by category
select 
	p.ProductName, p.CategoryID,
	ROW_NUMBER() OVER (partition by p.CategoryID ORDER BY p.CategoryID) as RowNum
from Products p
order by p.categoryid

--			LEAD and LAG
--================================
-- get previous price and next price for current row
select 
	p.ProductName, p.CategoryID, 
	LAG(p.UnitPrice, 1, 999)
	OVER (
		PARTITION BY p.CategoryID 	-- optional clause
		ORDER BY p.UnitPrice      	--this clause is required
	) PreviousPrice,
	p.UnitPrice,
	LEAD(p.UnitPrice, 1, 999)
	OVER (
		PARTITION BY p.CategoryID 	-- optional clause
		ORDER BY p.UnitPrice      	--this clause is required
	) NextPrice
from Products p

--			RANK and DENSE_RANK
--================================
-- 		Values:	100	100	110	120
-- RANK 		1	1	3	4
-- DENSE_RANK	1	1	2	3

-- get top stock by Supplier

select 
	p.ProductName, p.SupplierID, p.UnitsInStock,
	RANK() OVER 
		(PARTITION BY p.SupplierID
		ORDER BY p.UnitsInStock) as Rank,
	DENSE_RANK() OVER 
		(PARTITION BY p.SupplierID
		ORDER BY p.UnitsInStock) as Dense_Rank	
from Products p


--			FIRST_VALUE and LAST_VALUE
--==========================================
--			WINDOW clause ROWS and RANGE
--==========================================
--			WITH non-recursive
--==========================================
-- get top stock by Supplier
-- By default the window clause is set to 
--    	ROWS WITH UNBOUNDED PRECEDING AND CURRENT ROW
-- Other options of window clause ROWS are 
--		ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING

WITH myQuery as (
	select p.supplierid, p.productname, sum(od.quantity) as totalOrder 
	from [order details] od
	inner join products p on od.productid = p.productid
	group by p.supplierid, p.productname)
select supplierid, productname, totalorder,
	last_value(totalorder) 
	over (partition by supplierid
		order by totalorder
		ROWS BETWEEN UNBOUNDED PRECEDING
			AND UNBOUNDED FOLLOWING) as toporder,
	first_value(totalorder) 
	over (partition by supplierid
		order by totalorder) as lowestorder
from myquery
order by supplierid, productname


--			PIVOT rows to column
--==========================================

--			UNPIVOT column to rows 
--==========================================




-- get all the product orders in year 1996

select p.ProductName, count(od.orderid), sum(od.quantity)
from products p 
inner join [order details] od on p.productid = od.productid
inner join orders o on od.orderid = o.orderid
where year(o.orderdate) = 1996
group by p.productname