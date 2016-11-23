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

namespace EncryptFile
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
            string myFile = textBox1.Text;
            string myPassword = textBox2.Text;
            string myEnFile = textBox3.Text;
            try
            {
                byte[] myIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] myKey = System.Text.Encoding.UTF8.GetBytes(myPassword);
                FileStream myInStream = new FileStream(myFile, FileMode.Open, FileAccess.Read);
                FileStream myOutStream = new FileStream(myEnFile, FileMode.OpenOrCreate, FileAccess.Write);
                myOutStream.SetLength(0);
                byte[] myBytes = new byte[100];
                long myInLength = 0;
                long myLength = myInStream.Length;
                DES myProvider = new DESCryptoServiceProvider();
                CryptoStream myCryptoStream = new CryptoStream(myOutStream, myProvider.CreateEncryptor(myKey, myIV), CryptoStreamMode.Write);
                while (myInLength < myLength)
                {
                    int mylen = myInStream.Read(myBytes, 0, 100);
                    myCryptoStream.Write(myBytes, 0, mylen);
                    myInLength += mylen;
                }
                myCryptoStream.Close();
                myInStream.Close();
                myOutStream.Close();
                MessageBox.Show("加密文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
