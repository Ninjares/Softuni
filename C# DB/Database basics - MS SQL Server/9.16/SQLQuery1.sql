DECLARE @MyChar CHAR(4) = 'Test'
Declare @MyVarChar VARCHAR(4) = 'Test'
Declare @MyNvarChar NVARCHAR(4) = 'Test'

Select DATALENGTH(@MyChar) AS MyChar, DATALENGTH(@MyVarChar) AS MyVarChar, DATALENGTH(@MyNvarChar) AS MyNVarChar
Select @MyChar AS MyChar, @MyVarChar AS MyVarChar, @MyNvarChar AS MyNVarChar