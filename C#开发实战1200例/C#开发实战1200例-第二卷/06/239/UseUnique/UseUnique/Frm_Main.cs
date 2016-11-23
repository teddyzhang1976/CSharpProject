using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseUnique
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
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"CREATE UNIQUE INDEX index_Student
ON tb_Student(学生编号)");
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);//创建数据库连接对象
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                    P_Str_SqlStr, P_sc);
                if (P_cmd.ExecuteNonQuery()!=0)
                {
                    MessageBox.Show("添加索引成功", "提示");//弹出消息对话框
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
@"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL字符串
                @"DROP INDEX tb_Student.index_Student");
            SqlConnection P_sc = new SqlConnection(P_Str_ConnectionStr);//创建数据库连接对象
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                    P_Str_SqlStr, P_sc);
                if (P_cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("索引删除成功", "提示");//弹出消息对话框
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
