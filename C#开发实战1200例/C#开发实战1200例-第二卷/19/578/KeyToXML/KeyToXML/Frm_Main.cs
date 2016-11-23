using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace KeyToXML
{
    public partial class Frm_Main : Form
    {

        public Frm_Main()
        {
            InitializeComponent();
        }
        RSACryptoServiceProvider RSACrypto = new RSACryptoServiceProvider();//创建RSA算法加密解密对象
        byte[] M_bt_Data;//定义一个字节数组，用来存储临时数据

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = RSACrypto.ToXmlString(true);//显示生成的公钥
            this.textBox2.Text = RSACrypto.ToXmlString(false);//显示生成的私钥
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")//判断是否输入了要加密的数据
            {
                byte[] P_bt_Encrypt = Encoding.UTF8.GetBytes(textBox3.Text);//将要加密的数据转换为字节数组
                M_bt_Data = RSACrypto.Encrypt(P_bt_Encrypt, false);//加密数据
                textBox4.Text = Encoding.UTF8.GetString(M_bt_Data);//显示加密数据
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")//判断是否有加密过的数据
            {
                byte[] P_bt_Decrypt = RSACrypto.Decrypt(M_bt_Data, false);//对数据进行解密
                textBox5.Text = Encoding.UTF8.GetString(P_bt_Decrypt);//显示解密数据
            }
        }
    }
}
