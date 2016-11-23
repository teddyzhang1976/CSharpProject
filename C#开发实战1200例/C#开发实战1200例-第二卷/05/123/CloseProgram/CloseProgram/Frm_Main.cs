using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CloseProgram
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//清空控件中的信息
            Process[] myProcesses = Process.GetProcesses();//获取本地进程信息
            foreach (Process myProcess in myProcesses)//遍历进程数组
            {
                if (myProcess.MainWindowTitle.Length > 0)//如果进程存在主窗口标题
                    listBox1.Items.Add(myProcess.ProcessName.ToString().Trim());//将进程名称添加到控件中
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                //根据指定的进程名创建进程资源数组
                Process[] myProcesses = Process.GetProcessesByName(listBox1.SelectedItem.ToString().Trim());
                foreach (Process myProcess in myProcesses)//遍历数组
                {
                    myProcess.CloseMainWindow();//关闭拥有界面的进程
                }
                MessageBox.Show("进程已关闭！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}