using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace MoveData
{
    public partial class Frm_Main : Form
    {

        public Frm_Main()
        {
            InitializeComponent();
        }


        static int Num = 0;//数据记录的索引
        int Count = 0;//最大记录数量
        SqlConnection con = new SqlConnection(//创建数据库连接对象
@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        /// <summary>
        /// 方法返回数据集
        /// </summary>
        /// <param name="i">数据记录的索引</param>
        /// <returns>方法返回数据集</returns>
        private DataSet DtReslut(int i)
        {
            using (SqlDataAdapter da = new SqlDataAdapter())//创建数据适配器对象
            {
                da.SelectCommand = new SqlCommand(//创建命令对象
                    "select * from 员工表", con);
                DataSet ds = new DataSet();//创建数据集
                da.Fill(ds, i, 1, "员工表");//填充数据集
                return ds;//返回数据集
            }
        }

        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <param name="j">数据记录的索引</param>
        private void Resultinfo(int j)
        {
            DataSet dsNew = DtReslut(j);//根据数据记录索引查询数据记录
            this.txt_id.Text = dsNew.Tables[0].Rows[0][0].ToString();//显示员工编号
            this.txt_Name.Text = dsNew.Tables[0].Rows[0][1].ToString();//显示员工姓名
            this.txt_money.Text = dsNew.Tables[0].Rows[0][2].ToString();//显示员工工资
            this.txt_Message.Text = dsNew.Tables[0].Rows[0][3].ToString();//显示员工评价
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Resultinfo(Num);//显示员工信息
            using (SqlCommand cmd = new SqlCommand(//创建命令对象
                "select Count(*) from 员工表", con))
            {
                con.Open();//打开数据库连接
                Count = Convert.ToInt32(cmd.ExecuteScalar());//得到数据记录数量
                con.Close();//关闭数据库连接
            }
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            Num = 0;//设置数据记录索引
            Resultinfo(Num);//显示员工信息
        }

        private void btn_Befor_Click(object sender, EventArgs e)
        {
            Num -= 1;//设置数据记录索引
            if (Num >= 0)
            {
                Resultinfo(Num);//显示员工信息
            }
            else
            {
                MessageBox.Show("现已是首条记录");//弹出消息对话框
                Num = 0;//设置数据记录索引
            }
        }

        private void btn_After_Click(object sender, EventArgs e)
        {
            Num += 1;//设置数据记录索引
            if (Num < Count)
            {
                Resultinfo(Num);//显示员工信息
            }
            else
            {
                MessageBox.Show("现已是末条记录");//弹出消息对话框
                Num = Count - 1;//设置数据记录索引
            }
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            Num = Count - 1;//设置数据记录索引
            Resultinfo(Num);//显示员工信息
        }
    }
}