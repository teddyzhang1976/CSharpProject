GO
DECLARE @DEPT VARCHAR(20)
SET @DEPT = '系统分析部'

IF (SELECT COUNT(*) FROM dbo.tb_工资数据表 WHERE 部门名称=@DEPT)>0
BEGIN
    PRINT '该部门已经发过工资'
END
ELSE
BEGIN
    PRINT '该部门没有发过工资'
END