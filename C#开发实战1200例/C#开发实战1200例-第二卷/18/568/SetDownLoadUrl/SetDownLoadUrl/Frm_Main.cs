using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SetDownLoadUrl
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey rkBase = Registry.Users;//定位到Users注册表项
                //打开或创建指定的注册表项
                RegistryKey rkChild = rkBase.CreateSubKey(@".DEFAULT\Software\Microsoft\Internet Explorer");
                rkChild.SetValue("DownloadDirectory", textBox1.Text, RegistryValueKind.String);//将默认下载路径写入到注册表中
                MessageBox.Show("设置默认下载路径成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗体
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;//显示选择的文件夹路径
            }
        }
    }
}
