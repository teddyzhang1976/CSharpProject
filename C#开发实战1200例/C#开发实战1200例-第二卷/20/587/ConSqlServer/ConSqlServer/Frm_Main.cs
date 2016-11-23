using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace ConSqlServer
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public static string strCon = "";//记录数据库连接语句
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.Text = "(local)";//默认服务器设置为本地
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //使用Windows身份验证连接SQL数据库
                strCon = "Data Source=" + textBox6.Text + ";Initial Catalog =" + comboBox1.Text + ";Integrated Security=SSPI;";
            }
            else if (checkBox2.Checked == true)
            {
                strCon = "Data Source=" + textBox6.Text + ";Database=" + comboBox1.Text + ";Uid=" + textBox5.Text + ";Pwd=hbyt2008!@#;" + textBox4.Text + ";";//使用SQL Server身份验证连接SQL数据库
            }
            SqlConnection sqlcon = new SqlConnection(strCon);//使用SqlConnection连接数据库
            try
            {
                sqlcon.Open();//打开数据库连接
                richTextBox1.Clear();//清空文本框
                richTextBox1.Text = strCon + "\n连接成功……";//显示数据库连接字符串
            }
            catch
            {
                richTextBox1.Text = "连接失败";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                textBox4.Enabled = textBox5.Enabled = false;
                string str = "server=" + textBox6.Text + ";database=master;Integrated Security=SSPI;";
                comboBox1.DataSource = getTable(str);//设置下拉列表数据源
                comboBox1.DisplayMember = "name";//显示数据库列表
                comboBox1.ValueMember = "name";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            textBox4.Enabled = textBox5.Enabled = true;
            textBox5.Focus();
        }

        private DataTable getTable(string str)
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(str);//创建数据库连接对象
                SqlDataAdapter da = new SqlDataAdapter("select name from sysdatabases ", sqlcon);
                DataTable dt = new DataTable("sysdatabases");//创建DataTable对象
                da.Fill(dt);//填充DataTable数据表
                return dt;
            }
            catch
            {
                return null;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button4_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "server=" + textBox6.Text + ";database=master;Uid=" + textBox5.Text + ";Pwd=hbyt2008!@#;" + textBox4.Text + ";";
            comboBox1.DataSource = getTable(str);
            comboBox1.DisplayMember = "name";//刷新数据库列表
            comboBox1.ValueMember = "name";
        }
    }
}
