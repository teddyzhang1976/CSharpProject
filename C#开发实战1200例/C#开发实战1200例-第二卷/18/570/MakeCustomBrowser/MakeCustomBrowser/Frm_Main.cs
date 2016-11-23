using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MakeCustomBrowser
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
      
       
        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPageSetupDialog();//显示页面设置对话框
        }

        private void 打印浏览UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();//显示打印预览对话框
        }

        private void 打印PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();//打印网页
        }

        private void 属性NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPropertiesDialog();//显示属性对话框
        }

        private void 退出IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出应用程序
        }
        
        private void 保存DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();//显示保存对话框
        }
        private void GoaButton_Click(object sender, EventArgs e)
        {
            Navigate(toolStripTextBox1.Text);//打开指定的网址
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();//上一页
        }
        private void forwardButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();//下一页
        }
       
        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (!webBrowser1.Url.Equals("about:blank"))//判断是否是空页
            {
                webBrowser1.Refresh();//重新加载网页
            }
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();//返回主页
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();//打印
        }
        private void Navigate(String address)//打开指定的网址
        {
            if (String.IsNullOrEmpty(address)) return;//如果网址为空，则返回
            if (address.Equals("about:blank")) return;//如果为空网页，则返回
            //如果输入的网址以http://开头，则记录网址
            if (!address.StartsWith("http://")) address = "http://" + address;
            try
            {
                webBrowser1.Navigate(new Uri(address));//导航到指定的网页
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();//显示指定的网页
        }
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            forwardButton.Enabled = webBrowser1.CanGoForward;//设置是否能够返回
        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果按下回车键
            {
                Navigate(toolStripTextBox1.Text);//打开指定的网页
            }
        }
    }
}