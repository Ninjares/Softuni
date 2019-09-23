Use SoftUni
Create View v_EmployeesSalaryInfo as
Select FirstName +' '+ LastName as [FullName], JobTitle, Salary From dbo.Employees
Select DepartmentID, JobTitle From Employees

Select * From Employees Where MiddleName is NULL

Select Top(5) * From Employees Order By Salary Desc

Select * From v_EmployeesSalaryInfo

Select * From Employees Where EmployeeID = 10

Select FirstName, LastName, JobTitle Into FiredEmployess From Employees 
Select*From FiredEmployess

CREATE SEQUENCE seq_Employees_ID As Int
Start with 1 
Increment By 1
Select Next Value For seq_Employees_ID

--When Deleting From Tables An entry must not be referenced in a relationship as a one

Update Employees
Set AddressID = NULL
Where AddressID = 5

Delete From EmployeesProjects Where ProjectID = 5
