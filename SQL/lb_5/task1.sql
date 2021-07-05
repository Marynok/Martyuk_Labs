ALTER PROC MergeXMLIntoManufacturers 
	@Request xml
AS
BEGIN
	DECLARE @hdoc int; 

	BEGIN TRY
		BEGIN TRANSACTION 

		EXEC sp_xml_preparedocument @hdoc OUTPUT, @Request

		MERGE INTO Manufacturers   
		USING (SELECT *
				FROM OPENXML(@hdoc,'DeliveryService/Manufacturers', 1) WITH(
					ManufacturerId int,
					Name nvarchar(50),
					Phone nvarchar(10),
					AddressId int)) as NewManufacturers  (Id, NewName, NewPhone, NewAddressId) 
		ON ManufacturerId = Id  
		WHEN MATCHED AND (Name != NewName OR Phone  != NewPhone OR AddressId != NewAddressId)
		THEN UPDATE SET Name = NewName, Phone  = NewPhone, AddressId = NewAddressId
		WHEN NOT MATCHED BY TARGET THEN  
		INSERT (ManufacturerId, Name, Phone, AddressId) VALUES (Id, NewName, NewPhone, NewAddressId);  

		COMMIT TRANSACTION
		EXEC sp_xml_removedocument @hdoc

	END TRY

	BEGIN CATCH

		ROLLBACK TRANSACTION
		EXEC sp_xml_removedocument @hdoc

	END CATCH
END






DECLARE @doc varchar(1000);  
SET @doc ='  
<DeliveryService>  
<Manufacturers ManufacturerId="1" Name="Goga1" Phone="0502347669" AddressId="1"></Manufacturers>
<Manufacturers ManufacturerId="2" Name="MacMod" Phone="0502783469" AddressId="2"></Manufacturers>
<Manufacturers ManufacturerId="6" Name="MoreMoi" Phone="0505674369" AddressId="3"></Manufacturers>
</DeliveryService>'  

EXEC MergeXMLIntoManufacturers @doc
