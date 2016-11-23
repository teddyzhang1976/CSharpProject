using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace InsertToSQL
{
    class DataTier
    {
        public DataTier(string Server, string DataBase, string UserName, string Password)//定义对象构造器
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
        public List<InstanceClass> GetMessage()
        {
            string P_Str_Connection = string.Format(//创建数据库连接字符串
                "server={0};database={1};uid={2};pwd={3}",
                G_Server, G_DataBase, G_UserName, G_Password);
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter//创建数据适配器对象
            ("select * from tb_grade", P_Str_Connection);
            DataTable dt = new DataTable();//创建数据表对象
            P_SqlDataAdapter.Fill(dt);//填充数据表
            List<InstanceClass> P_List_InstanceClass =//创建数据集合对象
                new List<InstanceClass>();
            foreach (DataRow dr in dt.Rows)//遍历数据表
            {
                P_List_InstanceClass.Add(//向数据集合中添加数据
                    new InstanceClass()
                    {
                        id = (int)dr[0],
                        Name = dr[1].ToString().Trim(),
                        Chinese = (double)dr[2],
                        Math = (double)dr[3],
                        English = (double)dr[4]
                    });
            }
            return P_List_InstanceClass;//返回数据集合对象
        }

        /// <summary>
        /// 向数据库中插入数据的方法
        /// </summary>
        /// <param name="ls">数据集合</param>
        public void InsertMessage(List<InstanceClass> ls)
        {
            string P_Str_Connection = string.Format(//创建数据库连接字符串
                "server={0};database={1};uid={2};pwd={3}",
                G_Server, G_DataBase, G_UserName, G_Password);
            using (SqlConnection P_Connection =
                new SqlConnection(P_Str_Connection))
            {
                P_Connection.Open();
                foreach (InstanceClass ic in ls)
                {
                    SqlCommand P_Command = new SqlCommand();//创建Sql命令对象
                    P_Command.Connection = P_Connection;//设置连接属性
                    P_Command.CommandText = string.Format(//设置命令字符串
                        "insert into tb_grade(Names,Chinese,Math,English) values(@Name,@Chinese,@Math,@English)");
                    P_Command.Parameters.Add("@Name", SqlDbType.Char, 50).Value = ic.Name;
                    P_Command.Parameters.Add("@Chinese", SqlDbType.Float).Value = ic.Chinese;
                    P_Command.Parameters.Add("@Math", SqlDbType.Float).Value = ic.Math;
                    P_Command.Parameters.Add("@English", SqlDbType.Float).Value = ic.English;
                    P_Command.ExecuteNonQuery();
                }
            }
        }
    }
}
