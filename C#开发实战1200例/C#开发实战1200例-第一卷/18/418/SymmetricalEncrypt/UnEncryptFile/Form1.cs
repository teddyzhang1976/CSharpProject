using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace UnEncryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.*|*.*";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string strPwd = textBox2.Text;
            string str2 = textBox3.Text;
            try
            {
                byte[] myIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] myKey = System.Text.Encoding.UTF8.GetBytes(strPwd);
                FileStream myFileIn = new FileStream(str1, FileMode.Open, FileAccess.Read);
                FileStream myFileOut = new FileStream(str2, FileMode.OpenOrCreate, FileAccess.Write);
                myFileOut.SetLength(0);
                byte[] myBytes = new byte[100];
                long myLength = myFileIn.Length;
                long myInLength = 0;
                DES myProvider = new DESCryptoServiceProvider();
                CryptoStream myDeStream = new CryptoStream(myFileOut, myProvider.CreateDecryptor(myKey, myIV), CryptoStreamMode.Write);
                while (myInLength < myLength)
                {
                    int mylen = myFileIn.Read(myBytes, 0, 100);
                    myDeStream.Write(myBytes, 0, mylen);
                    myInLength += mylen;
                }
                myDeStream.Close();
                myFileOut.Close();
                myFileIn.Close();
                MessageBox.Show("解密文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
