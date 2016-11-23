GO
DECLARE @SUM INT
DECLARE @I INT
SET @SUM = 0
SET @I = 0
WHILE @I>=0
BEGIN
    SET @I=@I+1
    IF @I>100
    BEGIN	
        PRINT '1到100之间的奇数和:  '+CAST(@sum AS CHAR(10))
        BREAK
    END
    IF (@I%2!=0)	
    BEGIN
        SET @SUM = @SUM+@I
    END
    ELSE
    BEGIN
        CONTINUE
    END
END