using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace EncryptTextFileOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //选择加密解密文件路径
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件|*.txt|*.*|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        ///*************************/

        //加密
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("请选择要加密的文件"); }
            else
            {
                try
                {
                    string strPath = textBox1.Text;//加密文件的路径
                    int intLent = strPath.LastIndexOf("\\") + 1;
                    int intLong = strPath.Length;
                    string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                    int intTxt = strName.LastIndexOf(".");
                    int intTextLeng = strName.Length;
                    string strTxt = strName.Substring(intTxt, intTextLeng - intTxt);//取出文件的扩展名
                    strName = strName.Substring(0, intTxt);
                    //加密后的文件名及路径
                    string strOutName = strPath.Substring(0, strPath.LastIndexOf("\\") + 1) + strName + "Out" + strTxt;
                    byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 92 };
                    byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 99 };
                    RijndaelManaged myRijndael = new RijndaelManaged();
                    FileStream fsOut = File.Open(strOutName, FileMode.Create, FileAccess.Write);
                    FileStream fsIn = File.Open(strPath, FileMode.Open, FileAccess.Read);
                    //写入加密文本文件
                    CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    //读加密文本
                    BinaryReader br = new BinaryReader(fsIn);
                    csDecrypt.Write(br.ReadBytes((int)fsIn.Length), 0, (int)fsIn.Length);
                    csDecrypt.FlushFinalBlock();
                    csDecrypt.Close();
                    fsIn.Close();
                    fsOut.Close();
                    if (MessageBox.Show("加密成功!加密后的文件名及路径为:\n" + strOutName + ",是否册除源文件", "信息提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(strPath);
                        textBox1.Text = "";
                    }
                    else
                    { textBox1.Text = ""; }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }


        //解密
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择要解密的文件路径");
            }
            else
            {
                string strPath = textBox1.Text;//加密文件的路径
                int intLent = strPath.LastIndexOf("\\") + 1;
                int intLong = strPath.Length;
                string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                int intTxt = strName.LastIndexOf(".");
                int intTextLeng = strName.Length;
                strName = strName.Substring(0, intTxt);

                if (strName.LastIndexOf("Out") != -1)
                {
                    strName = strName.Substring(0, strName.LastIndexOf("Out"));

                }
                else
                {
                    strName = strName + "In";
                }
                //加密后的文件名及路径
                string strInName = strPath.Substring(0, strPath.LastIndexOf("\\") + 1) + strName + ".txt";
                byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 92 };
                byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 99 };
                RijndaelManaged myRijndael = new RijndaelManaged();
                FileStream fsOut = File.Open(strPath, FileMode.Open, FileAccess.Read);
                CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateDecryptor(key, IV), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(csDecrypt);//把文件读出来
                StreamWriter sw = new StreamWriter(strInName);//解密后文件写入一个新的文件
                sw.Write(sr.ReadToEnd());
                sw.Flush();
                sw.Close();
                sr.Close();
                fsOut.Close();
                if (MessageBox.Show("解密成功!解密后的文件名及路径为:"+strInName+"，是否册除源文件", "信息提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(strPath);
                    textBox1.Text = "";
                }
                else
                {
                    textBox1.Text = "";
                }

            }
        }
        

        /***************************/
    }
}
