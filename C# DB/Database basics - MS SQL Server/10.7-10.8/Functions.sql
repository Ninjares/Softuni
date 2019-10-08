Use SoftUni

Create Function udf_ProcessText(@Sometext VarChar(30))
Returns VarChar(50)
As 
	Begin
		Return @Sometext + ' up ya bumpa'
	End

Select dbo.udf_ProcessText('Nibba')

Create Function udf_SalaryLevel(@Salary Decimal)
Returns VarChar(10)
Begin
	Declare @ReturnWord VarChar(10)
	IF(@Salary<25000)
		Set @ReturnWord = 'Low'
	Else 
		IF(@Salary>=25000 and @Salary<=75000) Set @ReturnWord = 'Medium'
	Else 
		Set @ReturnWord = 'High' 
	Return @ReturnWord
End

Drop Function udf_SalaryLevel

Select dbo.udf_SalaryLevel(24000)

------Procedural (table returning) Functions

Create Proc dbo.usp_SeniorEmployees
As
	Select * From Employees
	Where DATEDIFF(Year, Hiredate, GetDate()) >= 19

Exec dbo.usp_SeniorEmployees