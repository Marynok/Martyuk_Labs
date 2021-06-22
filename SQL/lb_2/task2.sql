INSERT INTO Manufacturers(ManufacturerId, Name, Phone, AddressId)
VALUES (1,'Goga','0502347669',1),
(2,'MacMod','0502783469',2),
(3,'AnaG','0502074322',3),
(4,'Petri','0973342221',4),
(5,'Leora','0502347669',5)


INSERT INTO FoodTypes(FoodTypeId, Name)
VALUES (1,'Fast Food'),
(2,'Fish'),
(3,'Drink'),
(4,'Pizza'),
(5,'Roll')


INSERT INTO Foods(FoodId, Name, Price, ManufacturerId, FoodTypeId,Weight)
VALUES (1,'Burger',50 ,1, 1, 25),
(2,'Italian Pizza',150 ,2, 4, 100),
(3,'Tea',40 ,2, 3, 500),
(4,'Fish Soup',45 ,4, 2, 250),
(5,'Roll',250 ,2, 5, 300)


INSERT INTO Foods(FoodId, Name, Price, ManufacturerId, FoodTypeId,Weight)
VALUES (6,'Vegan Burger',30 ,1, 1, 25),
(7,'Meats Pizza',250 ,2, 4, 100),
(8,'Green Tea',45 ,2, 3, 500),
(9,'Fish Soup',45 ,4, 2, 250),
(11,'Green Tea',60 ,1, 3, 500),
(13,'Soup',30 ,4, 2, 250),
(10,'Big Roll',400 ,2, 5, 600),
(12,'Set Roll',400 ,3, 5, 400)


SELECT * FROM Foods

UPDATE Foods
SET Price = Price * 0.3
WHERE FoodTypeId IN (SELECT FoodTypeId 
						FROM FoodTypes 
						WHERE Name LIKE '%Roll%' )



UPDATE Foods 
SET Price = (SELECT AVG(f.Price)
				FROM Foods as f
				WHERE f.ManufacturerId = Foods.ManufacturerId AND f.FoodTypeId = Foods.FoodTypeId)
WHERE Weight BETWEEN 100 AND 400



UPDATE Foods
SET Weight = Weight*2
FROM Foods as f
LEFT JOIN Manufacturers as m 
ON f.ManufacturerId = m.ManufacturerId
LEFT JOIN  Addresses as a
ON m.AddressId = a.AddressId
LEFT JOIN Streets as s
ON s.StreetId = a.StreerId
WHERE s.Name = 'Serdyka' AND s.Number = 50