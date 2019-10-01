Use Softuni
Select DepartmentID, AVG(Salary) as AvgSalary, Sum(Salary) As TotalSalary From Employees --Cannot use * to pull everything by group
Group By DepartmentID Having Sum(Salary) >= 150000

Select FirstName+' '+LastName as FullName, [Name] as Department, AddressText as [Address] From Employees
Inner Join Departments On Employees.DepartmentID = Departments.DepartmentID
Inner Join Addresses On Employees.AddressID = Addresses.AddressID

Select
	e.DepartmentID,
	String_Agg(e.FirstName+' '+e.LastName,', ') as [Department Members]
From Employees e
Group By DepartmentID
