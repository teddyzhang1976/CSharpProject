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

namespace WordToAccess
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

        private void btn_display_Click(object sender, EventArgs e)
        {
            btn_display.Enabled = false;
            ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                    G_wa.Visible = true;
                    object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
                    Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                        ref P_Path, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                        , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//窗体线程执行
                        (MethodInvoker)(() =>//使用Lambda表达式
                    {
                        //btn_display.Enabled = true;//启用显示文档按钮
                        btn_Write.Enabled = true;//启用插入数据按钮
                    }));
                });
        }

        private void btn_DisplayData_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = //绑定数据库中的数据
                new DataTier().GetMessage();
            this.Height = 463;//设置窗体高度
        }

        private void btn_Write_Click(object sender, EventArgs e)
        {
            try
            {
                G_wa.ActiveDocument.Save();//保存文档
                object P_Save = false;//创建object对象
                ((Word._Application)G_wa.Application).Quit(//退出应用程序
                     ref P_Save, ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            btn_Write.Enabled = false;//停用插入数据按钮
            try
            {
                InsertData();//执行插入数据方法
                btn_display.Enabled = true;//启用显示文档按钮
            }
            catch (Exception ex)
            {
                MessageBox.Show(//提示异常信息
                    "插入信息失败，请确认Word中添入的信息是否正确\r\n"+ex.Message,"提示！");
            }
        }

        /// <summary>
        /// 向Access数据库插入数据方法
        /// </summary>
        private void InsertData()
        {
                G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                object P_Path = Directory.GetCurrentDirectory() + @"\Word.doc";
                Word.Document P_Document = G_wa.Documents.Open(//打开Word文档
                    ref P_Path, ref G_missing, ref G_missing, ref G_missing
                    , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                    , ref G_missing, ref G_missing, ref G_missing, ref G_missing
                    , ref G_missing, ref G_missing, ref G_missing, ref G_missing);
                try
                {
                    Word.Range P_Range =//得到文档范围
                        P_Document.Range(ref G_missing, ref G_missing);
                    Word.Table P_Table = P_Range.Tables[1];//得到文档内的表格对象
                    List<InstanceClass> P_List_InstanceClass = //建立集合对象
                        new List<InstanceClass>();
                    for (int i = 2; i < 7; i++)
                    {
                        if (P_Table.Cell(i, 1).Range.Text != "\r\a" &&//判断表格内是否已经添加信息
                            P_Table.Cell(i, 2).Range.Text != "\r\a" &&
                            P_Table.Cell(i, 3).Range.Text != "\r\a" &&
                            P_Table.Cell(i, 4).Range.Text != "\r\a")
                        {
                            P_List_InstanceClass.Add(//向数据集合中添加数据
                                new InstanceClass()
                                {
                                    Name = P_Table.Cell(i, 1).Range.Text.Replace("\r\a", ""),
                                    Chinese = float.Parse(P_Table.Cell(i, 2).Range.Text.Replace("\r\a", "")),
                                    Math = float.Parse(P_Table.Cell(i, 3).Range.Text.Replace("\r\a", "")),
                                    English = float.Parse(P_Table.Cell(i, 4).Range.Text.Replace("\r\a", ""))
                                });
                        }
                    }
                    new DataTier().InsertMessage(P_List_InstanceClass);//向Access数据库中插入数据
                    object P_Save = false;//创建object对象
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                         ref P_Save, ref G_missing, ref G_missing);
                    this.Invoke(//窗体线程执行
                        (MethodInvoker)(() =>//使用Lambda表达式
                        {
                            MessageBox.Show("向Access中插入数据成功！","提示！");
                        }));
                }
                catch (Exception ex)
                {
                    object P_Save = false;//创建object对象
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                         ref P_Save, ref G_missing, ref G_missing);
                    throw new Exception(ex.Message);//将异常抛向上一层
                }
        }
    }
}
