<Query Kind="SQL">
  <Connection>
    <ID>47c223bd-e79c-4583-9ef6-d763938432b6</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

use Master
go

if Exists(SELECT * FROM master.dbo.sysdatabases WHERE name = 'FileWatcher')  
begin
	drop database FileWatcher
End

create database FileWatcher
go

use FileWatcher
go

create Table [File] (
	Id int identity primary key not null ,
	Name nvarchar(300) not null,
	UpdateTime datetime not null,
	IsProcessed bit default 0 not null
);

