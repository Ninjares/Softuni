Use Softuni
Select * From Departments
Select [Name] From Departments
Select FirstName, LastName, Salary From Employees
Select FirstName, MiddleName, LastName From Employees
Select FirstName + '.' + LastName + '@softuni.bg' From Employees
Select Distinct Salary From Employees
Select * From Employees Where JobTitle = 'Sales Representative'
Select FirstName, LastName, JobTitle From Employees Where Salary BETWEEN 20000 AND 30000
Select Concat(FirstName,' ', MiddleName,' ', LastName) As Fullname From Employees Where Salary = 25000 or Salary = 14000 or Salary = 12500 or Salary = 23600
Select FirstName, LastName From Employees Where ManagerID IS NULL
Select FirstName, LastName, Salary From Employees Where Salary >= 50000 Order By Salary DESC
Select Top(5) FirstName, LastName From Employees Order By Salary Desc
Select FirstName, LastName From Employees Where DepartmentID != 4
Select * From Employees Order By Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC 

Create View V_EmployeesSalaries AS
Select FirstName, LastName, Salary From Employees

Create View V_EmployeeNameJobTitle AS
Select Concat(FirstName+' ', MiddleName+' ', LastName) as [Full Name], JobTitle as 'Job Title' From Employees

Select Distinct JobTitle From Employees
Select Top(10) * From Projects Order By StartDate, [Name]
Select Top(7) FirstName, LastName, HireDate From Employees Order By HireDate Desc

Update Employees
Set Salary = Salary * 1.12
Where DepartmentID In (1, 2, 4, 11)
Select Salary From Employees

Select * From Departments

Use [Geography]

Select PeakName From Peaks Order By PeakName
Select Top(30) CountryName, [Population] From Countries Where ContinentCode = 'EU'  Order By [Population] DESC, CountryName

Select CountryName, CountryCode,
Case
	When CurrencyCode = 'EUR' Then 'Euro'
	Else 'Not Euro'
End
As Currency From Countries Order By CountryName

Use Diablo
Select [Name] From Characters Order By [Name]