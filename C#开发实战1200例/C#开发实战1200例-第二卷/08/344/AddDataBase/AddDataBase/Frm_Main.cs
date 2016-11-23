using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace AddDataBase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_FileName.Text =//显示文件路径信息
                    this.openFileDialog1.FileName;
                this.btn_Add.Enabled = true;//启用按钮
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                this.txt_LogName.Text =//显示日志文件路径信息
                    this.openFileDialog2.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.txt_FileName.Text != "")
            {
                fujia();//附加数据库
            }
            else
            {
                MessageBox.Show("请输入数据库名");//弹出消息对话框
            }
        }

        private void fujia()
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=WIN-GI7E47AND9R\LS;pwd=;uid=sa;database=master"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();//创建命令对象
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    StringBuilder sb = new StringBuilder();//创建StringBuilder对象
                    sb.Append("sp_attach_db @dbname='" + this.txt_Name.Text + "',");//附加字符串
                    sb.Append("@filename1='" + this.txt_FileName.Text + "'");//附加字符串
                    if (this.txt_LogName.Text != "")
                    {
                        sb.Append(",@filename2='" + this.txt_LogName.Text + "'");//附加字符串
                    }
                    cmd.CommandText = sb.ToString();//设置要执行的SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    MessageBox.Show("附加成功");//弹出消息对话框
                    this.btn_Add.Enabled = false;//停用Button按钮
                }
                catch (Exception ety)
                {
                    MessageBox.Show(ety.Message);//弹出消息对话框
                }
            }
        }
    }
}