
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

			-- 5. Truncate Table Minions

DELETE Minions
DELETE Towns

			-- 6. Drop All Tables

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
 Title VARCHAR(50),
 DirectorId INT,
 CopyrightYear DATETIME,
 [Length] TIME, 
 GenreId INT,
 CategoryId INT,
 Rating DECIMAL (5,2),
 Notes VARCHAR (MAX)
)

INSERT INTO Directors(Id, DirectorName, Notes) VALUES
 (1, 'Stiven King', NULL),
 (2, 'Pesho', NULL),
 (3, 'Ivan', 'asd'),
 (4, 'Lukas', NULL),
 (5, 'Arts', 'SW')



SELECT * FROM Users







