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
    public partial class Frm_Main : Form
    {
        public Frm_Main()
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

        //加密
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//若未选择要加密的文本文件
            { MessageBox.Show("请选择要加密的文件"); }//如果没有选择则弹出提示
            else
            {
                try
                {
                    string strPath = textBox1.Text;//加密文件的路径
                    int intLent = strPath.LastIndexOf("\\") + 1;//设置截取的起始位置
                    int intLong = strPath.Length;//设置截取的长度
                    string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                    int intTxt = strName.LastIndexOf(".");//设置截取的起始位置
                    int intTextLeng = strName.Length;//设置截取的长度
                    string strTxt = strName.Substring(intTxt, intTextLeng - intTxt);//取出文件的扩展名
                    strName = strName.Substring(0, intTxt);
                    //加密后的文件名及路径
                    string strOutName = strPath.Substring(0, strPath.LastIndexOf("\\") + 1) + strName + "Out" + strTxt;
                    //加密文件密钥
                    byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 92 };
                    byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 99 };
                    RijndaelManaged myRijndael = new RijndaelManaged();
                    FileStream fsOut = File.Open(strOutName, FileMode.Create, FileAccess.Write);
                    FileStream fsIn = File.Open(strPath, FileMode.Open, FileAccess.Read);
                    //写入加密文本文件
                    CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    BinaryReader br = new BinaryReader(fsIn);//创建阅读器来读加密文本
                    csDecrypt.Write(br.ReadBytes((int)fsIn.Length), 0, (int)fsIn.Length);//将数据写入加密文本
                    csDecrypt.FlushFinalBlock();
                    csDecrypt.Close();//关闭CryptoStream对象
                    fsIn.Close();//关闭FileStream对象
                    fsOut.Close();//关闭FileStream对象
                    if (MessageBox.Show("加密成功!加密后的文件名及路径为:\n" + strOutName + ",是否删除源文件", "信息提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(strPath);//删除指定文件
                        textBox1.Text = "";//清空文本框
                    }
                    else
                    { textBox1.Text = ""; }
                }
                catch (Exception ee)//如果出现异常
                {
                    MessageBox.Show(ee.Message);//输出异常信息
                }
            }
        }

        //解密
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")//若未选择要解密的文件
            {
                MessageBox.Show("请选择要解密的文件路径");//如果没有选择则弹出提示
            }
            else
            {
                string strPath = textBox1.Text;//加密文件的路径
                int intLent = strPath.LastIndexOf("\\") + 1;//设置截取字符串的起始位置
                int intLong = strPath.Length;//设置截取长度
                string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                int intTxt = strName.LastIndexOf(".");//截取字符串的起始位置
                int intTextLeng = strName.Length;//截取长度
                strName = strName.Substring(0, intTxt);//获取文件扩展名
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
                //解密文件密钥
                byte[] key = { 24, 55, 102, 24, 98, 26, 67, 29, 84, 19, 37, 118, 104, 85, 121, 27, 93, 86, 24, 55, 102, 24, 98, 26, 67, 29, 9, 2, 49, 69, 73, 92 };
                byte[] IV = { 22, 56, 82, 77, 84, 31, 74, 24, 55, 102, 24, 98, 26, 67, 29, 99 };
                RijndaelManaged myRijndael = new RijndaelManaged();//创建RijndaelManaged对象
                //创建FileStream对象
                FileStream fsOut = File.Open(strPath, FileMode.Open, FileAccess.Read);
                CryptoStream csDecrypt = new CryptoStream(fsOut, myRijndael.CreateDecryptor(key, IV), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(csDecrypt);//把文件读出来
                StreamWriter sw = new StreamWriter(strInName);//解密后文件写入一个新文件
                sw.Write(sr.ReadToEnd());
                sw.Flush();
                sw.Close();
                sr.Close();
                fsOut.Close();
                if (MessageBox.Show("解密成功!解密后的文件名及路径为:" + strInName + "，是否删除源文件", "信息提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(strPath);//删除指定文件
                    textBox1.Text = "";	//清空文本框
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }
    }
}
