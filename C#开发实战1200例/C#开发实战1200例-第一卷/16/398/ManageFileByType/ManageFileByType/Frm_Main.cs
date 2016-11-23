using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ManageFileByType
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();//创建FolderBrowserDialog对象
            if (FBDialog.ShowDialog() == DialogResult.OK)//判断是否选择了文件夹
            {
                string strPath = FBDialog.SelectedPath;//记录选择的文件夹
                if (strPath.EndsWith("\\"))
                    textBox1.Text = strPath;//显示选择的文件夹
                else
                    textBox1.Text = strPath + "\\";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> listExten = new List<string>();//创建泛型集合对象
            DirectoryInfo DInfo = new DirectoryInfo(textBox1.Text);//创建DirectoryInfo对象
            FileInfo[] FInfos = DInfo.GetFiles();//获取文件夹中的所有文件
            string strExten = "";//定义一个变量，用来存储文件扩展名
            foreach (FileInfo FInfo in FInfos)//遍历所有文件
            {
                strExten = FInfo.Extension;//记录文件扩展名
                if (!listExten.Contains(strExten))//判断泛型集合中是否已经存在该扩展名
                {
                    listExten.Add(strExten.TrimStart('.'));//将扩展名去掉.之后添加到泛型集合中
                }
            }
            for (int i = 0; i < listExten.Count; i++)//遍历泛型集合
            {
                Directory.CreateDirectory(textBox1.Text + listExten[i]);//创建文件夹
            }
            foreach (FileInfo FInfo in FInfos)//遍历所有文件
            {
                FInfo.MoveTo(textBox1.Text + FInfo.Extension.TrimStart('.') + "\\" + FInfo.Name);//将文件移动到对应的文件夹中
            }
            MessageBox.Show("整理完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);//打开文件夹进行查看
        }
    }
}
