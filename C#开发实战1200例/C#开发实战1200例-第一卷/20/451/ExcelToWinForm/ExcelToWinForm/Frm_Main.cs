using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelToWinForm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 打开Excel文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter="Excel文件|*.xls";//设置打开文件筛选器
            OpenFileDialog.Title = "打开Excel文件";//设置打开对话框标题
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                WBrowser_Excel.Navigate(OpenFileDialog.FileName);//在窗体中显示Excel文件内容
            }
        }
    }
}
