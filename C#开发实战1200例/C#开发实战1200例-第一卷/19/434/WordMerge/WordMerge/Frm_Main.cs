using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace WordMerge
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private Word.Application G_wa;//定义Word应用程序
        private object G_missing = //定义G_missing字段并添加引用
            System.Reflection.Missing.Value;
        private OpenFileDialog G_OpenFileDialog;//定义打开文件对话框
        private SaveFileDialog G_SaveFileDialog;//定义保存文件对话框
        private List<string> G_Str_Files = new List<string>();//定义字符串集合

        private void btn_split_Click(object sender, EventArgs e)
        {
            btn_Merge.Enabled = false;//停用合并按钮
            ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                    Word.Document P_MainDocument =//新建合并文档对象
                        G_wa.Documents.Add(ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing);
                    foreach (string P_Str in G_Str_Files)//遍历文档的集合
                    {
                        object P_strs = P_Str;//创建object对象
                        Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                            ref P_strs, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                            , ref G_missing, ref G_missing, ref G_missing, ref o);
                        Word.Range P_Range_temp = //得到文档全部范围
                            P_Document.Range(ref G_missing, ref G_missing);
                        P_Range_temp.Select();//选择文档全部范围
                        P_Range_temp.Copy();//复制文档全部范围
                        Word.Range P_Range_temp2 =//得到文档的范围
                            P_MainDocument.Range(ref G_missing, ref G_missing);
                        object P_end= Word.WdCollapseDirection.wdCollapseEnd;//创建object对象
                        P_Range_temp2.Collapse(ref P_end);//折叠文档范围
                        P_Range_temp2.Select();//选择档的最后位置
                        P_Range_temp2.Paste();//粘贴文档内容
                        ((Word._Document)P_Document).Close(ref G_missing, ref G_missing,//关闭文档
                            ref G_missing);
                    }
                    object P_SavePath=G_SaveFileDialog.FileName;//创建object对象
                    P_MainDocument.SaveAs(//保存合并后的文档
                        ref P_SavePath, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            Clipboard.Clear();//清空剪切板
                            MessageBox.Show(//提示已经创建Word
                                "成功合并Word文档！", "提示！");
                            btn_Merge.Enabled = true;//启用合并按钮
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
                lb_FileCollection.Items.Add(G_OpenFileDialog.FileName);
                G_Str_Files.Add(G_OpenFileDialog.FileName);
                btn_Save.Enabled = true;
                txt_path.Text = //显示将要打开的文件
                    G_OpenFileDialog.FileName;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            G_SaveFileDialog = //创建保存文件对话框对象
                new SaveFileDialog();
            G_SaveFileDialog.Filter = "*.doc|*.doc";
            DialogResult P_DialogResult = //打开保存文件对话框
                G_SaveFileDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//判断是否保存文件
            {
                btn_Merge.Enabled = true;//启用合并按钮
                txt_SavePath.Text = //显示保存文件路径
                    G_SaveFileDialog.FileName;
            }
        }
    }
}
