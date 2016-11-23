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

namespace Multi_TxtToWord
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
        private OpenFileDialog G_OpenFileDialog;//定义文件对话框字段
        private List<string> G_List_FileName = new List<string>();//定义字符串集合并创建实例

        private void btn_Select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog =//创建浏览文件夹对象
              new FolderBrowserDialog();
            DialogResult P_DialogResult = //浏览文件夹
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件夹
            {
                btn_New.Enabled = true;//启用创建按钮
                txt_path.Text = //显示选择路径
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用创建按钮
            ThreadPool.QueueUserWorkItem(//使用线程池
                (P_temp) =>//使用lambda表达式
                {
                    G_wa = new Word.Application();//创建Word应用程序对象
                    Word.Document P_wd = G_wa.Documents.Add(//建立新文档
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;//得到文档段落范围
                    foreach (string s in G_List_FileName)//遍历文件集合
                    {
                        using (StreamReader P_StreamReader =//创建文件读取器对象
                             new StreamReader(s, Encoding.Default))
                        {
                            P_Range.Text += //将文本文件中的数据读到Word文档中
                                P_StreamReader.ReadToEnd();
                        }
                    }
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
                            MessageBox.Show("成功创建Word文档！", "提示！");//弹出消息对话框
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

        private void btn_txt_Click(object sender, EventArgs e)
        {
            G_OpenFileDialog = new OpenFileDialog();//创建文件对话框对象
            G_OpenFileDialog.Filter = "*.txt|*.txt";//筛选文件
            DialogResult P_DialogResult = //显示文件对话框
                G_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件
            {
                lb_FileName.Items.Add(G_OpenFileDialog.FileName);//将文件路径添加到文件列表
                G_List_FileName.Add(G_OpenFileDialog.FileName);//将文件路径添加到字符串集合
                txt_TxtPath.Text = //显示打开文件路径
                    G_OpenFileDialog.FileName;
                btn_Select.Enabled = true;//启用浏览按钮
            }
        }
    }
}
