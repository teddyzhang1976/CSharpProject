using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataObjectAlter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        static int Num = 0;//当前记录索引
        int Count = 0;//数据记录总数量
        SqlConnection con =//数据库连接对象
            new SqlConnection(@"server=LVSHUANG\SHJ;pwd=;uid=sa;database=db_TomeTwo");

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Resultinfo(Num);//显示记录信息
            using (SqlCommand cmd = new SqlCommand(//创建命令对象
                "select Count(*) from 员工表", con))
            {
                con.Open();//打开数据库连接
                Count = Convert.ToInt32(cmd.ExecuteScalar());//得到数据记录总数量
                con.Close();//关闭数据库连接
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        /// <summary>
        /// 从数据库中获取指定数据记录
        /// </summary>
        /// <param name="i">记录的索引位置</param>
        /// <returns>方法返回数据集</returns>
        private DataSet DtReslut(int i)
        {
            using (SqlDataAdapter da = new SqlDataAdapter())//创建数据适配器对象
            {
                da.SelectCommand = new SqlCommand(//创建命令对象
                    "select * from 员工表", con);
                DataSet ds = new DataSet();//创建数据集对象
                da.Fill(ds, i, 1, "员工表");//填充数据集
                return ds;//方法返回数据集
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num = 0;//设置记录索引
            Resultinfo(Num);//显示记录信息
        }

        /// <summary>
        /// 在窗体中显示指定数据记录
        /// </summary>
        /// <param name="j"></param>
        private void Resultinfo(int j)
        {
            DataSet dsNew = DtReslut(j);//得到数据集
            this.txt_id.Text = //得到员工编号
                dsNew.Tables[0].Rows[0][0].ToString();
            this.txt_Name.Text =//得到员工姓名
                dsNew.Tables[0].Rows[0][1].ToString();
            this.txt_money.Text =//得到员工工资
                dsNew.Tables[0].Rows[0][2].ToString();
            this.txt_Message.Text =//得到员工评价
                dsNew.Tables[0].Rows[0][3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Num -= 1;//计算记录索引
            if (Num >= 0)
            {
                Resultinfo(Num);//显示员工信息
            }
            else
            {
                MessageBox.Show("现已是首条记录");//弹出消息对话框
                Num = 0;//设置记录索引
                return;//退出事件
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Num += 1;//计算记录索引
            if (Num < Count)
            {
                Resultinfo(Num);//显示员工信息
            }
            else
            {
                MessageBox.Show("现已是末条记录");//弹出消息对话框
                Num = Count - 1;//设置记录索引
                return;//退出事件
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Num = Count;
            Resultinfo(Num - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (update())
            {
                MessageBox.Show("成功修改");//弹出消息对话框
            }
        }

        private bool update()
        {

            using (SqlCommand command = new SqlCommand("update 员工表 set" +//创建命令对象
               @" 员工姓名=@员工姓名,基本工资=@基本工资,
工作评价=@工作评价 where 员工编号=@员工编号 ", con))
            {
                con.Open();//打开数据库连接
                try
                {
                    command.Parameters.Add("@员工编号", SqlDbType.VarChar, 50,//设置命令对象参数并赋值
                        "员工编号").Value = this.txt_id.Text;
                    command.Parameters.Add("@员工姓名", SqlDbType.VarChar, 50,//设置命令对象参数并赋值
                        "员工姓名").Value = this.txt_Name.Text;
                    command.Parameters.Add("@基本工资", SqlDbType.Float, 8,//设置命令对象参数并赋值
                        "基本工资").Value = Convert.ToString(this.txt_money.Text);
                    command.Parameters.Add("@工作评价", SqlDbType.VarChar, 50,//设置命令对象参数并赋值
                        "工作评价").Value = this.txt_Message.Text;
                    command.ExecuteNonQuery();//执行SQL命令
                    con.Close();//关闭数据库连接
                    return true;//方法返回布尔值
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"提示！");//弹出消息对话框
                    return false;
                }
            }
        }

    }
}
