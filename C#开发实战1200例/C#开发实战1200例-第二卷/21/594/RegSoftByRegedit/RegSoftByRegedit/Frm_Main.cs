using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegSoftByRegedit
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //注册
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//判断公司名称是否为空
            {
                MessageBox.Show("公司名称不能为空"); 
                return;
            }
            if (textBox2.Text == "")//判断用户名称是否为空
            { 
                MessageBox.Show("用户名称不能为空"); 
                return; 
            }
            if (textBox3.Text == "")//判断注册码是否为空
            { 
                MessageBox.Show("注册码不能为空"); 
                return; 
            }
            //创建RegistryKey对象
            Microsoft.Win32.RegistryKey retkey1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("WXK").CreateSubKey("WXK.INI");
            foreach (string strName in retkey1.GetSubKeyNames())//判断注册码是否过期
            {
                if (strName == textBox3.Text)//如果注册表中已经存在
                {
                    MessageBox.Show("此注册码已经过期");
                    return;
                }
            }
            //在注册表中创建子项
            Microsoft.Win32.RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("WXK").CreateSubKey("WXK.INI").CreateSubKey(textBox3.Text.TrimEnd());
            retkey.SetValue("UserName", textBox2.Text);//向注册表中写入公司名称
            retkey.SetValue("capataz", textBox1.Text);//向注册表中写入用户名称
            retkey.SetValue("Code", textBox3.Text);//向注册表中写入注册码
            MessageBox.Show("注册成功，您可以使用本软件");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";//清空文本框
        }
    }
}