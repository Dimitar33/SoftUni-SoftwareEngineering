					-- 01. DDL

CREATE TABLE Countries (
  Id	INT PRIMARY KEY IDENTITY,
  Name	VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers (
  Id			INT PRIMARY KEY IDENTITY,
  FirstName		VARCHAR(25)  NOT NULL,
  LastName		VARCHAR(25)  NOT NULL,
  Gender		CHAR(1) CHECK (Gender IN ( 'M', 'F')) NOT NULL,
  Age			INT NOT NULL,
  PhoneNumber	VARCHAR(10),
  CountryId		INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products (
  Id			INT PRIMARY KEY IDENTITY,
  Name			VARCHAR(25) UNIQUE NOT NULL	,
  Description	VARCHAR(250) ,
  Recipe		VARCHAR(MAX),	-- not null ?
  Price			DECIMAL (12,2) CHECK (Price >= 0) NOT NULL
)

CREATE TABLE Feedbacks (
  Id			INT PRIMARY KEY IDENTITY,
  Description	VARCHAR(255) ,
  Rate			DECIMAL (4,2) NOT NULL,
  ProductId		INT FOREIGN KEY REFERENCES Products(Id),
  CustomerId	INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors (
  Id			INT PRIMARY KEY IDENTITY,
  Name			VARCHAR(25)	UNIQUE NOT NULL,
  AddressText	VARCHAR(30) NOT NULL,	
  Summary		VARCHAR(200),
  CountryId		INT FOREIGN KEY REFERENCES  Countries(Id)
)

CREATE TABLE Ingredients (
  Id				INT PRIMARY KEY IDENTITY,
  Name				VARCHAR(30) NOT NULL,	
  Description		VARCHAR(200),	
  OriginCountryId	INT FOREIGN KEY REFERENCES Countries(Id),
  DistributorId		INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients (
  ProductId		INT FOREIGN KEY REFERENCES Products(Id)  NOT NULL,
  IngredientId	INT FOREIGN KEY REFERENCES Ingredients(Id) NOT NULL
  PRIMARY KEY (ProductId, IngredientId)
)

					-- 02. Insert

INSERT INTO Distributors (Name, CountryId, AddressText, Summary) VALUES
('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',		13,	'58 Hancock St',	'Customer loyalty'),
('Kitchen People',		1,	'3 E 31st St #77',	'Triple-buffered stable delivery'),
('General Color Co Inc',21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',	23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) 
 VALUES
('Francoise',	'Rautenstrauch',	15, 'M', '0195698399',	5),
('Kendra',		'Loud',				22,	'F', '0063631526',	11),
('Lourdes',		'Bauswell',			50, 'M', '0139037043',	8),
('Hannah',		'Edmison',			18, 'F', '0043343686',	1),
('Tom',			'Loeza',			31, 'M', '0144876096',	23),
('Queenie',		'Kramarczyk',		30, 'F', '0064215793',	29),
('Hiu',			'Portaro',			25, 'M', '0068277755',	16),
('Josefa',		'Opitz',			43, 'F', '0197887645',	17)

					-- 03. Update

UPDATE Ingredients
 SET DistributorId = 35
 WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
 SET OriginCountryId = 14
 WHERE OriginCountryId = 8

					-- 04. Delete

DELETE FROM Feedbacks
 WHERE CustomerId = 14 or ProductId = 5

					-- 05. Products By Price

SELECT Name, Price, Description FROM Products
 ORDER BY Price DESC , Name

					-- 06. Negative Feedback

SELECT ProductId, Rate, Description, CustomerId, Age, Gender
 FROM Feedbacks f
 JOIN Customers c ON c.Id = f.CustomerId
 WHERE Rate < 5
 ORDER BY ProductId DESC , Rate

					-- 07. Customers without Feedback

SELECT CONCAT(FirstName,' ', LastName) AS CustomerName, c.PhoneNumber, c.Gender
 FROM Customers c
 LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
 WHERE f.Id IS NULL
 ORDER BY c.Id

					-- 08. Customers by Criteria
					
SELECT FirstName, Age, PhoneNumber FROM Customers
WHERE CountryId != 31 AND Age > 20 AND (FirstName LIKE '%an%' OR PhoneNumber LIKE '%38')
ORDER BY FirstName

					-- 09. Middle Range Distributors

SELECT d.Name, i.Name, p.Name, AVG(Rate)
 FROM Distributors d
 JOIN Ingredients i ON i.DistributorId = d.Id
 JOIN ProductsIngredients pin ON pin.IngredientId = i.Id
 JOIN Products p ON p.Id = pin.ProductId
 JOIN Feedbacks f ON f.ProductId = p.Id
 GROUP BY d.Name, i.Name, p.Name
 HAVING AVG(Rate) BETWEEN 5 AND 8
 ORDER BY d.Name, i.Name, p.Name

					-- 10. Country Representative

SELECT CountryName, DisributorName
	FROM (SELECT c.Name AS CountryName, d.Name AS DisributorName, 
	  COUNT(i.Name) AS Quantity,
	  DENSE_RANK() OVER(PARTITION BY c.name ORDER BY COUNT(i.Name) DESC) AS Ranked
     FROM Distributors d
     LEFT JOIN Ingredients i ON i.DistributorId = d.Id
     LEFT JOIN Countries c ON c.Id = d.CountryId
     GROUP BY c.Name, d.Name) AS r
 WHERE Ranked = 1
 ORDER BY CountryName

					-- 11. Customers With Countries

CREATE VIEW v_UserWithCountries 
AS
SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName, Age, Gender, ctr.Name AS CountryName
 FROM Customers cus
 JOIN Countries ctr ON cus.CountryId = ctr.Id

					-- 12. Delete Products

CREATE TRIGGER dbo.ProductsToDelete
ON Products 
INSTEAD OF DELETE 
AS
BEGIN
	DECLARE @OroductToDelete INT =
				(SELECT p.Id FROM Products p
				 JOIN deleted d ON d.Id = p.Id)

  DELETE FROM Feedbacks
  WHERE ProductId = @OroductToDelete

  DELETE FROM ProductsIngredients
  WHERE ProductId = @OroductToDelete

  DELETE FROM Products
  WHERE Id = @OroductToDelete
  END



