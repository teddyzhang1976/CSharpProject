/*判断表中是否有名为“[trig_InsertInfo]”的触发器*/
if EXISTS (SELECT name 
	FROM   sysobjects 
	WHERE  name = '[trig_InsertInfo]' 
	AND type = 'TR')
/*如果已经存在则删除*/
drop trigger [trig_InsertInfo]
go
create TRIGGER [trig_InsertInfo] on [dbo].[tb_Employee]
FOR insert
AS
if exists(select ID from inserted where ID in(select ID from tb_Salary))
begin
update tb_Salary set Name=(select Name from inserted),Salary=1500 where ID=(select ID from inserted) 
end
else
begin
insert into tb_Salary(ID,Name,Salary)
select ID,Name,1500 from inserted
end
go
