using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace ConcealDisk
{
    public partial class Frm_Main : Form
    {
        string strDisk = string.Empty;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bvalues;
            
            if (this.radioButton1.Checked)
            {
                bvalues = new byte[] { 04, 00, 00, 00 };//隐藏C盘
                strDisk = "C";
            }
            else if (this.radioButton2.Checked)
            {
                bvalues = new byte[] { 08, 00, 00, 00 };//隐藏D盘
                strDisk = "D";
            }
            else if (this.radioButton3.Checked)
            {
                bvalues = new byte[] { 16, 00, 00, 00 };//隐藏E盘
                strDisk = "E";
            }
            else
            { return; }
            DeskHide(bvalues);//隐藏磁盘驱动器
            MessageBox.Show("隐藏" + strDisk + "盘成功，请重新启动电脑！");
        }
        private void DeskHide(byte[] Values)//隐藏磁盘驱动器
        {
            try
            {
                //定位注册表项
                RegistryKey rgK = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                rgK.SetValue("NoDrives", Values, RegistryValueKind.Binary);//给默认值赋值
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeskHide(new byte[] { 00, 00, 00, 00 });
            MessageBox.Show("设置显示所有磁盘成功，请重新启动电脑！");
        }
    }
}