using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SQLToWord
{
    class DataTier
    {
        public DataTier(string Server,string DataBase,string UserName, string Password)//定义对象构造器
        {
            this.G_Server = Server;//得到数据库服务器字符串
            this.G_DataBase = DataBase;//得到数据库名称字符串
            this.G_UserName = UserName;//得到数据库用户名字符串
            this.G_Password = Password;//得到数据库密码字符串
        }

        private string G_Server;//定义私有变量存放数据库服务器信息
        private string G_DataBase;//定义私有变量存放数据库名称信息
        private string G_UserName;//定义私有变量存放用户名信息
        private string G_Password;//定义私有变量存放密码信息

        /// <summary>
        /// 从数据库中得到数据集合的方法
        /// </summary>
        /// <returns>返回数据集合</returns>
        public List<string> GetMessage()
        {
            string ConnectionStr = string.Format(//定义数据库连接字符串
           "server={0};database={1};uid={2};pwd={3}",
           G_Server, G_DataBase, G_UserName, G_Password);
            SqlDataAdapter P_SqlDataAdapter =//创建数据适配器对象
                new SqlDataAdapter("select * from tb_Message", ConnectionStr);
            DataTable P_DataTAble = new DataTable();//创建数据表对象
            P_SqlDataAdapter.Fill(P_DataTAble);//填充数据表
            List<string> P_List_Str = new List<string>();//定义数据集合
            foreach (DataRow P_dr in P_DataTAble.Rows)//遍历数据表
            {
                P_List_Str.Add(P_dr[1].ToString());//向数据集合中添加数据
            }
            return P_List_Str;//返回数据集合对象
        }
    }
}
