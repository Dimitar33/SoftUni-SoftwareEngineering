CREATE DATABASE TableRelations


				-- 1. One-To-One Relationship

CREATE TABLE Passports
(
 PassportID INT PRIMARY KEY IDENTITY(101, 1),
 PassportNumber CHAR(8)
)

INSERT INTO Passports (PassportNumber) VALUES
 ('N34FG21B'),
 ('K65LO4R7'),
 ('ZE657QP2')

CREATE TABLE Persons
(
 PersonID INT PRIMARY KEY IDENTITY,
 FirstName VARCHAR(30),
 Salary VARCHAR (30),
 PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Persons (FirstName, Salary, PassportID) VALUES
 ('Roberto', 43300.00, 102),
 ('Tom', 56100.00, 103),
 ('Yana', 60200.00, 101)

				-- 2. One-To-Many Relationship

CREATE TABLE Manufacturers
(
 ManufacturerID INT PRIMARY KEY IDENTITY ,
 [Name] VARCHAR(50),
 EstablishedOn DATETIME 
)

INSERT INTO Manufacturers ([Name], EstablishedOn) VALUES
 ('BMW', '07/03/1916'),
 ('Tesla', '01/01/2003'),
 ('Lada', '01/05/1966')

CREATE TABLE Models
(
 ModelID INT PRIMARY KEY IDENTITY (101, 1),
 [Name] VARCHAR (100),
 ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models ([Name], ManufacturerID) VALUES
 ('X1',		1),	
 ('i6',		1),			
 ('Model S', 2),			
 ('Model X', 2),			
 ('Model 3', 2),			
 ('Nova',	3)		

				-- 3. Many-To-Many Relationship

CREATE TABLE Students
(
 StudentID INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR (100)
)

INSERT INTO Students VALUES
 ('Mila'),('Toni'),('Ron')

CREATE TABLE Exams
(
 ExamID INT PRIMARY KEY IDENTITY (101, 1),
 [Name] VARCHAR(100)
)

INSERT INTO Exams VALUES
 ('SpringMVC'), ('Neo4j'), ('Oracle 11g')

CREATE TABLE StudentsExams
(
 StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
 ExamID INT FOREIGN KEY REFERENCES Exams(ExamID)

 CONSTRAINT PK_Sudents_Exams PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams VALUES
 (1, 101),
 (1, 102),
 (2, 101),
 (3, 103),
 (2, 102),
 (2, 103)

				-- 4. Self-Referencing 

CREATE TABLE Teachers
( 
 TeacherID INT PRIMARY KEY IDENTITY (101, 1),
 [Name] VARCHAR (100) NOT NULL,
 ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers ([Name], ManagerID) VALUES
 ('John',	NULL),
 ('Maya',	106),
 ('Silvia',	106),
 ('Ted',	105),
 ('Mark',	101),
 ('Greta',	101)

				-- 5. Online Store Database

CREATE TABLE Cities
(
 CityID INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50)
)

CREATE TABLE Customers
(
 CustomerID INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 Birthday DATE,
 CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE ItemTypes
(
 ItemTypeID INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Items
(
 ItemID INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(100) NOT NULL,
 ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Orders
(
 OrderID INT PRIMARY KEY IDENTITY,
 CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 ItemID INT FOREIGN KEY REFERENCES Items(ItemID)

 CONSTRAINT PK_Orrders_Items PRIMARY KEY (OrderID, ItemID)
)

				-- 6. University Database

CREATE DATABASE UniversityDatabase
USE UniversityDatabase

CREATE TABLE Majors
(
 MajorID INT PRIMARY KEY IDENTiTY,
 [Name] VARCHAR (100)
)

CREATE TABLE Subjects
(
 SubjectID INT PRIMARY KEY IDENTITY,
 SubjectName VARCHAR (100)
)

CREATE TABLE Students
(
 StudentID INT PRIMARY KEY IDENTITY,
 StudentNumber INT NOT NULL,
 StudentName VARChAR (100) NOT NULL,
 MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
 StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
 SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

 CONSTRAINT PK_Students_Subjects PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
 PaymentID INT PRIMARY KEY IDENTITY,
 PaymentDate DATE,
 PaymentAmount DECIMAL (11,2),
 StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

					-- 7. Peaks in Rila
USE Geography

SELECT MountainRange, PeakName, Elevation FROM Mountains, Peaks
WHERE MountainId = 17 AND MountainRange = 'Rila'
ORDER BY Elevation DESC








