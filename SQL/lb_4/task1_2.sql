ALTER TABLE CientsCopy ALTER COLUMN ClientsCopyId varchar(60) NOT NULL;


ALTER PROC IdGenerateProc
	@tableName varchar(20),
	@newId varchar(60) OUTPUT	
AS
BEGIN
    Set  @NewId = dbo.GetCapitalLetters(@TableName) + '-' + CONVERT(varchar(40), NEWID());
END


DECLARE @Id  varchar(60)
EXEC IdGenerateProc  'ClientsCopy', @Id OUTPUT;


INSERT INTO CientsCopy
VALUES (@Id,'Pou','Stephan','0990502352')

SELECT * FROM CientsCopy