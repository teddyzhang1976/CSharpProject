using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace SQLDelete
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        SqlConnection con =//创建数据库连接对象
            new SqlConnection(@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");
        
        /// <summary>
        /// 显示员工信息
        /// </summary>
        private void showinfo()
        {
            using (SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo"))
            {
                DataTable dt = new DataTable();//创建数据表
                SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器
                    "select * from 员工表", con);
                da.Fill(dt);//填充数据表
                this.dgv_Message.DataSource = dt.DefaultView;//设置数据源
            }    
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showinfo();//显示员工信息
        }

        private void txt_Execute_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())//创建命令对象
            {
                try
                {
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    cmd.CommandText = this.txt_SQL.Text;//设置SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    con.Close();//关闭数据库连接
                    showinfo();//显示员工信息
                    MessageBox.Show("删除成功");//弹出消息对话框
                    this.txt_SQL.Focus();//得到焦点
                    this.txt_SQL.SelectAll();//选中所有文本
                }
                catch
                {
                    MessageBox.Show("SQL语句有误");//弹出消息对话框
                    this.txt_SQL.Focus();//得到焦点
                    this.txt_SQL.SelectAll();//选中所有文本
                }
            }
        }
    }
}