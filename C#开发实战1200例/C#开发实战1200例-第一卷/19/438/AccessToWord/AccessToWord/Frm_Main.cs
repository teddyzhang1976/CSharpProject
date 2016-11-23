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

namespace AccessToWord
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
                    DataTier P_DataTier = new DataTier();//创建数据层对象
                    List<InstanceClass> P_List_InstanceClass //得到数据集合
                        = P_DataTier.GetMessage();
                    object o1=Word.WdDefaultTableBehavior.//设置文档中表格格式
                        wdWord8TableBehavior;
                    object o2 = Word.WdAutoFitBehavior.//设置文档中表格格式
                        wdAutoFitWindow;
                    Word.Table P_WordTable = P_Range.Tables.Add(P_Range,//在文档中添加表格
                        P_List_InstanceClass.Count + 2, 5, ref o1, ref o2);
                    P_WordTable.Cell(1, 1).Range.Text = "ID";//向表格中添加信息
                    P_WordTable.Cell(1, 2).Range.Text = "姓名";//向表格中添加信息
                    P_WordTable.Cell(1, 3).Range.Text = "语文成绩";//向表格中添加信息
                    P_WordTable.Cell(1, 4).Range.Text = "数学成绩";//向表格中添加信息
                    P_WordTable.Cell(1, 5).Range.Text = "英语成绩";//向表格中添加信息
                    for (int i = 2; i < P_List_InstanceClass.Count+2; i++)
                    {
                        P_WordTable.Cell(i, 1).Range.Text =//向表格中添加信息
                            P_List_InstanceClass[i - 2].id.ToString();
                        P_WordTable.Cell(i, 2).Range.Text =//向表格中添加信息
                            P_List_InstanceClass[i - 2].Name;
                        P_WordTable.Cell(i, 3).Range.Text =//向表格中添加信息
                            P_List_InstanceClass[i - 2].Chinese.ToString();
                        P_WordTable.Cell(i, 4).Range.Text =//向表格中添加信息
                            P_List_InstanceClass[i - 2].Math.ToString();
                        P_WordTable.Cell(i, 5).Range.Text =//向表格中添加信息
                            P_List_InstanceClass[i - 2].English.ToString();
                    }
                    float P_Chinese = 0;//定义变量用于计算数据列
                    float P_Math = 0;//定义变量用于计算数据列
                    float P_English = 0;//定义变量用于计算数据列
                    P_List_InstanceClass.
                        ForEach((Instance)=>//使用Lambda表达式
                        {
                            P_Chinese += ((InstanceClass)Instance).Chinese;//计算数据列
                            P_Math += ((InstanceClass)Instance).Math;//计算数据列
                            P_English += ((InstanceClass)Instance).English;//计算数据列
                        });
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2,//向表格中添加信息
                        1).Range.Text = "科目总成绩";
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 3).//向表格中添加信息
                        Range.Text = P_Chinese.ToString();
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 4).//向表格中添加信息
                        Range.Text = P_Math.ToString();
                    P_WordTable.Cell(P_List_InstanceClass.Count + 2, 5).//向表格中添加信息
                        Range.Text = P_English.ToString();
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
                            MessageBox.Show(//弹出消息对话框
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
