using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AddInternetStore
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string favoriterFolder = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);//获取收藏夹位置
                StreamWriter sw = File.CreateText(favoriterFolder + "\\" + textBox2.Text + textBox1.Text + ".url");//创建收藏夹网址文件
                sw.WriteLine("[InternetShortcut]");//写入指定节点
                sw.WriteLine("URL =" + textBox1.Text);//写入网址
                sw.Close();//关闭写入流对象
                MessageBox.Show("添加成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}