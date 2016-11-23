--判断是否存在所要创建的存储过程名称
IF EXISTS(SELECT name 
   FROM sysobjects 
 WHERE name='Proc_Return'
AND type='P')
--存在所要创建的存储过程则删除
DROP PROCEDURE Proc_Return
GO
CREATE PROCEDURE Proc_Return 
@ID varchar(20),
@Name  varchar(20)
AS
--执行SELECT语句
SELECT * FROM tb_Employee WHERE ID = @ID
Return @@Error
GO
--执行存储过程
DECLARE @Int int
EXEC @Int=Proc_Return 'YGBH0001','小科'--将返回值赋给@Int变量
Select @Int as '返回值'    --显示返回信息
