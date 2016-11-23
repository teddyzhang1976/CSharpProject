using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace HistoryMenu
{
    public partial class Frm_Main : Form
    {
        string address;
        public Frm_Main()
        {
            InitializeComponent();
            address = //得到应用程序路径
                Environment.CurrentDirectory;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";//设置默认打开文件名称
            openFileDialog1.ShowDialog();//弹出打开文件对话框
            StreamWriter s = //创建流写入器对象
                new StreamWriter(address + "\\History.ini", true);
            s.WriteLine(openFileDialog1.FileName);//向文件中写入历史信息
            s.Flush();//将信息压入流
            s.Close();//关闭流
            ShowWindows(openFileDialog1.FileName);//打开新窗口
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = //创建流读取器对象
                new StreamReader(address + "\\History.ini");
            int i = //得到菜单项索引
                文件ToolStripMenuItem.DropDownItems.Count-2;
            while (sr.Peek()>=0)//循环读取流中文本
            {
                ToolStripMenuItem menuitem = //创建菜单项对象
                    new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.//向菜单中添加新项
                    DropDownItems.Insert(i, menuitem);
                i++;//向菜单中插入索引的位置
                menuitem.Click += //添加点击事件
                    new EventHandler(menuitem_Click);
            }
            sr.Close();
        }

       private  void menuitem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = //得到菜单项
                (ToolStripMenuItem)sender;
            ShowWindows(menu.Text);//打开新窗口
        }
        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);//得到图像对象
            Form f = new Form();//创建窗体对象
            f.MdiParent = this;//设置父窗体
            f.BackgroundImage = p;//设置背景图片
            f.Show();//显示窗体
        }

        private void 退出ToolStripMenuItem_Click(object sender,EventArgs e)
        {
            Application.Exit();//退出应用程序
        }
    }
}