Create Database Airport
Use AirPort

Create Table Planes (
	Id int Primary Key Identity,
	[Name] VarChar(30) NOT NULL,
	Seats int NOT NULL,
	[Range] int NOT NULL
	)

Create Table Flights(
	Id int Primary Key Identity,
	DepartureTime DateTime,
	ArrivalTime DateTime,
	Origin VarChar(50) NOT NULL,
	Destination VarChar(50) NOT NULL,
	PlaneId int NOT NULL Foreign Key References Planes(Id)
)

Create Table Passengers(
	Id int Primary Key Identity,
	FirstName VarChar(30) NOT NULL,
	LastName VarChar(30) NOT NULL,
	Age int NOT NULL,
	[Address] VarChar(30) NOT NULL,
	PassportId Char(11) NOT NULL
	)

Create Table LuggageTypes(
	Id int Primary Key Identity,
	Type VarChar(30) NOT NULL
	)

Create Table Luggages(
	Id int Primary Key Identity,
	LuggageTypeId int NOT NULL Foreign Key References LuggageTypes(Id),
	PassengerId int NOT NULL Foreign Key References Passengers(Id)
)

Create Table Tickets(
	Id int Primary Key Identity,
	PassengerId int Foreign Key References Passengers(Id) NOT NULL,
	FlightId int Foreign Key References Flights(Id) NOT NULL,
	LuggageId int Foreign Key References Luggages(Id) NOT NULL,
	Price Decimal(12,2) NOT NULL
)

Insert Into Planes([Name], Seats, [Range]) VALUES
('Airbus 336',	112,	5132),
('Airbus 330',	432,	5325),
('Boeing 369',	231,	2355),
('Stelt 297',	254,	2143),
('Boeing 338',	165,	5111),
('Airbus 558',	387,	1342),
('Boeing 128',	345,	5541)

Insert Into LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

Update Tickets
Set Price *= 1.13
Where FlightId = (Select Id From Flights Where Destination = 'Carlsbad')

Delete From Tickets Where FlightId = (Select Id From Flights Where Destination = 'Ayn Halagim')
Delete From Flights Where Destination = 'Ayn Halagim'

-----Querying

Select * From Planes
Where [Name] Like '%tr%'
Order By Id, [Name], Seats, [Range]

Select FlightId, Sum(Price) as Price From Tickets
Group By FlightId
Order By Sum(Price) DESC

Select Concat(FirstName,' ',LastName) as [Full Name], Origin, Destination From Tickets
Inner Join Passengers
On Tickets.PassengerId = Passengers.Id
Inner Join Flights
On Tickets.FlightId = Flights.Id
Order By Concat(FirstName,' ',LastName), Origin, Destination

Select FirstName as [First Name], LastName as [Last Name], Age From Passengers
Left Join Tickets
On Tickets.PassengerId = Passengers.Id
Where Tickets.Id is NULL
Order By Age DESC, FirstName, LastName

Select Concat(FirstName, ' ', LastName) as [Full Name], Planes.[Name], Concat(Origin,' - ', Destination) as Trip, LuggageTypes.[Type] as [Luggage Type] From Passengers
Inner Join Tickets
On Passengers.Id = Tickets.PassengerId
Inner Join Flights
On Tickets.FlightId = Flights.Id
Inner Join Planes
On Flights.PlaneId = Planes.Id
Inner Join Luggages
On Tickets.LuggageId = Luggages.Id
Inner Join LuggageTypes
On Luggages.LuggageTypeId = LuggageTypes.Id
Order By FirstName, LastName, Planes.[Name], Origin, Destination, [Luggage Type]

Select Planes.[Name], Planes.Seats, Count(PassengerId) as [Passengers Count] From Planes
Left Join Flights
On Planes.Id = Flights.PlaneId
Left Join Tickets
On Flights.Id = Tickets.FlightId
Group By Planes.[Name], Planes.Seats
Order By Count(PassengerId) Desc, [Name], Seats

Create Or Alter Proc usp_CancelFlights As
Begin
	Update Flights
	Set DepartureTime = Null, ArrivalTime = Null
	Where (DepartureTime < ArrivalTime) and (DepartureTime is not null and ArrivalTime is not null)
End

Exec usp_CancelFlights

Create Function udf_CalculateTickets(@origin VarChar(50) , @destination VarChar(50), @peopleCount int)
Returns VarChar(30)
Begin
	Declare @ReturnString VarChar(30)
	If(@peopleCount<1)
	Set @ReturnString = 'Invalid people count!'
	Else If(0=(Select Count(*) From Flights Where @origin = Flights.Origin and @destination = Flights.Destination))
	Set @ReturnString = 'Invalid flight!'
	Else
	Begin
		Declare @TotalSum Decimal(10,2)
		Set @TotalSum = @peopleCount*(Select Price From Flights Inner Join Tickets On Tickets.FlightId = Flights.Id  Where @origin = Flights.Origin and @destination = Flights.Destination)
		Set @ReturnString = CONCAT('Total price ', @TotalSum)
	End
	Return @ReturnString
End

Select dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)