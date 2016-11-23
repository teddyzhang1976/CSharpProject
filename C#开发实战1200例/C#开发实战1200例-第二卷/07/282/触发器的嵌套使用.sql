/*为tb_teacher表创建DELETE触发器*/
  create trigger teacher_delete
   on tb_teacher
    after delete as
   declare @rowcount int
   select @rowcount=@@rowcount  	/*删除操作所涉及的记录行数*/
    if @rowcount >1             	/*判断删除的记录是否多余一行*/
       begin
    rollback transaction
    print('删除tb_teacher表中记录多余一条，删除失败')
     end
    else
     declare @教师  varchar(10) 	/*删除记录的“教师”列信息*/
    select @教师 = 教师 from deleted
     delete tb_school where 教师 = @教师
/*为tb_school表创建DELETE触发器*/
go
 create trigger school_delete
    on tb_school
 after delete as
   declare @rowcount int
 select @rowcount = @@rowcount  /*删除操作所涉及的记录行数*/
   if @rowcount >1             	 /*判断删除的记录是否多余一行*/
   begin
    rollback transaction       	/*回滚操作*/
   print('删除tb_school表中记录多余一条，删除失败')
 end
   else
   print('tb_school表和tb_teacher表中相应的数据均被删除')
