declare @id char(20)/*声明变量*/
declare @names char(20)
declare @age int
set @age=27--为变量赋值
declare @ages int
declare deletecursor cursor for--声明游标
select 员工编号,姓名,年龄 from tb_TestDel
open deletecursor--打开游标
fetch next from deletecursor--获取游标的下一行
into @id,@names,@ages--使变量获得当前游标指定行的员工编号，姓名和年龄
while @@fetch_status=0
begin
if @age=@ages--判断变量的值是否与游标指定的年龄相等
begin
delete tb_TestDel where 年龄=@ages--删除指定条件的数据
end
fetch next from deletecursor--获取游标的下一行
into @id,@names,@ages
end
close deletecursor--关闭游标
deallocate deletecursor--释放游标
select * from tb_TestDel--重新查看tb_TestDel表
