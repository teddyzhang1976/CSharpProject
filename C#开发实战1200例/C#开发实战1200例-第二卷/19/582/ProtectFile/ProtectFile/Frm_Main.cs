using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace ProtectFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileMenu(Application.ExecutablePath + ",0", Application.ExecutablePath);
            string[] str = Environment.GetCommandLineArgs();
            try
            {
                string strFile = "";
                for (int i = 2; i < str.Length; i++)
                    strFile += str[i];
                FileInfo FInfo = new FileInfo(strFile);
                if (FInfo.Extension.ToLower() == ".mr")
                {
                    textBox1.Text = strFile;
                    button2.Enabled = false;
                    button3.Enabled = true;
                }
            }
            catch { }
        }

        //选择加密、解密文件
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                FileInfo FInfo = new FileInfo(textBox1.Text);
                if (FInfo.Extension.ToLower() == ".mr")
                {
                    button2.Enabled = false;
                    button3.Enabled = true;
                }
                else
                {
                    button2.Enabled = true;
                    button3.Enabled = false;
                }
            }
        }

        //加密
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text.Length < 6)
                    MessageBox.Show("密码不能小于6位！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    EDncrypt myEDncrypt = new EDncrypt(textBox1.Text, textBox2.Text, progressBar1);
                    myEDncrypt.StartEncrypt();
                    progressBar1.Value = 0;
                }
            }
        }

        //解密
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text.Length < 6)
                    MessageBox.Show("密码不能小于6位！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    EDncrypt myEDncrypt = new EDncrypt(textBox1.Text, textBox2.Text, progressBar1);
                    myEDncrypt.StartDncrypt();
                    progressBar1.Value = 0;
                }
            }
        }

        //创建快捷菜单
        public static void FileMenu(string strPath, string strName)
        {
            try
            {
                Registry.ClassesRoot.CreateSubKey(".mr");
                RegistryKey RKey1 = Registry.ClassesRoot.OpenSubKey(".mr", true);
                RKey1.SetValue("", "mrfile");
                RKey1.Close();
                Registry.ClassesRoot.CreateSubKey("mrfile");
                RegistryKey RKey2 = Registry.ClassesRoot.OpenSubKey("mrfile", true);
                RKey2.CreateSubKey("DefaultIcon");
                RKey2.CreateSubKey("shell");
                RKey2.Close();
                RegistryKey RKey3 = Registry.ClassesRoot.OpenSubKey("mrfile\\DefaultIcon", true);
                RKey3.SetValue("", strPath);
                RKey3.Close();
                RegistryKey RKey4 = Registry.ClassesRoot.OpenSubKey("mrfile\\shell", true);
                RKey4.CreateSubKey("解密");
                RKey4.Close();
                RegistryKey RKey5 = Registry.ClassesRoot.OpenSubKey("mrfile\\shell\\解密", true);
                RKey5.CreateSubKey("command");
                RKey5.Close();
                RegistryKey RKey6 = Registry.ClassesRoot.OpenSubKey("mrfile\\shell\\解密\\command", true);
                RKey6.SetValue("", strName + " \\F %1");
                RKey6.Close();
            }
            catch
            {
            }
        }
    }

    #region 加密、解密类
    class EDncrypt
    {
        #region 定义全局变量及类对象
        private string strFile = "";
        private string strNewFile = "";
        private string strPwd = "";
        private ProgressBar PBar = null;
        private Thread EThread = null;
        private Thread DThread = null;
        #endregion
        //含参数的构造函数，用来初始化全局变量及对象
        public EDncrypt(string name, string pwd, ProgressBar pb)
        {
            strFile = name;
            strPwd = pwd;
            PBar = pb;
            EThread = new Thread(new ThreadStart(this.myEThread));
            DThread = new Thread(new ThreadStart(this.myDThread));
        }
        //文件加密
        private void myEThread()
        {
            byte[] btRKey = new byte[0];
            if (strPwd.Length == 6)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
            }
            if (strPwd.Length == 7)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
            }
            if (strPwd.Length >= 8)
            {
                btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
            }
            FileStream FStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
            FileStream NewFStream = new FileStream(strFile + ".mr", FileMode.OpenOrCreate, FileAccess.Write);
            NewFStream.SetLength((long)0);
            byte[] buffer = new byte[0x400];
            int MinNum = 0;
            long length = FStream.Length;
            int MaxNum = (int)(length / ((long)0x400));
            PBar.Maximum = MaxNum;
            DES myDES = new DESCryptoServiceProvider();
            CryptoStream CStream = new CryptoStream(NewFStream, myDES.CreateEncryptor(btRKey, btRKey), CryptoStreamMode.Write);
            while (MinNum < length)
            {
                int count = FStream.Read(buffer, 0, 0x400);
                CStream.Write(buffer, 0, count);
                MinNum += count;
                try
                {
                    if (PBar.Value < PBar.Maximum)
                    {
                        PBar.Value++;
                    }
                }
                catch
                {
                }
            }
            CStream.Close();
            NewFStream.Close();
            FStream.Close();
            File.Delete(strFile);
            MessageBox.Show("文件加密成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //运行加密线程
        public void StartEncrypt()
        {
            EThread.Start();
        }
        //文件解密
        private void myDThread()
        {
            FileStream FStream = null;
            FileStream NewFStream = null;
            CryptoStream CStream = null;
            try
            {
                try
                {
                    byte[] btRKey = new byte[0];
                    if (strPwd.Length == 6)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
                    }
                    if (strPwd.Length == 7)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
                    }
                    if (strPwd.Length >= 8)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
                    }
                    FStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                    strNewFile = strFile.Substring(0, strFile.Length - 3);
                    NewFStream = new FileStream(strNewFile, FileMode.OpenOrCreate, FileAccess.Write);
                    NewFStream.SetLength((long)0);
                    byte[] buffer = new byte[0x400];
                    int MinNum = 0;
                    long length = FStream.Length;
                    int MaxNum = (int)(length / ((long)0x400));
                    PBar.Maximum = MaxNum;
                    DES myDES = new DESCryptoServiceProvider();
                    CStream = new CryptoStream(NewFStream, myDES.CreateDecryptor(btRKey, btRKey), CryptoStreamMode.Write);
                    while (MinNum < length)
                    {
                        int count = FStream.Read(buffer, 0, 0x400);
                        CStream.Write(buffer, 0, count);
                        MinNum += count;
                        try
                        {
                            if (PBar.Value < PBar.Maximum)
                            {
                                PBar.Value++;
                            }
                        }
                        catch
                        {
                        }
                    }
                    MessageBox.Show("文件解密成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("文件解密失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                CStream.Close();
                FStream.Close();
                NewFStream.Close();
            }
        }
        //运行解密线程
        public void StartDncrypt()
        {
            DThread.Start();
        }
    }
    #endregion
}