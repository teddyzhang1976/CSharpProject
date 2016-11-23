using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CreateAndRemoveFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            SaveFileDialog P_SaveFileDialog = new SaveFileDialog();//创建保存文件对话框对象
            if (P_SaveFileDialog.ShowDialog() == DialogResult.OK)//判断是否确定保存文件
            {
                File.Create(P_SaveFileDialog.FileName);//创建文件
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = new OpenFileDialog();//创建打开文件对话框对象
            if (P_OpenFileDialog.ShowDialog() == DialogResult.OK)//判断是否确定删除文件
            {
                File.Delete(P_OpenFileDialog.FileName);//删除文件
            }
        }
    }
}
