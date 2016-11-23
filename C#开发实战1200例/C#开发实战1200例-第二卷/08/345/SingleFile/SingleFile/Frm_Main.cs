using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace SingleFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                if(this.openFileDialog1.FileName!="")
                {
                    this.txt_Path.Text =//得到数据库路径信息
                        this.openFileDialog1.FileName;
                    
                  
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txt_Name.Text != "")
            {
                fujia();//附加数据库
            }
            else
            {
                MessageBox.Show("请写入数据库名称");//弹出消息对话框
            }
        }

        private void fujia()
        {
            using (SqlConnection con =//创建数据库连接对象
                new SqlConnection("server=.;pwd=;uid=sa;database=master"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();//创建命令对象
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    StringBuilder sb = new StringBuilder();//创建StringBuilder对象
                    sb.Append("sp_attach_single_file_db @dbname='"//追加文本内容
                        + this.txt_Name.Text + "',");
                    sb.Append("@physname='" + this.txt_Path.Text + "'");//追加文本内容
                    cmd.CommandText = sb.ToString();//设置要执行的SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    MessageBox.Show("附加成功");//弹出消息对话框
                }
                catch (Exception ety)
                {
                    MessageBox.Show(ety.Message);//弹出消息对话框
                }
            }
        }
    }
}