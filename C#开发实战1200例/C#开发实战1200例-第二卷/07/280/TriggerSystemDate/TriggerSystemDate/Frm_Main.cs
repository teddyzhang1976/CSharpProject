using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace TriggerSystemDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;");	//连接数据库
            con.Open();//打开连接的数据库
            SqlCommand cmd = new SqlCommand("update 系统管理员表 set 用户名称='" + textBox1.Text + "',密码='" + textBox2.Text + "'", con);//建立SQL语句与数据库的连接
            cmd.ExecuteNonQuery();//执行SQL语句
            con.Close();//关闭数据库的连接
            MessageBox.Show("修改成功！");
        }
    }
}
