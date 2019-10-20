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
Create Proc usp_DeleteEmployeesFromDepartment (@departmendId int) As
Begin
	Delete From EmployeesProjects Where EmployeeID in (Select EmployeeID From Employees Where @departmendId=DepartmentID) --Working
	Update Employees Set ManagerID = null Where ManagerID in (Select EmployeeID From Employees Where @departmendId=DepartmentID)
	Alter Table Departments Alter Column ManagerID int null
	Update Departments Set ManagerID = Null Where DepartmentID = @departmendId
	Delete From Employees Where @departmendId=DepartmentID
	Delete From Departments Where @departmendId=DepartmentID
	Alter Table Departments Alter Column ManagerID int not null
	Select Count(*) From Employees Where DepartmentID = @departmendId
End

------
Use Bank

Create Proc usp_GetHoldersFullName As
	Select ConCat(FirstName , ' ',LastName) as [FullName] From AccountHolders

------

Create Proc usp_GetHoldersWithBalanceHigherThan (@HigherThan money) as
Begin
	Select [First Name], [Last Name] From (Select FirstName as [First Name], LastName as [Last Name], Sum(Accounts.Balance) as Total From Accounts
	Inner Join AccountHolders
	On Accounts.AccountHolderId=AccountHolders.Id
	Group By FirstName, LastName
	) as A
	Where Total > @HigherThan
	Order By [First Name], [Last Name]
End
Exec usp_GetHoldersWithBalanceHigherThan @HigherThan = 50000

Create Function ufn_CalculateFutureValue (@sum money, @InterestRate float, @years int)
Returns decimal(10,4)
Begin
	Return @sum * Power(@interestRate + 1, @years)
End

Select dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

Create Proc usp_CalculateFutureValueForAccount(@AccountId int, @InterestRate float) as
Begin
	Select Accounts.Id as [Account Id], FirstName as [First Name], LastName as [Last Name], Balance as [Current Balance],
	dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) as [Balance in 5 years] From Accounts
	Inner Join AccountHolders
	On Accounts.AccountHolderId=AccountHolders.Id
	Where Accounts.Id=@AccountId
End

Exec usp_CalculateFutureValueForAccount @AccountId = 5, @InterestRate = 0.06

-----------
Use Diablo 

Create Or Alter Function ufn_CashInUsersGames (@GameName NvarChar(50))
Returns @OutPut Table (SumCash Decimal(18,4))
Begin
	Insert into @OutPut Select(
	Select Sum(Cash) as [SumCash] From (
	Select Cash, ROW_NUMBER() Over(Order By Cash DESC) as RN From UsersGames
	Inner Join Games
	On Games.Id = UsersGames.GameId
	Where [Name] = @GameName
	) as A
	Where RN % 2!=0
	)
	Return
End

Select dbo.ufn_CashInUsersGames('Love in a Mist')

-------
Use Bank