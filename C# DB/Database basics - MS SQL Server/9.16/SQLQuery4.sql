Create Table Students
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL
)

Insert into Students (FirstName, LAstName) VALUES ('testime', 'testfamilia')
SELECT * FROM Students