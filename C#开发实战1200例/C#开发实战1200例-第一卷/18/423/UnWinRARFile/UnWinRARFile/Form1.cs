using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace UnWinRARFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "RAR文件(*.rar)|*.rar";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                textBox2.Text = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf("\\") + 1);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            String myRar;
            RegistryKey myReg;
            Object myObj;
            String myInfo;
            ProcessStartInfo myStartInfo;
            Process myProcess;
            string strRar;
            string strFile;

            try
            {
                myReg = Registry.ClassesRoot.OpenSubKey("Applications\\WinRar.exe\\Shell\\Open\\Command");
                myObj = myReg.GetValue("");
                myRar = myObj.ToString();
                myReg.Close();
                myRar = myRar.Substring(1, myRar.Length - 7);
                strRar = textBox1.Text.Substring(textBox1.Text.LastIndexOf("\\") + 1);
                strFile = textBox2.Text.Substring(textBox2.Text.LastIndexOf("\\") + 1);
                myInfo = " X " + strRar + " " + strFile + "\\";
                myStartInfo = new ProcessStartInfo();
                myStartInfo.FileName = myRar;
                myStartInfo.Arguments = myInfo;
                myStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myStartInfo.WorkingDirectory = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf("\\"));
                myProcess = new Process();
                myProcess.StartInfo = myStartInfo;
                myProcess.Start();
                MessageBox.Show("解压文件成功！");
            }
            catch { }
        }
    }
}
