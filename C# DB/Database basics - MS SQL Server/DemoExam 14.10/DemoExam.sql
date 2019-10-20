Create Database School
Use School

Create Table Students(
	Id int Primary Key Identity,
	FirstName NVarChar(30) Not Null,
	MiddleName NVarChar(25),
	LastName NVarChar(30) Not Null,
	Age smallint Check (Age>=5 and Age<=100),
	[Address] NVarChar(50),
	Phone NChar(10)
)

Create Table Subjects(
	Id int Primary Key Identity,
	[Name] NvarChar(20) NOT NULL,
	Lessons int NOT NULL Check (Lessons>0)
	)
Create Table StudentsSubjects(
	Id int Primary Key Identity,
	StudentId int NOT NULL Foreign Key References Students(Id),
	SubjectId int NOT NULL Foreign Key References Subjects(Id),
	Grade Decimal(14,2) NOT NULL Check(Grade Between 2 and 6)
)

Create Table Exams(
	Id int Primary Key Identity,
	[Date] DateTime,
	SubjectId int NOT NULL Foreign Key References Subjects(Id)
	)
Create Table StudentsExams(
	StudentId int NOT NULL Foreign Key References Students(Id),
	ExamId int NOT NULL Foreign Key References Exams(Id),
	Grade Decimal(14,2) NOT NULL Check(Grade Between 2 and 6)
	Constraint PK_StudentExam Primary Key(StudentId, ExamId) --Nqma go v uslovieto ama go ima v testovete
	)
Create Table Teachers(
	Id int Primary Key Identity,
	FirstName NVarChar(20) NOT NULL,
	LastName NVarChar(20) NOT NULL,
	[Address] NVarChar(20) NOT NULL,
	Phone Char(10),
	SubjectId int NOT NULL Foreign Key References Subjects(Id)
	)
Create Table StudentsTeachers(
	StudentId int NOT NULL Foreign Key References Students(Id),
	TeacherId int NOT NULL Foreign Key References Teachers(Id),
	Constraint PK_StTch Primary Key (StudentId, TeacherId)
	)

Insert Into Subjects([Name], Lessons) Values
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

Insert Into Teachers(FirstName, LastName, [Address], Phone, SubjectId) Values
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

Update StudentsSubjects
Set Grade = 6.00
Where Grade>=5.5

Delete From StudentsTeachers
Where TeacherId in (Select Id From Teachers Where Phone Like '%72%')

Delete From Teachers
Where Phone Like '%72%'

---------Queries

Select FirstName, LastName, Age From Students
Where Age>=12
Order By FirstName, LastName

Select FirstName, LastName, Count(*) as TeachersCount From Students
Inner Join StudentsTeachers
On Students.Id=StudentsTeachers.StudentId
Group By FirstName, LastName

Select CONCAT(FirstName, ' ', LastName) as [Full Name] From Students
Left Join StudentsExams
On Students.Id=StudentsExams.StudentId
Where StudentId is Null
Order By CONCAT(FirstName, ' ', LastName)

Select Top(10) FirstName, LastName, cast(Avg(Grade) as decimal(6,2)) as Grade From Students
Inner Join StudentsExams
On Id = StudentId
Group By FirstName, LastName
Order By Avg(Grade) Desc, FirstName, LastName

Select CONCAT(FirstName+' ', ISNULL(MiddleName+' ', MiddleName), LastName) as [Full Name]From Students --Judge doesn't recognize concat_ws
Left Join StudentsSubjects
On Students.Id = StudentsSubjects.StudentId
Where StudentsSubjects.Id is Null
Order By  CONCAT(FirstName+' ', ISNULL(MiddleName+' ', MiddleName), LastName)

Select [Name], AVG(Grade) as AvarageGrade From Subjects
Inner Join StudentsSubjects
On Subjects.Id = StudentsSubjects.SubjectId
Group By [Name], Subjects.Id
Order By Subjects.Id

Create Or Alter Proc usp_ExcludeFromSchool (@StudentId int) As
Begin
	If(0=(Select Count(Id) From Students Where Students.Id=@StudentId))
		Throw 50001, 'This school has no student with the provided id!',1
	Else 
	Begin 
		Delete From StudentsTeachers Where StudentsTeachers.StudentId=@StudentId
		Delete From StudentsSubjects Where StudentsSubjects.StudentId=@StudentId
		Delete From StudentsExams Where StudentsExams.StudentId=@StudentId
		Delete From Students Where Students.Id=@StudentId
	End
End

Exec usp_ExcludeFromSchool @StudentId = 3

Go

Create Function udf_ExamGradesToUpdate (@studentId int, @grade Decimal(14,2))
Returns NvarChar(100)
Begin
	Declare @ReturnStatement NvarChar(100)
	If(0=(Select Count(Id) From Students Where Students.Id=@StudentId))
		Set @ReturnStatement = 'The student with provided id does not exist in the school!'
	Else If(@grade > 6)
		Set @ReturnStatement =  'Grade cannot be above 6.00!'
	Else
	Begin
		Declare @FirstName NvarChar(30)
		Set @FirstName = (Select FirstName From Students Where @studentId=Students.Id)
		Declare @GradesCount int
		Set @GradesCount = (Select Count(*) From Students
							Inner Join StudentsExams
							On Students.Id = StudentsExams.StudentId
							Where Students.Id = @studentId and Grade Between @grade and @grade +0.5
							)
		Set @ReturnStatement = Concat('You have to update ', @GradesCount, ' grades for the student ', @FirstName)
	End
	Return @ReturnStatement
End

Select dbo.udf_ExamGradesToUpdate(121, 5.5)