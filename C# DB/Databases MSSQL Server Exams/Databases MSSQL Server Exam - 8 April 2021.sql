
						-- 01. DDL

CREATE TABLE Users (
  Id	INT PRIMARY KEY IDENTITY,
  Username	VARCHAR (30) UNIQUE NOT NULL,
  Password	VARCHAR(50) NOT NULL,
  Name		VARCHAR(50),
  Birthdate	DATETIME,
  Age		INT CHECK (Age BETWEEN 14 AND 110),
  Email		VARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
  Id	INT PRIMARY KEY IDENTITY,
  Name	VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
  Id		INT PRIMARY KEY IDENTITY,
  FirstName	VARCHAR(25),
  LastName	VARCHAR(25),
  Birthdate	DATETIME,
  Age		INT CHECK (Age BETWEEN 18 AND 110),
  DepartmentId	INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories (
  Id	INT PRIMARY KEY IDENTITY,
  Name	VARCHAR(50) NOT NULL,
  DepartmentId	INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status (
  Id	INT PRIMARY KEY IDENTITY,
  Label	VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
  Id	INT PRIMARY KEY IDENTITY,
  CategoryId	INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
  StatusId		INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
  OpenDate	DATETIME NOT NULL,
  CloseDate	DATETIME,
  Description	VARCHAR(200) NOT NULL,
  UserId	INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
  EmployeeId	INT FOREIGN KEY REFERENCES Employees(Id)
)

						-- 02. Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES 
('Marlo',	'O''Malley',		1958-9-21	,1 ),
('Niki' ,	'Stanaghan',	1969-11-26	,4 ),
('Ayrton' ,	'Senna',		1960-03-21	,9 ),
('Ronnie' ,	'Peterson',		1944-02-14	,9 ),
('Giovanna','Amati',		1959-07-20	,5 )

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, 
						Description, UserId, EmployeeId)
VALUES
(1	,1	,'2017-04-13' ,	NULL		,'Stuck Road on Str.133			',6,	2 ),
(6	,3	,'2015-09-05' ,2015-12-06	,'Charity trail running			',3,	5 ),
(14	,2	,'2015-09-07' ,	NULL		,'Falling bricks on Str.58		',5,	2 ),
(4	,3	,'2017-07-03' ,2017-07-06	,'Cut off streetlight on Str.11	',1,	1 )

						-- 03. Update

UPDATE Reports
 SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL

						-- 04. Delete

DELETE Reports
 WHERE StatusId = 4

						-- 05. Unassigned Reports

SELECT Description, CONVERT(VARCHAR, OpenDate, 105)
 FROM Reports
 WHERE EmployeeId IS NULL
 ORDER BY OpenDate, Description

						-- 06. Reports & Categories

SELECT Description, c.Name
 FROM Reports r
 JOIN Categories c ON c.Id = r.CategoryId
 WHERE CategoryId IS NOT NULL
 ORDER BY Description, c.Name

						-- 07. Most Reported Category

SELECT TOP (5) c.Name, COUNT(r.Id) AS ReportsNumber
 FROM Categories c
 JOIN Reports r ON r.CategoryId = c.Id
 GROUP BY c.Name
 ORDER BY COUNT(r.Id) DESC, c.Name

						-- 08. Birthday Report

SELECT Username, c.Name
 FROM Users u
 JOIN Reports r ON r.UserId = u.Id
 JOIN Categories c ON c.Id = r.CategoryId
 WHERE MONTH(Birthdate) = MONTH(OpenDate) AND  DAY(Birthdate) =  DAY(OpenDate)
 ORDER BY Username, c.Name

						-- 09. User per Employee

SELECT CONCAT(FirstName, ' ', LastName) AS FullName, COUNT(u.Username) FROM Users u
 JOIN Reports r ON r.UserId = u.Id
 RIGHT JOIN Employees e ON e.Id = r.EmployeeId
 GROUP BY CONCAT(FirstName, ' ', LastName)
 ORDER BY  COUNT(u.Username) DESC, CONCAT(FirstName, ' ', LastName)

						-- 10. Full Info

SELECT ISNULL(FirstName + ' '+ LastName,'None') Employee, 
		ISNULL(d.Name , 'None') Department,
		c.Name Category, r.Description, CONVERT(VARCHAR, r.OpenDate, 104),
		s.Label Status, u.Name [User]
 FROM Reports r
 LEFT JOIN Users u ON u.Id = r.UserId
 LEFT JOIN Status s ON s.Id = r.StatusId
 LEFT JOIN Employees e ON e.Id = r.EmployeeId
 LEFT JOIN Categories c ON c.Id = r.CategoryId
 LEFT JOIN Departments d ON d.Id = e.DepartmentId
 ORDER BY FirstName DESC, LastName DESC , d.Name DESC, c.Name, Description, 
			CONVERT(VARCHAR, r.OpenDate, 104), s.Label, u.Name

						-- 11. Hours to Complete

CREATE FUNCTION  udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT 

BEGIN

  RETURN ( SELECT TOP(1)
 CASE 
  WHEN @StartDate IS NULL OR @EndDate IS NULL THEN  0
  ELSE DATEDIFF(HOUR, @StartDate, @EndDate )
  END AS TotalHours
  FROM Reports)
  END



						-- 12. Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS

  DECLARE @EmployeeDepartment INT = 
		(SELECT d.Id FROM Employees e 
		 JOIN Departments d ON d.Id = e.DepartmentId
		 WHERE e.Id = @EmployeeId)

  DECLARE @ReportDepartmentId INT = 
		(SELECT TOP(1) d.Id FROM Reports r
		 JOIN Categories c ON c.Id = r.CategoryId
		 JOIN Departments d ON d.Id = c.DepartmentId
		 WHERE c.id = @ReportId)

	 IF @EmployeeDepartment != @ReportDepartmentId
	   THROW 50002, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
	 SET EmployeeId = @EmployeeId
	 WHERE Id = @ReportId						






