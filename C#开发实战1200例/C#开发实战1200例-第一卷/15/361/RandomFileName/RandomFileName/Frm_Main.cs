using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RandomFileName
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog =new FolderBrowserDialog();//创建文件夹对话框对象
            if (P_FolderBrowserDialog.ShowDialog()==DialogResult.OK)//判断是否选择文件夹
            {
                File.Create(P_FolderBrowserDialog.SelectedPath + "\\" +//根据GUID生成文件名
                     Guid.NewGuid().ToString()+ ".txt");
            }
        }

        private void btn_Drictory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog P_FolderBrowserDialog = new FolderBrowserDialog();//创建文件夹对话框对象
            if (P_FolderBrowserDialog.ShowDialog() == DialogResult.OK)//判断是否选择文件夹
            {
                Directory.CreateDirectory(P_FolderBrowserDialog.SelectedPath +//根据GUID生成文件夹名
                    "\\" + Guid.NewGuid().ToString());
            }
        }
    }
}
