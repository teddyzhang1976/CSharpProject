GO
IF EXISTS (SELECT * FROM dbo.tb_工资数据表)
    PRINT '该表中有数据'
ELSE
    PRINT '该表中无数据'