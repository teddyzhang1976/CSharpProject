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

namespace EncryptTextFileTwo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        //打开图片
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg,bmp,gif|*.jpg;*.gif;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }
        //打开加密文件
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
        // 加密
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.ImageLocation == null)
                { MessageBox.Show("请选择一幅图片用于加密"); return; }
                if (textBox1.Text == "")
                { MessageBox.Show("请选择加密文件路径"); return; }
                //图片流
                FileStream fsPic = new FileStream(pictureBox1.ImageLocation, FileMode.Open, FileAccess.Read);
                //加密文件流
                FileStream fsText = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                //初始化Key IV
                byte[] bykey = new byte[16];
                byte[] byIv = new byte[8];
                fsPic.Read(bykey, 0, 16);
                fsPic.Read(byIv, 0, 8);
                //临时加密文件
                string strPath = textBox1.Text;//加密文件的路径
                int intLent = strPath.LastIndexOf("\\") + 1;
                int intLong = strPath.Length;
                string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                string strLinPath = "C:\\" + strName;//临时加密文件路径，所以被加密的文件不可以放在C盘的根目录下
                FileStream fsOut = File.Open(strLinPath, FileMode.Create, FileAccess.Write);
                //开始加密
                RC2CryptoServiceProvider desc = new RC2CryptoServiceProvider();//des进行加
                BinaryReader br = new BinaryReader(fsText);//从要加密的文件中读出文件内容
                CryptoStream cs = new CryptoStream(fsOut, desc.CreateEncryptor(bykey, byIv), CryptoStreamMode.Write);//写入临时加密文件
                cs.Write(br.ReadBytes((int)fsText.Length), 0, (int)fsText.Length);//写入加密流
                cs.FlushFinalBlock();
                cs.Flush();
                cs.Close();
                fsPic.Close();
                fsText.Close();
                fsOut.Close();
                File.Delete(textBox1.Text.TrimEnd());//删除原文件
                File.Copy(strLinPath, textBox1.Text);//复制加密文件
                File.Delete(strLinPath);//删除临时文件
                MessageBox.Show("加密成功");
                pictureBox1.ImageLocation = null;
                textBox1.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        //解密
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //图片流
                FileStream fsPic = new FileStream(pictureBox1.ImageLocation, FileMode.Open, FileAccess.Read);
                //解密文件流
                FileStream fsOut = File.Open(textBox1.Text, FileMode.Open, FileAccess.Read);
                //初始化Key IV
                byte[] bykey = new byte[16];
                byte[] byIv = new byte[8];
                fsPic.Read(bykey, 0, 16);
                fsPic.Read(byIv, 0, 8);
                //临时解密文件
                string strPath = textBox1.Text;//加密文件的路径
                int intLent = strPath.LastIndexOf("\\") + 1;
                int intLong = strPath.Length;
                string strName = strPath.Substring(intLent, intLong - intLent);//要加密的文件名称
                string strLinPath = "C:\\" + strName;//临时解密文件路径
                FileStream fs = new FileStream(strLinPath, FileMode.Create, FileAccess.Write);
                //开始解密
                RC2CryptoServiceProvider desc = new RC2CryptoServiceProvider();//des进行解
                CryptoStream csDecrypt = new CryptoStream(fsOut, desc.CreateDecryptor(bykey, byIv), CryptoStreamMode.Read);//读出加密文件
                BinaryReader sr = new BinaryReader(csDecrypt);//从要加密流中读出文件内容
                BinaryWriter sw = new BinaryWriter(fs);//写入解密流
                sw.Write(sr.ReadBytes(Convert.ToInt32(fsOut.Length)));
                sw.Flush();
                sw.Close();
                sr.Close();
                fs.Close();
                fsOut.Close();
                fsPic.Close();
                csDecrypt.Flush();
                File.Delete(textBox1.Text.TrimEnd());//删除原文件
                File.Copy(strLinPath, textBox1.Text);//复制加密文件
                File.Delete(strLinPath);//删除临时文件
                MessageBox.Show("解密成功");
                pictureBox1.ImageLocation = null;
                textBox1.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
