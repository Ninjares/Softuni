Use Softuni

Create Table MyTable(
	MyDate Date,
	MyTime Time,
	MyDateTime DateTime
	)
Truncate Table MyTable

Insert Into MyTable (MyDate, MyTime, MyDateTime) VALUES
('01.01.2019', '20:41', '01/01/2019 12:45:33'),
('20190101', '20:41:42.5', '01/01/2019 12:45:33.234')

Select * From MyTable