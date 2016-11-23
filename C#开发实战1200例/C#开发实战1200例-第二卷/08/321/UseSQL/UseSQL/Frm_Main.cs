using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseSQL
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(//声明数据库连接字段
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ControlInfo(false);//停用控件
            showinfo();//显示员工信息
        }

        private void showinfo()
        { 
             using (SqlDataAdapter da =//创建数据适配器对象
                 new SqlDataAdapter("select * from 员工表", con))
            {
                DataTable dt = new DataTable();//创建数据表
                da.Fill(dt);//填充数据表
                DataView dv = new DataView(dt);//创建数据视图对象
                this.dataGridView1.DataSource = dv;//设置数据源

            }
        }
        private void tbADD_Click(object sender, EventArgs e)
        {
            ControlInfo(true);//启用控件
            this.tbSave.Enabled = true;//启用Button按钮
            this.tbADD.Enabled = false;//停用Button按钮
          
        }
        private void ControlInfo(Boolean B)
        {
            foreach (Control ct in this.groupBox1.Controls)
            {
                if (ct is TextBox)
                {
                    ct.Text = "";//显示空文本
                    if (B)
                    {
                        ct.Enabled = true;//启用控件
                    }
                    else
                    {
                        ct.Enabled = false;//停用控件
                    }
                }
            }
        }
        private void tbSave_Click(object sender, EventArgs e)
        {
            StringBuilder strSQL = new StringBuilder();//创建StringBuilder对象
            strSQL.Append("insert into 员工表(员工编号, 员工姓名,基本工资,工作评价)");//追加文本内容
            strSQL.Append(" values('" + textBox1.Text.Trim().ToString() + "','" +//追加文本内容
                textBox2.Text.Trim().ToString() + "',");
            strSQL.Append("'" + Convert.ToSingle(textBox4.Text.Trim().ToString()) +//追加文本内容
                "','" + textBox5.Text.Trim().ToString() + "')");
            using(SqlCommand cmd =//创建数据库命令对象
                new SqlCommand(strSQL.ToString(),con))
            {
                con.Open();//打开数据库连接
                cmd.ExecuteNonQuery();//执行SQL命令
                MessageBox.Show("添加数据成功");//弹出消息对话框
                ControlInfo(false);//停用控件
                con.Close();//关闭数据库连接
            }
            showinfo();//显示员工信息
            this.tbSave.Enabled = false;//停用Button按钮
            this.tbADD.Enabled = true;//启用Button按钮
        }
    }
}
