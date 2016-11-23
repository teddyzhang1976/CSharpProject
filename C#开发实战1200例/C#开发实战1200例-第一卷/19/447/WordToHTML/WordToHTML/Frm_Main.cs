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

namespace WordToHTML
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
        private object G_FilePath;//定义文档路径字段

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //创建打开文件对话框对象
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult =//浏览文件夹
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件夹
            {
                btn_New.Enabled = false;//停用新建按钮
                btn_Open.Enabled = false;//停用打开按钮
                G_FilePath = P_OpenFileDialog.FileName;
                ThreadPool.QueueUserWorkItem(//开始线程池
                    (pp) =>//使用Lambda表达式
                    {
                        G_wa = //创建应用程序对象
                             new Microsoft.Office.Interop.Word.Application();
                        G_wa.Visible = true;//将文档设置为可见
                        Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                           ref G_FilePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing);
                        this.Invoke(//窗体线程
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                btn_SaveAs.Enabled = true;//启用转换按钮
                            }));
                    });
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按钮
            btn_Open.Enabled = false;//停用打开按钮
            FolderBrowserDialog P_FolderBrowserDialog = //创建浏览文件夹对象
                new FolderBrowserDialog();
            DialogResult P_DialogResult = //弹出浏览文件夹对话框
                P_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判断是否确认选择文件夹
            {
                G_FilePath = string.Format(//计算文件保存路径
                    @"{0}\{1}", P_FolderBrowserDialog.SelectedPath,
                    DateTime.Now.ToString("yyyy年M月d日h时m分s秒fff毫秒") + ".doc");
                ThreadPool.QueueUserWorkItem(//开始线程池
                    (pp) =>//使用lambda表达式
                    {
                        G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                        G_wa.Visible = true;//将文档设置为可见
                        object P_obj = "Normal.dot";//定义文档模板
                        Word.Document P_wd = G_wa.Documents.Add(//向Word应用程序中添加文档
                            ref P_obj, ref G_missing, ref G_missing, ref G_missing);
                        P_wd.SaveAs(//保存Word文件
                            ref G_FilePath,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing);
                        this.Invoke(//窗体线程
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                btn_SaveAs.Enabled = true;//启用转换按钮
                            }));
                    });
            }
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            btn_SaveAs.Enabled = false;//停用转换按钮
            try
            {
                G_wa.ActiveDocument.Save();//保存文档
                ((Word._Application)G_wa.Application).Quit(//退出应用程序
                  ref G_missing, ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            SaveFileDialog P_SaveFileDialog = //创建保存文件对话框对象
                new SaveFileDialog();
            P_SaveFileDialog.Filter = "*.html|*.html";//筛选文件扩展名
            DialogResult P_DialogResult = //打开保存文件对话框
                P_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判断是否确认保存文件
            {
                object P_str_path = P_SaveFileDialog.FileName;//创建object对象
                ThreadPool.QueueUserWorkItem(//开始线程澉
                    (pp) =>//使用Lambda表达式
                    {
                        G_wa = //创建应用程序对象
                          new Microsoft.Office.Interop.Word.Application();
                        G_wa.Visible = false;
                        Word.Document P_wd = G_wa.Documents.Open(//打开Word文档
                           ref G_FilePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                           ref G_missing);
                        object P_Format = Word.WdSaveFormat.wdFormatHTML;//创建保存文档参数
                        P_wd.SaveAs(//保存Word文件
                            ref P_str_path,
                            ref P_Format, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                            ref G_missing, ref G_missing, ref G_missing);
                        ((Word._Application)G_wa.Application).Quit(//退出应用程序
                            ref G_missing, ref G_missing, ref G_missing);
                        this.Invoke(//调用窗体线程
                            (MethodInvoker)(() =>//使用lambda表达式
                            {
                                btn_Open.Enabled = true;//启用打开按钮
                                btn_New.Enabled = true;//启用新建按钮
                                MessageBox.Show(//提示已经创建Word
                                    "文件已经创建", "提示！");
                            }));
                    });
            }
        }
    }
}
