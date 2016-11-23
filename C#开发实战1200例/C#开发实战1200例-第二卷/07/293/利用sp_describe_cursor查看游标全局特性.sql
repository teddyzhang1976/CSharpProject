USE db_TomeTwo
GO
DECLARE 明日科技 CURSOR KEYSET FOR    --创建游标
SELECT 图书分类 FROM tb_Csharpbook
WHERE 图书分类  LIKE '娱乐类'
OPEN 明日科技    --打开游标
DECLARE @x CURSOR    --创建一个游标变量
EXEC sp_describe_cursor @cursor_return = @x OUTPUT,
       @cursor_source = N'global', @cursor_identity = N'明日科技'  
FETCH NEXT from @x    --游标指针下移一行
WHILE (@@FETCH_STATUS <> -1)    --如果FETCH语句执行成功
BEGIN
   FETCH NEXT from @x    --游标继续向下移动
END
CLOSE @x                --关闭游标
DEALLOCATE @x           --释放游标
GO
CLOSE 明日科技         --关闭游标
DEALLOCATE 明日科技    --释放游标
