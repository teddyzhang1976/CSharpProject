using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseINDEXVIEW
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);//创建数据库连接对象
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                    @"SET NUMERIC_ROUNDABORT OFF
SET ANSI_PADDING,ANSI_WARNINGS,CONCAT_NULL_YIELDS_NULL,
ARITHABORT,QUOTED_IDENTIFIER,ANSI_NULLS ON", P_sc);
                P_cmd.ExecuteNonQuery();//执行SQL语句
                P_cmd.CommandText = @"CREATE VIEW VIEW_Student
WITH SCHEMABINDING
AS
SELECT
st.所在学院,
SUM(CONVERT(INT,总分)) AS 学院总分,
COUNT_BIG(*) AS 学生数量
FROM
dbo.tb_Student AS st,
dbo.tb_Grade AS gr
WHERE
st.学生编号=gr.学生编号
GROUP BY
所在学院";
                P_cmd.ExecuteNonQuery();//执行SQL语句
                P_cmd.CommandText = "CREATE UNIQUE CLUSTERED INDEX INDEX_VIEW ON tb_Student(学生编号)";
                if (P_cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("添加索引视图成功", "提示");//弹出消息对话框
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");//弹出消息对话框
            }
            finally
            {
                P_sc.Close();//关闭数据库连接
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
    @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT * FROM VIEW_Student");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            try
            {
                P_SqlDataAdapter.Fill(P_dt);//填充数据表
                dgv_Message.DataSource = P_dt;//设置数据源
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"DROP VIEW VIEW_Student 
DROP INDEX tb_Student.INDEX_VIEW ");
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);//创建数据库连接对象
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                    P_Str_SqlStr, P_sc);
                if (P_cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("索引视图删除成功", "提示");//弹出消息对话框
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");//弹出消息对话框
            }
            finally
            {
                P_sc.Close();//关闭数据库连接
            }
        }
    }
}
