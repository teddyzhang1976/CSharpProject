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

namespace DrawColumn
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
            Conn();													//打开数据库连接
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con))
            {
                SqlDataReader dr = cmd.ExecuteReader();							//创建SqlDataReader对象
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);		//创建画布
                Graphics g = Graphics.FromImage(bitM);							//创建Graphics对象
                g.Clear(Color.White);										//设置画布背景
                for (int j = 0; j < 4; j++)										//开始读取数据库中的数据并绘图
                {
                    if (dr.Read())											//读取记录集
                    {
                        int x, y, w, h;										//声明变量存储坐标和大小
                        g.DrawString(dr[0].ToString(), new Font("宋体", 8, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);											//绘制文字
                        x = 78 + 40 * j;										//x坐标
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));															//y坐标
                        w = 24;											//宽
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100);//高
                        g.FillRectangle(new SolidBrush(Color.FromArgb(56, 129, 78)), x, y, w, h);//开始绘制柱形图
                    }
                }
                this.panel1.BackgroundImage = bitM;							//显示绘制的柱形图
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowPic();
        }
    }
}
