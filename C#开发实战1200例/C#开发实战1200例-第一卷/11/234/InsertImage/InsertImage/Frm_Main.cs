using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_InsertImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //创建打开文件对话框对象
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";
            DialogResult P_DialogResult = //弹出打开文件对话框
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult==DialogResult.OK)//判断是否选中文件
            {
                Clipboard.SetDataObject(//将图像放入剪切板
                    Image.FromFile(P_OpenFileDialog.FileName), false);
                if (rtbox_Display.CanPaste(//判断剪切板内是否是图像
                    DataFormats.GetFormat(DataFormats.Bitmap)))
                {
                    rtbox_Display.Paste();//粘贴剪切板的内容到控件中
                }
            }
        }
    }
}
