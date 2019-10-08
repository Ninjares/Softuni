Use Softuni

Create Proc usp_GetEmployeesSalaryAbove35000 As
	Select FirstName as [First Name], LastName as [Last Name] From Employees
	Where Salary > 35000

Create or Alter Proc usp_GetEmployeesSalaryAboveNumber(@Above Decimal(18,4)) As
	Select FirstName as [First Name], LastName as [Last Name] From Employees
	Where Salary >= @Above

Exec usp_GetEmployeesSalaryAboveNumber @Above = 48100

Create Proc usp_GetTownsStartingWith (@StartWith VarChar(20)) As
Select [Name] as [Town] From Towns
Where Left([Name], Len(@StartWith)) = @StartWith

Exec usp_GetTownsStartingWith @StartWith = 'b'

Create Proc usp_GetEmployeesFromTown (@Town varchar(50)) As
	Select FirstName as [First Name], LastName as [Last Name] From Employees
	Inner Join Addresses
	On Addresses.AddressID = Employees.AddressID
	Inner Join Towns
	On Addresses.TownID = Towns.TownID
	Where Towns.Name = @Town

Exec usp_GetEmployeesFromTown @Town = 'Sofia'

Create Function ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
Returns VarChar(7)
Begin 
	Declare @SalaryLevel VarChar(7)
	If(@Salary<30000)
		Set @SalaryLevel = 'Low'
	Else If(@Salary > 50000)
		Set @SalaryLevel = 'High'
	Else Set @SalaryLevel = 'Average'
	Return @SalaryLevel
End

Select dbo.ufn_GetSalaryLevel(25000)

Create Proc usp_EmployeesBySalaryLevel(@SalaryLevel VarChar(7)) As
	Select FirstName as [First Name], LastName as [Last Name] From Employees
	Where @SalaryLevel = dbo.ufn_GetSalaryLevel(Salary)

Exec usp_EmployeesBySalaryLevel @SalaryLevel = 'High'

Create Function ufn_IsWordComprised(@setOfLetters VarChar(30), @word VarChar(30))
Returns Bit
Begin
	Declare @IsComprised Bit Set @IsComprised = 1
	Declare @AtWordLetter int Set @AtWordLetter = 1
	while (@AtWordLetter <= Len(@word))
	Begin
		Declare @AtLetter int
		Set @AtLetter = 1
		Declare @IsContained bit
		Set @IsContained = 0
		While(@AtLetter <= Len(@setOfLetters))
			Begin 
			If(SUBSTRING(@setOfLetters, @AtLetter, 1) = SUBSTRING(@word, @AtWordLetter, 1)) 
				Set @IsContained = 1
			Set @AtLetter = @AtLetter + 1
			End;
		If(@IsContained = 0) Set @IsComprised = 0
		Set @AtWordLetter = @AtWordLetter + 1
	End;
	Return @IsComprised
End

Select dbo.ufn_IsWordComprised('oistmiahf', 'sofia')

Use SoftUni
Create  Proc usp_DeleteEmployeesFromDepartment (@departmendId int) As
Alter Table dbo.Departments Alter Column ManagerID int Null
Update Departments Set ManagerID = null Where @departmendId=DepartmentID
Delete From Employees Where DepartmentID=@departmendId
Delete From Departments Where Departments.DepartmentID = @departmendId
Alter Table dbo.Departments Alter Column ManagerID int Not Null
Select Count(*) From Employees Where DepartmentID = @departmendId

Exec usp_DeleteEmployeesFromDepartment @departmendId = 4

Use [master]
Drop Database SoftUni