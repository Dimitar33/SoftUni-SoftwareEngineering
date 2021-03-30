						--Queries for SoftUni Database

				-- 1. Employees with Salary Above 35000

--CREATE PROC usp_GetEmployeesSalaryAbove35000 
--AS
--SELECT FirstName, LastName FROM Employees
--WHERE Salary > 35000

				-- 2. Employees with Salary Above Number

--CREATE PROC usp_GetEmployeesSalaryAboveNumber @Salary DECIMAL(18,4)
--AS
--SELECT FirstName, LastName FROM Employees
--WHERE Salary >= @Salary

				-- 3. Town Names Starting With

--CREATE PROC usp_GetTownsStartingWith @String VARCHAR(20)
--AS
--SELECT [Name] AS Town FROM Towns
--WHERE [Name] LIKE @String + '%'

				-- 4. Employees from Town

--CREATE PROC usp_GetEmployeesFromTown @TownName VARCHAR(30)
--AS
--SELECT FirstName, LastName FROM Employees AS e
--  JOIN Addresses AS a ON a.AddressID = e.AddressID
--  JOIN Towns AS t ON t.TownID = a.TownID
-- WHERE t.[Name] = @TownName

				-- 5. Salary Level Function

--ALTER FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
--RETURNS VARCHAR(30)
--AS
-- BEGIN
-- DECLARE @result VARCHAR(30)

--  IF @salary < 30000
--	SET @result = 'Low'

--  ELSE IF @salary BETWEEN 30000 AND 50000
--    SET @result = 'Average'

--  ELSE
--    SET @result = 'High'

--  RETURN @result 
--  END

				-- 6. Employees by Salary Level

--CREATE PROC usp_EmployeesBySalaryLevel @salary VARCHAR(20)
--AS
--SELECT FirstName, LastName FROM Employees
--  WHERE dbo.ufn_GetSalaryLevel(Salary) = @salary

				-- 7. Define Function

--CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50) , @word VARCHAR (50)) 
--RETURNS INT
--AS
-- BEGIN 
--	 DECLARE @count INT = 0

--  WHILE @count < LEN(@word)
--	 BEGIN
--		SET @count += 1
--		DECLARE @CurrenLetter VARCHAR(1) = SUBSTRING(@word, @count, 1)

--		IF CHARINDEX(@CurrenLetter, @setOfLetters) = 0
--		 RETURN 0

--	 END
-- RETURN 1
-- END

				-- 8. Delete Employees and Departments

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
 ALTER TABLE Departments 
 ALTER COLUMN ManagerID INT NULL

 DELETE FROM EmployeesProjects
 WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

 UPDATE Employees
   SET ManagerID = NULL
  WHERE DepartmentID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

 UPDATE Employees
   SET ManagerID = NULL
  WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

 UPDATE Departments 
 SET ManagerID = NULL
 WHERE DepartmentID = @departmentId

DELETE FROM Employees 
 WHERE DepartmentID = @departmentId

DELETE FROM Departments
 WHERE DepartmentID = @departmentId

 SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

 EXEC usp_DeleteEmployeesFromDepartment 1

						-- Queries for Bank Database

				-- 9. Find Full Name

CREATE PROC usp_GetHoldersFullName 
AS
SELECT FirstName + ' ' + LastName AS [Full Name] FROM AccountHolders

				-- 10. People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@balance DECIMAL(18, 2))
AS
SELECT FirstName, LastName FROM AccountHolders AS ah
 JOIN Accounts AS a ON a.AccountHolderId = ah.Id
 GROUP BY FirstName,LastName
  HAVING SUM(Balance) > @balance
  ORDER BY FirstName,LastName

				-- 11. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,2), @yearlyInterestRate float, @numberOfYears int)
RETURNS DECIMAL (18,4)
AS
 BEGIN 
	DECLARE @result DECIMAL (18,4) = @Sum*(POWER((1 + @yearlyInterestRate), @numberOfYears))
	RETURN @result
END

				-- 12. Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interest DECIMAL (12,2))
AS
SELECT a.Id AS [Account Id], FirstName, LastName, Balance AS [Current Balance], dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) AS [Balance in 5 years]
 FROM AccountHolders AS ah
 JOIN Accounts AS a ON a.AccountHolderId = ah.Id
 WHERE a.Id = @accountId

				-- 13. Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(MAX))
RETURNS TABLE
AS
  RETURN (SELECT SUM(Cash) AS SumCash FROM
(SELECT  Cash,
	ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RN
	FROM Games AS g
JOIN UsersGames AS ug ON g.Id = ug.GameId
WHERE Name = @gameName
GROUP BY Cash
) AS a
 WHERE RN % 2 != 0)

