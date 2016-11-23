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

namespace WordToMulti_Txt
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

        private void btn_split_Click(object sender, EventArgs e)
        {
            btn_split.Enabled = false;//停用分解按钮
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
                    bool P_bl = false; ;
                    this.Invoke(//调用窗体线程
                         (MethodInvoker)(() =>//使用lambda表达式
                         {
                             P_bl = cbox_Select.SelectedIndex == 0;
                         }));
                    if (P_bl)//判断使用什么方式分割文档
                    {
                        foreach (Word.Paragraph Paragraph in G_wa.ActiveDocument.Paragraphs)
                        {
                            AddFile(Paragraph.Range.Text);//将文本内容写入文本文件
                        }
                    }
                    else
                    {
                        Word.Range P_Range = G_wa.ActiveDocument.Content;//得到文档区域
                        int P_int_count = P_Range.Text.Length;//得到文档字符总长度
                        int P_int_i = P_int_count / 100;//计算循环建立文档次数
                        if (P_int_i > 0)//如果文档内文字大于100个
                        {
                            for (int i = 0; i < P_int_i; i++)//开始循环创建文档
                            {
                                object P_o1 = i == 0 ? 0 : i * 100 + 1;//复制文档范围的开始部份
                                object P_o2 = i * 100 + 101;//复制文档范围的结尾部份
                                Word.Range P_Range_temp = //得到文档的范围
                                    G_wa.ActiveDocument.Range(ref P_o1, ref P_o2);
                                AddFile(P_Range_temp.Text);//将文本内容写入文本文件
                            }
                            object P_o11 = P_int_i * 100 + 1;//复制文档范围的开始部份
                            Word.Range P_Range_temp1 = //得到文档的范围
                                G_wa.ActiveDocument.Range(ref P_o11, ref G_missing);
                            AddFile(P_Range_temp1.Text);//将文本内容写入文本文件
                        }
                        else
                        {
                            Word.Range P_Range2 = //得到文档区域
                                G_wa.ActiveDocument.Content;
                            AddFile(P_Range2.Text);//将文本内容写入文本文件
                        }
                    }
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            Clipboard.Clear();//清空剪切板
                            MessageBox.Show(//弹出消息对话框
                                "成功分解Word文档！", "提示！");
                            btn_split.Enabled = true;//启用分解按钮
                        }));
                });
        }

        /// <summary>
        /// 创建文本文件方法
        /// </summary>
        private void AddFile(string text)
        {
            string G_str_path = string.Format(//计算文件保存路径
                     @"{0}\{1}", G_FolderBrowserDailog.SelectedPath,
                     DateTime.Now.ToString("yyyy年M月d日h时m分s秒fff毫秒") + ".txt");
            using (StreamWriter P_StreamWriter =
                 new StreamWriter(G_str_path, true))
            {
                P_StreamWriter.Write(text);
                P_StreamWriter.Flush();
            }
            Thread.Sleep(5);
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
                btn_split.Enabled = true;//启用分割按钮
                txt_SavePath.Text = //显示选择路径
                    G_FolderBrowserDailog.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_Select.SelectedIndex = 0;//设置默认选择第一项
        }
    }
}
