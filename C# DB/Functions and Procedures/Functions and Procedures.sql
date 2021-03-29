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

SELECT * FROM Employees

SET FOREIGN_KEY_CHECKS = 0 
DELETE FROM Employees 
 WHERE DepartmentID = 1

 ALTER TABLE Employees ALTER COLUMN ManagerID INT NULL

 ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees

				-- 9. Find Full Name
				-- 10. People with Balance Higher Than
				-- 11. Future Value Function
				-- 12. Calculating Interest
				-- 13. Cash in User Games Odd Rows