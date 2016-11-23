using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OneTimePadArithmetic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";//清空文本框
            Encoding encoding = Encoding.Default;//获取字符编码
            byte[] btData = encoding.GetBytes(textBox1.Text);//将要加密的数据转换为字节数组
            byte[] btKey = encoding.GetBytes(textBox4.Text);//将密钥转换为字节数组
            if (btData.Length == btKey.Length)//判断长度是否相等
            {
                byte[] btEncrypt = Encrypt(btData, btKey);//加密数据
                for (int i = 0; i < btEncrypt.Length; i++)//遍历加密后的字节数组
                {
                    textBox2.Text += btEncrypt[i];//显示在文本框中
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Encoding encoding = Encoding.Default;//获取字符编码
            byte[] btData = encoding.GetBytes(textBox1.Text);//将要加密的数据转换为字节数组
            byte[] btKey = encoding.GetBytes(textBox4.Text);//将密钥转换为字节数组
            if (btData.Length == btKey.Length)//判断长度是否相等
            {
                byte[] btDecrypt = Encrypt(Encrypt(btData, btKey), btKey);//解密数据
                textBox3.Text = encoding.GetString(btDecrypt);//将解密后的字节数组转换为字符串并显示
            }
        }

        public static byte[] Encrypt(byte[] btData, byte[] btKey)
        {
            if (btKey.Length != btData.Length)//判断长度是否相等
            {
                MessageBox.Show("请确保要加密数据的长度与密钥的长度一致！");
            }
            byte[] btResult = new byte[btData.Length];//声明一个字节数组，用来存储加密数据
            for (int i = 0; i < btResult.Length; ++i)//遍历字节数组
            {
                btResult[i] = (byte)(btKey[i] ^ btData[i]);//为字节数组赋值
            }
            return btResult;//返回得到的加密数据
        }
    }
}
