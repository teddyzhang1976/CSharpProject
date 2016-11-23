using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AlterConfiguration
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string tag = "null";//声明字符串字段
        SqlConnection con = new SqlConnection(//声明数据库连接字段
@"Data Source=LVSHUANG\SHJ;Initial Catalog=db_TomeTwo;Integrated Security=SSPI");
        DataTable dt;//声明数据表字段

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showTrack();//查询数据表信息
            types();//设置ComboBox控件数据源
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.dataGridView1.SelectedCells[0].Value.ToString();//得到列名
            this.comboBox1.Text = this.dataGridView1.SelectedCells[1].Value.ToString();//得到类型
            this.textBox2.Text = this.dataGridView1.SelectedCells[2].Value.ToString();//得到长度
            this.textBox1.Enabled = false;//停用TextBox控件
        }
        private void showTrack()
        {
            con.Open();//打开数据库连接
            dt = new DataTable();//创建数据表
            SqlDataAdapter da = new SqlDataAdapter();//创建数据适配器对象
            SqlCommand cmd = new SqlCommand();//创建命令对象
            cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
            cmd.CommandText = "Poc_Linshi";//设置要执行的存储过程
            cmd.Connection = con;//设置连接对象
            da.SelectCommand = cmd;//设置查询命令属性
            da.Fill(dt);//填充数据表
            this.dataGridView1.DataSource = dt.DefaultView;//设置数据源
            con.Close();//关闭数据库连接
        }

        private void types()
        {
            string[] strtype = { "varchar", "char" };//创建字符串数组
            this.comboBox1.DataSource = strtype;//设置数据源
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = true;//启用按钮
            this.textBox1.Enabled = true;//启用文本框
            this.textBox1.Text = "";//清空文本框
            this.textBox2.Text = "";//清空文本框
            tag = "add";//设置操作类型
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = true;//启用按钮
            tag = "update";//设置操作类型
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除", "提示",//弹出消息对话框并判断
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                con.Open();//打开数据库连接
                string str = //创建SQL字符串
                    "alter table tb_Alter drop column " + this.textBox1.Text + "";
                SqlCommand cmd = new SqlCommand();//创建SQL命令对象
                cmd.CommandText = str;//设置要执行的SQL语句
                cmd.Connection = con;//设置连接对象
                cmd.ExecuteNonQuery();//执行SQL命令
                con.Close();//关闭数据库连接
                showTrack();//更新数据库结构
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();//打开数据库连接
                string str = string.Empty;//创建空字符串对象
                if (tag == "add")
                {
                    str += "alter table tb_Alter add " + this.textBox1.Text + " ";//创建SQL字符串
                    str += "" + this.comboBox1.Text + "(" + this.textBox2.Text + ")";//创建SQL字符串
                }
                else if (tag == "update")
                {
                    str += "alter table tb_Alter alter column " + this.textBox1.Text + " ";//创建SQL字符串
                    str += "" + this.comboBox1.Text + "(" + this.textBox2.Text + ")";//创建SQL字符串
                }
                SqlCommand cmd = new SqlCommand();//创建命令对象
                cmd.CommandText = str;//设置要执行的SQL语句
                cmd.Connection = con;//设置连接对象
                cmd.ExecuteNonQuery();//执行SQL命令
                con.Close();//关闭数据库连接
                showTrack();//更新数据库结构
                this.button4.Enabled = false;//停用Button按钮
            }
            catch(Exception ex)
            {
                con.Close();//关闭数据库连接
                MessageBox.Show(ex.Message,"提示！");//弹出消息对话框
            }
        }
    }
}
