using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog = new FolderBrowserDialog();//创建浏览文件夹对话框对象
            if (P_FolderBrowserDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                File.Create(P_FolderBrowserDialog.SelectedPath + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt");//创建文件
            }
        }
    }
}
