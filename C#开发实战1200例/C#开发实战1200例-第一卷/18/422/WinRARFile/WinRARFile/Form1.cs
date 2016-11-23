using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace WinRARFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "所有文件(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择源文件!", "信息提示");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入压缩文件名!", "信息提示");
                return;
            }

            String myRar;//表示WinRAR.exe文件所在的路径
            RegistryKey myReg;//声明RegistryKey类的引用
            Object myObj;
            String myInfo;//表示压缩命令的字符串
            ProcessStartInfo myStartInfo;//声明ProcessStartInfo类的引用
            Process myProcess;//声明Process类的引用
            string strRar;//表示压缩文件名
            string strFile;//表示源文件名
            try
            {
                //检索注册表HKEY_CLASSES_ROOT基项下的指定子项
                myReg = Registry.ClassesRoot.OpenSubKey(@"Applications\WinRAR.exe\Shell\Open\Command");
                myObj = myReg.GetValue("");//检索子项中与指定名称关联的值
                myRar = myObj.ToString();//获取包含WinRAR.exe文件所在路径的字符串
                myReg.Close();//关闭指定的注册表项
                myRar = myRar.Substring(1, myRar.Length - 7);//获取WinRAR.exe文件所在的完整路径
                strRar = textBox2.Text.Trim() + ".rar";//设置压缩文件的名称
                strFile = textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1);//获取源文件的名称
                myInfo = " a " + strRar + " " + strFile + "";//设置压缩命令
                myStartInfo = new ProcessStartInfo();//实例化ProcessStartInfo类
                myStartInfo.FileName = myRar;//设置要启动的应用程序
                myStartInfo.Arguments = myInfo;//设置启动应用程序时要使用的命令参数
                myStartInfo.WindowStyle = ProcessWindowStyle.Hidden;//隐藏进程窗口
                myStartInfo.WorkingDirectory = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf("\\"));//设置要启动的进程的初始目录
                myProcess = new Process();//新建进程
                myProcess.StartInfo = myStartInfo;//设置要传递给进程的Start方法的属性
                myProcess.Start();//启动进程
                myProcess.WaitForExit();//等待关闭进程
                myProcess.Close();//释放进程资源
                MessageBox.Show("压缩文件成功！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
