if exists(select name from sysobjects 
where name='pro_out'and type='p')
drop proc pro_out
GO
create procedure pro_out
  @id varchar(20),
  @name varchar(30),
  @sex int output    --设置带返回值的参数
as
select * from tb_Employee where ID=@id
GO
--执行存储过程
declare @sex char(4)   --自定义变量
exec pro_out 'YGBH0001','小科',100--调用存储过程
if @sex='男'--利用存储过程的返回值进行判断
  print '男生'
if @sex='女'
  print '女生'
go
