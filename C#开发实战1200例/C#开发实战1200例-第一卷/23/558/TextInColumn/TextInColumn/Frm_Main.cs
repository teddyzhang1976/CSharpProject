using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Data.SqlClient;
namespace TextInColumn
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Conn()
        {
            con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
            con.Open();
        }
        private void ShowPic()
        {
            Conn();												//打开数据库
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();						//创建SqlDataReader对象
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);	//创建画布
                Graphics g = Graphics.FromImage(bitM);						//创建Graphics对象
                Pen p = new Pen(new SolidBrush(Color.SlateGray), 1.0f);			//创建Pen对象
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;		//设置虚线
                g.Clear(Color.White);									//设置画布颜色
                for (int i = 0; i < 5; i++)
                {
                    //绘制水平线条
                    g.DrawLine(p, 50, this.panel1.Height - 20 - i * 20, this.panel1.Width - 40, this.panel1.Height - 20 - i * 20);
                    g.DrawString(Convert.ToString(i * 100), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 20, this.panel1.Height - 27 - i * 20);					//绘制商品的增长值
                }
                for (int j = 0; j < 4; j++)
                {
                    g.DrawLine(p, 50, this.panel1.Height - 20, 50, 20);			//绘制垂直线条
                    if (dr.Read())
                    {
                        int x, y, w, h;									//声明变量存储坐标和大小
                        g.DrawString(dr[0].ToString(), new Font("宋体", 9, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);										//绘制商品名称
                        x = 78 + 40 * j;									//X坐标
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));														//Y坐标
                        w = 24;										//宽度
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100);//高度
                        g.FillRectangle(new SolidBrush(Color.SlateGray), x, y, w, h);	//绘制柱形图
                        g.DrawString((h * 100 / 20).ToString(), new Font("宋体", 8, FontStyle.Bold), new SolidBrush(Color.Tomato), new Point(x + 4, y - 10));												//在柱形图指定的位置绘制文字
                    }
                }
                this.panel1.BackgroundImage = bitM;						//显示绘制的图形
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowPic();
        }
    }
}
