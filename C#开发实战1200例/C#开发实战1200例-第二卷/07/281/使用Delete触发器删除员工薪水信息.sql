create TRIGGER [trig_DeleteInfo] on [dbo].[tb_Employee]
FOR delete
AS
if exists(select ID from deleted where ID in(select ID from tb_Salary))
begin
delete from tb_Salary where ID=(select ID from deleted)
end
else
print '不存在该员工编号'