USE AdventureWorks
GO

		--1. Select all customers; products; orders; 

SELECT * FROM Sales.Customer , Production.Product, Production.WorkOrder

		--2. Select all customers from specific country 

SELECT p.FirstName, sp.Name AS ProvinceName, cr.Name as Country 
 FROM Sales.Customer as c
 JOIN Person.Person as p ON p.BusinessEntityID = c.PersonID
 JOIN Person.BusinessEntity be ON be.BusinessEntityID = p.BusinessEntityID
 JOIN Person.BusinessEntityAddress as adres ON be.BusinessEntityID = adres.BusinessEntityID
 JOIN Person.Address as padres ON padres.AddressID = adres.AddressID
 JOIN Person.StateProvince sp ON padres.StateProvinceID = sp.StateProvinceID
 JOIN Person.CountryRegion cr ON cr.CountryRegionCode = sp.CountryRegionCode
 WHERE cr.Name = 'France'

		--3. Select all customers from specific country sorted by name

SELECT p.FirstName, sp.Name AS ProvinceName, cr.Name as Country FROM Sales.Customer as c
 JOIN Person.Person as p ON p.BusinessEntityID = c.PersonID
 JOIN Person.BusinessEntity be ON be.BusinessEntityID = p.BusinessEntityID
 JOIN Person.BusinessEntityAddress as adres ON be.BusinessEntityID = adres.BusinessEntityID
 JOIN Person.Address as padres ON padres.AddressID = adres.AddressID
 JOIN Person.StateProvince sp ON padres.StateProvinceID = sp.StateProvinceID
 JOIN Person.CountryRegion cr ON cr.CountryRegionCode = sp.CountryRegionCode
 WHERE cr.Name = 'France'
 ORDER BY p.FirstName

		--4. Select all countries for customers 

SELECT * FROM Person.CountryRegion as cr
 JOIN Sales.SalesTerritory as st ON st.CountryRegionCode = cr.CountryRegionCode
 JOIN Sales.Customer as c ON st.TerritoryID = c.TerritoryID

		--5. Select only customers placed/made orders

SELECT c.AccountNumber, c.CustomerID, c.StoreID 
 FROM Sales.Customer as c
 JOIN Sales.SalesOrderHeader AS so ON so.CustomerID = c.CustomerID

		--6. Select customers without orders 

SELECT c.AccountNumber, c.CustomerID, c.StoreID
FROM Sales.Customer as c
 LEFT JOIN Sales.SalesOrderHeader AS so ON so.CustomerID = c.CustomerID
 WHERE so.SalesOrderID IS NULL

		--7. Select customers and their orders 

SELECT * FROM Sales.Customer as c
 JOIN Sales.SalesOrderHeader AS so ON so.CustomerID = c.CustomerID
 JOIN Sales.SalesOrderDetail AS od ON od.SalesOrderID = so.SalesOrderID

		--8. Select top 10 customers by total order amount 

SELECT  oh.CustomerID, Total = SUM(od.OrderQty)
 FROM Sales.SalesOrderHeader as oh
 JOIN Sales.SalesOrderDetail as od ON od.SalesOrderID = oh.SalesOrderID
 GROUP BY oh.CustomerID
 ORDER BY total DESC

		--9. Select top 10 products ordered by customers 

SELECT TOP 10 p.Name, Total = COUNT(p.Name)
 FROM Sales.SalesOrderDetail as od
 JOIN Production.Product as p ON p.ProductID = od.ProductID
 GROUP BY p.Name
 ORDER BY Total DESC

		--10. Select top 10 categories or products (by total orders amount) 

SELECT TOP 10 p.Name, Total = SUM(OrderQty)
 FROM Sales.SalesOrderDetail as od
 JOIN Production.Product as p ON p.ProductID = od.ProductID
 GROUP BY p.Name
 ORDER BY Total DESC

		--11. Select products and all related tables and their related tables and so on (up to 6 levels). Sort the result by product, category name, sub category name. Use appropriate inner or left outer joins.

SELECT p.Name AS product, pc.Name AS [categoty name], sc.Name AS [subcatgegory name]
 FROM Production.Product p
 JOIN Production.ProductSubcategory sc ON sc.ProductSubcategoryID = p.ProductSubcategoryID
 JOIN Production.ProductCategory pc ON pc.ProductCategoryID = sc.ProductCategoryID
 ORDER BY p.Name, pc.Name, sc.Name

		--12. 

		--13. Select top 5 employee processed/done most orders for specific product.

SELECT TOP 5 SalesPersonID, COUNT(SalesOrderID) AS orders
 FROM Sales.SalesOrderHeader
 WHERE SalesPersonID IS NOT NULL
 GROUP BY SalesPersonID
 ORDER BY orders DESC

		--14. Select top 5 employee processed/done most orders for each year for specific product.

SELECT TOP 5 SalesPersonID, YEAR(OrderDate), COUNT(SalesOrderID) AS orders
 FROM Sales.SalesOrderHeader
 WHERE SalesPersonID IS NOT NULL
 GROUP BY SalesPersonID, YEAR(OrderDate)
 ORDER BY orders DESC

		--15. Customers and employees from the same country/city.

