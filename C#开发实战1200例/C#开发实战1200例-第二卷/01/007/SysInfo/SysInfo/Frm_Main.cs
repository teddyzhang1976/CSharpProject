using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SysInfo
{
    public partial class Frm_Main : Form
    {
       MessageFilter mf = new MessageFilter();

        public Frm_Main()
        {
            InitializeComponent();
        }
        //窗体加载消息筛选器
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //添加消息筛选器以便在向目标传送 Windows 消息时监视这些消息
            Application.AddMessageFilter(mf);
        }
        //从窗体中移除一个消息筛选器
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //从应用程序的消息泵移除一个消息筛选器
            Application.RemoveMessageFilter(mf);
        }

        //方法一，重写WndProc虚方法，与方法二不可同时存在
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)//判断系统消息的ID号
            {
                case 513:
                    MessageBox.Show("单击了鼠标左键！", "系统信息");
                    m.Result = (IntPtr)0;//为了响应消息处理而向 Windows 返回的值
                    break;
                case 516:
                    MessageBox.Show("单击了鼠标右键！", "系统信息");
                    m.Result = (IntPtr)0;//为了响应消息处理而向 Windows 返回的值
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }

    //方法二，实现IMessageFilter接口，从而获得Windows消息，与方法一不可同时存在
    public class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message message)
        {
            switch (message.Msg)//判断系统消息的ID号
            {
                case 513:
                    MessageBox.Show("单击了鼠标左键！", "系统信息");
                    return true;
                case 516:
                    MessageBox.Show("单击了鼠标右键！", "系统信息");
                    return true;
                default:
                    return false;
            }
        }
    }
}
