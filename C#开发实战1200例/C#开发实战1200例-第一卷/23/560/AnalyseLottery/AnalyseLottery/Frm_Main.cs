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

namespace AnalyseLottery
{
    public partial class Frm_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Conn()
        {
            con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
            con.Open();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select * from tb_lottery where t_year between '" + Convert.ToDateTime(this.dateTimePicker1.Text).ToShortDateString() + "' and '" + Convert.ToDateTime(this.dateTimePicker2.Text).ToShortDateString() + "' order by t_year";
            DrowInfo(str);

        }

        private void DrowInfo(string SQL)
        {
            try
            {
                System.Drawing.Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);	//定义画布
                Graphics g = Graphics.FromImage(bmp);								//创建Graphics对象
                g.Clear(Color.White);											//设置画布背景颜色
                Brush bru = new SolidBrush(Color.Blue);								//创建Brush对象
                Pen p = new Pen(bru);											//定义画笔
                Font font = new Font("Arial", 9, FontStyle.Bold);						//定义字体
                Conn();													//连接数据库
                cmd = new SqlCommand(SQL, con);								//实例化SqlCommand
                SqlDataReader dr = cmd.ExecuteReader();								//创建SqlDataReader对象
                int i = 0;
                Pen pLine = new Pen(Color.Orange, 4.0f);									//定义画笔
                string str = null;
                float f = 0.0f;
                while (dr.Read())													//开始读取数据库中的数据
                {
                    i++;
                    g.DrawString(dr[0].ToString().Substring(0, 7) + "月---", font, bru, 10, 15.0f * i);		//绘制月份
                    g.DrawString(dr[1].ToString(), font, bru, this.panel1.Width - 50, 15.0f * i);			//绘制每个月份的中奖情况
                    str += dr[1].ToString() + "#";
                    f += Convert.ToSingle(dr[1].ToString());
                }
                dr.Close();														//关闭SqlDataReader对象
                this.panel1.BackgroundImage = bmp;									//显示绘制的图像
                Bitmap bmpP = new Bitmap(this.panel3.Width, this.panel3.Height);				//定义画布
                Graphics gP = Graphics.FromImage(bmpP);								//创建Graphics对象
                gP.Clear(Color.White);												//设置背景颜色
                Brush bruImg = new SolidBrush(Color.Orange);								//定义笔刷
                Pen Pg = new Pen(bruImg, 1.0f);										//定义画笔
                string[] strCount = str.Split('#');
                int[] ICount = new int[strCount.Length];
                for (int l = 0; l < strCount.Length - 1; l++)
                {
                    ICount[l] = Convert.ToInt32(strCount[l]);
                }
                Point[] P = new Point[ICount.Length - 1];									//用于存储直线的坐标
                for (int j = 0; j < ICount.Length - 1; j++)
                {
                    P[j].X = 35 + 28 * j;												//设置X坐标
                    P[j].Y = this.panel3.Height - 20 - Convert.ToInt32(ICount[j] / f * (this.panel3.Height + 20));//设置Y坐标
                }
                f = 0.0f;
                str = null;
                gP.DrawLines(new Pen(new SolidBrush(Color.Red)), P);						//绘制走势图
                gP.DrawString("分析结果走势图", new Font("宋体", 16), bru, this.panel3.Width / 2 - 80, 10);	//绘制标题
                this.panel3.BackgroundImage = bmpP;									//显示绘制的图像
            }
            catch
            {
                MessageBox.Show("此范围内没有任何信息！！！");
                return;
            }
        }
    }
}
