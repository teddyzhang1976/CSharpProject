DECLARE mycursor CURSOR  /*声明游标*/
FOR 
 SELECT a.员工编号,a.员工姓名,所属部门,基本工资,奖金 /*定义游标结果集*/ 
 FROM 员工表 a,薪水表 b
 WHERE a.员工编号 = b.员工编号
ORDER BY a.员工编号 desc /*进行排序*/
OPEN mycursor  /*打开游标*/
  FETCH NEXT FROM  mycursor /*执行取数操作*/
WHILE @@fetch_status = 0  /*判断是否可以继续取数*/
BEGIN
  FETCH NEXT FROM  mycursor  
END 
CLOSE mycursor /*关闭游标*/
DEALLOCATE mycursor /*释放游标*/
