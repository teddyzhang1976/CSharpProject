CREATE VIEW v_ware
AS SELECT 商品编号,金额,销售票号
from 销售表
go
select * from v_ware