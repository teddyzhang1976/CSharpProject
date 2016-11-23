using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace ColumnByControl
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("server=WRET-MOSY688YVW\\MRGLL;UID=sa;Pwd=hbyt2008!@#;database=db_TomeOne"))	//实例化一个SqlConnection对象
            {
                int XValse = 20;
                DataSet ds = new DataSet();									//创建DataSet对象
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand("select * from tb_Rectangle select Sum(t_Num) from tb_Rectangle", con);
                SqlDataAdapter da = new SqlDataAdapter();						//创建SqlDataAdapter对象
                da.SelectCommand = cmd;
                da.Fill(ds);												//Fill方法填充DataSet
                Panel[] p = new Panel[ds.Tables[0].Rows.Count];					//实例化一个Panel数组
                int Values = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());			//商品总数
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i][0].ToString();
                    float f = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());		//获取每个商品的数量
                    Size s = new Size();										//创建Size对象
                    s.Width = 30;											//设置柱形图宽度
                    s.Height = Convert.ToInt32(f / Values * 200);					//计算柱形图高度
                    Point pint = new Point();									//创建Point对象
                    pint.X = XValse;										//x坐标
                    pint.Y = this.Height - 50 - s.Height;							//y坐标
                    p[i] = new Panel();										//实例化一个Panel对象
                    p[i].Location = pint;										//设置位置
                    p[i].BackColor = Color.Red;								//设置背景颜色
                    p[i].Size = s;											//设置大小
                    XValse += 40;											//设置Xvalse变量的值
                    Label lbl = new Label();									//创建Label对象
                    lbl.Text = ds.Tables[0].Rows[i][0].ToString();					//设置Label显示的文本
                    lbl.Font = new Font("宋体", 9, FontStyle.Regular);				//设置Label的Font属性
                    lbl.ForeColor = Color.White;								//设置Label的ForeColor属性
                    p[i].Controls.Add(lbl);									//添加控件
                    this.Controls.Add(p[i]);									//将控件数组添加到当前容器中
                }
            }
        }
    }
}
