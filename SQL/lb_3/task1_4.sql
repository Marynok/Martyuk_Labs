SELECT *
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products)



SELECT MAX(p.UnitPrice), c.CategoryName
FROM Products as p, Categories as c
WHERE p.CategoryID = c.CategoryID
GROUP BY  c.CategoryName
ORDER BY  MAX(p.UnitPrice) DESC



SELECT e.FirstName, e.LastName, t.TerritoryDescription,r.RegionDescription
FROM Employees as e
LEFT JOIN EmployeeTerritories as et
ON e.EmployeeID =et.EmployeeID
LEFT JOIN Territories as t
ON t.TerritoryID = et.TerritoryID
LEFT JOIN Region as r
ON r.RegionID = t.RegionID



SELECT t.TerritoryDescription,r.RegionDescription
FROM Region as r
LEFT JOIN Territories as t
ON r.RegionID = t.RegionID
LEFT JOIN EmployeeTerritories as et
ON t.TerritoryID = et.TerritoryID
WHERE et.EmployeeID IS NULL









