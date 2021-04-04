
					-- 01. DDL

CREATE TABLE Planets (
 Id		INT PRIMARY KEY IDENTITY,
 Name	VARCHAR(30) NOT	NULL -- moje da e CHAR ili NVARCHAR
)

CREATE TABLE Spaceports (
 Id		INT PRIMARY KEY IDENTITY,
 Name	VARCHAR(50) NOT	NULL,
 PlanetId	INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships (
 Id				INT PRIMARY KEY IDENTITY,
 Name			VARCHAR(50) NOT	NULL,
 Manufacturer	VARCHAR(30) NOT	NULL,
 LightSpeedRate	INT DEFAULT 0
)

CREATE TABLE Colonists (
 Id			INT PRIMARY KEY IDENTITY,
 FirstName	VARCHAR(20) NOT	NULL,
 LastName	VARCHAR(20) NOT	NULL,
 Ucn		VARCHAR(10) NOT	NULL UNIQUE,
 BirthDate	DATE NOT NULL 
)

CREATE TABLE Journeys (
 Id			INT PRIMARY KEY IDENTITY,
 JourneyStart	DateTime	NOT NULL ,
 JourneyEnd		DateTime	NOT NULL ,
 Purpose	VARCHAR(11) CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
 DestinationSpaceportId	INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
 SpaceshipId	INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards (
 Id			INT PRIMARY KEY IDENTITY,
 CardNumber	VARCHAR(10) NOT	NULL UNIQUE,
 JobDuringJourney	VARCHAR(8) CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
 ColonistId	INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
 JourneyId	INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

					-- 02. Insert

INSERT INTO Planets (Name) VALUES
('Mars'),('Earth'), ('Jupiter'), ('Saturn')

INSERT INTO Spaceships (Name, Manufacturer, LightSpeedRate) VALUES
('Golf',	 'VW',		3),
('WakaWaka', 'Wakanda',	4),
('Falcon9',  'SpaceX',	1),
('Bed',		 'Vidolov',	6)

					-- 03. Update

UPDATE Spaceships
 SET LightSpeedRate += 1
 WHERE Id BETWEEN 8 AND 12

					-- 04. Delete

DELETE FROM TravelCards
 WHERE JourneyId IN (1,2,3)

DELETE TOP(3) FROM Journeys
 
					-- 05. Select All Military Journeys

SELECT Id, CONVERT(VARCHAR, JourneyStart, 103),CONVERT(VARCHAR, JourneyEnd, 103) 
 FROM Journeys
 WHERE Purpose = 'Military'
 ORDER BY JourneyStart 

					-- 06. Select All Pilots

SELECT c.id, CONCAT(FirstName,' ', LastName) AS full_name 
 FROM Colonists c
 JOIN TravelCards tc ON tc.ColonistId = c.Id
 WHERE JobDuringJourney = 'Pilot'
 ORDER By c.Id

					-- 07. Count Colonists

SELECT COUNT(*) FROM Colonists c
 JOIN TravelCards tc ON tc.ColonistId = c.Id
 JOIN Journeys j ON j.Id = tc.JourneyId
 WHERE Purpose = 'Technical'

					-- 08. Select Spaceships With Pilots

SELECT s.Name, Manufacturer FROM Colonists c
 JOIN TravelCards tc ON tc.ColonistId = c.Id
 JOIN Journeys j ON j.Id = tc.JourneyId
 JOIN Spaceships s ON s.Id = j.SpaceshipId
 WHERE BirthDate > '1989/01/01' AND JobDuringJourney = 'Pilot'
 ORDER BY s.Name

					-- 09. Planets And Journeys

SELECT p.Name AS PlanetName,COUNT(j.Id) AS JourneysCount
 FROM Planets p
 JOIN Spaceports s ON s.PlanetId = p.Id
 JOIN Journeys j ON j.DestinationSpaceportId = s.Id
 GROUP BY p.Name
 ORDER BY COUNT(j.Id) DESC, p.Name

					-- 10. Select Special Colonists

SELECT * FROM (SELECT JobDuringJourney, 
	CONCAT(FirstName,' ', LastName) AS FullName,
	DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) AS Ranked
 FROM Colonists c
 JOIN TravelCards tc ON tc.ColonistId =  c.Id) AS r
  WHERE Ranked = 2

					-- 11. Get Colonists Count

CREATE FUNCTION dbo.udf_GetColonistsCount (@PlanetName VARCHAR (30))
RETURNS INT
BEGIN
 RETURN (SELECT COUNT(c.Id) AS [Count] FROM Planets p
 JOIN Spaceports s ON p.Id = s.PlanetId
 JOIN Journeys j ON j.DestinationSpaceportId = s.Id
 JOIN TravelCards tc ON tc.JourneyId = j.Id
 JOIN Colonists c ON c.Id = tc.ColonistId

 WHERE p.Name LIKE @PlanetName)
 END
 
					-- 12. Change Journey Purpose

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
 
   IF NOT EXISTS (SELECT Id FROM Journeys WHERE Id = @JourneyId)
     THROW 50001, 'The journey does not exist!', 1
   
   IF @NewPurpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)
	 THROW 50002, 'You cannot change the purpose!', 1

  UPDATE Journeys
   SET Purpose = @NewPurpose
   WHERE Id = @JourneyId

 END