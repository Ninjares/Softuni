Create Database Reports
Use Reports 

Create Table Users(
	Id int Primary Key Identity,
	UserName VarChar(30) NOT NULL Unique,
	[Password] VarChar(50) NOT NULL,
	[Name] VarChar(30),
	Birthdate DateTime,
	Age int Check (Age Between 14 and 110),
	Email VarChar(50) NOT NULL
	)

Create Table Departments(
	Id int Primary Key Identity,
	[Name] VarChar(50) NOT NULL
	)

Create Table Employees(
	Id int Primary Key Identity,
	FirstName VarChar(25),
	LastName VarChar(25),
	Birthdate DateTime,
	Age int Check (Age Between 18 and 110),
	DepartmentId int Foreign Key References Departments(Id)
	)

Create Table Categories(
	Id int Primary Key Identity,
	[Name] VarChar(50) NOT NULL,
	DepartmentId int NOT NULL Foreign Key References Departments(Id)
	)

Create Table [Status](
	Id int Primary Key Identity,
	Label VarChar(30) NOT NULL
	)

Create Table Reports(
	Id int Primary Key Identity,
	CategoryId int NOT NULL Foreign Key References Categories(Id),
	StatusId int NOT NULL Foreign Key References [Status](Id),
	OpenDate DateTime NOT NULL,
	CloseDate DateTime,
	[Description] VarChar(200) NOT NULL,
	UserId int NOT NULL Foreign Key References Users(Id),
	EmployeeId int Foreign Key References Employees(Id)
	)

Insert Into Employees(FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

Insert Into Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId) VALUES
(1,	1, '2017-04-13', null,			'Stuck Road on Str.133', 6,	2),
(6,	3, '2015-09-05','2015-12-06',	'Charity trail running', 3, 5),
(14,2, '2015-09-07', null, 			'Falling bricks on Str.58',	5,	2),
(4,	3, '2017-07-03','2017-07-06',	'Cut off streetlight on Str.11', 1,	1)


Update Reports
Set CloseDate = GETDATE()
Where CloseDate is null

Delete From Reports
Where StatusId = 4

Select [Description], Convert(VarChar, OpenDate, 105) as OpenDate From Reports
Where EmployeeId is NULL
Order By Reports.OpenDate, [Description]

Select [Description], Categories.[Name] as CategoryName From Reports
Inner Join Categories
On Reports.CategoryId = Categories.Id
Order By [Description], CategoryName

Select Top(5) [Name] as CategoryName, Count(Reports.Id) as ReportsCount From Categories
Inner join Reports
On Categories.Id = Reports.CategoryId
Group By [Name]
Order By ReportsCount DESC, CategoryName

Select UserName, Categories.[Name] as Category From Reports
Inner Join Users
On Reports.UserId = Users.Id
Inner Join Categories
On Reports.CategoryId = Categories.Id
Where DATEPART(Day, Birthdate) = DATEPART(Day, OpenDate) and DATEPART(Month, BirthDate) = DATEPART(MONTH, OpenDate)
Order By UserName, Categories.[Name]

	
Select FirstName+' '+LastName as [Full Name], ISNULL(Sum(convert(int,UserOrNot)),0) as UsersCount From(
	Select FirstName, LastName, Employees.Id, UserId, CONVERT(BIT, UserId) as UserOrNot From Employees
	Left Join Reports
	On Employees.Id =  EmployeeId
	Group By FirstName, LastName, Employees.Id, UserId
	) as tbl
Group By FirstName, LastName, Id
Order By UsersCount Desc, [Full Name]

Select 
	ISNULL(Employees.FirstName+' '+Employees.LastName, 'None') As Employee,
	ISNULL(Departments.[Name], 'None') as Department,
	Categories.[Name] as Category,
	[Description],
	CONVERT(VarChar, OpenDate, 104) as OpenDate,
	[Status].Label as [Status],
	Users.[Name] as [User]
From Reports
Left Join Employees
On Reports.EmployeeId = Employees.Id
Left Join Departments
On Employees.DepartmentId = Departments.Id
Inner Join Categories
On Categories.Id = Reports.CategoryId
Inner Join [Status]
On [Status].Id = Reports.StatusId
Inner Join Users
On Reports.UserId = Users.Id
Order By FirstName DESC, LastName Desc, Departments.[Name] Asc, Categories.[Name] Asc, [Description] Asc, OpenDate Asc, [Status].Label Asc, Users.[Name] Asc

Create Function udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
Returns Int
Begin
	Declare @ReturnInt int
	If(@StartDate is NULL or @EndDate is NULL) Set @ReturnInt = 0
	Else Set @ReturnInt = DATEDIFF(Hour, @StartDate, @EndDate)
	Return @ReturnInt
End

Create Or Alter Proc usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) AS
Begin
	 If((Select DepartmentId From Employees Where Employees.Id = @EmployeeId) = (Select Categories.DepartmentId From Reports Inner Join Categories On Reports.CategoryId = Categories.Id Where Reports.Id = @ReportId))
	 Begin
		Update Reports
		Set EmployeeId = @EmployeeId
		Where Reports.Id = @ReportId
	 End
	 Else
	 Throw 50001, 'Employee doesn''t belong to the appropriate department!',1
End

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2