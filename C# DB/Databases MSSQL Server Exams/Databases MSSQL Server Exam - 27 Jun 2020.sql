
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

					-- 09. Past Expenses

SELECT * FROM ( 
	SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity),0) AS Total  FROM Jobs AS j
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
	 WHERE Status = 'Finished'
	 GROUP BY j.JobId) AS r
  ORDER BY r.Total DESC, JobId

					-- 10. Missing Parts

SELECT p.PartId, p.[Description], pn.Quantity AS [Required], 
		StockQty AS [In Stock],
		IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
 FROM Parts AS p
 LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
 LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
 LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
 LEFT JOIN Orders AS o ON o.JobId = j.JobId
 WHERE Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
 ORDER BY PartId

					-- 11. Place Order

CREATE PROC usp_PlaceOrder (@jobID INT, @serialNumber VARCHAR(50), @quantity INT) 
AS
BEGIN
  IF @quantity <= 0
	 THROW 50012, 'Part quantity must be more than zero!', 1
  ELSE IF NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @jobID)
	 THROW 50013, 'Job not found!', 1
  ELSE IF EXISTS (SELECT JobID FROM Jobs WHERE JobId = @jobID AND Status = 'Finished')
     THROW 50011, 'This job is not active!', 1
  ELSE IF NOT EXISTS (SELECT SerialNumber FROM Parts WHERE SerialNumber = @serialNumber)
	 THROW 50014, 'Part not found!', 1

	 DECLARE @partId INT = 
		(SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

	 DECLARE @ExistingOrderId INT =
	   (SELECT o.OrderID FROM Orders o 
	     JOIN Jobs j ON j.JobId = o.JobId
		 JOIN OrderParts op ON op.OrderId = o.OrderId
		 WHERE o.IssueDate IS NULL AND j.JobId = @jobID AND op.PartId = @partId)

	 IF @ExistingOrderId IS NULL
	   BEGIN 
	    INSERT INTO Orders(JobId, IssueDate) VALUES
		 (@jobID, NULL)

		SELECT @ExistingOrderId = OrderId FROM Orders o
		 JOIN Jobs j ON j.JobId = o.JobId
		 WHERE o.IssueDate IS NULL AND j.JobId = @jobID

   INSERT INTO OrderParts(OrderID, PartId , quantity) VALUES
    (@ExistingOrderId, @partId, @quantity)
	END
  ELSE
   BEGIN
    UPDATE OrderParts
	  SET Quantity += @quantity
	  WHERE OrderId = @ExistingOrderId
   END
END

					-- 12. Cost of Order

CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL (12,2)
AS
BEGIN
  DECLARE @result DECIMAL (12,2) = (SELECT SUM(Price * Quantity) AS TotalSum 
  FROM Orders AS o
  JOIN OrderParts AS op ON op.OrderId = o.OrderId
  JOIN Parts AS p ON p.PartId = op.PartId
  WHERE JobId = @jobId
  GROUP BY JobId)  
  RETURN ISNULL(@result, 0)
 END




 SELECT o.JobId, (Price) FROM Parts AS p
 LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
 LEFT JOIN Orders AS o ON o.OrderId = op.OrderId
 LEFT JOIN Jobs AS j ON o.JobId = j.JobId


