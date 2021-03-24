
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



				-- 14. Employees Minimum Salaries
				-- 15. Employees Average Salaries
				-- 16. Employees Maximum Salaries
				-- 17. Employees Count Salaries
				-- 18. 3rd Highest Salary
				-- 19. Salary Challenge

