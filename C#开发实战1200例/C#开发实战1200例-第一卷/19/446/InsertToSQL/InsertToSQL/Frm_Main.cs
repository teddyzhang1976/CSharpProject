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

namespace InsertToSQL
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
                            btn_display.Enabled = true;
                        }));
                });
        }

        private void btn_DisplayData_Click(object sender, EventArgs e)
        {
            dgv_Message.DataSource = //绑定数据库中的数据
              new DataTier(txt_Server.Text,
                  txt_DataBase.Text,
                  txt_UserName.Text,
                  txt_PassWord.Text).GetMessage();
            this.Height = 517;//设置窗体高度
        }

        /// <summary>
        /// 向SQL数据库插入数据方法
        /// </summary>
        private void InsertData()
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
            btn_Begin.Enabled = false;//停用插入数据按钮
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
                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format(//提示异常信息
                            "Word表格中第{0}行数据不正确，插入失败！" +
                            ex.Message, (i - 1).ToString()), "错误！");
                    }

                }
                new DataTier(txt_Server.Text, txt_DataBase.Text, txt_UserName.Text,//向SQL数据库中插入数据
                    txt_PassWord.Text).InsertMessage(P_List_InstanceClass);
                object P_Save = false;//创建object对象
                ((Word._Application)G_wa.Application).Quit(//退出应用程序
                     ref P_Save, ref G_missing, ref G_missing);
                this.Invoke(//窗体线程执行
                    (MethodInvoker)(() =>//使用Lambda表达式
                    {
                        dgv_Message.DataSource = //绑定数据库中的数据
                          new DataTier(txt_Server.Text,
                              txt_DataBase.Text,
                              txt_UserName.Text,
                              txt_PassWord.Text).GetMessage();
                        MessageBox.Show("向SQL中插入数据成功！", "提示！");
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

        private void btn_SetTask_Click(object sender, EventArgs e)
        {
            this.Width = 697;//设置窗体宽度
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            this.Width = 444;//设置窗体宽度
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            this.Height = 254;//设置窗体高度
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            btn_Begin.Enabled = false;
            Thread P_th = new Thread(//创建线程
                () => //使用Lambda表达式
                {
                    while (true)//开始无限循环
                    {
                        this.Invoke(//在窗体线程中执行
                            (MethodInvoker)(() =>//使用Lambda表达式
                            {
                                foreach (object P_O in lbox_Task.Items)
                                {
                                    Time P_Time = (Time)P_O;//将对象转换为Time类型
                                    if (P_Time.Hours.ToString() == //判断时间是否相等
                                        DateTime.Now.Hour.ToString() &&
                                        P_Time.Minutes.ToString() ==
                                        DateTime.Now.Minute.ToString() &&
                                        P_Time.Seconds.ToString() ==
                                        DateTime.Now.Second.ToString())
                                    {
                                        if (P_Time.Execute)//判断任务是否已经执行
                                        {
                                            P_Time.Execute = false;//设置任务为已执行
                                            InsertData();//开始插入数据
                                        }
                                    }
                                }
                                if ("0" == DateTime.Now.Hour.ToString() &&//是否重置任务
                                     "0" == DateTime.Now.Minute.ToString() &&
                                     "0" == DateTime.Now.Second.ToString())
                                {
                                    foreach (object P_1 in lbox_Task.Items)
                                    {
                                        ((Time)P_1).Execute = true;
                                    }
                                }
                            }));
                        Thread.Sleep(1000);//线程挂起1秒钟
                    }
                });
            P_th.IsBackground = true;//设置线程为后台线程
            P_th.Start();//线程开始执行
        }

        private void btn_RemoveTask_Click(object sender, EventArgs e)
        {
            if (lbox_Task.SelectedIndex != -1)//如果选择了正确的选项
            {
                lbox_Task.Items.RemoveAt(lbox_Task.SelectedIndex);//删除选择的项
            }
        }

        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            lbox_Task.Items.Add(new Time()//向集合中添加元素
            {
                Times = string.Format("任务时间：每日{0}时{1}分{2}秒",
                txt_Hours.Text, txt_Minutes.Text,txt_Seconds.Text),
                Hours = byte.Parse(txt_Hours.Text),
                Minutes = byte.Parse(txt_Minutes.Text),
                Seconds=byte.Parse(txt_Seconds.Text),
                Execute = true
            });
        }


    }
}
