using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ROT13Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text= ROT13Encode(textBox1.Text);
        }

        public string ROT13Encode(string InputText)
        {
            char tem_Character;
            int UnicodeChar;
            string EncodedText = "";
            for (int i = 0; i < InputText.Length; i++)//遍历字符串中的所有字符，只能加密字符串，无法加密汉字
            {
                tem_Character = System.Convert.ToChar(InputText.Substring(i, 1));//获取字符串中指定的字符
                UnicodeChar = (int)tem_Character;//获取当前字符的Unicode编码
                if (UnicodeChar >= 97 && UnicodeChar <= 109)//对字符进行加密
                {
                    UnicodeChar = UnicodeChar + 13;
                }
                else if (UnicodeChar >= 110 && UnicodeChar <= 122)//对字符进行解密
                {
                    UnicodeChar = UnicodeChar - 13;
                }
                else if (UnicodeChar >= 65 && UnicodeChar <= 77)//对字符进行加密
                {
                    UnicodeChar = UnicodeChar + 13;
                }
                else if (UnicodeChar >= 78 && UnicodeChar <= 90)//对字符进行解密
                {
                    UnicodeChar = UnicodeChar - 13;
                }
                EncodedText = EncodedText + (char)UnicodeChar;//返回设置后的字符
            }
            return EncodedText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ROT13Encode(textBox2.Text);
        }  
    }
}
