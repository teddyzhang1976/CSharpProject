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

namespace ConProAccess
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public static string strCon = "";//记录数据库连接语句

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.mdb(Access数据库文件)|*.mdb|*.xls(Excel文件)|*.xls|*.*(所有文件)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;//显示选择的数据库文件
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//判断是否选择了数据库
            {
                if (textBox2.Text != "")//判断是否输入了密码
                {
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";JET OLEDB:Database Password=" + textBox2.Text + ";";//组合Access数据库连接字符串
                }
                else
                {
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";";//连接无密码的数据库
                }
            }
            OleDbConnection oledbcon = new OleDbConnection(strCon);//使用OLEDB连接对象连接数据库
            try
            {
                oledbcon.Open();//打开数据库连接
                richTextBox1.Clear();//清空文本框
                richTextBox1.Text = strCon + "\n连接成功……";//显示数据库连接字符串
            }
            catch
            {
                richTextBox1.Text = "连接失败";
            }
        }
    }
}
