using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace GoodsSallTrend
{
    public partial class Frm_Main : Form
    {
        SqlConnection con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;pwd=;uid=sa;database=db_TomeOne");
        SqlDataAdapter sqlAda;
        SqlCommand cmd;
        DataSet ds;
        static int G = 0;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            G++;
            DrowFont(this.comboBox1.Text.ToString());
            DrowInfo(this.comboBox1.Text.ToString());
            DrowPic(this.comboBox1.Text.ToString());
        }

        private void DrowPic(string str)
        {
            int MaxValue, MinValue;								//声明变量记录最大值和最小值
            using (cmd = new SqlCommand("select Max(t_price) from tb_merchandise where t_name='" + str + "'", con))
            {
                con.Open();										//打开数据库连接
                MaxValue = Convert.ToInt16(cmd.ExecuteScalar());			//获取最大值
                con.Close();										//关闭数据库连接
            }
            using (cmd = new SqlCommand("select Min(t_price) from tb_merchandise where t_name='" + str + "'", con))
            {
                con.Open();										//打开数据库连接
                MinValue = Convert.ToInt16(cmd.ExecuteScalar());			//获取最小值
                con.Close();										//关闭数据库连接
            }
            Graphics g = this.groupBox1.CreateGraphics();					//创建Graphics对象
            g.Clear(Color.SeaShell);									//设置背景
            Brush b = new SolidBrush(Color.Blue);						//创建Brush对象
            Font f = new Font("Arial", 9, FontStyle.Regular);				//创建Font对象
            Pen p = new Pen(b);									//创建Pen对象
            using (sqlAda = new SqlDataAdapter("select * from tb_merchandise where t_name='" + str + "' order by t_date", con))
            {
                ds = new DataSet();								//实例化DataSet对象
                sqlAda.Fill(ds, "t_date");								//Fill方法填充对象
                int M = MaxValue / 50 + 1;							//最大值
                int N = MinValue / 50;								//最小值
                int T = N;
                for (int i = 0; i <= M - N; i++)
                {
                    g.DrawString(Convert.ToString(T * 50), f, b, 0, 190 - 30 * i);
                    g.DrawLine(p, 30, 200 - 30 * i, 260, 200 - 30 * i);
                    T++;
                }
                int Num = ds.Tables[0].Rows.Count;
                int[] Values = new int[Num];
                for (int C = 0; C < Num; C++)
                {
                    Values[C] = Convert.ToInt32(ds.Tables[0].Rows[C][3].ToString());
                    g.DrawString(Convert.ToDateTime(ds.Tables[0].Rows[C][2].ToString()).Month + "月", f, b, 30 * (C + 1) - 10, 15);
                    g.DrawLine(p, 30 * (C + 1), 200, 30 * (C + 1), 30);
                }
                Point[] P = new Point[Num];
                for (int i = 0; i < Num; i++)
                {
                    P[i].X = 30 * (i + 1);
                    P[i].Y = 290 - Convert.ToInt32(Values[i] / 50f * 30);
                }
                g.DrawLines(p, P);
            }
        }
        private void DrowInfo(string str)
        {
            Graphics g = this.groupBox2.CreateGraphics();					//创建Graphics对象
            g.Clear(Color.SeaShell);									//设置背景颜色
            Brush b = new SolidBrush(Color.Blue);						//创建Brush对象
            Font f = new Font("Arial", 9, FontStyle.Regular);					//设置Font对象
            using (sqlAda = new SqlDataAdapter("select * from tb_merchandise where t_name='" + str + "' order by t_date", con))
            {
                DataSet ds = new DataSet();							//创建DataSet对象
                sqlAda.Fill(ds, "tb_09");								//Fill方法填充对象
                g.DrawString("月份：       " + "价格", f, b, 10.0f, 25.0f);	//绘制标题
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)			//绘制月份及相应的产品价格
                {
                    int month = Convert.ToDateTime(ds.Tables[0].Rows[i][2].ToString()).Month;//获取月份
                    if (month >= 10)
                    {
                        //绘制月份及价格
                        g.DrawString(month + "月： " + "『" + ds.Tables[0].Rows[i][3].ToString() + " 』", f, b, 10.0f, (i + 2) * 25.0f);
                    }
                    else
                    {
                        g.DrawString("0" + month + "月： " + "『" + ds.Tables[0].Rows[i][3].ToString() + " 』", f, b, 10.0f, (i + 2) * 25.0f);
                    }
                }
            }
        }

        private void DrowFont(string str)
        {
            using(Graphics GrapFont = this.panel1.CreateGraphics())
            {
                GrapFont.Clear(Color.SeaShell);
                Pen p = new Pen(Color.Blue, 2.0f);
                Font f = new Font("华文新魏", 12, FontStyle.Regular);
                Brush b = new SolidBrush(Color.Blue);
                GrapFont.DrawString("『" + str + "』"+"产品销售走势", f, b, 4.0f, 5.0f);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (sqlAda = new SqlDataAdapter("select distinct(t_name) from tb_merchandise", con))
            {
                DataSet ds = new DataSet();
                sqlAda.Fill(ds, "tb_merchandise");
                this.comboBox1.DataSource = ds.Tables[0];
                this.comboBox1.DisplayMember = "t_name";
            }
        }
    }
}