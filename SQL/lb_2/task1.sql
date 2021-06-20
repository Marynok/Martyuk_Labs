INSERT INTO Clients
VALUES (1,'Vladislav','Podparinov','0502352114'),
(2,'Olena','Tatarchuk','0509352565'),
(3,'Alla','Vakarchuk','0502352345'),
(4,'Dmytro','Podparinov','0509467318'),
(5,'Igor','Vasilev','0578345914')


INSERT INTO Streets
VALUES (1,'Serdyka',50),
(2,'Proletarska',35),
(3,'Myra',4),
(4,'Molodizna',30),
(5,'Tyha',24)

INSERT INTO Addresses(AddressId,StreerId,HouseNumber)
VALUES (1,2, null),
(2,1,3),
(3,5,null),
(4,4,7),
(5,2,6)


CREATE TABLE CientsCopy(
ClientsCopyId bigint NOT NULL,
Name varchar(30) NOT NULL,
Surname varchar(30) NOT NULL,
Phone nvarchar(10)NOT NULL
)

INSERT INTO CientsCopy (ClientsCopyId, Name, Surname,Phone)
SELECT *
FROM Clients


