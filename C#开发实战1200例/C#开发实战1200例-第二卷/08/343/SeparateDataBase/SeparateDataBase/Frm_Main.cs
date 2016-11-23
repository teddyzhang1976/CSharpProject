using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace SeparateDataBase
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            biandingiInfo();
        }

        private void biandingiInfo()
        {
            using (SqlConnection con = new SqlConnection(
@"server=WIN-GI7E47AND9R\LS;pwd=;uid=sa;database=master"))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select name from sysdatabases", con);
                da.Fill(dt);
                this.comboBox1.DataSource = dt.DefaultView;
                this.comboBox1.DisplayMember = "name";
                this.comboBox1.ValueMember = "name";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=WIN-GI7E47AND9R\LS;pwd=;uid=sa;database=master"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();//创建数据库命令对象
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    cmd.CommandText =//设置要执行的SQL语句
                        "sp_detach_db @dbname='" + this.comboBox1.Text+"'";
                    cmd.ExecuteNonQuery();//执行SQL语句
                    MessageBox.Show("分离成功");//弹出消息对话框
                }
                catch(Exception ey)
                {
                    MessageBox.Show(ey.Message);//弹出消息对话框
                }
            }
        }

    }
}