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

namespace SQLToWord
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
        private FolderBrowserDialog G_FolderBrowserDialog;//定义浏览文件夹字段
        private object G_str_path;//定义文件保存路径字段

        private void btn_New_Click(object sender, EventArgs e)
        {
            btn_New.Enabled = false;//停用新建按钮
            ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                    object P_obj = "Normal.dot";//定义文档模板
                    Word.Document P_wd = G_wa.Documents.Add(//向Word应用程序中添加文档
                        ref P_obj, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Range(//得到文档范围
                        ref G_missing, ref G_missing);
                    string P_Server = string.Empty;//定义字符串变量用于存放服务器信息
                    string P_DataBase = string.Empty;//定义字符串变量用于存放数据库名称
                    string P_UserName = string.Empty;//定义字符串变量用于存放用户名
                    string P_PassWord = string.Empty;//定义字符串变量用于存放密码
                    this.Invoke(
                        (MethodInvoker)(() => 
                        {
                            P_Server = txt_Server.Text;//得到数据库服务器信息
                            P_DataBase = txt_DataBase.Text;//得到数据库名称
                            P_UserName = txt_UserName.Text;//得到数据库用户名
                            P_PassWord = txt_PassWord.Text;//得到数据库密码
                        }));
                    DataTier P_DataTier = new DataTier(//创建数据层对象
                        P_Server, P_DataBase, P_UserName, P_PassWord);
                    List<string> P_List_Str = P_DataTier.GetMessage();//得到数据集合
                    foreach (string P_str in P_List_Str)//遍历数据集合
                    {
                        P_Range.Text += P_str;//向文档中添加数据
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
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            MessageBox.Show(//提示已经创建Word
                                "成功创建Word文档！", "提示！");
                            btn_display.Enabled = true;//启用显示按钮
                        }));
                });
        }

        private void txt_select_Click(object sender, EventArgs e)
        {
            G_FolderBrowserDialog = //创建浏览文件夹对象
                new FolderBrowserDialog();
            DialogResult P_DialogResult =//浏览文件夹
                G_FolderBrowserDialog.ShowDialog();
            if (P_DialogResult == DialogResult.OK)//确认已经选择文件夹
            {
                btn_New.Enabled = true;//启用新建按钮
                txt_path.Text = //显示选择路径
                    G_FolderBrowserDialog.SelectedPath;
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
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
    }
}
