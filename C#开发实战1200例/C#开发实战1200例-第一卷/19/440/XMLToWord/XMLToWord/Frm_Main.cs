using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace XMLToWord
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
                    Word.Range P_Range = P_wd.Paragraphs[1].Range;//得到文档段落范围
                    XmlDocument P_XML = new XmlDocument();//创建XML对象
                    P_XML.Load("test.xml");//打开XML文档
                    XmlElement P_XmlElement = P_XML.DocumentElement;//得到XML根节点
                    XmlNodeList P_XmlNodeList = P_XmlElement.ChildNodes;//得到子节点集合
                    string P_Str_Message = string.Empty;//创建空字符串对象
                    foreach (XmlNode xn in P_XmlNodeList)//遍例所有子节点
                    {
                        foreach (XmlNode xn2 in xn.ChildNodes)//遍例子节点中的节点
                        {
                            P_Str_Message += xn2.InnerText+" ";//得到字符串信息
                        }
                        P_Str_Message += "\r\n";
                    }
                    P_Range.Text = P_Str_Message;//向Word中添加字符串信息
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
    }
}
