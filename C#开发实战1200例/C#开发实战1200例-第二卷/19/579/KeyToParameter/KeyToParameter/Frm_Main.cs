using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace KeyToParameter
{
    public partial class Frm_Main : Form
    {
        RSACryptoServiceProvider RSACrypto;//声明RSA算法加密解密对象
        RSAParameters RSAParame;//声明RSAParameters参数对象
        byte[] M_bt_Data;//定义一个字节数组，用来存储临时数据

        public Frm_Main()
        {
            InitializeComponent();
            RSACrypto = new RSACryptoServiceProvider();//初始化RSA算法加密解密对象
            RSAParame = RSACrypto.ExportParameters(true);//初始化RSAParameters参数
            RSACrypto.Clear();//清空RSACryptoServiceProvider对象
            RSACrypto = new RSACryptoServiceProvider();//初始化RSA算法加密解密对象
            RSACrypto.ImportParameters(RSAParame);//导入密钥
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//判断是否输入了要加密的数据
            {
                byte[] P_bt_Encrypt = Encoding.UTF8.GetBytes(textBox1.Text);//将要加密的数据转换为字节数组
                M_bt_Data = RSACrypto.Encrypt(P_bt_Encrypt, false);//加密数据
                textBox2.Text = Encoding.UTF8.GetString(M_bt_Data);//显示加密数据
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")//判断是否有加密过的数据
            {
                byte[] P_bt_Decrypt = RSACrypto.Decrypt(M_bt_Data, false);//对数据进行解密
                textBox3.Text = Encoding.UTF8.GetString(P_bt_Decrypt);//显示解密数据
            }
        }
    }
}
