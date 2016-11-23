using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace StopSQLServer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=master"))
            {
                try
                {
                    string strShutdown = "SHUTDOWN WITH NOWAIT";//创建SQL字符串
                    SqlCommand cmd = new SqlCommand();//创建命令对象
                    cmd.Connection = con;//设置连接属性
                    cmd.Connection.Open();//打开数据库连接
                    cmd.CommandText = strShutdown;//设置将要执行的SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    MessageBox.Show("已成功断开服务");//弹出消息对话框
                }
                catch(Exception euy)
                {
                    MessageBox.Show(euy.Message);//弹出消息对话框
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }
    }
}