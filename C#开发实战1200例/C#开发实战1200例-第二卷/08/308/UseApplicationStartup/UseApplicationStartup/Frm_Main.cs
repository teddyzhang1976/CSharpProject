using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UseApplicationStartup
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();//声明DataTable字段
        int index=0;//声明计数器
        int count = 0;//记录数量

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\test.mdb";//得到数据库路径
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strPath;//创建连接字符串
            OleDbDataAdapter OleDatOleDat = new OleDbDataAdapter(//创建数据适配器对象
                "select * from 帐目", ConStr);
            OleDatOleDat.Fill(dt);//填充数据表
            count = dt.Rows.Count;
            textBox1.Text = dt.Rows[0][0].ToString();//显示数据表中数据
            textBox2.Text = dt.Rows[0][1].ToString();//显示数据表中数据
            textBox3.Text = dt.Rows[0][2].ToString();//显示数据表中数据
            textBox4.Text = dt.Rows[0][3].ToString();//显示数据表中数据
        }

        private void GetMessage(int index)
        {
            string strPath = Application.StartupPath + "\\test.mdb";//得到数据库路径
            string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + strPath;//创建连接字符串
            OleDbDataAdapter OleDatOleDat = new OleDbDataAdapter(//创建数据适配器对象
                "select * from 帐目", ConStr);
            dt = new DataTable();//创建数据表
            OleDatOleDat.Fill(index, 1, new DataTable[] {dt });//填充数据表
        }



        private void btn_First_Click(object sender, EventArgs e)
        {
            index = 0;//设置索引位置
            GetMessage(index);//得到数据记录
            textBox1.Text = dt.Rows[0][0].ToString();//显示数据表中数据
            textBox2.Text = dt.Rows[0][1].ToString();//显示数据表中数据
            textBox3.Text = dt.Rows[0][2].ToString();//显示数据表中数据
            textBox4.Text = dt.Rows[0][3].ToString();//显示数据表中数据
        }

        private void btn_Before_Click(object sender, EventArgs e)
        {
            if (index!=0)
            {
                index--;//设置索引位置
                GetMessage(index);//得到数据记录
                textBox1.Text = dt.Rows[0][0].ToString();//显示数据表中数据
                textBox2.Text = dt.Rows[0][1].ToString();//显示数据表中数据
                textBox3.Text = dt.Rows[0][2].ToString();//显示数据表中数据
                textBox4.Text = dt.Rows[0][3].ToString();//显示数据表中数据
            }
        }

        private void btn_After_Click(object sender, EventArgs e)
        {
            if (index != count - 1)
            {
                index++;//设置索引位置
                GetMessage(index);//得到数据记录
                textBox1.Text = dt.Rows[0][0].ToString();//显示数据表中数据
                textBox2.Text = dt.Rows[0][1].ToString();//显示数据表中数据
                textBox3.Text = dt.Rows[0][2].ToString();//显示数据表中数据
                textBox4.Text = dt.Rows[0][3].ToString();//显示数据表中数据
            }
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            index = count - 1;//设置索引位置
            GetMessage(index);//得到数据记录
            textBox1.Text = dt.Rows[dt.Rows.Count - 1][0].ToString();//显示数据表中数据
            textBox2.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();//显示数据表中数据
            textBox3.Text = dt.Rows[dt.Rows.Count - 1][2].ToString();//显示数据表中数据
            textBox4.Text = dt.Rows[dt.Rows.Count - 1][3].ToString();//显示数据表中数据
        }
    }
}
