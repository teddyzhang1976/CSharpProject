--删除、创建数据表
if object_id('CGoods') is not null drop table CGoods
GO
CREATE TABLE CGoods
(
  g_id varchar(50),
  g_name varchar(50),
  g_price money
)
GO
--插入数据
INSERT INTO CGoods
SELECT 'SP10001','婴儿夏套装',108 UNION ALL
SELECT 'SP10002','婴儿玻璃奶瓶',88 UNION ALL
SELECT 'SP10003','GG玩具（盒）',189 UNION ALL
SELECT 'SP10004','幼儿早教（套书配光盘）',389
GO
--应用事务
BEGIN TRAN tra01
SELECT * FROM CGoods WITH(HOLDLOCK)
WAITFOR DELAY '00:00:10' 
COMMIT TRAN tra01
GO
BEGIN TRAN tra02
UPDATE CGoods
SET g_name = '婴儿秋套装'
WHERE g_id = 'SP10001'
SELECT * FROM CGoods WITH(HOLDLOCK)
COMMIT TRAN tra02

