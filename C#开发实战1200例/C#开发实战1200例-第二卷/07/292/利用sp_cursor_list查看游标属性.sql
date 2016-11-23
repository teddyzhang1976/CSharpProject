USE db_TomeTwo
GO
DECLARE 神州电脑 CURSOR KEYSET FOR    --创建游标
SELECT 课程类别 FROM course
WHERE 课程类别  LIKE '娱乐类'
OPEN 神州电脑    --打开游标
DECLARE @x CURSOR    --创建一个游标变量
EXEC sp_cursor_list @cursor_return = @x OUTPUT,
      @cursor_scope = 2    --使用sp_cursor_list过程返回全局游标的特性
FETCH NEXT from @x    --游标指针下移一行
WHILE (@@FETCH_STATUS <> -1)    --如果FETCH语句执行成功
BEGIN
   FETCH NEXT from @x    --游标继续向下移动
END
CLOSE @x                --关闭游标
DEALLOCATE @x           --释放游标
GO
CLOSE 神州电脑         --关闭游标
DEALLOCATE 神州电脑    --释放游标   
GO
