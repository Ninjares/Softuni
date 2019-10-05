Create Database RelationshipExcercises
Use RelationshipExcercises
---------------
--1
Create Table Persons(
	PersonID int Primary Key,
	FirstName NVarChar(25),
	Salary Decimal (8,2),
	PassportID int
	)
Create Table Passports(
	PassportID int Primary Key,
	PassportNumber varchar(8)
	)
Alter Table Persons
Add Foreign Key (PassportID) References Passports(PassportID)

---------------
--2
Create Table Models(
	ModelID int Primary Key,
	[Name] VarChar(30),
	ManufacturerID int
	)
Create Table Manufacturers(
	ManufacturerID int Primary Key,
	[Name] VarChar(25),
	EstablishedOn Date
	)
Alter Table Models
Add Foreign Key (ManufacturerID) References Manufacturers(ManufacturerID)

---------------
--3
Create Table Students(
	StudentID int Primary Key Identity,
	[Name] NVarChar(25) NOT NULL
	)

Create Table Exams(
	ExamID int Primary Key Identity,
	[Name] NvarChar(25) NOT NULL
	)

Create Table StudentsExams(
	StudentID int Foreign Key References Students(StudentID),
	ExamID int Foreign Key References Exams(ExamID),
	Constraint PK_StudentExam Primary Key (StudentID,ExamID)
	)

Insert Into Students([Name]) Values
('Tashi'), ('Ron'), ('Jerry')

Insert Into Exams([Name]) Values
('C#'),
('YEAH WAY'),
('Kaballah magicc')

Insert Into StudentsExams(StudentID, ExamID) Values
(1,1),
(1,2),
(2,1),
(3,3)

---------------
--4
Create Table Teachers(
	TeacherID int Primary Key,
	[Name] NVarChar(25),
	ManagerID int Foreign Key References Teachers(TeacherID)
	)

---------------
--5

Create Table ItemTypes(
	ItemTypeID int Primary Key,
	[Name] varChar(50)
	)
Create Table Items(
	ItemID int Primary Key,
	[Name] varChar(50),
	ItemTypeID int Foreign Key References ItemTypes(ItemTypeID)
	)

Create Table Cities(
	CityID int Primary Key,
	[Name] varChar(50)
	)
Create Table Customers(
	CustomerID int Primary Key,
	[Name] varchar(50),
	BirthDay Date,
	CityID int Foreign Key References Cities(CityID)
	)
Create Table Orders(
	OrderID int Primary Key,
	CustomerID int Foreign Key References Customers(CustomerID)
	)
Create Table OrderItems(
	OrderID int Foreign Key References Orders(OrderID),
	ItemID int Foreign Key References Items(ItemID),
	Constraint PK_OrderItem Primary Key (OrderID, ItemID)
	)
----------
--6
Create Table Majors(
	MajorID int Primary Key Identity,
	[Name] VarChar(30)
	)
Create Table Subjects(
	SubjectID int Primary Key,
	[Name] VarChar(30)
	)
Create Table Students(
	StudentID int Primary Key Identity,
	StudentNumber VarChar(25),
	StudentName NvarChar(50),
	MajorID int Foreign Key References Majors(MajorID)
	)
Create Table Payments(
	PaymentID int Primary Key,
	PaymentDate Date,
	PaymentAmount Decimal(8,2),
	StudentID int Foreign Key References Students(StudentID)
	)
Create Table Agenda(
	StudentID int Foreign Key References Students(StudentID) NOT NULL, --You cannot set primary keys on fields which are allowed to be null
	SubjectID int Foreign Key References Subjects(SubjectID) NOT NULL,
	)
Alter Table Agenda
Add Constraint PK_StudentSubject Primary Key (StudentID, SubjectID)

-------------
--9
Use [Geography]

Select m.MountainRange, p.PeakName, p.Elevation From Peaks as p
Inner Join Mountains as m
On p.MountainId = m.Id
Where m.MountainRange = 'Rila' Order By Elevation Desc