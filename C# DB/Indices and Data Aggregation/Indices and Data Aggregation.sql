
				-- 01. Records’ Count

SELECT COUNT(*) AS [Count] FROM WizzardDeposits

				-- 02. Longest Magic Wand

SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

				-- 03. Longest Magic Wand per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
 GROUP BY DepositGroup

				-- 04. Smallest Deposit Group per Magic Wand Size

SELECT TOP(2) DepositGroup FROM WizzardDeposits
 GROUP BY DepositGroup
 ORDER BY AVG(MagicWandSize)

				-- 05. Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
 GROUP BY DepositGroup

				-- 06. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
 WHERE MagicWandCreator = 'Ollivander family'
 GROUP BY DepositGroup

				-- 07. Deposits Filter

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
 WHERE MagicWandCreator = 'Ollivander family' 
 GROUP BY DepositGroup
 HAVING SUM(DepositAmount) < 150000
 ORDER BY TotalSum DESC

				-- 08. Deposit Charge

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits 
 GROUP BY DepositGroup, MagicWandCreator
 ORDER BY MagicWandCreator, DepositGroup

				-- 09. Age Groups

SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount FROM 
(
SELECT
 CASE 
  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
  WHEN Age > 60 THEN '[61+]'
  ELSE NULL
  END AS AgeGroup
FROM WizzardDeposits
) AS res
GROUP BY AgeGroup

				-- 10. First Letter

SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
 WHERE DepositGroup = 'Troll Chest'

				-- 11. Average Interest

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AverageInterest FROM WizzardDeposits
 WHERE DepositStartDate > '01/01/1985'
 GROUP BY DepositGroup, IsDepositExpired
 ORDER BY DepositGroup DESC, IsDepositExpired

				-- 12. Rich Wizard, Poor Wizard

SELECT SUM(Diff) AS SumDifference FROM
(
SELECT 	
	DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS Diff
	FROM WizzardDeposits
) AS Result

				-- 13. Departments Total Salaries

SELECT DepartmentID, SUM(Salary) AS TotalSalary 
	FROM Employees 
  GROUP BY DepartmentID
  ORDER BY DepartmentID

				-- 14. Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary) AS TotalSalary 
	FROM Employees 
	WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
  GROUP BY DepartmentID

				-- 15. Employees Average Salaries

SELECT EmployeeID, ManagerID, DepartmentID, Salary
  INTO NewTable FROM Employees
  WHERE  Salary > 30000

DELETE FROM NewTable
 WHERE ManagerID = 42

UPDATE NewTable
 SET Salary += 5000
 WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM NewTable
 GROUP BY DepartmentID

				-- 16. Employees Maximum Salaries

SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees
 WHERE Salary NOT BETWEEN 30000 AND 70000
 GROUP BY DepartmentID

				-- 17. Employees Count Salaries

SELECT COUNT(Salary) AS [Count] FROM Employees
 WHERE ManagerID IS NULL

				-- 18. 3rd Highest Salary

SELECT DISTINCT DepartmentID, ThirdHighestSalary FROM (
	SELECT DepartmentID, FirstName, Salary AS ThirdHighestSalary,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranked
 FROM Employees
 ) AS Result
 WHERE Ranked = 3 

				-- 19. Salary Challenge

SELECT TOP (10) FirstName, LastName, DepartmentID FROM Employees AS main
 WHERE Salary > (SELECT AVG(Salary) FROM Employees
					WHERE DepartmentID = main.DepartmentID
					GROUP BY DepartmentID)
 ORDER BY DepartmentID




