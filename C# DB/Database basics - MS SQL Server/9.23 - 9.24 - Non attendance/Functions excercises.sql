Use SoftUni

Select FirstName, LastName From Employees
Where FirstName Like 'Sa%' --  '=' will not work

Select FirstName, LastName From Employees
Where LastName Like '%ei%'

Select FirstName From Employees
Where DepartmentID in (3,10) and Year(Hiredate) Between 1995 and 2005

Select FirstName, LastName From Employees
Where JobTitle Not Like '%engineer%'

Select [Name] From Towns
Where Len([name]) in (5,6) Order By [Name]

Select * From Towns
Where Left([Name],1) in ('M','K','B','E') Order By [Name]

Select * From Towns
Where [Name] not like '[RBD]%' Order By [Name]

Create View V_EmployeesHiredAfter2000 As
Select FirstName, LastName From Employees
Where Year(HireDate) > 2000

Select FirstName, LastName From Employees
Where Len(LastName) = 5

Select EmployeeID, FirstName, LastName, Salary ,
Dense_RANK() Over (Partition by Salary Order By EmployeeID) as [Rank] --Partition razdelq na malki tablichki, order podrejda malkite tablichki
From Employees
Where Salary Between 10000 and 50000 Order By Salary Desc 

Select * From( Select EmployeeID, FirstName, LastName, Salary ,
Dense_RANK() Over (Partition by Salary Order By EmployeeID) as [Rank] 
From Employees
Where Salary Between 10000 and 50000 Order By Salary Desc) As Temp
Where temp.[Rank] = 2
Order by Temp.Salary Desc


Use [Geography]

Select CountryName, IsoCode From Countries
Where CountryName like '%A%A%A%' Order By IsoCode

Select Peaks.PeakName, Rivers.RiverName, Lower(Peaks.PeakName+Substring(Rivers.RiverName, 2, Len(Rivers.RiverName))) as Mix
From Peaks, Rivers
Where Right(Peaks.PeakName,1) = Left(Rivers.RiverName,1) Order By Mix

Use Diablo
Select Top(50) [Name], Format([Start], 'yyyy-MM-dd') as [Start] From Games
Where DATEPART(Year, [Start]) in (2011, 2012) Order By [Start], [Name]

Select Username, SUBSTRING(Email, CHARINDEX('@', Email, 0)+1 , Len(Email)) as [Email Provider] From Users
Order By [Email Provider], Username

Select UserName, IpAddress as [IP Address] From Users
Where IpAddress Like '___.1%.%.___' Order By Username

Select * From Games
Select [Name] as Game, 
Case 
	When DatePart(hour, [Start]) Between 12 and 17 Then 'Afternoon'
	When Datepart(hour, [Start]) Between 18 and 23 Then 'Evening'
	Else 'Morning'
End
As [Part of the Day],
Case
	When Duration <= 3 then 'Extra Short'
	When Duration between 4 and 6 then 'Short'
	When Duration >6 then 'Long'
	Else 'Extra Long'
End
As [Duration]
From Games Order By Game, Duration

Select ProductName, OrderDate, DATEADD(day, 3, OrderDate) as [Pay Due], DATEADD (month, 1, OrderDate) as [Deliver Due] From Orders