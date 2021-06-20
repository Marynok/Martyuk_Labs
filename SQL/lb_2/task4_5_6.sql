SELECT *
FROM Customers 
WHERE Region = 'BC'  
UNION  
SELECT * 
FROM Customers 
WHERE City IN ('Tsawassen','Berlin','Lulea') 




SELECT EmployeeID, LastName, FirstName, City, Region
FROM Employees 
WHERE Region = 'WA'  
EXCEPT  
SELECT EmployeeID, LastName, FirstName, City, Region 
FROM Employees 
WHERE City = 'Seattle' 




SELECT City, Region, COUNT(Region) as 'Count'
FROM Suppliers
WHERE Region IS NOT NULL 
GROUP BY  City, Region
HAVING COUNT(Region)>1



