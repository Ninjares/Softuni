Create Database SoftUni
Use SoftUni

Create Table Towns(
	Id int Primary Key Identity,
	[Name] NvarChar(30)
	)
Create Table Addresses(
	Id int Primary Key Identity,
	[Name] NvarChar(50),
	TownId int Foreign Key References Towns(Id)
	)
Create Table Departments(
	Id int Primary Key Identity,
	[Name] NvarChar(30),
	)
Create Table Employees(
	Id int Primary Key Identity,
	FirstName NvarChar(20),
	MiddleName NvarChar(20),
	LastName NvarChar(20),
	JobTitle NvarChar(30),
	DepartmentId int Foreign Key References Departments(Id),
	HireDate Date,
	Salary Decimal(10,2),
	AddressId int Foreign Key References Addresses(id)
)

Insert Towns([Name]) Values
('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

Insert Departments([Name]) Values
('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

Select * From Towns
Select * From Departments
Select * From Employees
Truncate Table Employees

Backup Database SoftUni 
To Disk = 'D:\DB Backups\SoftuniDB.bak';

Insert Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-2-1', 3500),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-3-2', 4000),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-8-28', 525.25),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-9', 3000),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

Select FirstName+' '+MiddleName+' '+LastName as FullName, JobTitle, d.[Name] as Department, Salary From Employees As e
INNER JOIN Departments As d On d.Id = e.DepartmentId

Select [Name] From Towns Order By [Name]
Select [Name] From Departments Order By [name]
Select FirstName, LastName, JobTitle, Salary From Employees Order By Salary Desc

Update Employees
   Set Salary *=1.1
Select Salary From Employees