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

namespace Real_TimeToSQL
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
        private Thread G_th;//定义线程字段
        private List<InstanceClass> G_List_InstanceClass = //定义数据集合字段并赋值
            new List<InstanceClass>();

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
                    TrackData();//将Word数据更新到SQL
                });
        }

        /// <summary>
        /// 跟踪Word文档数据并更新到SQL的方法
        /// </summary>
        private void TrackData()
        {
            G_th = new Thread(//使用线程
                () =>
                {
                    while (true)
                    {
                        try
                        {
                            Word.Range P_Rang = G_wa.ActiveDocument.Range(
                                ref G_missing, ref G_missing);
                            Word.Table P_Table = P_Rang.Tables[1];
                            List<InstanceClass> P_List_InstanceClass = //建立集合对象
                                new List<InstanceClass>();
                            List<InstanceClass> P_List_InstanceClass_temp = //建立集合对象
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
                                        P_List_InstanceClass_temp.Add(//向数据集合中添加数据
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
                                    this.Invoke(
                                        (MethodInvoker)(() =>
                                        {
                                            this.Text = "请输入正确的信息！" + ex.Message;
                                        }));
                                }
                            }
                            if (ListToList(P_List_InstanceClass, P_List_InstanceClass_temp))//判断数据是否有更新
                            {
                                P_List_InstanceClass = P_List_InstanceClass_temp;//同步两个集合内所有元素
                                new DataTier(txt_Server.Text, txt_DataBase.Text, txt_UserName.Text,//更新SQL中的数据
                                    txt_PassWord.Text).InsertMessage(P_List_InstanceClass_temp);
                                this.Invoke(
                                    (MethodInvoker)(() =>
                                    {
                                        dgv_Message.DataSource = new DataTier(//重新绑定数据
                                            txt_Server.Text, txt_DataBase.Text,
                                            txt_UserName.Text, txt_PassWord.Text).GetMessage();
                                    }));
                            }
                        }
                        catch (Exception ex)
                        {
                            object P_Save = false;//创建object对象
                            this.Invoke(
                                (MethodInvoker)(() =>
                                {
                                    btn_display.Enabled = true;//启用跟踪数据按钮
                                    MessageBox.Show("Word应程序操作异常,\r\n操作线程已经关闭\r\n" + ex.Message, "错误！");
                                }));
                            G_th.Abort();//退出监视线程
                        }
                        Thread.Sleep(100);
                    }
                });
            G_th.IsBackground = true;
            G_th.Start();
        }

        private bool ListToList(List<InstanceClass> l1, List<InstanceClass> l2)
        {
            if (l1.Count != l2.Count) return true;//判断集合中元素数量是否相同
            for (int i = 0; i < l1.Count; i++)//遍历集合
            {
                if (l1[i].Name != l2[i].Name) return true;//判断两个集合中元素是否相同
                if (l1[i].Chinese != l2[i].Chinese) return true;//判断两个集合中元素是否相同
                if (l1[i].Math != l2[i].Math) return true;//判断两个集合中元素是否相同
                if (l1[i].English != l2[i].English) return true;//判断两个集合中元素是否相同
            }
            return false;//全部相同则返回false
        }
    }
}
