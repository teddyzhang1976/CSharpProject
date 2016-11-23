using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CreateDataBase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog =//创建文件浏览对话框对象
                new FolderBrowserDialog();
            if (P_FolderBrowserDialog.ShowDialog() == DialogResult.OK)//判断是否选择文件夹
            {
                txt_Path.Text = P_FolderBrowserDialog.SelectedPath;//显示选择文件夹路径
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (txt_Path.Text != "" && txt_Name.Text != "")
            {
                SqlConnection P_sc = new SqlConnection(//创建数据库连接对象
                    @"server=LVSHUANG\SHJ;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
                try
                {
                    P_sc.Open();//打开数据库连接
                    SqlCommand P_cmd = new SqlCommand(//创建数据库命令对象
                        string.Format(@"CREATE DATABASE {0}
ON
(
	NAME='{0}1',
	FILENAME='{1}\{0}.mdf',
	SIZE=10MB,
	FILEGROWTH=10%
)
LOG ON
(
	NAME='{0}2',
	FILENAME='{1}\{0}.ldf',
	SIZE=10MB,
	FILEGROWTH=10%
)", txt_Name.Text, txt_Path.Text), P_sc);
                    P_cmd.ExecuteNonQuery();//创建数据库
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
    }
}
