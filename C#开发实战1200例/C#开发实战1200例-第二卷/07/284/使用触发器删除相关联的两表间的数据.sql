--判断是否存在名为‘tri_delete_laborage’的触发器
if exists(
select name from sysobjects where name='tri_delete_laborage' 
and type='TR')
drop trigger tri_delete_laborage--删除已经存在的触发器
go
create trigger tri_delete_laborage--创建触发器
on 员工表 for delete
as 
begin
if @@rowcount>1
  begin
    rollback transaction
    raiserror('每次只能删除一条记录',16,1)
  end
end
--声明变量
declare @id varchar(50)
select @id = 员工编号 from deleted
delete 薪水表 where 员工编号 = @id
go