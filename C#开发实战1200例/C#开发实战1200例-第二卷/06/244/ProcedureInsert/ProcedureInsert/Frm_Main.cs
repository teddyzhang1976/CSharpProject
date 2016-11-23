using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProcedureInsert
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CreateProcedure();//创建存储过程并查询
        }


        /// <summary>
        /// 创建存储过程添加数据记录并查询
        /// </summary>
        private void CreateProcedure()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_InsertStudent') 
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
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.CommandText = "proc_InsertStudent";//设置存储过程
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.Parameters.Add("学生编号", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Id.Text);
                    P_cmd.Parameters.Add("学生姓名", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Name.Text;
                    P_cmd.Parameters.Add("性别", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Sex.Text;
                    P_cmd.Parameters.Add("出生年月", SqlDbType.SmallDateTime).Value =//添加参数
                        txt_BirthDay.Text;
                    P_cmd.Parameters.Add("年龄", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Age.Text);
                    P_cmd.Parameters.Add("所在学院", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_School.Text;
                    P_cmd.Parameters.Add("所学专业", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Subject.Text;
                    P_cmd.Parameters.Add("家庭住址", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Address.Text;
                    P_cmd.Parameters.Add("统招否", SqlDbType.Bit).Value =//添加参数
                        txt_Yes.Text == "是" ? 1 : 0;
                    P_cmd.Parameters.Add("备注信息", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Message.Text;
                    P_cmd.ExecuteNonQuery();//添加数据
                    dgv_Message.DataSource = GetMessage();//设置数据源
                }
                else
                {
                    sdr.Close();//关闭数据读取器
                    string P_Str_Cmd = string.Format(//创建SQL字符串
       @"CREATE PROC proc_InsertStudent
@学生编号	int,
@学生姓名	nvarchar(50),
@性别	nvarchar(50),
@出生年月	smalldatetime,
@年龄	int,
@所在学院	nvarchar(50),
@所学专业	nvarchar(50),
@家庭住址	nvarchar(50),
@统招否	bit,
@备注信息	nvarchar(50)
AS
INSERT INTO tb_Student(学生编号,学生姓名,性别,出生年月,年龄,所在学院,所学专业,家庭住址,统招否,备注信息)
values(@学生编号,@学生姓名,@性别,@出生年月,@年龄,@所在学院,@所学专业,@家庭住址,@统招否,@备注信息)");
                    P_cmd.CommandText = P_Str_Cmd;//设置执行的SQL语句
                    P_cmd.ExecuteNonQuery();//添加存储过程
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.CommandText = "proc_InsertStudent";//设置存储过程
                    P_cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    P_cmd.Parameters.Add("学生编号", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Id.Text);
                    P_cmd.Parameters.Add("学生姓名", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Name.Text;
                    P_cmd.Parameters.Add("性别", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Sex.Text;
                    P_cmd.Parameters.Add("出生年月", SqlDbType.SmallDateTime).Value =//添加参数
                        txt_BirthDay.Text;
                    P_cmd.Parameters.Add("年龄", SqlDbType.Int).Value =//添加参数
                        int.Parse(txt_Age.Text);
                    P_cmd.Parameters.Add("所在学院", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_School.Text;
                    P_cmd.Parameters.Add("所学专业", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Subject.Text;
                    P_cmd.Parameters.Add("家庭住址", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Address.Text;
                    P_cmd.Parameters.Add("统招否", SqlDbType.Bit).Value =//添加参数
                        txt_Yes.Text == "是" ? 1 : 0;
                    P_cmd.Parameters.Add("备注信息", SqlDbType.NVarChar, 50).Value =//添加参数
                        txt_Message.Text;
                    P_cmd.ExecuteNonQuery();//添加数据
                    dgv_Message.DataSource = GetMessage();//设置数据源
                }
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"SELECT CASE WHEN EXISTS
(SELECT * FROM sysobjects WHERE id=object_id('dbo.proc_InsertStudent') 
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
                        "drop proc proc_InsertStudent";
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
