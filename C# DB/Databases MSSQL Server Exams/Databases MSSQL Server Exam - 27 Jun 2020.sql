
						-- 01. DDL

CREATE TABLE Clients(
  ClientId	 INT PRIMARY KEY IDENTITY,
  FirstName	 VARCHAR(50) NOT NULL,	
  LastName	 VARCHAR(50) NOT NULL,	
  Phone		 CHAR(12) CHECK (LEN(Phone) = 12) NOT NULL
  )

CREATE TABLE Mechanics(
  MechanicId	INT	PRIMARY KEY IDENTITY,
  FirstName		VARCHAR(50) NOT NULL,	
  LastName		VARCHAR(50) NOT NULL,	
  Address		VARCHAR(255) NOT NULL,
  )

CREATE TABLE Models (
  ModelId	INT	PRIMARY KEY IDENTITY,
  Name		VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs (
  JobId			INT	PRIMARY KEY IDENTITY,
  ModelId		INT FOREIGN KEY REFERENCES Models(ModelId)  NOT NULL ,
  Status		VARCHAR(11) DEFAULT 'Pending' CHECK (Status IN ('Pending', 'In Progress', 'Finished'))  
					 NOT NULL,
  ClientId		INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
  MechanicId	INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
  IssueDate		DATE NOT NULL,	
  FinishDate	DATE
)

CREATE TABLE Orders (
  OrderId	INT	PRIMARY KEY IDENTITY,
  JobId		INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
  IssueDate	DATE ,
  Delivered	BIT	DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors (
  VendorId	INT	PRIMARY KEY IDENTITY,
  [Name]	VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts (
  PartId	INT	PRIMARY KEY IDENTITY,
  SerialNumber	VARCHAR(50) UNIQUE NOT NULL,
  [Description]	VARCHAR(255),
  Price	DECIMAL (15,2) CHECK (Price > 0 AND Price <= 9999.99) NOT NULL,
  VendorId	INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
  StockQty	 INT DEFAULT 0 CHECK (StockQty >= 0)
)

CREATE TABLE PartsNeeded (
  JobId		INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
  PartId	INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
  Quantity	INT DEFAULT 1 CHECK (Quantity > 0)

  CONSTRAINT PK_Parts_Jobs PRIMARY KEY (JobId, PartId)
)

CREATE TABLE OrderParts (
  OrderId	INT FOREIGN KEY REFERENCES Orders(OrderId),
  PartId	INT FOREIGN KEY REFERENCES Parts(PartId),
  Quantity	INT DEFAULT 1 CHECK (Quantity > 0)  NOT NULL 

  CONSTRAINT PK_Orders_Parts PRIMARY KEY (OrderId, PartId)
)
					-- 02.Insert

INSERT INTO Clients (FirstName,	LastName, Phone) VALUES
('Teri',	'Ennaco',	'570-889-5187'),
('Merlyn',	'Lawler',	'201-588-7810'),
('Georgene','Montezuma','925-615-5185'),
('Jettie',	'Mconnell',	'908-802-3564'),
('Lemuel',	'Latzke',	'631-748-6479'),
('Melodie',	'Knipp',	'805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')

INSERT INTO Parts (SerialNumber, [Description],	Price, VendorId) VALUES
('W10780048',	'Suspension Rod',				42.81, 1),
('WP8182119',	'Door Boot Seal',				117.86, 2),
('WPY055980',	'High Temperature Adhesive',	13.94, 3),
('W10841140',	'Silicone Adhesive', 			6.77, 4)

					-- 03. Update

 UPDATE Jobs
 SET MechanicId = 3 , Status = 'In Progress'
 WHERE Status = 'Pending'

					-- 04. Delete

DELETE FROM OrderParts
WHERE OrderId = 19
DELETE FROM Orders
WHERE OrderId = 19

					-- 05. Mechanic Assignments

SELECT FirstName +' ' + LastName AS Mechanic, Status, IssueDate FROM Mechanics AS m
 JOIN Jobs AS j ON j.MechanicId = m.MechanicId
 ORDER BY m.MechanicId, IssueDate, JobId

					-- 06. Current Clients

SELECT FirstName +' ' + LastName AS  Client, DATEDIFF(DAY, IssueDate, '2017-4-24') [Days going], Status FROM Clients AS c
 JOIN Jobs AS j ON j.ClientId = c.ClientId
 WHERE Status IN ('In Progress' , 'Pending')
 ORDER BY DATEDIFF(DAY, IssueDate, '2017-4-24') DESC

					-- 07. Mechanic Performance

SELECT Mechanic, [Average Days] FROM (
SELECT FirstName +' ' + LastName AS Mechanic, m.MechanicId,
		AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days] 
 FROM Mechanics AS m
 JOIN Jobs AS j ON j.MechanicId = m.MechanicId
 WHERE Status = 'Finished'
 GROUP BY FirstName, LastName, m.MechanicId) AS r
 ORDER BY r.MechanicId

					-- 08. Available Mechanics

SELECT FirstName +' ' + LastName AS Mechanic FROM Mechanics AS m
 LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
 WHERE j.JobId IS NULL OR (SELECT COUNT(JobId) FROM Jobs WHERE Status != 'Finished' AND								MechanicId = m.MechanicId
						GROUP BY MechanicId, Status) IS NULL
 GROUP BY m.MechanicId, (m.FirstName +' ' + m.LastName)


 
SELECT * FROM Jobs
					-- 09. Past Expenses
					-- 10. Missing Parts
					-- 11. Place Order
					-- 12. Cost of Order







