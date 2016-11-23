/*判断表中是否有名为“delete_employee”的触发器*/
if EXISTS (SELECT name 
	FROM   sysobjects 
	WHERE  name = 'delete_employee' 
	AND type = 'TR')
/*如果已经存在则删除*/
drop trigger delete_employee
go
  create trigger delete_employee
   on 员工表
    after delete as
       declare @rowcount int
       select @rowcount = @@rowcount
  if @rowcount>1
       begin
          rollback transaction
       print('当前删除的记录条数大于一条，一次只允许删除一条')
       end
  if @rowcount=1
      begin
          declare @所属部门 varchar(50) 
          select @所属部门 = 所属部门 from deleted
      delete from 员工表 where 所属部门 = @所属部门
      end
go
