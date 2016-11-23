Set xact_Abort on
/*显示启动分布事务*/
Begin DISTRIBUTED TRANSACTION
Update EmployeeInfo set Name='小刘' 
where EmployeeCode='20091117091811609'
Update [MRWXK].[Northwind].[dbo].[Employees] 
set FirstName='smith' where LastName='bob'
/*结束分布式事务*/
COMMIT TRANSACTION