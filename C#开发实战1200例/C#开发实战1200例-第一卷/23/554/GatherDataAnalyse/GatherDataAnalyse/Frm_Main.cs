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
namespace GatherDataAnalyse
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPic();
        }
        private void Conn()
        {
            con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
            con.Open();
        }
        private void ShowPic()
        {
            Conn();														//打开数据库连接
            using (cmd = new SqlCommand("SELECT TOP 3 * FROM tb_Rectangle order by t_Num desc", con)) ;//实例化SqlCommand对象
            {
                SqlDataReader dr = cmd.ExecuteReader();								//创建SqlDataReader对象
                Bitmap bitM = new Bitmap(this.panel1.Width, this.panel1.Height);			//实例化一个新画布
                Graphics g = Graphics.FromImage(bitM);								//创建Graphics对象
                g.Clear(Color.White);											//设置画布背景
                for (int i = 0; i < 5; i++)
                {
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 2.0f), 50, this.panel1.Height - 20 - i * 20, this.panel1.Width - 40, this.panel1.Height - 20 - i * 20);												//绘制水平直线
                    g.DrawString(Convert.ToString(i * 100), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 20, this.panel1.Height - 27 - i * 20);							//绘制文字
                }
                for (int j = 0; j < 4; j++)
                {
                    //绘制垂直直线
                    g.DrawLine(new Pen(new SolidBrush(Color.Red), 1.0f), 50 + 40 * j, this.panel1.Height - 20, 50 + 40 * j, 20);
                    if (dr.Read())
                    {
                        int x, y, w, h;											//声明变量存储坐标和宽高
                        g.DrawString(dr[0].ToString(), new Font("宋体", 8, FontStyle.Regular), new SolidBrush(Color.Black), 76 + 40 * j, this.panel1.Height - 16);													//绘制说明文字
                        x = 78 + 40 * j;											//X轴
                        y = this.panel1.Height - 20 - Convert.ToInt32((Convert.ToDouble(Convert.ToDouble(dr[1].ToString()) * 20 / 100)));																//Y轴
                        w = 24;												//宽
                        h = Convert.ToInt32(Convert.ToDouble(dr[1].ToString()) * 20 / 100); 	//高
                        g.FillRectangle(new SolidBrush(Color.FromArgb(56, 129, 78)), x, y, w, h);	//绘制柱形图
                    }
                }
                this.panel1.BackgroundImage = bitM; //将画布设为panel1控件的背景图
            }
        }
    }
}
