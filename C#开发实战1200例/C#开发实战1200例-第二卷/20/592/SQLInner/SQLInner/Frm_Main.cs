using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLInner
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=WIN-GI7E47AND9R\\LS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");//创建数据库连接对象
            SqlDataAdapter sqlda = new SqlDataAdapter("select Name,Pwd from tb_Login where Name=@name and Pwd=@pwd", sqlcon);//创建数据库桥接器对象
            //为SQL语句中的参数赋值
            sqlda.SelectCommand.Parameters.Add("@name", SqlDbType.NChar, 10).Value = textBox1.Text;
            sqlda.SelectCommand.Parameters.Add("@pwd", SqlDbType.NChar, 10).Value = textBox2.Text;
            DataSet myds = new DataSet();//创建DataSet数据集对象
            sqlda.Fill(myds);//填充数据集
            if (myds.Tables[0].Rows.Count > 0)//判断数据集中的表中是否有行
                MessageBox.Show("用户登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("用户登录失败，原因为：用户名或密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = textBox2.Text = "";//清空文本框
                textBox1.Focus();//为用户姓名文本框设置输入焦点
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            textBox1.Focus();
        }
    }
}
