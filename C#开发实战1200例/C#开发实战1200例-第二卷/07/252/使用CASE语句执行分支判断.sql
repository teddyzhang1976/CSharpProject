GO
SELECT 人员编号,人员姓名,部门名称,实发合计,工资年,
    CASE 工资月份
        WHEN 1  THEN '1月份工资'
        WHEN 2  THEN '2月份工资'
        WHEN 3  THEN '3月份工资'
        WHEN 4  THEN '4月份工资'
        WHEN 5  THEN '5月份工资'
        WHEN 6  THEN '6月份工资'
        WHEN 7  THEN '7月份工资'
        WHEN 8  THEN '8月份工资'
        WHEN 9  THEN '9月份工资'
        WHEN 10 THEN '10月份工资'
        WHEN 11 THEN '11月份工资'
        WHEN 12 THEN '12月份工资'
    END
FROM dbo.tb_工资数据表
ORDER BY 人员姓名
