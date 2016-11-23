using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace FromTable
{
    class DataTier
    {
        public DataTable GetDate()
        {
            string P_Connection = string.Format(//创建数据库连接字符串
              "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbDataAdapter P_DataAdapter = new OleDbDataAdapter(//创建数据适配器对象
                @"select id as 编号,Name as 名称,Begin as 开始时间,
                Factory as 配件厂家名称,Phone as 电话,Address as 联系地址 from [tb_Ware] 
                inner join [tb_Number] on [tb_Ware].Number=[tb_Number].Number",
                P_Connection);
            DataTable dt = new DataTable();//创建数据表
            P_DataAdapter.Fill(dt);//填充数据表
            return dt;//返回数据表
        }
    }
}
