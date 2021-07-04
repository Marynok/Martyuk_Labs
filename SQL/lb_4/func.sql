ALTER FUNCTION GetCapitalLetters (@tableName varchar(20))
RETURNS varchar(60) 	
AS
BEGIN
    DECLARE @len int, @i int, @word char(1) ;
	DECLARE @capitalLetters varchar(60);
	SET @len = LEN(@tableName)+1;
	SET @i = 0;
	SET @capitalLetters = '';
	WHILE @i < @len
    BEGIN
        SET @word = SUBSTRING(@tableName, @i, @i+1);
		IF (ASCII(@word) BETWEEN ASCII('A') AND ASCII('Z'))
			SET @capitalLetters += @word;
		SET @i = @i+1;
    END;
	RETURN @capitalLetters;
END
