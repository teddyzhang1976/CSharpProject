using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace RegSoftByNetworkCard  
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string[] strLanCode = new string[12];// 网卡信息存储到
        string[] strkey = { "Q", "W", "7", "E", "D", "F", "2", "G", "R", "T", "Y", "8", "P", "N", "B", "V", "C", "X", "Z", "0", "9", "I", "8", "6", "U", "O", "P", "M", "5", "4", "3", "1", "A", "S", "H", "J", "K", "L" };
        //生成注册码
        public int intRand = 0;//判断随机生成次数

        private void button1_Click(object sender, EventArgs e)
        {
            //把网卡信息转换成字符串
            string strCode = GetNetCardMacAddress();//调用自定义方法获取网卡信息
            strCode = strCode.Substring(0, 2) + strCode.Substring(3, 2) + strCode.Substring(6, 2) + strCode.Substring(9, 2) + strCode.Substring(12, 2) + strCode.Substring(15, 2);
            string strb = strCode.Substring(0, 4) + strCode.Substring(4, 4) + strCode.Substring(8, 4);//网卡信息存储
            for (int i = 0; i < strLanCode.Length; i++)//把网卡信息存入数组
            {
                strLanCode[i] = strb.Substring(i, 1);
            }
            Random ra = new Random();
            switch (intRand)//随机生成注册码的顺序
            {
                case 0://当第一次生成随机注册码时执行
                    label5.Text = strCode.Substring(0, 4) + "-" + strCode.Substring(4, 4) + "-" + strCode.Substring(8, 4) + "-" + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString();													//生成随机注册码
                    intRand = 1;//使变量intRand等于1
                    break;
                case 1://第二次生成随机注册码时执行
                    label5.Text = strCode.Substring(0, 4) + "-" + strCode.Substring(4, 4) + "-" + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString();
                    intRand = 2;//使变量intRand等于2
                    break;
                case 2://第3次生成随机注册码时执行
                    label5.Text = strCode.Substring(0, 4) + "-" + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString();				//生成随机注册码
                    intRand = 3;											//使变量intRand等于3
                    break;
                case 3://第4次生成随机注册码时执行
                    label5.Text = strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + strLanCode[ra.Next(0, 11)] + "-" + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString() + strkey[ra.Next(0, 37)].ToString();							//生成随机注册码
                    intRand = 0;//使变量intRand等于0
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = Environment.MachineName.ToString();//得到计算机名
            label4.Text = GetNetCardMacAddress();//得到网卡信息

        }
        //获得网卡信息函数
        public string GetNetCardMacAddress()
        {
            //创建ManagementClass对象
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();//创建ManagementObjectCollection对象
            string str = "";//用于存储网卡序列号
            foreach (ManagementObject mo in moc)//遍历得到的集合
            {
                if ((bool)mo["IPEnabled"] == true)//判断IPEnabled属性是否为true
                    str = mo["MacAddress"].ToString();//获取网卡序列号
            }
            return str;//返回网卡序列号
        }
        //注册
        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")//判断是否生成注册码
            { MessageBox.Show("请生成注册码"); }//如果没有生成则弹出提示
            else
            {
                string strNameKey = textBox1.Text.TrimEnd() + textBox2.Text.TrimEnd() + textBox3.Text.TrimEnd() + textBox4.Text.TrimEnd();											//获取输入的注册码
                string strNumber = label5.Text.Substring(0, 4) + label5.Text.Substring(5, 4) + label5.Text.Substring(10, 4) + label5.Text.Substring(15, 4);											//获取生成的注册码
                if (strNameKey == strNumber)//判断输入的和生成的注册码是否相等
                {
                    //打开相应的键值
                    Microsoft.Win32.RegistryKey retkey1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("ZHY").CreateSubKey("ZHY.INI");
                    foreach (string strName in retkey1.GetSubKeyNames())//判断注册码是否过期
                    {
                        //如果输入的与注册表中原始的序列号相等则说明注册码过期
                        if (strName == strNameKey)
                        {
                            MessageBox.Show("此注册码已经过期");//弹出提示
                            return;
                        }
                    }//开始注册信息
                    Microsoft.Win32.RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("ZHY").CreateSubKey("ZHY.INI").CreateSubKey(strNumber.TrimEnd());
                    retkey.SetValue("UserName", "明日科技");//设置注册名
                    MessageBox.Show("注册成功!", "提示");//弹出提示
                }
                else//否则
                { MessageBox.Show("注册码输入错误"); }//弹出错误提示
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text.Length == 4)
            {
                textBox2.Focus();
                textBox2.SelectAll();
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text.Length == 4)
            {
                textBox3.Focus();
                textBox3.SelectAll();
                e.Handled = true;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text.Length == 4)
            {
                textBox4.Focus();
                textBox4.SelectAll();
                e.Handled = true;
            }
        }
    }
}