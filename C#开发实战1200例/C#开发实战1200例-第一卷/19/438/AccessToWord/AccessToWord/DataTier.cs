using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AccessToWord
{
    class DataTier
    {
        private string OLEConnection = string.Format(//定义连接字符串
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User Id=Admin; Password=",
            System.IO.Directory.GetCurrentDirectory() + @"\access.mdb");

        /// <summary>
        /// 从数据库中得到数据集合的方法
        /// </summary>
        /// <returns>返回数据集合</returns>
        public List<InstanceClass> GetMessage()
        {
            OleDbDataAdapter P_OleDbDataAdapter = //创建数据适配器对象
                new OleDbDataAdapter(
                "select * from tb_grade", OLEConnection);
            DataTable dt = new DataTable();//创建数据表对象
            P_OleDbDataAdapter.Fill(dt);//填充数据表
            List<InstanceClass> P_List_InstanceClass =//创建数据集合对象
                new List<InstanceClass>();
            foreach (DataRow dr in dt.Rows)//遍历数据表
            {
                P_List_InstanceClass.Add(//向数据集合中添加数据
                    new InstanceClass() { id = (int)dr[0], Name = dr[1].ToString(),
                                          Chinese = (float)dr[2],
                                          Math = (float)dr[3],
                                          English = (float)dr[4]
                    });
            }
            return P_List_InstanceClass;//返回数据集合对象
        }
    }
}
