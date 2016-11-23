DECLARE khqc_Cursor CURSOR --声明游标
for select * FROM 销售表
OPEN khqc_Cursor --打开游标
BEGIN
   --读取记录到游标返回指行数据
   FETCH next FROM khqc_Cursor  
END
CLOSE khqc_Cursor   /*关闭游标*/
DEALLOCATE khqc_Cursor  /*释放游标*/
GO