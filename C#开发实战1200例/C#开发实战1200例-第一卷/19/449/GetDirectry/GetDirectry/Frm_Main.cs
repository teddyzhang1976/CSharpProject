using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace GetDirectry
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
        private object G_FilePath = string.Empty;//定义文档路径并赋值
        private SaveFileDialog G_SaveFileDialog;//定义打开文件对话框字段



        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog P_OpenFileDialog = //创建打开文件对话框对象
                new OpenFileDialog();
            P_OpenFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult =//浏览文件夹
                P_OpenFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件夹
            {
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
                                btn_Path.Enabled = true;//启用浏览按钮
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
                    Word.Document P_document = G_wa.Documents.Add(//添加新的Word文档
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    object P_start = 0;//定义范围的开始位置
                    object p_end = 0;//定义范围的结束位置
                    Word.Range rg = //得到文档的范围
                        P_wd.Range(ref P_start, ref p_end);
                    WordToWord(P_wd, P_document, rg);//将目录提取到新文档中
                    object P_str_path = G_SaveFileDialog.FileName;//设置保存的文件名称
                    P_document.SaveAs(//保存Word文件
                        ref P_str_path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    object P_Save = false;//设置参数为不保存
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref P_Save, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            btn_Open.Enabled = true;//启用打开按钮
                            Clipboard.Clear();//清空剪切板信息
                            MessageBox.Show(//提示已经创建Word
                                "目录已经提取完成！", "提示！");
                        }));
                });
        }

        /// <summary>
        /// 将目录提取到新文档中
        /// </summary>
        /// <param name="P_wd">将要提取目录的文档</param>
        /// <param name="P_document">新建文档</param>
        /// <param name="rg">文档范围</param>
        private void WordToWord(Word.Document P_wd, Word.Document P_document, Word.Range rg)
        {
            object P_start = System.Reflection.Missing.Value;
            object p_end = System.Reflection.Missing.Value;
            object P_UseHeadingStyles = true;//是否使用内置样式创建目录
            object P_UpperHeadingLevel = 1;//目录起始的标题级别
            object P_LowerHeadingLevel = 9;//目录结束的标题级别
            object P_UseFields = false;//是否使用TC(目录项)创建目录
            object P_TableID = 1;//单字母标识符，用于根据TC域创建目录
            object P_RightAlignPageNumbers = false;//目录是否右边距对齐
            object P_IncludePageNumbers = false;//目录中是否包含页码
            object P_AddedStyles = null;//目录其它样式的字符串名称
            object P_UseHyperlinks = false;//是否将文档发布到WEB
            object P_HidePageNumbersInWeb = false;//目录中的页码是否被隐藏
            P_wd.TablesOfContents.Add(rg, ref P_UseHeadingStyles,//将提取的目录插入到文档的开始位置
                ref P_UpperHeadingLevel, ref P_LowerHeadingLevel,
                ref P_UseFields, ref P_TableID, ref P_RightAlignPageNumbers,
                ref P_IncludePageNumbers, ref P_AddedStyles, ref P_UseHyperlinks,
                ref P_HidePageNumbersInWeb, ref G_missing);
            if (P_wd.Fields.Count >= 1)
            {
                P_wd.Paragraphs[1].Range.Cut();//剪切文档开始位置的目录信息
                P_document.Range(ref P_start, ref p_end).Paste();//将目录信息粘贴到新文档
            }
        }

        private void btn_Path_Click(object sender, EventArgs e)
        {
            G_SaveFileDialog = new SaveFileDialog();//创建保存文件对话框对象 
            G_SaveFileDialog.Filter = "*.doc|*.doc";//筛选文件
            DialogResult P_DialogResult = //打开保存文件对话框
                G_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判断是否保存文件
            {
                btn_SaveAs.Enabled = true;//启用保存按钮
                txt_Path.Text = G_SaveFileDialog.FileName;//显示保存文件位置
            }
        }
    }
}
