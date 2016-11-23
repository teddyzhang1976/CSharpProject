using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ModiFyTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog =//创建打开文件对话框对象
                 new OpenFileDialog();
            if (P_OpenFileDialog.ShowDialog() == DialogResult.OK)//判断是选中文件
            {
                FileInfo f = new FileInfo(P_OpenFileDialog.FileName);//创建FileInfo对象
                MessageBox.Show("文件最后一次修改时间：" +//弹出消息对话框
                    f.LastWriteTime.ToString(), "提示！");
            }
        }
    }
}
