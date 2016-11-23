using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProcedureSelect
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            CreateProcedure();//创建存储过程并查询
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetStudent()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"proc_GetStudent");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

        /// <summary>
        /// 创建存储过程并查询
        /// </summary>
        private void CreateProcedure()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_GetStudent') 
AND XTYPE='p')
THEN '存在' 
ELSE '不存在' 
END");
            using (SqlConnection sc = //创建数据库连接对象
                new SqlConnection(P_Str_ConnectionStr))
            {
                sc.Open();//打开数据库连接
                SqlCommand P_cmd =//创建数据库命令对象
                    new SqlCommand(P_Str_SqlStr, sc);
                SqlDataReader sdr =//得到数据读取器
                    P_cmd.ExecuteReader();
                sdr.Read();//读取一条记录
                if (sdr[0].ToString() == "存在")//判断存储过程是否存在
                {
                    dgv_Message.DataSource = GetStudent();//设置数据源
                }
                else
                {
                    string P_Str_Cmd = string.Format(//创建SQL字符串
       @"CREATE PROC proc_GetStudent
AS
SELECT st.学生编号,st.学生姓名,st.年龄,gr.总分 
FROM tb_Student AS st
INNER JOIN tb_Grade AS gr
ON st.学生编号 = gr.学生编号");
                    P_cmd.CommandText = P_Str_Cmd;//设置执行的SQL语句
                    sdr.Close();//关闭数据读取器
                    P_cmd.ExecuteNonQuery();//添加存储过程
                    dgv_Message.DataSource = GetStudent();//设置数据源
                }
            }
        }

        private void btn_RemoveProcedure_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
    @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_GetStudent') 
AND XTYPE='p')
THEN '存在' 
ELSE '不存在' 
END");
            using (SqlConnection sc =//创建数据库连接对象
                new SqlConnection(P_Str_ConnectionStr))
            {
                sc.Open();//打开数据库连接
                SqlCommand P_cmd =//创建数据库命令对象
                    new SqlCommand(P_Str_SqlStr, sc);
                SqlDataReader sdr =//得到数据读取器
                    P_cmd.ExecuteReader();
                sdr.Read();//读取一条记录
                if (sdr[0].ToString() == "存在")
                {
                    sdr.Close();//关闭数据读取器
                    P_cmd.CommandText =//设置执行的SQL语句
                        "drop proc proc_GetStudent";
                    P_cmd.ExecuteNonQuery();//删除存储过程
                }
            }
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT * FROM tb_Student");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }
    }
}
