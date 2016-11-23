using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
namespace AutoRunPro
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public void RefreshSystem()
        {
            Process[] mprocess;
            mprocess = Process.GetProcessesByName("explorer");//创建进程组件的数组，并将它们与共享“explorer”进程名称的所有进程资源关联。
            foreach (Process mp in mprocess)
            {
                mp.Kill();//立即停止“关联”的进程
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;//设置要运行的指定应用程序名
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string strName = textBox1.Text.Trim();//获取要自动运行的应用程序名
                if (!System.IO.File.Exists(strName))//判断要自动运行的应用程序文件是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);//获取应用程序文件名，不包括路径
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//检索指定的子项
                if (RKey == null)//若指定的子项不存在
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
                RKey.SetValue(strnewName, strName);//设置该子项的新的“键值对”
                if (MessageBox.Show("设置完毕") == DialogResult.OK)
                {
                    RefreshSystem();//刷新系统
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//判断是否已输入要取消的应用程序名
            {
                string strName = textBox1.Text.Trim();//获取应用程序名
                if (!System.IO.File.Exists(strName))//判断要取消的应用程序文件是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);///获取应用程序文件名，不包括路径
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//读取指定的子项
                if (RKey == null)//若指定的子项不存在
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
                RKey.DeleteValue(strnewName, false);//删除指定“键名称”的键/值对
                if (MessageBox.Show("设置完毕") == DialogResult.OK)
                {
                    RefreshSystem();
                }
            }
        }
    }
}
