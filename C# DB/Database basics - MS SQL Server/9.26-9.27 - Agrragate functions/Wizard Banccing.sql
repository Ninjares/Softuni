Use Gringotts
Select * From WizzardDeposits

Select Count(Id) From WizzardDeposits
Select Max(MagicWandSize) From WizzardDeposits
Select DepositGroup, Max(MagicWandSize) as LongestMagicWand From WizzardDeposits
Group By DepositGroup

Select Top(2) DepositGroup From WizzardDeposits
Group By DepositGroup Order By Avg(MagicWandSize) Asc

Select DepositGroup, Sum(DepositAmount) as TotalSum From WizzardDeposits
Group By DepositGroup

Select DepositGroup, Sum(DepositAmount) as TotalSum From WizzardDeposits
Where MagicWandCreator = 'Ollivander family'
Group By DepositGroup

Select * From (Select DepositGroup, Sum(DepositAmount) as TotalSum From WizzardDeposits
Where MagicWandCreator = 'Ollivander family'
Group By DepositGroup) as t
Where TotalSum < 150000
Order By TotalSum DESC

Select DepositGroup, MagicWandCreator, Min(DepositCharge) as MinDepositCharge From WizzardDeposits
Group By DepositGroup, MagicWandCreator
Order By MagicWandCreator, DepositGroup

Select AgeGroup, Count(AgeGroup) as WizardCount From 
	(Select 
	Case
		When Age Between 0 and 10  then '[0-10]'
		When Age Between 11 and 20 then '[11-20]'
		When Age Between 21 and 30 then '[21-30]'
		When Age Between 31 and 40 then '[31-40]'
		When Age Between 41 and 50 then '[41-50]'
		When Age Between 51 and 60 then '[51-60]'
		else '[61+]'
	 End as AgeGroup
     From WizzardDeposits
	) as t
Group By AgeGroup

Select Left(FirstName, 1) as FirstLetter From WizzardDeposits
Where DepositGroup = 'Troll Chest'
Group By Left(FirstName, 1)

Select DepositGroup, IsDepositExpired, Avg(DepositInterest) as AverageInterest From WizzardDeposits
Where DepositStartDate > '1985-01-01'
Group By DepositGroup, IsDepositExpired Order By DepositGroup Desc, IsDepositExpired Asc  

Select Sum(SumPiece) as [SumDifference] From(
Select 
Top((Select Count(Id) From WizzardDeposits) - 1) d.Id, d.DepositAmount, t.ToChange, d.DepositAmount-t.ToChange as SumPiece From WizzardDeposits as d
Inner Join (Select Id, DepositAmount as ToChange From WizzardDeposits order By Id Offset 1 Rows) as t
On d.Id = t.Id - 1
) as z



Use SoftUni
Select * From Employees

Select DepartmentId, Sum(Salary) as TotalSalary From Employees
Group By DepartmentID

Select DepartmentID, Min(Salary) as MinimumSalary From Employees
Where DepartmentID In (2,5,7) and HireDate>'2000-01-01'
Group By DepartmentID Order By DepartmentID

Select * Into NewEmployeesTable From Employees
Where Salary > 30000
Delete From NewEmployeesTable Where ManagerID = 42
Update NewEmployeesTable
Set Salary += 5000
Where DepartmentID = 1
Select DepartmentId, Avg(Salary) as AvarageSalary From NewEmployeesTable
Group By DepartmentID

Select * From (Select DepartmentID, Max(Salary) as MaxSalary From Employees
Group By DepartmentID) as A
Where MaxSalary Not BetWeen 30000 and 70000

Select Count(Salary) as [Count] From Employees --17
Where ManagerID is Null

Select Distinct DepartmentID, Salary From (Select DepartmentId, Salary, 
DENSE_RANK() Over (Partition By DepartmentId Order by Salary Desc) as [Rank] From Employees)as A 
Where [Rank] = 3

--19
Select Top(10)FirstName, LastName, DepartmentId From Employees as e1
Where Salary >
		(
		Select Avg(Salary) From Employees as e2
		Where e2.DepartmentID = e1.DepartmentID
		Group By DepartmentID
		)
Order By e1.DepartmentID