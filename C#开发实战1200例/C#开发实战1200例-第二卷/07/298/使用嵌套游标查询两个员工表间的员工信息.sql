declare @name varchar(10)/*声明变量*/
  declare cur_lab cursor for/*声明游标*/
    select 员工编号 from 薪水表 where 员工编号 =1001 /*定义游标结果集*/
  open cur_lab/*打开游标*/
    fetch next from cur_lab into @name/*将变量赋值*/
    while ( @@fetch_status=0 )  
begin
    declare @day varchar(10) /*声明变量*/
    declare cur_lab_2 cursor for/*声明游标*/
    select 请假天数 from 请假表 where 编号 = @name/*定义结果集*/
    open cur_lab_2/*打开游标*/
    fetch next from cur_lab_2 into @day/*使用游标将变量赋值*/
    while ( @@fetch_status=0)  
    begin
      print '编号为1001的员工的请假天数为' +@day +'天'/*输出编号为1的请假天数*/
      return 
    end
    close cur_lab_2/*关闭游标*/
    deallocate cur_lab_2/*释放游标*/ 
end   
    close cur_lab 
    deallocate cur_lab
