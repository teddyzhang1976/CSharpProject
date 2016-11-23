using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseADO
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(//创建数据库连接字段
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            ControlInfo(false);//停用TextBox控件
        }

        private void tbADD_Click(object sender, EventArgs e)
        {
            ControlInfo(true);//启用TextBox控件
            this.textBox1.Enabled = false;//停用文本框
            con.Open();//打开数据库连接
            using (SqlCommand cmd =//创建数据库命令对象
                new SqlCommand("select Max(员工编号) from 员工表", con))
            {
                if (Convert.ToString(cmd.ExecuteScalar()) != "")
                {
                    string strID = Convert.ToString(cmd.ExecuteScalar());//得到员工编号
                    this.textBox1.Text =//得到加1的员工编号
                        strID.Substring(0, 1) + Convert.ToString(Convert.ToUInt32(strID.Substring(1)) + 1);
                }
                else
                {
                    this.textBox1.Text = "P1001";//得到员工编号
                }
            }
            con.Close();//关闭数据库连接
        }
        private void ControlInfo(Boolean B)
        {
            foreach (Control ct in this.groupBox1.Controls)
            {
                if (ct is TextBox)//判断是否是TextBox控件
                {
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
            con.Open();//打开数据库连接
            using (SqlCommand command = new SqlCommand("INSERT INTO 员工表 " +//创建数据库命令对象
               "VALUES (@员工编号, @员工姓名,@基本工资,@工作评价,@所属部门)", con))
            {
                command.Parameters.Add("@员工编号",//添加参数并赋值
                    SqlDbType.VarChar, 50, "员工编号").Value = this.textBox1.Text;
                command.Parameters.Add("@员工姓名",//添加参数并赋值
                    SqlDbType.VarChar, 50, "员工姓名").Value = this.textBox2.Text;
                command.Parameters.Add("@基本工资",//添加参数并赋值
                    SqlDbType.Float, 8, "基本工资").Value = Convert.ToString(this.textBox4.Text);
                command.Parameters.Add("@工作评价",//添加参数并赋值
                    SqlDbType.VarChar, 50, "工作评价").Value = this.textBox5.Text;
                command.Parameters.Add("@所属部门",//添加参数并赋值
                    SqlDbType.VarChar, 50, "所属部门").Value = "";
                command.ExecuteNonQuery();//执行SQL语句
                MessageBox.Show("添加数据成功");//弹出消息对话框
            }
            con.Close();//关闭数据库连接
        }
    }
}
