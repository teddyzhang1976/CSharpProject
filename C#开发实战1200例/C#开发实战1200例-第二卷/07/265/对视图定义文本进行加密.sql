--创建视图
CREATE VIEW Lesson_Profession_view
WITH ENCRYPTION--加密视图
AS
--定义SELECT查询语句
SELECT a.Name,a.JoinTime, 
      b.PreName, a.ID
FROM tb_Lesson AS a INNER JOIN
      tb_Profession AS b ON a.ofProfession = b.ID
GO
--查看创建的视图中的数据
EXEC sp_helptext Lesson_Profession_view
