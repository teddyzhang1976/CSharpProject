if exists(select name from sysobjects 
where name ='proc_encrypt' and type='p')
  drop procedure proc_encrypt
GO
create procedure proc_encrypt
with encryption--¼ÓÃÜ´æ´¢¹ý³Ì
as
  select * from tb_Employee
GO
exec sp_helptext proc_encrypt
