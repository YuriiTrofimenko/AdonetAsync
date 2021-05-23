CREATE TABLE [Product]
(
    [id] INT IDENTITY PRIMARY KEY,
    [name] CHAR(50),
    [price] DECIMAL(10,2),
    [quantity] INT
    );

-- SELECT CAST(ROUND(RAND() * 100, 0) AS CHAR(3))

DECLARE @i INT = 0
WHILE(@i < 100000)
BEGIN
    DECLARE @random INT = ROUND(RAND() * 100, 0)
    INSERT INTO [Product] ([name], [price], [quantity])
        VALUES (
                'product ' + CAST(@random AS CHAR(3)),
                @random + 0.99,
                @random * @random
            )
    SET @i = @i + 1
END;

CREATE PROC [sp_select_products] AS
BEGIN
    WAITFOR DELAY '00:00:15';
SELECT COUNT(*) FROM [Product] WHERE [price] = 50.99 OR [quantity] = 70;
END;