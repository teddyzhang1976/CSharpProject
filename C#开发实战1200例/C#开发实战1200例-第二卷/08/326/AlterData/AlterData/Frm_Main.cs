using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AlterData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showList();//显示
        }

        SqlConnection con = new SqlConnection(
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");
        DataTable dt = null;
        private void tbExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }



        private void showList()
        {
            
            lv_Employee.View = View.Details;//视图
            lv_Employee.GridLines = true;//网格线
            using (SqlDataAdapter da = new SqlDataAdapter("select * from 员工表", con))
            {
                //生成结果集
                dt = new DataTable();
                da.Fill(dt);
                ColumnHeader ch;
                
                for (int i = 0; i < dt.Columns.Count; i++)//列
                {
                    ch = new ColumnHeader();
                    ch.Text = dt.Columns[i].ColumnName.ToString();
                    ch.Name = dt.Columns[i].ColumnName.ToString();
                    ch.Width = 72;
                    this.lv_Employee.Columns.Add(ch);
                }
                //建立结构
                Method(dt);
            }
        }

        private void Method(DataTable dt)
        {
            lv_Employee.Items.Clear();
            ListViewItem listItem = null;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listItem = new ListViewItem(dt.Rows[j][0].ToString());
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    listItem.SubItems.Add(dt.Rows[j][k].ToString());
                }
                lv_Employee.Items.Add(listItem);
            }
        }


        private void showInfo(string strid)
        {
            using (SqlCommand cmd = new SqlCommand("select * from 员工表 where 员工编号='" + strid + "'", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    this.textBox1.Text = dr[0].ToString();
                    this.textBox2.Text = dr[1].ToString();
                    this.textBox4.Text = dr[2].ToString();
                    this.textBox5.Text = dr[3].ToString();
                }
                dr.Close();
                con.Close();
                this.tbUpdate.Enabled = true;
            }
        }

        private void tbUpdate_Click(object sender, EventArgs e)
        {
            if (Updateinfo())
            {
                MessageBox.Show("修改成功");
                this.tbUpdate.Enabled = false;
                lv_Employee.Columns.Clear();
                showList();
            }
            else
            {
                MessageBox.Show("修改失败");
                return;
            }

        }
        private bool Updateinfo()
        {
            using (SqlCommand cmd = new SqlCommand())//创建数据命令对象
            {
                try
                {
                    cmd.CommandText = "update 员工表 set 员工姓名='" +//设置将要执行的SQL语句
                        this.textBox2.Text + "',基本工资='" + this.textBox4.Text + 
                        "',工作评价='" + this.textBox5.Text + 
                        "' where 员工编号='" + this.textBox1.Text + "'";
                    con.Open();//打开数据库连接
                    cmd.Connection = con;//设置命令对象的连接属性
                    cmd.ExecuteNonQuery();//执行SQL语句
                    con.Close();//关闭数据库连接
                    return true;//方法返回布尔值
                }
                catch
                {
                    return false;//方法返回布尔值
                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string str = this.lv_Employee.SelectedItems[0].Text.ToString();
            showInfo(str);
        }
    }
}
