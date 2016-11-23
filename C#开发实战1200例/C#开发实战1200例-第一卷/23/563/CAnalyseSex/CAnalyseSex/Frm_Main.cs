using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
namespace CAnalyseSex
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Conn()
        {
            con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
            con.Open();
        }


        private void ShowPic(string SexCode, float f)
        {
            Graphics g = this.panel1.CreateGraphics();					//通过panel1控件创建一个Graphics对象
            Pen p = new Pen(new SolidBrush(Color.Blue));					//创建画笔
            Point p1 = new Point(0, 0);								//创建Point对象
            Size s = new Size(this.panel1.Width, this.panel1.Height);			//创建Size对象
            Rectangle trct = new Rectangle(p1, s);						//创建Rectangle对象
            g.FillEllipse(new SolidBrush(Color.Red), trct);					//绘制椭圆
            g.FillPie(new SolidBrush(Color.Blue), trct, 180, f * 360);			//绘制扇形
            Graphics ginfo = this.panel2.CreateGraphics();					//通过panel2控件创建一个Graphics对象
            Font font = new Font("宋体", 10, FontStyle.Regular);			//设置字体
            //绘制性别
            ginfo.DrawString(SexCode + " " + f.ToString().Substring(0, 4), font, new SolidBrush(Color.Blue), 0, 5);
            ginfo.DrawString("女" + " " + (1.0 - Convert.ToDouble(f.ToString().Substring(0, 4))).ToString().Substring(0, 4), font, new SolidBrush(Color.Red), 0, 25);										//绘制比例
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Conn();
            using (cmd = new SqlCommand("SELECT sex,COUNT(sex) num FROM tb_sex group by sex", con))
               {
                   SqlDataReader dr=cmd.ExecuteReader();
                   string[] str = new string[2];
                   int i=0;
                   while (dr.Read())
                   {
                       str[i] = dr[0].ToString() + "," + dr[1].ToString();
                       i++;
                   }
                   float N = Convert.ToInt16(str[0].Substring(2)) + Convert.ToInt16(str[1].Substring(2));
                   float f =  Convert.ToInt16(str[0].Substring(2))/N;
                   ShowPic(str[0].Substring(0,1), f);
               }
        }
    }
}
