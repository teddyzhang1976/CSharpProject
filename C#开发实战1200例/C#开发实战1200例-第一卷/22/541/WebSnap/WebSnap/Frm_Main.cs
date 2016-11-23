using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//**************************
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Runtime.InteropServices;
//**************************
namespace WebSnap
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //********************************
        public  struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("gdi32")]
        public static extern int SelectObject(int hdc, int hObject);
        [DllImport("gdi32")]
        public static extern int CreateDC(string lpDriverName, string lpDeviceName, string lpOutput, int lpInitData);
        [DllImport("gdi32")]
        public static extern int CreateCompatibleDC(int hdc);
        [DllImport("gdi32")]
        public static extern int CreateCompatibleBitmap(int hdc, int nWidth, int nHeight);
        [DllImport("user32")]
        public static extern int GetWindow(int hwnd,int wCmd);
        [DllImport("user32")]
        public static extern int GetClassNameA(int hwnd,string lpClassName,int nMaxCount);
        [DllImport("user32")]
        private  static extern int GetWindowRect(IntPtr hwnd,ref RECT lpRect);
        [DllImport("gdi32")]
        public static extern int BitBlt(int hDestDC,int x,int y,int nWidth,int nHeight,int hSrcDC,int xSrc,int ySrc,int dwRop);
        [DllImport("user32")]
        public static extern int OpenClipboard(IntPtr hwnd);
        [DllImport("user32")]
        public static extern int EmptyClipboard();
        [DllImport("user32")]
        public static extern int SetClipboardData(int wFormat,int hMem);
        [DllImport("user32")]
        public static extern int CloseClipboard();
        int DestDC;
        int SourceDC;
        int Bhandle;
        IntPtr winpoint;
        RECT Rectangles;
        bool flag = false;
        //*******************************
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mingribook.com");
        }

        private Uri getUrl(string address)
        {
            string tempaddress = address;
            if ((!address.StartsWith("http://")) && (!address.StartsWith("https://")) && (!address.StartsWith("ftp://")))
            {
                tempaddress = "http://" + address;
            }
            Uri myurl;
            try
            {
                myurl = new Uri(tempaddress);
            }
            catch
            {
                myurl = new Uri("about:blank");
            }
            return myurl;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string strUrl = tstbURL.Text.Trim();
            webBrowser1.Navigate(getUrl(strUrl));
            tstbURL.Text =Convert.ToString(getUrl(strUrl));
            tsslStatus.Text = tstbURL.Text;
            flag = true;
        }

        private void tstbURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }

        private void inputHide()
        {
            toolStrip1.Focus();
        }
        private void Snapweb()
        {
            this.TopMost = true;
            SelectObject(DestDC, Bhandle);
            int linewidth=0;
            int lineheight=0;
            int i=0;
            int j=0;
            winpoint = webBrowser1.Handle;
            GetWindowRect(winpoint,ref Rectangles);
            webBrowser1.Document.Body.ScrollTop = 0;
            while (lineheight < webBrowser1.Document.Body.ScrollRectangle.Height - 199)
            {
                if (webBrowser1.Document.Body.ScrollTop == 0)
                {
                    inputHide();
                    BitBlt(DestDC, 0, 0, webBrowser1.Document.Body.ClientRectangle.Width, webBrowser1.Document.Body.ClientRectangle.Height, SourceDC, Rectangles.Left, Rectangles.Top, 13369376);//获取可见区域场景
                    linewidth = webBrowser1.Document.Body.ClientRectangle.Width+5; //赋值宽
                    if (linewidth < webBrowser1.Document.Body.ScrollRectangle.Width)
                    {
                        while (linewidth < webBrowser1.Document.Body.ScrollRectangle.Width - 199)
                        {
                            inputHide();
                            webBrowser1.Document.Body.ScrollLeft += 199;
                            BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, 0, 199, webBrowser1.Document.Body.ClientRectangle.Height, SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - 199, Rectangles.Top, 13369376);
                            linewidth = linewidth + 199;
                            j = j + 1;
                        }
                        if (linewidth >= webBrowser1.Document.Body.ScrollRectangle.Width - 199)
                        {
                            inputHide();
                            webBrowser1.Document.Body.ScrollLeft += 199;
                            BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, 0, webBrowser1.Document.Body.ScrollRectangle.Width - linewidth, webBrowser1.Document.Body.ClientRectangle.Height, SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - (webBrowser1.Document.Body.ScrollRectangle.Width - linewidth), Rectangles.Top, 13369376);
                            webBrowser1.Document.Body.ScrollLeft= 0;
                            j = 0;
                        }

                    }
                    lineheight = lineheight + webBrowser1.Document.Body.ClientRectangle.Height;
                }
                else
                {
                    inputHide();
                    BitBlt(DestDC, 0, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ClientRectangle.Width, 199, SourceDC, Rectangles.Left, Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - 199, 13369376);//获取可见区域场景
                    linewidth = webBrowser1.Document.Body.ClientRectangle.Width;//当前宽度
                    if (linewidth < webBrowser1.Document.Body.ScrollRectangle.Width)
                    {
                        while (linewidth < webBrowser1.Document.Body.ScrollRectangle.Width-199)
                        {
                            inputHide();
                            webBrowser1.Document.Body.ScrollLeft += 199;
                            BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ClientRectangle.Width, 199, SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - 199, Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - 199, 13369376);
                            linewidth = linewidth + 199;
                            j = j + 1;
                        }
                        if(linewidth >=webBrowser1.Document.Body.ScrollRectangle.Width-199)
                        {
                            inputHide();
                            webBrowser1.Document.Body.ScrollLeft+=199;
                            BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ScrollRectangle.Width - linewidth, 199, SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - (webBrowser1.Document.Body.ScrollRectangle.Width - linewidth), Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - 199, 13369376);
                            webBrowser1.Document.Body.ScrollLeft=0;
                            j = 0;
                        }
                    }
                    i = i + 1;//纵向计数器累计
                    lineheight = lineheight + 199;
                }
                webBrowser1.Document.Body.ScrollTop+=199;//调整纵向滚动条位置
            }
            if (lineheight >= webBrowser1.Document.Body.ScrollRectangle.Height - 199)
            {
                inputHide();
                BitBlt(DestDC, 0, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ClientRectangle.Width, (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), SourceDC, Rectangles.Left, Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), 13369376);
                linewidth = webBrowser1.Document.Body.ClientRectangle.Width;
                if(linewidth < webBrowser1.Document.Body.ScrollRectangle.Width)
                {
                    while(linewidth<webBrowser1.Document.Body.ScrollRectangle.Width-199)
                    {
                        inputHide();
                        webBrowser1.Document.Body.ScrollLeft+=199;
                        BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ClientRectangle.Width, (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - 199, Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), 13369376);
                        linewidth = linewidth + 199;
                        j = j + 1;
                    }
                    if(linewidth >=webBrowser1.Document.Body.ScrollRectangle.Width-199)
                    {
                        inputHide();
                        webBrowser1.Document.Body.ScrollLeft+=199;
                        BitBlt(DestDC, webBrowser1.Document.Body.ClientRectangle.Width + 199 * j, webBrowser1.Document.Body.ClientRectangle.Height + 199 * i, webBrowser1.Document.Body.ScrollRectangle.Width - linewidth, (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), SourceDC, Rectangles.Left + webBrowser1.Document.Body.ClientRectangle.Width - (webBrowser1.Document.Body.ScrollRectangle.Width - linewidth), Rectangles.Top + webBrowser1.Document.Body.ClientRectangle.Height - (webBrowser1.Document.Body.ScrollRectangle.Height - lineheight), 13369376);
                        webBrowser1.Document.Body.ScrollLeft=0;
                    }
                }
                i=0;
                OpenClipboard(this.Handle);
                EmptyClipboard();
                SetClipboardData(2,Bhandle);
                CloseClipboard();
                Image ig = (Image)Clipboard.GetImage();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    ig.Save(path);
                    MessageBox.Show("保存成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    webBrowser1.Document.Body.ScrollTop = 0;
                    ig.Dispose();
                }
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                Snapweb();
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            SourceDC = CreateDC("DISPLAY", "0", "0", 0);
            DestDC = CreateCompatibleDC(SourceDC);
            Bhandle = CreateCompatibleBitmap(SourceDC, webBrowser1.Document.Body.ScrollRectangle.Width, webBrowser1.Document.Body.ScrollRectangle.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
