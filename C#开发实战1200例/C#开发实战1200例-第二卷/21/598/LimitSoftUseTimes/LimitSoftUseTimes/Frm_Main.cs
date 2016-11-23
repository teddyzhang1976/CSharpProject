using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ClassLibrary1;

namespace LimitSoftUseTimes
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        SoftReg softreg = new SoftReg();//实例化公共类对象
        private void frmMain_Load(object sender, EventArgs e)
        {
            RegistryKey retkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software", true).CreateSubKey("mrwxk").CreateSubKey("mrwxk.ini");				//打开注册表项
            foreach (string strRNum in retkey.GetSubKeyNames())//判断是否注册
            {
                if (strRNum == softreg.getRNum())//判断注册码是否相同
                {
                    this.Text = "限制软件的使用次数（已注册）";
                    button1.Enabled = false;
                    return;
                }
            }
            this.Text = "限制软件的使用次数（未注册）";
            button1.Enabled = true;
            MessageBox.Show("您现在使用的是试用版，该软件可以免费试用30次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Int32 tLong;
            try
            {
                //获取软件的已经使用次数
                tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\tryTimes", "UseTimes", 0);
                MessageBox.Show("感谢您已使用了" + tLong + "次", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                //首次使用软件
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\tryTimes", "UseTimes", 0, RegistryValueKind.DWord);
                MessageBox.Show("欢迎新用户使用本软件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //获取软件已经使用次数
            tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\tryTimes", "UseTimes", 0);
            if (tLong < 30)
            {
                int Times = tLong + 1;//计算软件本次是第几次使用
                //将软件使用次数写入注册表
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\tryTimes", "UseTimes", Times);
            }
            else
            {
                MessageBox.Show("试用次数已到", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();//退出应用程序
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Register frmregister = new Frm_Register();
            frmregister.Show();
            this.Hide();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
