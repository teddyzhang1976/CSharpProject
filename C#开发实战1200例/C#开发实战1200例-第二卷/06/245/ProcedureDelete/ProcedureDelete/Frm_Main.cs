using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProcedureDelete
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ProcedureDelete();//创建存储过程并查询
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_RemoveStudent') 
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
                        "drop proc proc_RemoveStudent";
                    P_cmd.ExecuteNonQuery();//删除存储过程
                }
            }
        }

        /// <summary>
        /// 创建存储过程删除数据记录并查询
        /// </summary>
        private void ProcedureDelete()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_RemoveStudent') 
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
                    sdr.Close();//关闭数据读取器
                    P_cmd.CommandType = CommandType.StoredProcedure;
                    P_cmd.CommandText = "proc_RemoveStudent";
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.Parameters.Add("学生编号", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Id.Text);
                    P_cmd.ExecuteNonQuery();//删除数据记录
                    dgv_Message.DataSource = GetMessage();//设置数据源
                }
                else
                {
                    sdr.Close();//关闭数据读取器
                    string P_Str_Cmd = string.Format(//创建SQL字符串
       @"CREATE PROC proc_RemoveStudent
@学生编号	int
AS
delete tb_Student where 学生编号=@学生编号");
                    P_cmd.CommandText = P_Str_Cmd;//设置执行的SQL语句
                    P_cmd.ExecuteNonQuery();//添加存储过程
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.CommandText = "proc_RemoveStudent";//设置存储过程
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.Parameters.Add("学生编号", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Id.Text);
                    P_cmd.ExecuteNonQuery();//删除数据记录
                    dgv_Message.DataSource = GetMessage();//设置数据源
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
