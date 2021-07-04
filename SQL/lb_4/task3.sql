ALTER FUNCTION IdGenerateFunc (@tableName varchar(20), @newId uniqueIdentifier )
RETURNS varchar(60) 	
AS
BEGIN
    RETURN dbo.GetCapitalLetters(@TableName) + '-' + CONVERT(varchar(40), @NewId);
END


INSERT INTO CientsCopy
VALUES (dbo.IdGenerateFunc ('ClientsCopy', NEWID()),'Sophy','Stephan','0997890982')

