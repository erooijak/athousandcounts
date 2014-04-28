
SET IDENTITY_INSERT dbo.CountModel ON
DECLARE @i int = 1
WHILE @i < 1001 BEGIN
    
    INSERT INTO dbo.CountModel (Count)
    VALUES (@i)

    SET @i = @i + 1
END