DECLARE @dept AS VARCHAR(20)/*定义参数*/
SET @dept='Java开发部'/*为参数赋值*/
DECLARE cur_eaf CURSOR/*声明游标*/
  FOR (SELECT * FROM tb_Dept WHERE dept=@dept)/*定义游标结果集*/
  OPEN cur_eaf/*打开游标*/
    FETCH NEXT FROM cur_eaf/*向下移动游标指针*/
    WHILE @@FETCH_STATUS = 0/*判断是否存在下一条记录*/
      BEGIN
        FETCH NEXT FROM cur_eaf/*向下移动游标指针*/
      END
  CLOSE cur_eaf/*关闭游标*/
DEALLOCATE cur_eaf/*释放游标*/
