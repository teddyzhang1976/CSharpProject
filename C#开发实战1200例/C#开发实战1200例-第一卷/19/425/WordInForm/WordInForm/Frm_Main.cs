using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace WordInForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_GetFile = new OpenFileDialog();//创建打开文件对话框对象
            DialogResult P_dr = P_GetFile.ShowDialog();//显示打开文件对话框
            if (P_dr == DialogResult.OK)//是否点击确定
            {
                WebBrowser.Navigate(P_GetFile.FileName);//打开Word文档并显示
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
