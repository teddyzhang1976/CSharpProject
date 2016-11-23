--判断proc_TransInProc存储过程是否存在，如果存在将它删除
if exists(select name from sysobjects 
where name='proc_TransInProc'and type='p')
  drop proc proc_TransInProc  --删除存储过程
GO
create procedure proc_TransInProc
as
declare @truc int
select @truc=@@trancount
if @truc=0
begin tran p1
else
save tran pl
if (@truc=2)
begin
rollback tran pl
return 25
end
if(@truc=0)
commit tran pl
return 0
