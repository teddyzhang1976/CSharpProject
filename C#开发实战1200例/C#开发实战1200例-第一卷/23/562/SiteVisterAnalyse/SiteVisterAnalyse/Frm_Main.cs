using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SiteVisterAnalyse
{
    public partial class Frm_Main : Form
    {
        static int i = 0;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            i += 1;
        }
        private void drowPic()
        {
            Graphics g = this.CreateGraphics();							//创建Graphics对象
            g.Clear(Color.WhiteSmoke);								//设置背景色
            Pen p = new Pen(Color.Blue);								//绘制画笔
            //设置用到的字体
            Font fontO = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            Font fontT = new System.Drawing.Font("华文新魏", 16, FontStyle.Regular);
            //绘制边框与显示字体
            Point pointStart = new Point(0, 0);
            Size sizeWindows = new Size(this.Width - 8, this.Height - 34);		//创建Size对象
            Rectangle rect = new Rectangle(pointStart, sizeWindows);		//创建Rectangle对象
            g.DrawRectangle(p, rect);								//绘制矩形
            Brush brus = new SolidBrush(Color.Red);						//创建笔刷
            g.DrawString("网站人气指数曲线分析", fontT, brus, this.Width / 2.00f - 150, 10.00f);
            //绘制网格线
            int x = this.Width / 10;
            int y = this.Height / 14;
            int z = this.Width / 10;
            int k = y * 12;
            //X
            for (int i = 0; i < 12; i++)
            {
                g.DrawLine(p, x, y * 3 - 10, x, y * 12);					//绘制水平线条
                x = x + (this.Width - 34) / 14;
            }
            //X轴
            String[] n = {" 1月", " 2月", " 3月", " 4月", " 5月", " 6月", " 7月",
             " 8月", " 9月", "10月", "11月", "12月"};			//绘制月份
            x = this.Width / 10 - 16;
            for (int i = 0; i < 12; i++)
            {
                g.DrawString(n[i].ToString(), fontO, Brushes.Red, x, y * 12);	//设置文字内容及输出位置
                x = x + (this.Width - 34) / 14;
            }
            //Y
            for (int i = 0; i < 12; i++)
            {
                g.DrawLine(p, z, k, x + 10, k);							//绘制垂直线条
                k = k - (y * 12) / 16;
            }
            //Y轴
            int h = k;
            String[] m = {"5500","5000","4500", "4000", "3500", "3000", "2500", "2000", "1500", "1000",
             "  500"};									//绘制Y轴显示的文字
            k = y * 12;
            for (int i = 0; i < 11; i++)
            {
                g.DrawString(m[10 - i].ToString(), fontO, Brushes.Red, z - 35, k - y); //开始绘制文字
                k = k - (y * 12) / 16;
            }
            int[] Count = new int[12];
            Pen mypen = new Pen(Color.Red, 2);						//创建画笔
            Point[] points = new Point[12];
            x = this.Width / 10;
            k = y * 12;
            SqlConnection Con = new SqlConnection("Server=WRET-MOSY688YVW\\MRGLL;DataBase=db_TomeOne;Uid=sa;Pwd=hbyt2008!@#;");
            string cmdtxt2 = "SELECT * FROM tb_reticulation";					//声明SQL语句
            SqlCommand Com1 = new SqlCommand(cmdtxt2, Con);			//创建SqlCommand对象
            SqlDataAdapter da = new SqlDataAdapter();					//创建SqlDataAdapter对象
            da.SelectCommand = Com1;
            DataSet ds = new DataSet();								//创建DataSet对象
            da.Fill(ds);											//Fill方法填充DataSet对象
            int j = 0;
            for (j = 0; j < 12; j++)
            {
                //与Y轴数生成有关(y * 12)/16因为起始为500
                Count[j] = Convert.ToInt32(ds.Tables[0].Rows[0][j + 2].ToString()) * (y * 12) / 16 / 500;
            }
            //设置绘制曲线的坐标数组
            points[0].X = x; points[0].Y = k - Count[0];
            x = x + (this.Width - 34) / 14;
            points[1].X = x; points[1].Y = k - Count[1];
            x = x + (this.Width - 34) / 14;
            points[2].X = x; points[2].Y = k - Count[2];
            x = x + (this.Width - 34) / 14;
            points[3].X = x; points[3].Y = k - Count[3];
            x = x + (this.Width - 34) / 14;
            points[4].X = x; points[4].Y = k - Count[4];
            x = x + (this.Width - 34) / 14;
            points[5].X = x; points[5].Y = k - Count[5];
            x = x + (this.Width - 34) / 14;
            points[6].X = x; points[6].Y = k - Count[6];
            x = x + (this.Width - 34) / 14;
            points[7].X = x; points[7].Y = k - Count[7];
            x = x + (this.Width - 34) / 14;
            points[8].X = x; points[8].Y = k - Count[8];
            x = x + (this.Width - 34) / 14;
            points[9].X = x; points[9].Y = k - Count[9];
            x = x + (this.Width - 34) / 14;
            points[10].X = x; points[10].Y = k - Count[10];
            x = x + (this.Width - 34) / 14;
            points[11].X = x; points[11].Y = k - Count[11];
            g.DrawLines(mypen, points);									//绘制折线 
        }
      
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (i != 0)
                drowPic();
        }
    }
}
