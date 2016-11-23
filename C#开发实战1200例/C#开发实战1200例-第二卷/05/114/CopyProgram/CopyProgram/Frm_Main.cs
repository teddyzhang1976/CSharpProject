using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyProgram
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.Copy(Application.ExecutablePath,@" C:\\mingrisoft.exe",true);//将程序复制到指定位置
            MessageBox.Show("程序复制成功！　复制目标文件路径为：Ｃ：\\mingrisoft.exe");
        }
    }
}