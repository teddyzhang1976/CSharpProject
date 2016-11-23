using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace MultiCAnalyseHR
{
    public partial class Frm_Main : Form
    {
        SqlConnection con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;pwd=;uid=sa;database=db_TomeOne");
        SqlCommand cmd;
        static int ConutNum = 0;
        static float floatNum=0.0f;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand("select sum(t_Num) from tb_manpower ", con))
            {
                con.Open();
                int Sum = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                ShowPic(Sum);
            }
        }

        private void ShowPic(int Sum)//通过自定义ShowPic( )方法,绘制多饼图分析企业人力资源情况
        {
            using (cmd = new SqlCommand("select t_Point,sum(t_Num) from tb_manpower group by t_Point order by sum(t_Num) desc", con))
            {
                Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);			//创建画布
                Graphics g = Graphics.FromImage(bmp);							//创建Graphics对象
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();							//创建SqlDataReader对象
                while (dr.Read())											//开始读取记录
                {
                    float f = Convert.ToSingle(dr[1]) / Sum;
                    string str = dr[0].ToString();
                    drowPic(g, f, str);										//调用drowPic方法绘制饼图
                }
                //绘制线条
                g.DrawLine(new Pen(Color.Black), 0, this.panel1.Height / 2, this.panel1.Width, this.panel1.Height / 2);
                g.DrawLine(new Pen(Color.Black), this.panel1.Width / 2, 0, this.panel1.Width / 2, this.panel1.Height);
                this.panel1.BackgroundImage = bmp;								//显示绘制的图形
                dr.Close();												//关闭SqlDataReader对象
                con.Close();												//关闭数据库连接
            }
        }
        private void drowPic(Graphics g, float f, string str) 							//根据要求绘制饼图
        {
            if (ConutNum == 0)											//如果ConutNum为0时执行
            {
                //绘制扇形
                g.FillPie(new SolidBrush(Color.Black), 0, 0, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, 0, 360 * f);
                //绘制文本
                g.DrawString(str, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), (this.panel1.Width) / 2 - 70, 10);
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Black), (this.panel1.Width) / 2 - 70, 25);							//绘制文本
                floatNum = 360 * f;										//计算角度
                ConutNum += 1;											//使ConutNum为1
            }
            else if (ConutNum == 1)										//如果ConutNum为1时执行
            {
                g.FillPie(new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2, 0, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);												//绘制扇形
                g.DrawString(str, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2 + 10, 10);															//绘制文本
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), (this.panel1.Width) / 2 + 10, 25);					//绘制文本
                floatNum += 360 * f;										//计算角度
                ConutNum += 1;										// ConutNum为2
            }
            else if (ConutNum == 2)										// ConutNum为2时执行
            {
                g.FillPie(new SolidBrush(Color.Red), 0, (this.panel1.Height - 10) / 2 + 10, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);									//绘制扇形
                g.DrawString(str, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Red), 10, (this.panel1.Height - 10) / 2 + 20);															//绘制文本
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Red), 10, (this.panel1.Height - 10) / 2 + 35);						//绘制文本
                floatNum += 360 * f;										//计算角度
                ConutNum += 1;											// ConutNum为3
            }
            else if (ConutNum == 3)										// ConutNum为3时执行
            {
                g.FillPie(new SolidBrush(Color.Blue), (this.panel1.Width) / 2 - 10, (this.panel1.Height - 10) / 2 + 10, (this.panel1.Width) / 2, (this.panel1.Height - 10) / 2, floatNum, 360 * f);				//绘制扇形
                g.DrawString(str, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Blue), (this.panel1.Width) / 2 + 10, (this.panel1.Height - 10) / 2 + 20);											//绘制文本
                g.DrawString(Convert.ToString(f * 100).Substring(0, 5) + "%", new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Blue), (this.panel1.Width) / 2 + 10, (this.panel1.Height - 10) / 2 + 35);		//绘制文本
            }
        }
    }
}