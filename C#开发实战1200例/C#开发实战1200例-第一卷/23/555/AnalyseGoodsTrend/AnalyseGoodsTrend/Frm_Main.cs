using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace AnalyseGoodsTrend
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne"))
            {
                DataTable dt=new DataTable();
                SqlCommand cmd = new SqlCommand("select ShowYear from tb_Stat", Con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                this.comboBox1.DataSource = dt.DefaultView;
                this.comboBox1.DisplayMember = "ShowYear";
                this.comboBox1.ValueMember = "ShowYear";
            }
        }

        private int SumYear(int Year)
        {
            string cmdtxt2 = "SELECT SUM(Year_M1+Year_M2+Year_M3+Year_M4+Year_M5+Year_M6+Year_M7+Year_M8+Year_M9+Year_M10+Year_M11+Year_M12) AS number FROM tb_Stat WHERE ShowYear=" + Year + "";
            using (SqlConnection Con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne"))
            {
                Con.Open();
                SqlDataAdapter dap = new SqlDataAdapter(cmdtxt2, Con);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
        }

        private void CreateImage(int Year)
        {
            int height = 400, width = 600;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(width, height);
            //创建Graphics类对象
            Graphics g = Graphics.FromImage(image);

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
                Font font1 = new System.Drawing.Font("宋体", 20, FontStyle.Regular);

                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
                Brush brush1 = new SolidBrush(Color.Blue);

                g.DrawString("" + Year + " 年某商品走势", font1, brush1, new PointF(180, 30));
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 4, image.Height - 4);

                Pen mypen = new Pen(brush, 1);
                //绘制线条
                //绘制横向线条
                int x = 100;
                for (int i = 0; i < 11; i++)
                {
                    g.DrawLine(mypen, x, 80, x, 340);
                    x = x + 40;
                }
                Pen mypen1 = new Pen(Color.Blue, 2);
                g.DrawLine(mypen1, x - 480, 80, x - 480, 340);

                //绘制纵向线条
                int y = 106;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(mypen, 60, y, 540, y);
                    y = y + 26;
                }
                g.DrawLine(mypen1, 60, y, 540, y);

                //x轴
                String[] n = {"  一月", "  二月", "  三月", "  四月", "  五月", "  六月", "  七月",
                     "  八月", "  九月", "  十月", "十一月", "十二月"};
                x = 62;
                for (int i = 0; i < 12; i++)
                {
                    g.DrawString(n[i].ToString(), font, Brushes.Red, x, 348); //设置文字内容及输出位置
                    x = x + 40;
                }

                //y轴
                String[] m = {"100%", " 90%", " 80%", " 70%", " 60%", " 50%", " 40%", " 30%",
                     " 20%", " 10%", "  0%"};
                y = 85;
                for (int i = 0; i < 11; i++)
                {
                    g.DrawString(m[i].ToString(), font, Brushes.Red, 25, y); //设置文字内容及输出位置
                    y = y + 26;
                }

                int[] Count = new int[12];
                string cmdtxt2 = "SELECT * FROM tb_Stat WHERE ShowYear=" + Year + "";
                SqlConnection Con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
                Con.Open();
                SqlCommand Com = new SqlCommand(cmdtxt2, Con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = Com;
                DataSet ds = new DataSet();
                da.Fill(ds);
                int j = 0;
                int number = SumYear(Year);
                for (j = 0; j < 12; j++)
                {
                    Count[j] = Convert.ToInt32(ds.Tables[0].Rows[0][j + 1].ToString()) * 100 / number;
                }
                //显示柱状效果
                x = 70;
                for (int i = 0; i < 12; i++)
                {
                    SolidBrush mybrush = new SolidBrush(Color.Red);
                    g.FillRectangle(mybrush, x, 340 - Count[i] * 26 / 10, 20, Count[i] * 26 / 10);
                    x = x + 40;
                }
                this.panel1.BackgroundImage = image;
              
            }
            catch (Exception ey)
            {
                MessageBox.Show(ey.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Year = Convert.ToInt32(this.comboBox1.Text);
            this.CreateImage(Year);
        }
    }
}
