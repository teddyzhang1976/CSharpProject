using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvokHelp
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strpath = //得到路径信息
                Application.StartupPath.Substring(0, 
                Application.StartupPath.Substring(0, 
                Application.StartupPath.LastIndexOf("\\")).
                LastIndexOf("\\"));
            strpath += @"\mrHelp.chm";//得到帮助文件信息
            helpProvider1.HelpNamespace=strpath;//关联帮助文件
        }
    }
}