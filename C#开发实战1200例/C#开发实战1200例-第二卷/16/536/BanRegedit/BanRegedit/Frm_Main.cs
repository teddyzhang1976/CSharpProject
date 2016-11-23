using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BanRegedit
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
                //打开指定子项
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                rk.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);//修改指定键值，禁止使用注册表
                MessageBox.Show("禁止注册表成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                //打开指定子项
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                rk.SetValue("DisableRegistryTools",0, RegistryValueKind.DWord);//修改指定键值，允许使用注册表
                MessageBox.Show("禁止注册表成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
