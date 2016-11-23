using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace WordPreView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        private Word.Application G_wa;//定义Word应用程序字段
        private object G_missing = //定义G_missing字段并添加引用
            System.Reflection.Missing.Value;
        private OpenFileDialog G_OpenFileDialog;//定义浏览文件夹字段

        private void btn_Open_Click(object sender, EventArgs e)
        {
            btn_Open.Enabled = false;//将打开按钮设置为不可用
            ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = //创建应用程序对象
                         new Microsoft.Office.Interop.Word.Application();
                    G_wa.Visible = true;//将文档设置为可见
                    object P_FileName = G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                        ref P_FileName, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                    P_Document.PrintPreview();//开始预览
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog = //创建打开文件对话框对象
                new OpenFileDialog();
            DialogResult P_DialogResult =//浏览文件
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件
            {
                btn_Open.Enabled = true;//启用打开按钮
                txt_path.Text = //显示选择文件
                    G_OpenFileDialog.FileName;
            }
        }
    }
}
