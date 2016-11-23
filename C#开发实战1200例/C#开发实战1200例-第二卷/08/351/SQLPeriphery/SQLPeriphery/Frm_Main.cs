using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace SQLPeriphery
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=WIN-GI7E47AND9R\LS;pwd=;uid=sa;database=master"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();//创建命令对象
                    cmd.Connection = con;//设置连接属性
                    cmd.Connection.Open();//打开数据库连接
                    cmd.CommandText =//设置要执行的存储过程
@"sp_configure 'xp_cmdshell',1
reconfigure";
                    cmd.ExecuteNonQuery();//执行存储过程
                    string str = "xp_cmdshell 'copy "//创建SQL字符串
                        + this.textBox1.Text + " ";
                    str += "" + this.textBox2.Text + "'";//组合SQL字符串
                    cmd.CommandText = str;//设置要执行的SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    this.label3.Text = "已成功完成信息拷贝";//显示提示信息

                }
                catch (Exception ey) 
                { 
                    MessageBox.Show(ey.Message);//弹出消息对话框
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label3.Text = "";//设置空字符串
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text =//显示文件路径信息
                    this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text =//显示文件路径信息
                    this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}