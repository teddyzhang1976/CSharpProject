using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace TimeTask
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMessage();//显示任务信息
            BeginTask();//开始监视任务
        }

        private List<task> G_Task = new List<task>();//任务集合

        /// <summary>
        /// 开始监视任务
        /// </summary>
        private void BeginTask()
        {
            Thread th = new Thread(//建立线程
                (() =>//使用Lambda表达式
                {
                    while (true)//无限循环
                    {
                        for (int i = 0; i < G_Task.Count; i++)//循环任务集合
                        {
                            if (DateTime.Now.ToShortDateString() == //判断是否执行任务
                                G_Task[i].Date.ToShortDateString())
                            {
                                this.Invoke(//调用窗体线程
                                    ((MethodInvoker)(() =>//使用Lambda表达式
                                    {
                                        Form P_Form = new Form();//创建窗体对象
                                        Label lb_txt = new Label();//创建Label标签
                                        lb_txt.Text = G_Task[i].Task;//设置标签文本
                                        lb_txt.Font = new Font("隶书", 30);//设置标签字体
                                        lb_txt.AutoSize = true;//设置标签自动调整大小
                                        lb_txt.ForeColor = Color.Blue;//设置文字颜色
                                        P_Form.Controls.Add(lb_txt);//将标签加入窗体控件集合
                                        P_Form.Width = 500;//设置窗体宽度
                                        P_Form.Height = 100;//设置窗体高度
                                        P_Form.StartPosition = //设置窗体开始位置
                                            FormStartPosition.CenterScreen;
                                        P_Form.Text = "任务提示！";//设置窗体标题文本
                                        P_Form.Show();//显示窗体
                                    })));
                                new DataTier().Delete(//从数据库中删除数据
                                    G_Task[i].Date.ToShortDateString(),
                                    G_Task[i].Task);
                                Thread.Sleep(2000);//线程挂起2秒
                                G_Task.RemoveAt(i);//删除任务集合中的任务
                                this.Invoke(//调用窗体线程
                                    ((MethodInvoker)(() =>//使用Lambda表达式
                                    {
                                        GetMessage();//显示任务信息
                                    })));
                                break;//退出循环
                            }
                        }
                        Thread.Sleep(5000);//线程挂起5秒
                    }
                }));
            th.IsBackground = true;//设置线程为后台线程
            th.Start();//开始执行线程
        }

        /// <summary>
        /// 显示任务信息
        /// </summary>
        private void GetMessage()
        {
            lv_Task.Items.Clear();//清空控件项
            G_Task = new DataTier().Select();//得到任务集合
            foreach (task t in G_Task)//遍历任务集合
            {
                lv_Task.Items.Add(//向控件中加入任务项
                    new ListViewItem(new string[] 
                { 
                    t.Date.ToShortDateString(),t.Task
                }));
            }

        }

        private void Moth_Display_MouseUp(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show(//弹出消息对话框并判断是否添加任务
                "是否添加任务", "提示！", MessageBoxButtons.OKCancel
                ) == DialogResult.OK)
            {
                if (txt_Task.Text != string.Empty)//如果任务内容不为空
                {
                    try
                    {
                        new DataTier().Add(//向数据库中添加任务
                            Moth_Display.SelectionStart.ToShortDateString(),
                            txt_Task.Text);
                        MessageBox.Show(//弹出消息对话框
                            "添加任务成功！", "提示！");
                        GetMessage();
                    }
                    catch (Exception ex)//捕获异常
                    {
                        MessageBox.Show(//弹出消息对话框
                            "添加数据失败！\r\n" + ex.Message, "错误！");
                    }
                }
                else
                {
                    MessageBox.Show(//弹出消息对话框
                        "请填写任务信息！", "提示！");
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lv_Task.SelectedIndices.Count != 0)//如果选中任务
            {
                foreach (ListViewItem lvi//遍历选中控件中任务集合
                    in lv_Task.SelectedItems)
                {
                    new DataTier().Delete(//删除任务
                        lvi.SubItems[0].Text,
                        lvi.SubItems[1].Text);
                    for (int i = 0; i < G_Task.Count; i++)
                    {
                        if (G_Task[i].Date.ToShortDateString() //遍历任务集合
                            == lvi.SubItems[0].Text &&
                            G_Task[i].Task == lvi.SubItems[1].Text)
                        {
                            G_Task.RemoveAt(i);//删除任务
                            break;//退出循环
                        }
                    }
                }

                MessageBox.Show(//弹出消息对话框
                    "成功删除任务!", "提示！");
                GetMessage();//显示任务信息
            }
        }
    }
}
