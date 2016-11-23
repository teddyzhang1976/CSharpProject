--创建视图
create view V_waregoods
(编号, 商品名称,数量,单价,进价,销售额,利润)
as 
--定义SELECT查询语句
select 编号, 商品名称,数量,单价,进价,(单价*数量) AS 销售额,
        (单价*数量-进价*数量) AS 利润
from tb_xsb
go
--查询视图
select * from V_waregoods 
