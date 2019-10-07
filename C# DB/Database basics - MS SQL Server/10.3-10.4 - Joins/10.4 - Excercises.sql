Use SoftUni

Select Top(5) EmployeeID, JobTitle, Addresses.AddressID, Addresses.AddressText From Employees
Inner Join Addresses
On Employees.AddressID = Addresses.AddressID
Order By AddressID

Select Top(50) FirstName, LastName, Towns.[Name] as Town, Addresses.AddressText From Employees
Inner Join Addresses
On Employees.AddressID = Addresses.AddressID
Inner Join Towns
On Addresses.TownID = Towns.TownID
Order By FirstName ASC, LastName

Select EmployeeID, FirstName, LastName, Departments.[Name] as DepartmentName From Employees
Inner Join Departments
On Employees.DepartmentID = Departments.DepartmentID
Where Departments.[Name] = 'Sales'
Order By EmployeeID

Select Top(5) EmployeeID, FirstName, Salary, Departments.[Name] as DepartmentName From Employees
Inner Join Departments
On Employees.DepartmentID = Departments.DepartmentID
Where Salary > 15000
Order By Departments.DepartmentID

Select Top(3) Employees.EmployeeID, FirstName From Employees
Left Join EmployeesProjects
On Employees.EmployeeID = EmployeesProjects.EmployeeID
Where EmployeesProjects.EmployeeID is NULL
Order By Employees.EmployeeID

Select FirstName, LastName, HireDate, Departments.[Name] as DeptName From Employees
Inner Join Departments
On Employees.DepartmentID = Departments.DepartmentID
Where HireDate > '1999-1-1' and Departments.[Name] in ('Sales', 'Finance')
Order By HireDate

Select Top(5) Employees.EmployeeID, FirstName, Projects.[Name] as ProjectName From Employees
Inner Join EmployeesProjects
On Employees.EmployeeID = EmployeesProjects.EmployeeID
Inner Join Projects
On EmployeesProjects.ProjectID = Projects.ProjectID
Where Projects.StartDate > '2002-08-13' And EndDate is null
Order by Employees.EmployeeID

Select Employees.EmployeeID, FirstName,
	Case 
		When Startdate >= '2005-01-01' Then NULL
		Else Projects.[Name]
	End
As ProjectName
From Employees
Inner Join EmployeesProjects
On Employees.EmployeeID = EmployeesProjects.EmployeeID
Inner Join Projects
On EmployeesProjects.ProjectID = Projects.ProjectID
Where Employees.EmployeeID = 24

Select e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName As ManagerName From Employees as e
Inner Join Employees as m
On e.ManagerID = m.EmployeeID
Where e.ManagerID in (3,7)
Order By e.EmployeeID

Select Top(50) e.EmployeeID, Concat(e.FirstName, ' ', e.LastName) as EmployeeName,
ConCat(m.FirstName,' ', m.LastName) As ManagerName, d.[Name] as DepartmentName From Employees as e
Inner Join Employees as m
On e.ManagerID = m.EmployeeID
Inner Join Departments as d
On e.DepartmentID = d.DepartmentID
Order By EmployeeID

Select Min(Avarage) as MinAvarageSalary From (
	Select Avg(Salary) as Avarage From Employees
	Group By DepartmentID
	) as A

Use [Geography]

Select c.CountryCode, m.MountainRange, p.PeakName, p.Elevation From Countries as c
Inner Join MountainsCountries as mc
On mc.CountryCode = c.CountryCode
Inner Join Mountains as m
On mc.MountainId = m.Id
Inner Join Peaks as p
On p.MountainId = m.Id
Where c.CountryName = 'Bulgaria' and Elevation > 2835
Order By Elevation DESC

Select CountryCode, Count(MountainId) as MountainRanges From MountainsCountries
Where CountryCode in ('BG', 'RU', 'US')
Group By CountryCode

Select Top(5) c.CountryName, r.RiverName From Countries as c
Inner Join Continents as con
On c.ContinentCode = con.ContinentCode
Left Join CountriesRivers as cr
On cr.CountryCode = c.CountryCode
Left Join Rivers as r
On cr.RiverId = r.Id
Where con.ContinentName = 'Africa'
Order By c.CountryName ASC

Select ContinentCode, CurrencyCode, CurrencyUsage From
	(Select *, DENSE_RANK() Over (Partition By ContinentCode Order By CurrencyUsage DESC) as [Rank] From (
		Select ContinentCode, CurrencyCode, Count (CurrencyCode) as CurrencyUsage From Countries --------15
		Group By ContinentCode, CurrencyCode
		Having Count(CurrencyCode)>1
		) as a
		) as b
Where [Rank] = 1
Order By ContinentCode

Select Count(*) From Countries
Left Join MountainsCountries
On Countries.CountryCode = MountainsCountries.CountryCode
Where MountainsCountries.CountryCode is null

Select Top(5) CountryName, Max(p.Elevation) as HighestPeakElevation, Max(r.[Length]) As LongestRiverLength From Countries as c
Left Join MountainsCountries as mc
On c.CountryCode = mc.CountryCode
Left Join Peaks as p
On mc.MountainId = p.MountainId
Left Join CountriesRivers as cr
On cr.CountryCode = c.CountryCode
Left Join Rivers as r
On cr.RiverId = r.Id
Group By CountryName
Order By Max(p.Elevation) DESC, Max(r.[Length]) Desc, CountryName

Select CountryName as [Country],
	ISNULL(PeakName, '(no highest peak)') as [Highest Peak Name],
	ISNULL(Elevation, 0) as [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') as Mountain From(
	Select CountryName, PeakName, Elevation, MountainRange, Rank() Over (Partition By CountryName Order By Elevation DESC) as [Rank]
	From Countries as c
	Left Join MountainsCountries as mc
	On mc.CountryCode = c.CountryCode
	Left Join Mountains as m
	On mc.MountainId = m.Id
	Left Join Peaks as p
	On p.MountainId = m.Id
	) as a
Where [Rank] = 1
Order By CountryName, [Highest Peak Name]