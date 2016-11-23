using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace GetCount
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

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_Get.Enabled = false;//停用统计按钮
            ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                    object P_OpenFileDialog = //创建object对象
                        G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                        ref P_OpenFileDialog, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    int P_count = 0;//定义计数器并初始化为0
                    foreach (Word.Paragraph paragraph in P_Document.Paragraphs)
                    {
                        Word.Range P_Range_temp = paragraph.Range;//得到段落文本范围
                        foreach (char P_chr in P_Range_temp.Text)//遍历每一个字符
                        {
                            P_count = //计数器开始计数
                                P_chr.ToString() != "\r" ?
                                rbtn_Blank.Checked ? ++P_count :
                                P_chr.ToString() != " " ? ++P_count :
                                P_count : P_count;
                        }
                    }
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            MessageBox.Show(//提示已经创建Word
                                string.Format("{0}共{1}个字符",
                                rbtn_Blank.Checked ? "记空格" : "不记空格",
                                P_count.ToString()), "提示！");
                            btn_Get.Enabled = true;//启用统计按扭
                        }));
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog//创建文件对话框对象
                = new OpenFileDialog();
            G_OpenFileDialog.Filter = //筛选文件
                "*.doc|*.doc";
            DialogResult P_DialogResult =//打开文件对话框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件
            {
                btn_Get.Enabled = true;//启用统计字符按钮
                btn_display.Enabled = true;//启用显示文档按钮
                txt_path.Text = //显示将要打开的文件
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                (P_P) =>
                {
                    G_wa = //创建应用程序对象
                       new Microsoft.Office.Interop.Word.Application();
                    G_wa.Visible = true;//将文档设置为可见
                    object P_str_filename = G_OpenFileDialog.FileName;
                    Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                        ref P_str_filename, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                });
        }
    }
}
