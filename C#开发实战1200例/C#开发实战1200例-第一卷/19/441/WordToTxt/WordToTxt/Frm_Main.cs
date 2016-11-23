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
using System.IO;

namespace WordToTxt
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
        private OpenFileDialog G_OpenFileDialog;//定义打开文件对话框字段
        private FolderBrowserDialog G_FolderBrowserDailog;//定义浏览文件夹对话框字段

        private void btn_Get_Click(object sender, EventArgs e)
        {
            btn_Get.Enabled = false;//启用创建按钮
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
                    Word.Range P_Range = P_Document.Range(
                        ref G_missing, ref G_missing);
                    string P_Str = P_Range.Text;
                    string G_str_path = string.Format(//计算文件保存路径
                     @"{0}\{1}", G_FolderBrowserDailog.SelectedPath,
                     DateTime.Now.ToString("yyyy年M月d日h时m分s秒fff毫秒") + ".txt");
                    using (StreamWriter P_StreamWrite = new StreamWriter(//创建StreamWriter对象
                        G_str_path, true))
                    {
                        P_StreamWrite.Write(P_Str);//向文件中写入字符串
                        P_StreamWrite.Flush();//将信息写入基础流
                    }
                    ((Word._Document)P_Document).Close(ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            Clipboard.Clear();//清空剪切板
                            MessageBox.Show(//提示已经创建Word
                                "成功创建文本文件！", "提示！");
                            btn_Get.Enabled = true;//停用创建按钮
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
                btn_Save.Enabled = true;
                txt_path.Text = //显示将要打开的文件
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDailog = //创建浏览文件夹对象
                new FolderBrowserDialog();
            DialogResult P_DialogResult = //打开浏览文件夹对话框
                G_FolderBrowserDailog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判断是否选择文件夹
            {
                btn_Get.Enabled = true;//启用分割按钮
                txt_SavePath.Text = //显示选择路径
                    G_FolderBrowserDailog.SelectedPath;
            }
        }
    }
}
