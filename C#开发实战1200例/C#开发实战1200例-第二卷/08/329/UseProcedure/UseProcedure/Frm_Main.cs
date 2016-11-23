using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseProcedure
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        DataTable dt = null;//定义数据表字段
        SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showList();//显示员工信息
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string str = this.lv_Message.SelectedItems[0].Text.ToString();//得到员工编号
            showInfo(str);//显示单个员工信息
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (TextClear())
            {
                using (SqlCommand cmd = new SqlCommand())//创建命令对象
                {
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    cmd.CommandType = CommandType.StoredProcedure;//设置命令类型
                    cmd.CommandText = "proc_Update";//设置要执行的存储过程
                    SqlParameter[] par ={ //创建参数数组并赋值
                    new SqlParameter("@id",this.txt_id.Text), 
                    new SqlParameter("@name",this.txt_Name.Text),
                    new SqlParameter("@money",this.txt_Money.Text),
                    new SqlParameter("@talk",this.txt_Message.Text)
                };
                    foreach (SqlParameter parms in par)
                    {
                        cmd.Parameters.Add(parms);//添加参数
                    }
                    cmd.ExecuteNonQuery();//执行存储过程
                    con.Close();//关闭数据库连接
                    MessageBox.Show("修改成功");//弹出消息对话框
                    showList();//显示员工信息
                }
            }
            else
            {
                MessageBox.Show("请选择信息");//弹出消息对话框
            }
        }

        /// <summary>
        /// 清空控件内容
        /// </summary>
        /// <returns>方法返回布尔值</returns>
        private Boolean TextClear()
        {
            foreach (Control c in this.groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")
                    { return false; }//方法返回布尔值
                    else
                    { return true; }//方法返回布尔值
                }
            }
            return true;//方法返回布尔值
        }


        private void showList()
        {
            lv_Message.View = View.Details;//设置显示方式
            lv_Message.GridLines = true;//显示网格线
            using (SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器对象
                "select * from 员工表", con))
            {
                dt = new DataTable();//创建数据表对象
                da.Fill(dt);//填充数据表
                ColumnHeader ch;//声明列标题变量
                for (int i = 0; i < dt.Columns.Count; i++)//列
                {
                    ch = new ColumnHeader();//创建列标题对象
                    ch.Text = dt.Columns[i].ColumnName.ToString();//设置标题内容
                    ch.Name = dt.Columns[i].ColumnName.ToString();//设置标题名称
                    ch.Width = 72;//设置标题宽度
                    this.lv_Message.Columns.Add(ch);//添加列标题
                }
                Method(dt);//显示员工信息
            }
        }

        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <param name="dt">数据表对象</param>
        private void Method(DataTable dt)
        {
            lv_Message.Items.Clear();//清空数据项
            ListViewItem listItem = null;//声明数据项变量
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listItem = new ListViewItem(dt.Rows[j][0].ToString());//创建数据项对象
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    listItem.SubItems.Add(dt.Rows[j][k].ToString());//添加数据项子项
                }
                lv_Message.Items.Add(listItem);//添加数据项
            }
        }

        /// <summary>
        /// 显示单个员工信息
        /// </summary>
        /// <param name="strid">员工编号</param>
        private void showInfo(string strid)
        {
            using (SqlCommand cmd = new SqlCommand(//创建命令对象
                "select * from 员工表 where 员工编号='" + strid + "'", con))
            {
                con.Open();//打开数据库连接
                SqlDataReader dr = cmd.ExecuteReader();//得到数据读取器对象
                if (dr.HasRows)//判断是否有数据
                {
                    dr.Read();//读取数据记录
                    this.txt_id.Text = dr[0].ToString();//显示员工编号
                    this.txt_Name.Text = dr[1].ToString();//显示员工姓名
                    this.txt_Money.Text = dr[2].ToString();//显示员工工资
                    this.txt_Message.Text = dr[3].ToString();//显示员工评价
                }
                dr.Close();//关闭数据读取器
                con.Close();//关闭数据库连接
            }
        }
    }
}
