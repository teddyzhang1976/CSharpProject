using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SaveWindowsLocation
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            label1.Text = "窗体的大小："+this.Size.ToString();//记录窗体大小
            label2.Text = "窗体的位置：" + this.Location.ToString();//记录窗体位置
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SubKey\\key", "窗体的大小", this.Size.ToString());//将窗体大小写入注册表
                Registry.SetValue("HKEY_CURRENT_USER\\SubKey\\key", "窗体的位置", this.Location.ToString());//将窗体位置写入注册表
                MessageBox.Show("保存窗体信息成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
