using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetAllDrives
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public void listFolders(ComboBox tscb)//获取本地磁盘目录
        {
            string[] logicdrives = System.IO.Directory.GetLogicalDrives();//获取本地逻辑分区的数组
            for (int i = 0; i < logicdrives.Length; i++)//遍历数组
            {
                tscb.Items.Add(logicdrives[i]);//将数组中的项目添加到ComboBox控件中
                tscb.SelectedIndex = 0;//设置第一项被选中
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listFolders(comboBox1);
        }
    }
}
