using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseSQLUpdate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        DataTable dt = null;//定义表对象字段
        SqlConnection con = new SqlConnection(//创建数据连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showList();//显示员工表信息
        }

        /// <summary>
        /// 显示员工表信息
        /// </summary>
        private void showList()
        {
            listView1.View = View.Details;//设置显示方式
            listView1.GridLines = true;//显示网格线
            using (SqlDataAdapter da = new SqlDataAdapter(//创建数据适配器对象
                "select * from 员工表", con))
            {
                dt = new DataTable();//创建数据表对象
                da.Fill(dt);//填充数据表
                ColumnHeader ch;//定义列标题变量
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ch = new ColumnHeader();//创建列标题对象
                    ch.Text = dt.Columns[i].ColumnName.ToString();//设置标题文本内容
                    ch.Name = dt.Columns[i].ColumnName.ToString();//设置标题名称
                    ch.Width = 72;//设置标题宽度
                    this.listView1.Columns.Add(ch);//添加标题列
                }
                Method(dt);//显示数据内容
            }
        }

        /// <summary>
        /// 显示数据内容
        /// </summary>
        /// <param name="dt">数据表对象</param>
        private void Method(DataTable dt)
        {
            listView1.Items.Clear();//清空数据项
            ListViewItem listItem = null;//声明数据项变量
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listItem =//创建数据项对象
                    new ListViewItem(dt.Rows[j][0].ToString());
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    listItem.SubItems.Add(//添加数据项子项
                        dt.Rows[j][k].ToString());
                }
                listView1.Items.Add(listItem);//添加数据项
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())//创建命令对象
            {
                try
                {
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置连接属性
                    cmd.CommandText = this.textBox1.Text;//设置SQL语句
                    cmd.ExecuteNonQuery();//执行SQL语句
                    con.Close();//关闭数据库连接
                    showList();//显示员工表信息
                    MessageBox.Show("成功修改");//弹出消息对话框
                    this.textBox1.Focus();//控件得到焦点
                    this.textBox1.SelectAll();//选中所有内容
                }
                catch
                {
                    MessageBox.Show("SQL语句有误");//弹出消息对话框
                    this.textBox1.Focus();//控件得到焦点
                    this.textBox1.SelectAll();//选中所有内容
                }
            }
        }
    }
}
