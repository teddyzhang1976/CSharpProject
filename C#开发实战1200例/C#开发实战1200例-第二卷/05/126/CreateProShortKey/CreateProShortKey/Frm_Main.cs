using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using System.IO;

namespace CreateProShortKey
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string exePath = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exePath = openFileDialog1.FileName;
                textBox1.Text = exePath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (exePath.Length == 0)//判断是否选择了应用程序
            {
                MessageBox.Show("请选择应用程序");//如果没有选择则弹出提示信息
            }
            else//如果选择了应用程序
            {
                WshShell sl = new WshShell();//创建WshShell对象
                //设置桌面快捷方式的路径
                string dtpath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\wxk.lnk";
                //设置开始菜单里的快捷方式路径
                string dtpath1 = System.Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\程序\\小科\\wxk.lnk";
                string dd = Path.GetDirectoryName(dtpath1);	//判断开始菜单中指定的文件夹是否存在
                if (!Directory.Exists(dd))
                {
                    Directory.CreateDirectory(dd);//如果不存在则创建该文件夹
                }
                IWshShortcut sc = (IWshShortcut)sl.CreateShortcut(dtpath1);//创建IwshShortcut对象
                sc.TargetPath = exePath;//设置应用程序路径
                sc.Description = "创建应用程序的快捷方式";//添加描述信息
                sc.Save();//保存快捷方式
                IWshShortcut sc1 = (IWshShortcut)sl.CreateShortcut(dtpath);//创建IwshShortcut对象
                sc1.TargetPath = exePath;//设置应用程序路径
                sc1.Description = "创建应用程序的快捷方式";//添加描述信息
                sc1.Save();//保存快捷方式
                MessageBox.Show("创建快捷方式成功");//弹出提示信息
            }
        }
    }
}
