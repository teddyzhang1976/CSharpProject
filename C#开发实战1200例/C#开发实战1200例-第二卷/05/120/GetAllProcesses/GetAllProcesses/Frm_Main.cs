using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GetAllProcesses
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();//清空listView1
            Process[] MyProcesses = Process.GetProcesses();//声明Process数组
            string[] Minfo = new string[6];//声明一个字符串数组
            foreach (Process MyProcess in MyProcesses)//遍历MyProcesses数组
            {
                Minfo[0] = MyProcess.ProcessName;//获取进程名
                Minfo[1] = MyProcess.Id.ToString();//获取进程ID
                Minfo[2] = MyProcess.Threads.Count.ToString();//获取线程数
                Minfo[3] = MyProcess.BasePriority.ToString();//获取优先级
                //获取物理内存
                Minfo[4] = Convert.ToString(MyProcess.WorkingSet / 1024) + "K";
                //获取虚拟内存
                Minfo[5] = Convert.ToString(MyProcess.VirtualMemorySize / 1024) + "K";
                //将信息添加到ListView控件中
                ListViewItem lvi = new ListViewItem(Minfo, "process");
                listView1.Items.Add(lvi);
            }
        }
    }
}
