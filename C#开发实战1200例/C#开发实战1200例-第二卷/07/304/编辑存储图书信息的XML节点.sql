USE db_TomeTwo 
GO
insert into tb_SQLandXML  values('mr008','计算机类','<计算机>
 <图书>
   <图书编号>mr01</图书编号>
   <图书名称>C#范例大全</图书名称>
   <图书类别>计算机语言类</图书类别>
   <图书内容>C#</图书内容>
   <图书价格>89</图书价格>
 </图书>
 <图书>
   <图书编号>mr02</图书编号>
   <图书名称>C#从入门到精通（第2版）</图书名称>
   <图书类别>计算机C#类</图书类别>
   <图书内容>C#</图书内容>
   <图书价格>79</图书价格>
 </图书>
</计算机>
')
-- insert a new element
UPDATE  tb_SQLandXML
SET 图书内容.modify('insert <编写者>王小科</编写者> as first
  into   (/计算机/图书/图书内容)[1]
');
select 图书内容.query('//图书/图书内容')
from tb_SQLandXML
