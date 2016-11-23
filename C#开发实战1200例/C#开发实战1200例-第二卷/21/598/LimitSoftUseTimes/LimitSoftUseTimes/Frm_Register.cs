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
    public partial class Frm_Register : Form
    {
        public Frm_Register()
        {
            InitializeComponent();
        }
        SoftReg softreg = new SoftReg();//实例化公共类对象
        private void frmRegister_Load(object sender, EventArgs e)
        {
            textBox1.Text = softreg.getMNum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("注册码输入不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text.Equals(softreg.getRNum()))
                {
                    RegistryKey retkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software", true).CreateSubKey("mrwxk").CreateSubKey("mrwxk.ini").CreateSubKey(textBox2.Text);
                    retkey.SetValue("UserName", "mrsoft");
                    MessageBox.Show("注册成功,程序需要重新加载！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Frm_Main frmmain = new Frm_Main();
                    frmmain.Show();
                }
                else
                {
                    MessageBox.Show("注册码输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_Main frmmain = new Frm_Main();
            frmmain.Show();
        }
    }
}
