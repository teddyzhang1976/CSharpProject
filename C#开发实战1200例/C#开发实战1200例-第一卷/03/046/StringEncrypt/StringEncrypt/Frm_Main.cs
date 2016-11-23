using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringEncrypt
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            if (txt_password.Text.Length == 4)//判断加密密钥长度是否正确
            {
                try
                {
                    txt_EncryptStr.Text = //调用实例ToEncrypt方法得到加密后的字符串
                        new Encrypt().ToEncrypt(
                        txt_password.Text, txt_str.Text);
                    //Encrypt P_Encrypt = new Encrypt();
                    //P_Encrypt.ToEncrypt(""
                }
                catch (Exception ex)//捕获异常
                {
                    MessageBox.Show(ex.Message);//输出异常信息
                }
            }
            else
            {
                MessageBox.Show("密钥长度不符！", "提示");//提示用户输入密钥长度不正确
            }
        }
        private void btn_UnEncrypt_Click(object sender, EventArgs e)
        {
            if (txt_password2.Text.Length == 4)//判断加密密钥长度是否正确
            {
                try
                {
                    txt_str2.Text = //调用ToDecrypt方法得到解密后的字符串
                        new Encrypt().ToDecrypt(
                        txt_password2.Text, txt_EncryptStr2.Text);
                }
                catch (Exception ex)//捕获异常
                {
                    MessageBox.Show(ex.Message);//输出异常信息
                }
            }
            else
            {
                MessageBox.Show("密钥长度不符！", "提示");//提示用户输入密钥长度不正确
            }
        }
    }
}
