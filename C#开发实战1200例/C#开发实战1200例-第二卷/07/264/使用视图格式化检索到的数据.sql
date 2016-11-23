--创建视图
create view v_warebooks
as 
--定义SELECT查询语句并格式化日期
select 图书名称,图书分类,出版日期,
       convert(varchar(10) ,
       cast(出版日期 as smalldatetime),120)as 格式化日期
from tb_Csharpbook
go
--查询所创建的视图中的数据
select * from v_warebooks
