using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeleteTable
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "")
            {
                SqlConnection P_sc = new SqlConnection(//创建数据库连接对象
                    @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
                try
                {
                    P_sc.Open();//打开数据库连接
                    SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                        string.Format(
@"CREATE TABLE {0}
(ID INT IDENTITY(1,1) PRIMARY KEY,
	NAMES VARCHAR(10) NOT NULL)",
                                txt_Name.Text), P_sc);
                    P_cmd.ExecuteNonQuery();//创建数据表
                    txt_Name2.Text = txt_Name.Text;//得到数据表名称
                    MessageBox.Show("数据库创建成功", "提示！");//弹出消息对话框
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误！");//弹出消息对话框
                }
                finally
                {
                    P_sc.Close();//关闭数据库连接
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection P_sc = new SqlConnection(//创建数据库连接对象
    @"server=WIN-GI7E47AND9R\LS;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            try
            {
                P_sc.Open();//打开数据库连接
                SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                    string.Format("DROP TABLE {0}", txt_Name2.Text), P_sc);
                P_cmd.ExecuteNonQuery();//删除数据表
                MessageBox.Show("数据库删除成功", "提示！");//弹出消息对话框
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误！");//弹出消息对话框
            }
            finally
            {
                P_sc.Close();//关闭数据库连接
            }
        }
    }
}
