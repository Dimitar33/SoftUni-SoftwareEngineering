
				-- 1. Employee Address			

SELECT TOP (5) e.EmployeeId, e.JobTitle, e.AddressId, a.AddressText
 FROM Employees AS e
 JOIN Addresses AS a ON e.AddressID = a.AddressID
 ORDER BY AddressID

				-- 2. Addresses with Towns

SELECT TOP (50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText 
  FROM Employees AS e
  JOIN Addresses as a ON a.AddressID = e.AddressID
  JOIN Towns as t ON a.TownID = t.TownID
  ORDER BY FirstName, LastName

				-- 3. Sales Employee

SELECT EmployeeID, FirstName, LastName, d.[Name] AS DepartmentName
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
 WHERE d.Name = 'sales'
 ORDER BY EmployeeID

				-- 4. Employee Departments
				
SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name] AS DepartmentName 
  FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
 WHERE Salary > 15000
 ORDER BY e.DepartmentID

				-- 5. Employees Without Project

SELECT TOP(3) e.EmployeeID, FirstName
  FROM Employees AS e
  LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
  LEFT JOIN Projects AS p ON p.ProjectID = ep.ProjectID
 WHERE p.[Name] IS NULL
 ORDER BY EmployeeID


				-- 6. Employees Hired After

SELECT FirstName, LastName, HireDate, d.[Name] AS DeptName
  FROM Employees AS e
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
 WHERE DATEPART(YEAR , HireDate) > 1998 AND d.[Name] IN ('sales', 'finance')
 ORDER BY HireDate

				-- 7. Employees with Project

SELECT TOP (5) e.EmployeeID, FirstName, p.[Name] AS ProjectName
  FROM Employees AS e
  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
  WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

				-- 8. Employee 24

SELECT e.EmployeeID, e.FirstName,
 CASE 
 WHEN DATEPART(YEAR , p.StartDate) > 2004 THEN NULL
 ELSE p.[Name]
	END AS ProjectName
  FROM Employees AS e
  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
  WHERE e.EmployeeID = 24

				-- 9. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
  FROM Employees AS e
  JOIN Employees AS m ON e.ManagerID = m.EmployeeID
 WHERE e.ManagerID IN (3, 7)
 ORDER BY e.EmployeeID

				-- 10. Employee Summary

SELECT TOP (50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName, 
		m.FirstName + ' ' + m.LastName AS ManagerName, d.[Name] AS DepartmentName
  FROM Employees AS e
  JOIN Employees AS m ON e.ManagerID = m.EmployeeID
  JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

				-- 11. Min Average Salary

SELECT TOP (1) AVG(Salary) AS MinAverageSalary 
 FROM Employees AS e
 JOIN Departments AS d ON d.DepartmentID = e.DepartmentID 
 GROUP BY e.DepartmentID
 ORDER BY MinAverageSalary

				-- 12. Highest Peaks in Bulgaria

SELECT CountryCode, MountainRange, PeakName, Elevation 
  FROM Peaks AS p
  JOIN Mountains AS m ON p.MountainId = m.Id
  JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
  WHERE CountryCode = 'bg' AND Elevation > 2835
  ORDER BY Elevation DESC

				-- 13. Count Mountain Ranges

SELECT CountryCode, COUNT(MountainRange) AS MountainRanges
  FROM MountainsCountries AS mc
  JOIN Mountains AS m ON mc.MountainId = m.Id
  WHERE CountryCode IN ('bg', 'us', 'ru') 
 GROUP BY CountryCode

				-- 14. Countries with Rivers

SELECT TOP (5) CountryName, RiverName 
  FROM Rivers AS r
  JOIN CountriesRivers AS cr ON cr.RiverId = r.Id
  RIGHT JOIN Countries AS c ON c.CountryCode = cr.CountryCode
 WHERE ContinentCode = 'af'
 ORDER BY CountryName

				-- 15. Continents and Currencies

SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM 
(SELECT ContinentCode, CurrencyCode, COUNT(ContinentCode) AS CurrencyUsage, 
  DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(ContinentCode) DESC) AS Ranked
  FROM Countries
  GROUP BY CurrencyCode, ContinentCode
  HAVING COUNT(ContinentCode) > 1
) AS asd
 WHERE Ranked = 1
	
				-- 16. Countries Without Any Mountains

SELECT COUNT(*) AS [Count] FROM Countries AS c
  LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
  WHERE MountainId IS NULL

				-- 17. Highest Peak and Longest River by Country

SELECT TOP (5) CountryName, HighestPeakElevation, LongestRiverLength FROM (
SELECT CountryName, p.Elevation AS HighestPeakElevation, r.[Length] AS LongestRiverLength,
 DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY p.Elevation DESC, r.[Length] DESC) AS Ranked
 FROM Countries AS c
 LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 LEFT JOIN Peaks AS p ON p.MountainId = m.Id
 LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
 LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
 ) AS asd
 WHERE Ranked = 1
 ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

				-- 18. Highest Peak Name and Elevation by Country

SELECT TOP (5) Country, [Highest Peak Name], [Highest Peak Elevation], Mountain
	FROM (
SELECT CountryName AS Country, 
	   ISNULL(PeakName,'(no highest peak)') AS [Highest Peak Name], 
	   ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation], 
	   ISNULL(MountainRange, '(no mountain)') AS Mountain, 
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
 FROM Countries AS c
 LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 LEFT JOIN Peaks AS p ON p.MountainId = m.Id
 GROUP BY c.CountryName, p.PeakName, m.MountainRange
 ) AS Result
 WHERE Ranked = 1
 ORDER BY Country, [Highest Peak Name]


