GO 
DECLARE @err varchar
SET @err = 1
IF @err <> 0
  RAISERROR ('用户自定义错误调试', 16, 1)