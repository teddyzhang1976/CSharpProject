using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace SetBackByRegistry
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();//创建打开对话框对象
            //设置文件的类型
            openFile.Filter = "*.jpg,*.jpeg,*.bmp,*.gif,*.ico,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.gif;*.ico;*.png;*.tif;*.wmf";
            if (openFile.ShowDialog() == DialogResult.OK)//判断是否选择了文件
                textBox1.Text = openFile.FileName;//显示选择的文件名
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string P_str_Path = textBox1.Text;//记录图片路径
            RegistryKey myRKey = Registry.CurrentUser;//获取册注表中的基表
            myRKey = myRKey.OpenSubKey("Control Panel\\Desktop", true);//检索指定的子项
            //通过调用RegistryKey对象的SetValue方法设置桌面背景
            myRKey.SetValue("WallPaper", P_str_Path);
            myRKey.SetValue("TitleWallPaper", "2");
            myRKey.Close();//关闭注册表
            MessageBox.Show("桌面背景已经更改，请重新启动计算机！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}