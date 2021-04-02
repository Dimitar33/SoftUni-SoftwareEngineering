					-- 01. DDL

CREATE TABLE Cities (
	Id		INT PRIMARY KEY IDENTITY NOT NULL,
	Name	VARCHAR(20) NOT	NULL,
	CountryCode	CHAR(2) NOT	NULL
)

CREATE TABLE Hotels (
	Id			INT PRIMARY KEY IDENTITY NOT NULL,
	Name		VARCHAR(30) NOT	NULL,
	CityId		INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount	INT NOT NULL,
	BaseRate	DECIMAL (18,2)
)

CREATE TABLE Rooms (
	Id		INT PRIMARY KEY IDENTITY NOT NULL,
	Price	DECIMAL (18,2) NOT NULL,
	Type	VARCHAR(20) NOT	NULL,
	Beds	INT NOT NULL,
	HotelId	INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips (
	Id	INT PRIMARY KEY IDENTITY NOT NULL,
	RoomId	INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate	DATE NOT NULL ,
	ArrivalDate	DATE NOT NULL ,
	ReturnDate	DATE NOT NULL ,
	CancelDate	DATE,
	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts (
	Id		INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName	VARCHAR(50) NOT	NULL,
	MiddleName	VARCHAR(20) ,	
	LastName	VARCHAR(50) NOT	NULL,
	CityId	INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate	DATE NOT NULL,
	Email	VARCHAR(100) UNIQUE NOT	NULL
)

CREATE TABLE AccountsTrips (
	AccountId	INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId	INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage	INT CHECK (Luggage >= 0) NOT NULL
	CONSTRAINT PK_Accounts_Trips PRIMARY KEY (AccountId, TripId)
)

					-- 02. Insert

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
 ('John',	'Smith',		'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
 ('Gosho',	 NULL,			'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
 ('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
 ('Friedrich', 'Wilhelm', 'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

 INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

					-- 03. Update

UPDATE Rooms
 SET Price *= 1.14
 WHERE HotelId IN (5,7,9)

					-- 04. Delete

DELETE FROM AccountsTrips
WHERE AccountId = 47

DELETE FROM Accounts
WHERE Id = 47

					-- 05. EEE-Mails

SELECT FirstName, LastName, 
		CONVERT(VARCHAR, BirthDate, 110), Name, Email 
 FROM Accounts a
 JOIN Cities c ON c.Id = a.CityId
 WHERE Email LIKE 'e%'
 ORDER BY c.Name

					-- 06. City Statistics

SELECT c.Name, COUNT(h.Name) AS Hotels FROM Cities c
 JOIN Hotels h ON h.CityId = c.Id
 GROUP BY c.Name
 ORDER BY COUNT(h.Name) DESC, c.Name

					-- 07. Longest and Shortest Trips

SELECT  AccountId, FirstName + ' ' + LastName AS FullName, 
	    MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip, 
		MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
 FROM Trips t 
 JOIN AccountsTrips ac ON ac.TripId = t.Id
 JOIN Accounts a ON ac.AccountId = a.Id
 WHERE CancelDate IS NULL AND MiddleName IS NULL
 GROUP BY AccountId,(FirstName + ' ' + LastName)
 ORDER BY LongestTrip DESC, ShortestTrip

					-- 08. Metropolis

SELECT TOP (10) c.Id, c.Name AS City, CountryCode AS Country, COUNT(a.Id) AS Accounts
 FROM Cities c
 JOIN Accounts a ON a.CityId = c.Id
 GROUP BY c.Id, c.Name, CountryCode
 ORDER BY Accounts DESC

					-- 09. Romantic Getaways

SELECT a.Id, a.Email, c.Name, COUNT(t.Id)
 FROM Accounts a
 JOIN AccountsTrips atr ON atr.AccountId = a.Id
 JOIN Trips t ON t.Id = atr.TripId
 JOIN Rooms r ON r.Id = t.RoomId
 JOIN Hotels h ON h.Id = r.HotelId
 JOIN Cities c ON c.Id = h.CityId
 WHERE a.CityId = h.CityId
 GROUP BY c.Name, a.Id, a.Email
 ORDER BY COUNT(t.Id) DESC, a.Id

					-- 10. GDPR Violation

SELECT t.Id, FirstName +' '+ ISNULL(MiddleName + ' ', '') + LastName AS [Full Name], 
			ac.Name [From], hc.Name [To],
			CASE 
			  WHEN CancelDate IS NOT NULL THEN 'Canceled' 
			  ELSE CONVERT(VARCHAR, (DATEDIFF(DAY, ArrivalDate, ReturnDate))) + ' days'
			END AS Duration
 FROM AccountsTrips atr
 JOIN Trips t ON atr.TripId = t.Id
 JOIN Accounts a ON atr.AccountId = a.Id
 JOIN Cities ac ON ac.Id = a.CityId
 JOIN Rooms r ON t.RoomId = r.Id
 JOIN Hotels h ON h.Id = r.HotelId
 JOIN Cities hc ON hc.Id = h.CityId
 ORDER BY [Full Name], TripId

					-- 11. Available Room

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR (MAX)
BEGIN
    DECLARE @RoomInfo VARCHAR(MAX) = 
	      (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.[Type] + ' (' +
		  CONVERT(VARCHAR, r.Beds) + ' beds) - $' +
		  CONVERT(VARCHAR, (BaseRate + Price) * @People)
				FROM Rooms r
				JOIN Hotels h ON h.Id = r.HotelId
				WHERE @People <= Beds AND HotelId = @HotelId
				AND NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.id AND
			   CancelDate IS NULL AND @Date BETWEEN ArrivalDate AND ReturnDate)
			   ORDER BY (BaseRate + Price) * @People DESC)
		IF
		@RoomInfo IS NULL 
			RETURN 'No rooms available'

		RETURN @RoomInfo
END

					-- 12. Switch Room

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TargetRoomHotelId INT = 
			(SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId	)
	DECLARE @TripHotelId INT =
			(SELECT HotelId FROM Rooms r
			 JOIN Trips t ON t.RoomId = r.Id
			 JOIN Hotels h ON r.HotelId = h.Id
			 WHERE t.Id = @TripId)

    IF @TargetRoomHotelId != @TripHotelId
	  THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @TripAccounts INT =
			(SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
    
	DECLARE @BedsNeeded INT =
			(SELECT Beds FROM Rooms  WHERE Id = @TargetRoomId) 

	IF @TripAccounts > @BedsNeeded
	   THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips
	  SET RoomId = @TargetRoomId
	  WHERE Id = @TripId



