Use Demo

Select SUBSTRING('SoftUni', 5,3) --Get a part of a string (string, start, length)
Select REPLACE('Softuni', 'Soft', 'Hard') --Replace part of a string (string, replace, with)
Select Left('String', 3) --Get n characters from the beginning of the string (string, n)
Select Right('String', 3) --Get n characters from the end of the string (string, n)
Select Lower('StRiNg')
Select Upper('sTrInG')
Select REVERSE('Forward')
Select REPLICATE('Bumpa ', 10) -- Copy a string n ammount of times (string, n)
Select CHARINDEX('find', 'Where Am find me', 2) --Returns the position of the start of the pattern, the offset doesn not affect the result
Select Stuff ('It''s gonna be here, yeet', 15,4,'benis') --Adds a substring into a main string (string being added to, start position, chars to delete after the string, substring to add)
--Select FORMAT() -- in excercise
SELECT TRANSLATE('2*[3+4]/{7-2}', '[]{}', '()()') --replaces chars in string with new set of chars (string, chars to replace, new chars)

Select * From Triangles
Select Id, (A*B)/2 As Area From Triangles
Select Pi()
Select ABS(-3.5) -- x => |x|
Select SQRT(9) -- x => √x
Select SQUARE(4) -- x => x*x
Select Power(10, 3) --(x,n) => xⁿ
Select Round(Pi(), 5) --Rounds with up to n digit precision
Select Floor(4.3)
Select Ceiling(4.3)
Select Sign(5)
Select Sign(-3)
Select Sign(0)
Select Rand() --random float between 0 and 1
Select Rand(1827)

Select Datepart (QUARTER, '2017/08/25') --Selects a part of the date check w3schools for more details (can be year, month or day)
Select Year('2017/08/25')
Select MONTH('2017/08/25')
Select Day('2017/08/25')
Select DATEDIFF(Week, '2017/08/25', '2018/09/19') --Distance between 2 dates
Select DATENAME(weekday, '2017/08/25') -- month also works
Select DATEADD(week, 2, '2018/09/19') --adds (,x,) of (x,,) to (,,x)
Select GETDATE() -- get current date
Select EOMONTH('2018/02/19') -- end of month

Select Cast('45' as decimal(3,1)) --turns one datatype into another
Select CONVERT(decimal(3,1), '45')
Select ISNULL(NULL, 'is Null') --if the data is null it return a specified data/object
Select ISNULL(5, 'is Null') --if not then it returns the data

Use SoftUni
Select * From Employees
OFFSET 1 Rows
Fetch Next 3 Rows 
