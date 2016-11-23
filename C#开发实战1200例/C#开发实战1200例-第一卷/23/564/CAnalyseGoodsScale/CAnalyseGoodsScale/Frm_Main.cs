using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;
namespace CAnalyseGoodsScale
{
    public partial class Frm_Main : Form
    {
        static int SumNum;
        static float TimeNum;
        SqlConnection con;
        SqlCommand cmd;
        Hashtable ht = new Hashtable();
        public Frm_Main()
        {
            InitializeComponent();
        }
        private void Conn()
        {
            con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne");
            con.Open();
        }

        private void showPic(float f, Brush B)
        {
            Graphics g = this.panel1.CreateGraphics();					//通过panel1控件创建一个Graphics对象
            if (TimeNum == 0.0f)
            {
                g.FillPie(B, 0, 0, this.panel1.Width, this.panel1.Height, 0, f * 360);//绘制扇形
            }
            else
            {
                g.FillPie(B, 0, 0, this.panel1.Width, this.panel1.Height, TimeNum, f * 360);
            }
            TimeNum += f * 360;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)			//在Paint事件中绘制窗体
        {
            ht.Clear();
            Conn();											//连接数据库
            Random rnd = new Random();								//生成随机数
            using (cmd = new SqlCommand("select t_Name,sum(t_Num) as Num  from tb_product group by t_Name", con))
            {
                Graphics g2 = this.panel2.CreateGraphics();				//通过panel2控件创建一个Graphics对象
                SqlDataReader dr = cmd.ExecuteReader();					//创建SqlDataReader对象
                while (dr.Read())									//读取数据
                {
                    ht.Add(dr[0], Convert.ToInt32(dr[1]));					//将数据添加到Hashtable中
                }
                float[] flo = new float[ht.Count];
                int T = 0;
                foreach (DictionaryEntry de in ht)						//遍历Hashtable
                {
                    flo[T] = Convert.ToSingle((Convert.ToDouble(de.Value) / SumNum).ToString().Substring(0, 6));
                    Brush Bru = new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    //绘制商品及百分比
                    g2.DrawString(de.Key + "  " + flo[T] * 100 + "%", new Font("Arial", 8, FontStyle.Regular), Bru, 7, 5 + T * 18);
                    showPic(flo[T], Bru);							//调用showPic方法绘制饼型图
                    T++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conn();
            using (cmd = new SqlCommand("select Sum(t_Num)  from tb_product", con))
            {
               SumNum=Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
