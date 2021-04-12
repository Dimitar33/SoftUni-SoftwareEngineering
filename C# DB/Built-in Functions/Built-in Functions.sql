
							--Queries for SoftUni Database
				-- 1. Find Names of All Employees by First Name

SELECT FirstName, LastName FROM Employees 
 WHERE FirstName LIKE 'sa%'

				-- 2. Find Names of All employees by Last Name 

SELECT FirstName, LastName FROM Employees 
 WHERE LastName LIKE '%ei%'

				-- 3. Find First Names of All Employees

SELECT FirstName FROM Employees
 WHERE DepartmentID IN (3, 10) AND HireDate BETWEEN '1995' AND '2006'

				-- 4. Find All Employees Except Engineers

SELECT FirstName, LastName FROM Employees 
 WHERE JobTitle  NOT LIKE '%engineer%'

				-- 5. Find Towns with Name Length

SELECT [Name] FROM Towns
 WHERE LEN(Name) IN (5, 6)
 ORDER BY [Name]

				-- 6. Find Towns Starting With

SELECT TownID, [Name] FROM Towns
 WHERE [Name] LIKE '[b e m k]%'
 ORDER BY [Name]

				-- 7. Find Towns Not Starting With

SELECT TownID, [Name] FROM Towns
 WHERE [Name] NOT LIKE '[b d r]%'
 ORDER BY [Name]

				-- 8. Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
 WHERE HireDate > '2001'
								--OR, BOTH VALID

SELECT FirstName, LastName, DATEPART(YEAR, HireDate) FROM Employees
 WHERE DATEPART(YEAR, HireDate) > 2000

				-- 9. Length of Last Name

SELECT FirstName, LastName FROM Employees
 WHERE LEN(LastName) = 5

				-- 10. Rank Employees by Salary

SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY  EmployeeID ) [Rank] FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000
 ORDER BY Salary DESC


				-- 11. Find All Employees with Rank 2 *

SELECT * FROM (
SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY  EmployeeID ) [Rank] FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000 
 ) AS Result
 WHERE [Rank] = 2
 ORDER BY Salary DESC
 
						--Queries for Geography Database
						
				-- 12. Countries Holding ‘A’ 3 or More Times

SELECT CountryName, IsoCode FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
 ORDER BY IsoCode

				-- 13. Mix of Peak and River Names

SELECT PeakName, RiverName, 
		LOWER(LEFT(PeakName ,(LEN(PeakName) - 1))) + LOWER(RiverName) AS Mix 
	FROM Peaks, Rivers
 WHERE LEFT(RiverName, 1) = RIGHT(PeakName, 1)
 ORDER BY Mix

						-- Queries for Diablo Database

				-- 14. Games from 2011 and 2012 year

SELECT TOP(50) [Name],CONVERT(VARCHAR, [Start], 23) AS [Start] FROM Games
 WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
 ORDER BY [Start], [Name]

				-- 15. User Email Providers

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider] FROM Users
 ORDER BY [Email Provider], Username

				-- 16. Get Users with IPAdress Like Pattern

SELECT Username, IPAddress FROM Users
 WHERE IpAddress LIKE '___.1%.%.___'
 ORDER BY Username

				-- 17. Show All Games with Duration and Part of the Day

SELECT [Name] ,
 CASE 
   WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
   WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon '
   ELSE 'Evening'
   END AS [Part of the Day],
 CASE
  WHEN Duration <= 3 THEN 'Extra Short'
  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
  WHEN Duration > 6 THEN 'Long'
  ELSE 'Extra Long'
  END AS Duration
   FROM Games
 ORDER BY [Name], Duration, [Part of the Day]

				-- 18. Orders Table

SELECT ProductName, OrderDate, 
		DATEADD(DAY, 3 , OrderDate) AS [Pay Due],
		DATEADD(MONTH, 1 , OrderDate) AS [Delivery Due]
 FROM Orders

				
				
