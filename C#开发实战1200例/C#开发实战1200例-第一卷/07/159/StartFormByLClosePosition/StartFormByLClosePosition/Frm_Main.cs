using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StartFormByLClosePosition
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            RegistryKey myReg1, myReg2;//声明注册表对象
            myReg1 = Registry.CurrentUser;//获取当前用户注册表项
            try
            {
                myReg2 = myReg1.CreateSubKey("Software\\MySoft");//在注册表项中创建子项
                this.Location = new Point(Convert.ToInt16(myReg2.GetValue("1")), Convert.ToInt16(myReg2.GetValue("2")));//设置窗体的显示位置
            }
            catch { }
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryKey myReg1, myReg2;//声明注册表对象
            myReg1 = Registry.CurrentUser;//获取当前用户注册表项
            myReg2 = myReg1.CreateSubKey("Software\\MySoft");//在注册表项中创建子项
            try
            {
                myReg2.SetValue("1", this.Location.X.ToString());//将窗体关闭位置的x坐标写入注册表
                myReg2.SetValue("2", this.Location.Y.ToString());//将窗体关闭位置的y坐标写入注册表
            }
            catch { }
        }
    }
}