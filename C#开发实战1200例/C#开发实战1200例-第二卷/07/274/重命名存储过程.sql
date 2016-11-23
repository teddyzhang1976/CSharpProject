--判断存储过程proc_Name是否存在，如果存在将它删掉
if exists(select name from sysobjects where name='proc_Name' and type='p')
drop proc proc_Name 
go
create procedure proc_Name--创建一个存储过程
as
select * from tb_User 
where User_Duty='程序员'
go
--重新命名存储过程
exec sp_rename 'proc_Name','proc_ReName'
go
