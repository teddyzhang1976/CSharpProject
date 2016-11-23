using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace AddLetter
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Word.Application G_wa;//定义Word应用程序字段
        private object G_missing = //定义missing字段并赋值
            System.Reflection.Missing.Value;
        private object G_str_path;//定义文件保存路径字段
        private FolderBrowserDialog G_FolderBrowserDialog;//定义文件夹浏览对话框字段

        private void btn_Select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog =//创建浏览文件夹对象
              new FolderBrowserDialog();
            DialogResult P_DialogResult = //浏览文件夹
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件夹
            {
                btn_New.Enabled = true;//启用新建按钮
                txt_path.Text = //显示选择路径
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按钮
            ThreadPool.QueueUserWorkItem(//使用线程池
                (P_temp) =>//使用lambda表达式
                {
                    G_wa = new Word.Application();//创建Word应用程序对象
                    Word.Document P_wd = G_wa.Documents.Add(//建立新文档
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;
                    P_Range.Text = txt_add.Text;
                    G_str_path = string.Format(//计算文件保存路径
                        @"{0}\{1}", G_FolderBrowserDialog.SelectedPath,
                        DateTime.Now.ToString("yyyy年M月d日h时s分m秒fff毫秒") + ".doc");
                    P_wd.SaveAs(//保存Word文件
                        ref G_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//开始执行窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            btn_Display.Enabled = true;//启用显示按钮
                            MessageBox.Show("成功创建Word文档！", "提示！");
                        }));
                });
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            G_wa = //创建应用程序对象
                 new Microsoft.Office.Interop.Word.Application();
            G_wa.Visible = true;//将文档设置为可见
            Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                ref G_str_path, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                ref G_missing);
        }

        private void txt_add_TextChanged(object sender, EventArgs e)
        {
            if (txt_add.Text != string.Empty)//判断文本框是否为空
            {
                btn_Select.Enabled = true;//启用浏览按钮
            }
        }
    }
}
