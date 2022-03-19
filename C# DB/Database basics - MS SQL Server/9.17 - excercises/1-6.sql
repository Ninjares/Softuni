Create Database Minions
Go
Use Minions
Create table Minions (Id int Primary Key NOT NULL, [Name] NVarChar(50), Age int)
Create table Towns (Id int Primary Key NOT NULL, [Name] NvarChar(50))

Alter table Minions
Add TownId int Foreign Key REFERENCES Towns(Id)

Insert into Towns (Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

Insert into Minions(Id, [Name], Age, TownId) Values 
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

Select * From Minions
Select * From Towns

Truncate Table Minions

Drop Table Minions, Towns