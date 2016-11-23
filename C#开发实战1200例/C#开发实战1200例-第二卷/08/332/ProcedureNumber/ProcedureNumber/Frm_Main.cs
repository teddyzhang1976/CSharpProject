using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace ProcedureNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int x = Int32.Parse(txt_Age.Text);//将年龄转换为整数
                if (x < 60 && x > 20)//判断年龄区间
                {
                    errorage.SetError(this.txt_Age, "");//指定错误描述字符串
                }
                else
                {
                    errorage.SetError(this.txt_Age, "数值应在20-60之间");//指定错误描述字符串
                }
            }
            catch
            {
                errorage.SetError(this.txt_Age, "应为整数");//指定错误描述字符串
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoID();//获取员工编号
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ifNull())//判断文本框是否为空
            {
                if (info())//判断工资信息是否正确
                {
                    if (IDCard(this.txt_Num.Text))
                    {
                        InsertInfo();
                    }
                    else
                    { MessageBox.Show("身份证号格式不正确"); }
                }
            }
            else
            {
                MessageBox.Show("请将信息添加完整");
            }
        }

        /// <summary>
        /// 判断身份证号码是否正确
        /// </summary>
        /// <param name="ID">身份证号码</param>
        /// <returns>方法返回布尔值</returns>
        public bool IDCard(string ID)
        {
            if (!Regex.IsMatch(ID,//使用正则表达式验证15位身份证号
@"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$"))
            {
                if (Regex.IsMatch(ID,//使用正则表达式验证18位身份证号
                @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$"))
                {
                    return true;//方法返回布尔值
                }
                else
                {
                    return false;//方法返回布尔值
                }
            }
            else
            {
                return true;//方法返回布尔值
            }
        }

        /// <summary>
        /// 判断工资信息是否正确
        /// </summary>
        /// <returns>方法返回布尔值</returns>
        private bool info()
        {
            for (int i = 0; i < this.txt_Money.Text.Length; i++)
            {
                if (!char.IsNumber(this.txt_Money.Text[i]))//判断工资是否为数值
                {
                    if (this.txt_Money.Text[i] != '.')
                    {
                        MessageBox.Show("工资信息有误");//弹出消息对话框
                        return false;//方法返回布尔值
                    }
                }

            }
            return true;//方法返回布尔值
        }

        /// <summary>
        /// 判断文本框是否为空
        /// </summary>
        /// <returns>方法返回布尔值</returns>
        private bool ifNull()
        {
            foreach (Control Con in this.Controls)
            {
                if (Con is TextBox)
                {
                    if (Con.Text == "")
                    {
                        return false;//方法返回布尔值
                    }
                }
            }
            return true;//方法返回布尔值
        }


        /// <summary>
        /// 清空文本框
        /// </summary>
        private void NullValue()
        {
            foreach (Control Con in this.Controls)
            {
                if (Con is TextBox)
                {
                    Con.Text = "";//清空文本框

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }

        /// <summary>
        /// 获取员工编号
        /// </summary>
        private void AutoID()
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                con.Open();//打开数据库连接
                SqlCommand cmd = new SqlCommand();//创建命令对象
                cmd.CommandText = "select Max(tb_ID) from 员工个人信息";//设置要执行的SQL语句
                cmd.Connection = con;//设置连接对象
                string str = cmd.ExecuteScalar().ToString();//得到员工编号字符串
                if (str == "")
                    this.txt_id.Text = "P1001";//得到员工编号
                else
                {
                    this.txt_id.Text = "P" + //得到员工编号
                        Convert.ToString(Convert.ToInt32(str.Substring(1)) + 1);
                }
            }
        }

        private void InsertInfo()
        {
            using (SqlConnection con = new SqlConnection(@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                con.Open();//打开数据库连接
                SqlCommand cmd = new SqlCommand();//创建命令对象
                string strSql = //创建SQL字符串
                    "insert into 员工个人信息 values ('" + this.txt_id.Text +
                    "','" + this.txt_Name.Text + "','" + this.txt_Age.Text + "','" +
                    this.txt_Money.Text + "','" + this.txt_Num.Text + "')";
                cmd.CommandText = strSql;//设置要执行的SQL语句
                cmd.Connection = con;//设置连接属性
                cmd.ExecuteNonQuery();//执行SQL语句
                con.Close();//关闭数据库连接
                MessageBox.Show("成功添加信息");//弹出消息对话框
                NullValue();//清空文本框
            }
            AutoID();//获取员工编号
        }
    }
}