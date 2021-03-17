
			-- 1. Create Database

CREATE DATABASE Minions

			-- 2. Create Tables

CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(30),
	Age INT 
)

CREATE TABLE Towns

(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(30)
)

			-- 3. Alter Minions Table

ALTER TABLE Minions
ADD TownId INT 



ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(ID)


			-- 4. Insert Records in Both Tables

INSERT INTO Towns(Id, Name) VALUES
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

INSERT INTO Minions (Id, Name, Age , TownId) VALUES
		(1, 'Kevin', 22, 1),
		(2, 'Bob' , 15, 3),
		(3, 'Steward', NULL, 2)

			-- 5. Truncate Table Minions (empty table)

DELETE Minions
DELETE Towns

			-- 6. Drop All Tables (delete table)

DROP TABLE Minions
DROP TABLE Towns

			-- 7. Create Table People

CREATE TABLE People
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(200) NOT NULL,
 Picture VARCHAR(MAX),
 Height DECIMAL(12,2),
 [Weight] DECIMAL(12,2),
 Gender CHAR(1) NOT NULL,
 Birthdate DATETIME NOT NULL,
 Biography VARCHAR(MAX)
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
 ('Pesho', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4', 165.11, 88.54, 'm' , '1982-12-12', null),
 ('Ivan', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4', 175.1, 78.54, 'f' , '1982-2-12', 'asd'),
 ('Adsa', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4', 132.21, 68.54, 'f' , '1982-3-12', null),
 ('Ndsa', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4', 177.31, 98.54, 'm' , '1982-2-12', 'asdsadas'),
 ('Gosho', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4', 162.1, 78.54, 'm' , '1982-11-12', null)

			--8. Create Table Users

CREATE TABLE Users
(
 Id BIGINT IDENTITY,
 Username VARCHAR(30) NOT NULL,
 [Password] VARCHAR(26) NOT NULL,
 ProfilePicture VARCHAR(MAX),
 LastLoginTime DATETIME,
 IsDeleted BIT
)
INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho', 'superpass', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4' , '2020/12/12', 0),
('ASdas', 'sup21erpass', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4' , '2020/11/12', 0),
('PeDssho', 'wwq342', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4' , '2020/12/1', 0),
('WEds', 'ewaw423', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4' , '2020/12/4', 0),
('Rasd', 'supererepass', 'https://avatars.githubusercontent.com/u/75310146?s=400&u=5f3c7ccd24ff85e372bb2d9194e8912ec9c9fec0&v=4' , '2020/12/21', 0)

			-- 9. Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

			-- 10. Add Check Constraint

ALTER TABLE Users
ADD CONSTRAINT CH_PassAtLeast5Simbols CHECK(LEN([Password]) > 5 )

			-- 11. Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT DF_LastLogInTime DEFAULT GETDATE() FOR LastLoginTime

			-- 12. Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameAtLeast3Symbols CHECK (LEN(Username) > 2)

			-- 13. Movies Database

CREATE DATABASE Movies

CREATE TABLE Directors
(
 Id INT PRIMARY KEY IDENTITY,
 DirectorName VARCHAR(50) NOT NULL,
 Notes VARCHAR (MAX)
)

CREATE TABLE Genres
(
 Id INT PRIMARY KEY IDENTITY,
 GenreName VARCHAR(50) NOT NULL,
 Notes VARCHAR (MAX)
)

CREATE TABLE Categories
(
 Id INT PRIMARY KEY IDENTITY,
 CategoryName VARCHAR(50) NOT NULL,
 Notes VARCHAR (MAX)
)

CREATE TABLE Movies
(
 Id INT PRIMARY KEY IDENTITY,
 Title VARCHAR(50) NOT NULL,
 DirectorId INT NOT NULL,
 CopyrightYear DATETIME NOT NULL,
 [Length] INT NOT NULL, 
 GenreId INT NOT NULL,
 CategoryId INT NOT NULL,
 Rating DECIMAL (5,2),
 Notes VARCHAR (MAX)
)

INSERT INTO Directors( DirectorName, Notes) VALUES
 ( 'Stiven King', NULL),
 ( 'Pesho', NULL),
 ( 'Ivan', 'asd'),
 ( 'Lukas', NULL),
 ( 'Arts', 'SW')

 INSERT INTO Genres( GenreName, Notes) VALUES
 ( 'Horror', 'scary'),
 ( 'Comedy', NULL),
 ( 'Action', 'asd'),
 ( 'SKYFY', NULL),
 ( 'Fantasy', 'gfd')

 INSERT INTO Categories( CategoryName, Notes) VALUES
 ( 'Animated', 'scary'),
 ( 'Clasic', NULL),
 ( 'Manga', 'asd'),
 ( 'Documentary', NULL),
 ( 'Serial', 'wredd')

 INSERT INTO Movies
 (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
 VALUES
  ('Rambo',		2, 1983, 93, 3 , 1, 8.2, 'asd'),
  ('It',		1, 1984, 63, 1 , 2, 5.2, 'gdfh'),
  ('Matrix',	3, 1999, 133, 5 , 3, 9.2, 'qweq'),
  ('AceVentura',4, 1993, 111, 2 , 4, 8.6, 'ggg'),
  ('StarWars',	5, 1973, 243, 4 , 5, 8.4, 'fd')

			-- 14. Car Rental Database

CREATE DATABASE CarRental 			

CREATE TABLE Categories 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 CategoryName VARCHAR(30) NOT NULL, 
 DailyRate DECIMAL (9,2) NOT NULL, 
 WeeklyRate DECIMAL (9,2) NOT NULL, 
 MonthlyRate DECIMAL (9,2) NOT NULL, 
 WeekendRate DECIMAL (9,2) 
)

INSERT INTO 
Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Economy', 12.21, 41.2, 123.11, NULL ),
('Compact', 15.21, 51.2, 155.11, NULL ),
('Mini', 7.21, 31.2, 73.11, NULL )

CREATE TABLE Cars 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 PlateNumber VARCHAR(10) NOT NULL, 
 Manufacturer VARCHAR(30) NOT NULL, 
 Model VARCHAR(30) NOT NULL, 
 CarYear DATETIME , 
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
 Doors INT NOT NULL, 
 Picture VARCHAR(MAX), 
 Condition VARCHAR (30), 
 Available BIT NOT NULL
)

INSERT INTO Cars 
(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
 ('A1211KA', 'BMW', 'X5', '1-12-2005', 1, 4, 'Good', 1),
 ('A2431KA', 'asda', 'gfd', '5-05-2012', 1, 4, 'Fair', 1),
 ('A1744KA', 'Bgfd', 'zxc', '12-11-2015', 1, 4, 'Good', 0)

CREATE TABLE Employees 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 FirstName VARCHAR(30) NOT NULL, 
 LastName VARCHAR(30) NOT NULL, 
 Title VARCHAR(30) NOT NULL, 
 Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
 ('Pesho', 'Peshev', 'mehanic', NULL),
 ('Ivan', 'Peshev', 'mehanic', NULL),
 ('Gosho', 'Peshev', 'security', NULL)

CREATE TABLE Customers 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 DriverLicenceNumber VARCHAR (30) NOT NULL, 
 FullName VARCHAR(50) NOT NULL, 
 [Address] VARCHAR(100) NOT NULL, 
 City VARCHAR (20) NOT NULL, 
 ZIPCode INT , 
 Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
 ('1234121', 'Ivan Ivanov', 'asda324sadwqe', 'Sofia', 9120, NULL),
 ('143244121', 'Iwertan Isada', 'assdf12dsadwqe', 'Bs', 8120, NULL),
 ('124353121', 'Iewran Iewr', 'asdgfd1dwqe', 'Pl', 5120, NULL)

CREATE TABLE RentalOrders 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
 CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
 CarId INT FOREIGN KEY REFERENCES Cars(Id), 
 TankLevel INT , 
 KilometrageStart INT, 
 KilometrageEnd INT, 
 TotalKilometrage AS KilometrageEnd - KilometrageStart, 
 StartDate DATETIME NOT NULL, 
 EndDate DATETIME NOT NULL, 
 TotalDays AS DATEDIFF(DAY, StartDate, EndDate), 
 RateApplied DECIMAL (9,2), 
 TaxRate DECIMAL (9,2), 
 OrderStatus VARCHAR (20) NOT NULL, 
 Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 3,  123, 213, '1-1-2012', '12-1-2012', NULL, NULL, 'available', NULL),
(2, 2,  213, 323, '1-2-2012', '12-3-2012', NULL, NULL, 'not available', NULL),
(3, 1,  323, 433, '1-12-2012', '12-12-2012', NULL, NULL, 'reserved', NULL)

 SELECT * FROM RentalOrders
			-- 15. Hotel Database

CREATE DATABASE Hotel

CREATE TABLE Employees
(
 Id  INT PRIMARY KEY IDENTITY, 
 FirstName VARCHAR(30) NOT NULL, 
 LastName VARCHAR(30) NOT NULL, 
 Title  VARCHAR(30) NOT NULL, 
 Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Pesho', 'Peshev', 'barman', 'mashina'),
('Ivan', 'Ivanov', 'shef', 'asd'),
('Gosho', 'Goshev', 'master', NULL)

CREATE TABLE Customers 
(
 AccountNumber BIGINT PRIMARY KEY NOT NULL,
 FirstName VARCHAR(30) NOT NULL, 
 LastName VARCHAR(30) NOT NULL, 
 PhoneNumber VARCHAR(15) NOT NULL, 
 EmergencyName VARCHAR(50), 
 EmergencyNumber VARCHAR(15), 
 Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(123123223, 'Asd', 'Ddsfad', '43432423', NULL, NULL, NULL),
(12543323, 'SAD', 'Dqwed', '412341423', NULL, NULL, NULL),
(123123123, 'ASf', 'Dfdsfd', '435435343', NULL, NULL, NULL)

CREATE TABLE RoomStatus 
(
 RoomStatus VARCHAR(20) NOT NULL, 
 Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Busy', NULL),
('Empty', NULL),
('Reserved', NULL)


CREATE TABLE RoomTypes 
(
 RoomType VARCHAR(30) PRIMARY KEY, 
 Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
 ('Apartment', NULL),
 ('Suite', NULL),
 ('Studio', NULL)

CREATE TABLE BedTypes 
(
 BedType VARCHAR(30) PRIMARY KEY NOT NULL,
 Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
 ('single' , NULL),
 ('double' , NULL),
 ('king size', 'asda')


CREATE TABLE Rooms 
(
 RoomNumber INT PRIMARY KEY IDENTITY NOT NULL, 
 RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType), 
 BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType), 
 Rate DECIMAL (5,2) NOT NULL, 
 RoomStatus VARCHAR(30) NOT NULL, 
 Notes VARCHAR(MAX)
 )
 
INSERT INTO Rooms (Rate, RoomStatus) VALUES
 ( 50.54 , 'free'),
 ( 55.54 , 'free'),
 ( 66.54 , 'free')


CREATE TABLE Payments 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
 PaymentDate DATETIME NOT NULL, 
 AccountNumber BIGINT FOREIGN KEY REFERENCES Customers(AccountNumber), 
 FirstDateOccupied DATETIME NOT NULL, 
 LastDateOccupied DATETIME NOT NULL, 
 TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied), 
 AmountCharged DECIMAL(9,2) NOT NULL, 
 TaxRate DECIMAL(5,2), 
 TaxAmount DECIMAL(5,2), 
 PaymentTotal DECIMAL(9,2), 
 Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
 (1, GETDATE(), '1-12-2020', '12-12-2020', 1231.22, NULL, NULL ,1231.22, NULL),
 (2, GETDATE(), '1-1-2020', '12-1-2020', 1251.22, NULL, NULL ,1251.22, NULL),
 (3, GETDATE(), '1-4-2020', '12-4-2020', 12131.22, NULL, NULL ,12131.22, NULL)

CREATE TABLE Occupancies 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
 DateOccupied DATETIME NOT NULL, 
 AccountNumber BIGINT FOREIGN KEY REFERENCES Customers(AccountNumber), 
 RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
 RateApplied DECIMAL(6,2), 
 PhoneCharge DECIMAL(6,2), 
 Notes VARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, RoomNumber) VALUES
 (1, '1-2-2012', 1),
 (2, '1-4-2012', 3),
 (3, '12-2-2012', 2)

				-- 16. Create SoftUni Database

CREATE DATABASE SoftUni

CREATE TABLE Towns 
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR (50) NOT NULL
)

CREATE TABLE Addresses 
(
 Id INT PRIMARY KEY IDENTITY, 
 AddressText VARCHAR (200) NOT NULL, 
 TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
 Id INT PRIMARY KEY IDENTITY, 
 [Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Employees 
(
 Id INT PRIMARY KEY IDENTITY, 
 FirstName VARCHAR(30) NOT NULL, 
 MiddleName VARCHAR(30), 
 LastName VARCHAR(30) NOT NULL, 
 JobTitle VARCHAR(50) NOT NULL, 
 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
 HireDate DATETIME NOT NULL, 
 Salary DECIMAL(9,2) NOT NULL, 
 AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

				-- 17. Backup Database

				-- 18. Basic Insert

INSERT INTO Towns ([Name]) VALUES
 ('Sofia'), 
 ('Plovdiv'), 
 ('Varna'), 
 ('Burgas')

INSERT INTO Departments ([Name]) VALUES
 ('Engineering'), 
 ('Sales'), 
 ('Marketing'), 
 ('Software Development'),
 ('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
 ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',	4,	'01/02/2013',	3500.00),
 ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
 ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25),
 ('Georgi', 'Teziev', 'Ivanov',	'CEO', 2, '09/12/2007', 3000.00),
 ('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88)

				-- 19. Basic Select All Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

				-- 20. ⦁	Basic Select All Fields and Order Them

SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC 

				-- 21. Basic Select Some Fields

SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC 

				-- 22. Increase Employees Salary

USE SoftUni
UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees
ORDER BY Salary DESC 

				-- 23. Decrease Tax Rate

USE Hotel
UPDATE Payments
SET TaxRate = 0.97;
SELECT TaxRate FROM Payments

				-- 24. Delete All Records

USE Hotel
DELETE  Occupancies
SELECT * FROM Occupancies