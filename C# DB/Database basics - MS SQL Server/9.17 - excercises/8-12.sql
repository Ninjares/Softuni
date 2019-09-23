Use Minions 

Create Table Users(
	Id int Primary Key Identity,
	UserName VarChar(30) NOT NULL,
	[Password] VarChar(26) NOT NULL,
	ProfilePicture VarBinary(Max), Check(DataLength(ProfilePicture)<=921600),
	LastLoginTime DateTime,
	IsDeleted bit NOT NULL,
)

Insert into Users(UserName, [Password], LastLoginTime, IsDeleted) VALUES
('Milcho', 'golemsumebach', '2007-09-15', 1), 
('Rangel', 'Domajorvcepkata', '2007-09-16', 0), 
('Kircho', 'qizlezdatividqochiti', '1980-09-15', 1), 
('GolemoKuche', 'ferman', '2019-09-15', 0),
('Maca', 'margaritki', '2012-09-15', 0) 

Alter table Users
Drop Constraint PK__Users__3214EC07979BDD9B

Alter table Users 
Add Constraint PK_IdAndUsername Primary Key (Id, UserName)

Alter table Users
Add Constraint MinPassLencth Check(Len([Password])>=5)

Alter Table Users
Add Constraint LogOut Default Current_TimeStamp For LastLoginTime;


Alter Table Users
Drop Constraint PK_IdAndUsername
Alter Table Users
Add Constraint Pk_Id Primary Key(Id)
Alter Table Users
Add Constraint MinUsername Check(Len(UserName)>=3)
