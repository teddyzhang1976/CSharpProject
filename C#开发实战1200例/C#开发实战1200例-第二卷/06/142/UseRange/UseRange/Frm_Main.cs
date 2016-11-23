using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseRange
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = GetMessage();//设置数据源
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            int Age1;//定义整型变量
            if (int.TryParse(txt_Age.Text,out Age1) )//转换为数值
            {
                dgv_Message.DataSource = GetStudent(Age1);//设置数据源
            }
            else
            {
                MessageBox.Show("请正确输入数值！","提示！");//弹出消息对话框
            }
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetStudent(int Age)
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=LVSHUANG\SHJ;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT  学生姓名,年龄,性别,家庭住址 FROM tb_Student WHERE 年龄 Like '{0}[0-9]'",
                Age);
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }

        /// <summary>
        /// 查询数据库信息
        /// </summary>
        /// <returns>方法返回DataTable对象</returns>
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format(//创建数据库连接字符串
                @"server=LVSHUANG\SHJ;database=db_TomeTwo;uid=sa;Pwd=hbyt2008!@#;");
            string P_Str_SqlStr = string.Format(//创建SQL查询字符串
                "SELECT  学生姓名,年龄,性别,家庭住址 FROM tb_Student");
            SqlDataAdapter P_SqlDataAdapter = new SqlDataAdapter(//创建数据适配器
                P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();//创建数据表
            P_SqlDataAdapter.Fill(P_dt);//填充数据表
            return P_dt;//返回数据表
        }
    }
}
