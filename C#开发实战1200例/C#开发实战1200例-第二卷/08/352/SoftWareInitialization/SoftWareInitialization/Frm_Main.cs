using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SoftWareInitialization
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(//创建数据库命令对象
                @"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器对象
                    "select name from tb_power", con);
                DataTable dt = new DataTable();//创建数据表
                da.Fill(dt);//填充数据表
                this.listBox1.DataSource = dt.DefaultView;//设置数据源
                this.listBox1.DisplayMember = "name";//设置显示属性
                this.listBox1.ValueMember = "name";//设置实实际值属性
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            uncheck("false");//设置所有的CheckBox控件为不选中状态
            string str = null;
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
                @"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                SqlCommand cmd = new SqlCommand(//创建数据库命令对象
                    "select power from tb_power where name='"
                    + this.listBox1.Text + "'", con);
                cmd.Connection = con;//设置连接属性
                cmd.Connection.Open();//打开数据库的连接
                SqlDataReader dr = cmd.ExecuteReader();//得到数据读取器
                if (dr.HasRows)//如果有记录
                {
                    dr.Read();//读取下一行
                    str = dr[0].ToString();//获取权限值
                }
                dr.Close();//关闭数据读取器
                con.Close();//关闭数据库连接
                string[] strpower = str.Split(',');//用逗号分隔字符串
                if (strpower[0] == "1")
                    cbox_Insert.Checked = true;//设置控件的Checked属性
                if (strpower[1] == "1")
                    cbox_Select.Checked = true;//设置控件的Checked属性
                if (strpower[2] == "1")
                    cbox_money.Checked = true;//设置控件的Checked属性
                if (strpower[3] == "1")
                    cbox_Master.Checked = true;//设置控件的Checked属性
                if (strpower[4] == "1")
                    btn_SelectX.Checked = true;//设置控件的Checked属性
                if (strpower[5] == "1")
                    cbox_Employee.Checked = true;//设置控件的Checked属性
                if (strpower[6] == "1")
                    cbox_Initial.Checked = true;//设置控件的Checked属性
                if (strpower[7] == "1")
                    cbox_Log.Checked = true;//设置控件的Checked属性
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uncheck("true");//设置控件的Checked属性
        }

        /// <summary>
        /// 设置控件的Checked属性
        /// </summary>
        /// <param name="str">布尔值</param>
        private void uncheck(string str)
        {
            cbox_Insert.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_Select.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_money.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_Master.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            btn_SelectX.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_Employee.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_Initial.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
            cbox_Log.Checked = Convert.ToBoolean(str);//设置控件的Checked属性
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uncheck("false");//设置控件的Checked属性
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strValue = string.Empty;//创建字符串对象
            if (cbox_Insert.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_Select.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_money.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_Master.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (btn_SelectX.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_Employee.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_Initial.Checked)//判断控件的Checked属性
                strValue += "1,";//组合字符串
            else
                strValue += "0,";//组合字符串
            if (cbox_Log.Checked)//判断控件的Checked属性
                strValue += "1";//组合字符串
            else
                strValue += "0";//组合字符串
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                SqlCommand cmd = new SqlCommand(//创建命令对象
                    "update tb_Power set power='" + strValue +
                    "' where name='" + this.listBox1.Text + "' ", con);
                cmd.Connection = con;//设置数据库连接属性
                cmd.Connection.Open();//打开数据库连接
                cmd.ExecuteNonQuery();//执行SQL语句
                MessageBox.Show("授权成功！！！");//弹出消息对话框
            }
        }
    }
}