SELECT p.FirstName,  cr.Name as Country 
 FROM Sales.Customer as c
 JOIN Person.Person as p ON p.BusinessEntityID = c.PersonID
 JOIN Person.BusinessEntity be ON be.BusinessEntityID = p.BusinessEntityID
 JOIN Person.BusinessEntityAddress as adres ON be.BusinessEntityID = adres.BusinessEntityID
 JOIN Person.Address as padres ON padres.AddressID = adres.AddressID
 JOIN Person.StateProvince sp ON padres.StateProvinceID = sp.StateProvinceID
 JOIN Person.CountryRegion cr ON cr.CountryRegionCode = sp.CountryRegionCode
 JOIN HumanResources.Employee emp ON emp.BusinessEntityID = p.BusinessEntityID
 WHERE cr.Name = 'France'

 SELECT p.FirstName,p.PersonType, sp.Name AS ProvinceName, cr.Name as Country 
 FROM Person.CountryRegion cr
 JOIN Person.StateProvince sp ON sp.CountryRegionCode = cr.CountryRegionCode
 JOIN Person.Address padres ON padres.StateProvinceID = sp.StateProvinceID
 JOIN Person.BusinessEntityAddress adres ON adres.AddressID = padres.AddressID
 JOIN Person.BusinessEntity be ON be.BusinessEntityID = adres.BusinessEntityID
 JOIN Person.Person p ON p.BusinessEntityID = be.BusinessEntityID
 JOIN HumanResources.Employee emp ON emp.BusinessEntityID = p.BusinessEntityID
 JOIN Sales.Customer c ON c.CustomerID = p.BusinessEntityID 

		--16. Customers with or without orders.

SELECT c.CustomerID, so.SalesOrderID
 FROM Sales.Customer as c
 LEFT JOIN Sales.SalesOrderHeader AS so ON so.CustomerID = c.CustomerID

		--17. Customers and their last 3 orders.

WITH ranked as ( SELECT CustomerID, OrderDate, DENSE_RANK() OVER (PARTITION BY CustomerID ORDER BY OrderDate DESC) [last orders]
 FROM Sales.SalesOrderHeader)

SELECT *
  FROM ranked
  WHERE [last orders] < 4

		--18. Select top 10 customers by total orders amount (total amount for all their orders) + their last 3 orders (only last 3 orders by order’s date)

WITH asd as( SELECT  oh.CustomerID, oh.OrderDate, SUM(od.OrderQty) Total, DENSE_RANK() OVER (PARTITION BY oh.CustomerID ORDER BY oh.OrderDate DESC) [last orders]
 FROM Sales.SalesOrderHeader as oh
 JOIN Sales.SalesOrderDetail as od ON od.SalesOrderID = oh.SalesOrderID
 GROUP BY oh.CustomerID, oh.OrderDate)

 SELECT TOP 10 * 
  FROM asd
  WHERE [last orders] < 4
  ORDER BY Total DESC

		--19. Total sales amounts (orders amount) per year, country, city

SELECT  YEAR(oh.OrderDate) [Year], ad.City, cr.Name Country, SUM(od.OrderQty) total
 FROM Sales.SalesOrderHeader oh
 JOIN Sales.SalesOrderDetail od ON od.SalesOrderID = oh.SalesOrderID
 JOIN Sales.SalesTerritory  st ON st.TerritoryID = oh.TerritoryID
 JOIN Person.CountryRegion cr ON cr.CountryRegionCode = st.CountryRegionCode
 JOIN Person.StateProvince sp ON sp.TerritoryID = st.TerritoryID
 JOIN Person.Address ad ON ad.StateProvinceID = sp.StateProvinceID
 GROUP BY YEAR(oh.OrderDate), cr.Name, ad.City
 ORDER BY total DESC

		--20. Total sales amounts grouped by year and month

SELECT YEAR(oh.OrderDate) [Year], MONTH(oh.OrderDate) [Month], SUM(od.OrderQty) [total oreders]
 FROM Sales.SalesOrderHeader oh
 JOIN Sales.SalesOrderDetail od ON od.SalesOrderID = oh.SalesOrderID
 GROUP BY YEAR(oh.OrderDate), MONTH(oh.OrderDate)
 ORDER BY YEAR(oh.OrderDate), MONTH(oh.OrderDate)

		--21. Total sales for last 12 months and % increase compared with the same month previous year.

SELECT YEAR(oh.OrderDate) [Year], MONTH(oh.OrderDate) [Month], SUM(od.OrderQty) [total oreders]
 FROM Sales.SalesOrderHeader oh
 JOIN Sales.SalesOrderDetail od ON od.SalesOrderID = oh.SalesOrderID
 GROUP BY YEAR(oh.OrderDate), MONTH(oh.OrderDate)
 ORDER BY YEAR(oh.OrderDate) DESC, MONTH(oh.OrderDate) DESC
 OFFSET 12 ROWS
 FETCH NEXT 12 ROWS ONLY























