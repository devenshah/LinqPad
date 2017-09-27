<Query Kind="SQL">
  <Connection>
    <ID>47055575-be2a-4d08-9dd6-f8313e56edf8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


/*
select od.productid, p.productname, od.quantity 
from [order details] od
inner join Products p on od.productid = p.productid
order by od.productid
*/

select p.productname, sum(od.quantity) 
from [order details] od
inner join Products p on od.productid = p.productid
where od.productid in (1, 10, 13)
group by p.productname


-- using PIVOT

select * from (
select p.productname, od.quantity 
from [order details] od
inner join Products p on od.productid = p.productid
) as source
PIVOT (
	sum(quantity)
	for productname in (chai, Ikura, Konbu)
) as pvt

-- using case

select
	sum(case when productid = 1 then quantity end) as Chai,
	sum(case when productid = 10 then quantity end) as Ikura,
	sum(case when productid = 13 then quantity end) as Konbu
from [order details]


