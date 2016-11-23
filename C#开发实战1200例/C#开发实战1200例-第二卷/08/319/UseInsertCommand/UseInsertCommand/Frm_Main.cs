using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseInsertCommand
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        DataTable dt=null;//声明DataTable字段
        TextBox[] txtBox;//声明TextBox数组字段
        SqlConnection con = new SqlConnection(//声明数据库连接字段
@"server=WIN-GI7E47AND9R\LS;pwd=;uid=sa;database=db_TomeTwo");


        private void showList()
        {
            listView1.View = View.Details;//设置视图显示方式
            listView1.GridLines = true;//显示网格线
            using (SqlDataAdapter da =//创建数据适配器对象
                new SqlDataAdapter("select * from 帐单", con))
            {
                //生成结果集
                dt = new DataTable();//创建DataTable对象
                da.Fill(dt);//填充数据表
                ColumnHeader ch;//声明列标题变量
                for (int i = 0; i < dt.Columns.Count; i++)//列
                {
                    ch = new ColumnHeader();//创建列标题对象
                    ch.Text = dt.Columns[i].ColumnName.ToString();//设置列标题文本内容
                    ch.Name = dt.Columns[i].ColumnName.ToString();//设置列标题名称
                    ch.Width = 72;//设置列标题宽度
                    this.listView1.Columns.Add(ch);//添加列标题
                }
                Method(dt);//添加数据记录
            }      
        }
        private void tbADD_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                txtBox = new TextBox[6];//创建数组对象
                txtBox[0] = this.textBox1;//得到TextBox对象的引用
                txtBox[1] = this.textBox2;//得到TextBox对象的引用
                txtBox[2] = this.textBox3;//得到TextBox对象的引用
                txtBox[3] = this.textBox4;//得到TextBox对象的引用
                txtBox[4] = this.textBox5;//得到TextBox对象的引用
                txtBox[5] = this.textBox6;//得到TextBox对象的引用
                DataRow row = dt.NewRow();//得到数据行对象
                for (int i = 0; i < dt.Columns.Count; i++)
                {            
                   row[dt.Columns[i].ToString()] =//向数据行内添加信息
                       this.txtBox[i].Text.ToString();
                }
                dt.Rows.Add(row);//添加数据行
                Method(dt);//显示数据表中内容
            }
        }

        private void Method(DataTable dt)
        {
            listView1.Items.Clear();//清空控件中的数据项
            ListViewItem listItem = null;//定义数据项变量
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                listItem = new ListViewItem(dt.Rows[j][0].ToString());//创建数据项对象
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    listItem.SubItems.Add(dt.Rows[j][k].ToString());//为数据项添加子项
                }
                listView1.Items.Add(listItem);//添加数据项
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            using (SqlDataAdapter da = new SqlDataAdapter())//创建数据适配器对象
            {
                SqlCommand command = new SqlCommand("INSERT INTO 帐单 " +//创建SQL命令对象
                "VALUES (@员工姓名, @基本工资,@奖金,@扣款,@午餐,@实际工资)", con);
                command.Parameters.Add("@员工姓名", SqlDbType.VarChar, 10, "员工姓名");//添加参数
                command.Parameters.Add("@基本工资", SqlDbType.VarChar, 10, "基本工资");//添加参数
                command.Parameters.Add("@奖金", SqlDbType.VarChar, 10, "奖金");//添加参数
                command.Parameters.Add("@扣款", SqlDbType.VarChar, 10, "扣款");//添加参数
                command.Parameters.Add("@午餐", SqlDbType.VarChar, 10, "午餐");//添加参数
                command.Parameters.Add("@实际工资", SqlDbType.VarChar, 10, "实际工资");//添加参数
                da.InsertCommand = command;//设置插入命令属性
                da.Update(dt);//同步数据
                MessageBox.Show("已成功地将信息解析回数据库");//弹出消息对话框
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            showList();//显示员工信息
        }
    }
}
