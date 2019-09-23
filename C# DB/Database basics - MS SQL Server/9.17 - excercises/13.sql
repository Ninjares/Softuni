Create Database Movies 

Use Movies

Create Table Directors(
	Id Int Primary Key,
	DirectorName NvarChar,
	Notes NvarChar(max)
	)
Create Table Genres(
	Id int Primary Key,
	GenreName NvarChar,
	Notes NvarChar(max)
	)
Create Table Categories(
	Id int Primary Key,
	CategoryName NvarChar,
	Notes NvarChar(max)
	)

Create Table Movies (
	Id int Primary Key,
	Title NvarChar,
	DirectorId int Foreign Key References Directors(Id),
	CopyRightYear int,
	[Length] Time, 
	GenreId int Foreign Key References Genres(Id),
	CategoryId int Foreign Key References Categories(Id),
	Rating float,
	Notes NvarChar(max)
	)

Drop Database Movies