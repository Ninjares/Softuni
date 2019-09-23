Use Minions

Create Table People(
	Id int Primary Key Identity,
	[Name] NVarChar(200) NOT NULL,
	Picture Image,
	Height Decimal(5,2),
	[Weight] Decimal(5,2), 
	Gender char(1) Check(Gender='m' OR Gender='f') Not Null, 
	BirthDate Date NOT NULL,
	Biography NvarChar(Max)
)

Insert into People ([Name], Height, [Weight], Gender, BirthDate, Biography) Values
('Nibba1', 1.9, 65, 'm', '1997-05-15', 'Smonks Bigg Bluntz'),
('Nekkav', 1.5, 40, 'm', '1957-05-15', 'Jalka napushalka'),
('Boyko', 2.1, 90, 'f', '1955-05-15', 'Asfalt'),
('Moyko', 1.8, 80, 'f', '1497-05-15', 'aaaaaaaaaaaaaaaaaaa'),
('Engie', 1.7, 70, 'm', '1967-05-15', 'Erecting dispensers')

Select * From People
Drop Table People