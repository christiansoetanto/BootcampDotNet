create database BootcampDotnetDB
go
use  BootcampDotNetDB
go
create table [User]
(UserID INT PRIMARY KEY IDENTITY(1,1), UserName VARCHAR(100), BirthDate DATETIME, Ranking INT)

insert into [User]
values ('joni', '1998-12-20',1),('budi', '2000-04-12',2),('alan', '1999-01-09',3),('susi', '2003-05-26',4)
go


CREATE TABLE Chef(
	ChefID INT PRIMARY KEY IDENTITY(1,1),
	ChefName VARCHAR(100)
)

GO

CREATE TABLE Food (
	FoodID INT PRIMARY KEY IDENTITY(1,1),
	FoodName VARCHAR(255),
	Price FLOAT,
	ChefID INT FOREIGN KEY REFERENCES Chef(ChefID)
)

GO

INSERT INTO Chef VALUES('tono'), ('budi')

GO

INSERT INTO Food VALUES('nasi goreng', 12.23, 1),('ayam goreng', 34.54, 1), ('burger', 5.98, 2)
