using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintStuCertificate
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        //窗体获得焦点时显示打印按钮
        private void frmPrint_Activated(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            labName.Text = Frm_Main.strName;
            labSex.Text = Frm_Main.strSex;
            labNPlace.Text = Frm_Main.strNPlace;
            labBirthday.Text = Convert.ToDateTime(Frm_Main.strBirthday).ToShortDateString();
            labNation.Text = Frm_Main.strNation;
            labSGao.Text = Frm_Main.strSGao;
            labTZhong.Text = Frm_Main.strTZhong;
            labHunYin.Text = Frm_Main.strHunYin;
            labXUELI.Text = Frm_Main.strXUELLI;
            labAddress.Text = Frm_Main.strAddress;
            labZY.Text = Frm_Main.strZHUANYE;
            labYX.Text = Frm_Main.strBYYX;
            labBYSJ.Text = Convert.ToDateTime(Frm_Main.strBYSJ).ToShortDateString();
            labWY.Text = Frm_Main.strWAIYU;
            labTel.Text = Frm_Main.strTel;
            labEmail.Text = Frm_Main.strEmail;
            labZW.Text = Frm_Main.strYPZW;
            labQZLX.Text = Frm_Main.strQZLX;
            labPlace.Text = Frm_Main.strGZDQ;
            labSalary.Text = Frm_Main.strSalary;
            labYear.Text = Frm_Main.strGZNX;
            labGZJL.Text = Frm_Main.strGZJL;
            labTC.Text = Frm_Main.strTECHANG;
            pictureBox1.Image = Frm_Main.imgPhoto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            CaptureScreen();
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,
            int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics mygraphics = panel1.CreateGraphics();//创建绘图对象
            Size s = panel1.Size;//得到面板宽度和高度
            memoryImage = new Bitmap(s.Width, s.Height,//创建Bitmap对象
                mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(//创建新的绘图对象
                memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();//得到绘图上下文
            IntPtr dc2 = memoryGraphics.GetHdc();//得到绘图上下文
            BitBlt(dc2, 0, 0, panel1.ClientRectangle.Width,//得到Panel面板中的图像
                panel1.ClientRectangle.Height, dc1, 0, 0,
                13369376);
            mygraphics.ReleaseHdc(dc1);//释放上下文
            memoryGraphics.ReleaseHdc(dc2);//释放上下文
        }
    }
}
