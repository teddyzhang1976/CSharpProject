using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//声明与文件的输入输出流有关的命名空间

namespace SelectFlash
{
    public partial class SelectFlash : Form
    {
        public SelectFlash()
        {
            InitializeComponent();
        }

        public static bool flag = false;//定义一个全局变量标识
        private void SelectFlash_Load(object sender,EventArgs e)
        {
            listView1.GridLines = true;//设置是否在listView1控件中显示网格线
            listView1.Dock = DockStyle.Fill;//设置listView1控件在其父容器中的停靠方式
            listView1.Columns.Add("文件名称",120,HorizontalAlignment.Left);//在listView1中添加“文件名称”列
            listView1.Columns.Add("文件属性",210,HorizontalAlignment.Left);//在listView1中添加“文件属性”列
            listView1.Columns.Add("创建时间",200,HorizontalAlignment.Left);//在listView1中添加“创建时间”列
            foreach(String fileName in Directory.GetFiles("C:\\"))//循环遍历C盘目录空间
            {
                FileInfo file = new FileInfo(fileName);//声明一个操作文件的实例
                ListViewItem OptionItem = new ListViewItem(file.Name);//实例化一个listView控件中选择项的实例
                OptionItem.SubItems.Add(file.Attributes.ToString());//在listView控件中添加文件属性列
                OptionItem.SubItems.Add(file.CreationTime.ToString());//在listView控件中文件创建时间列
                listView1.Items.Add(OptionItem);//向listView控件中追加新添加的各列
            }
            listView1.HideSelection = true;//设置控件的高亮显示属性为true
        }

        private void listView1_MouseClick(object sender,MouseEventArgs e)
        {
            listView1.SelectedItems[0].BackColor = Color.LightYellow;//设置当前选择项为高亮
        }

        private void 取消选择ToolStripMenuItem_Click(object sender,EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)//当listView1控件中的选择项不为0时
            {
                for(int i = 0; i < listView1.SelectedItems.Count; i++)//循环遍历控件中的每一个选择项
                {
                    if (listView1.SelectedItems[i].BackColor == Color.LightYellow)//当选择项为高亮时
                    {
                        listView1.SelectedItems[i].BackColor = Color.White;//设置选择项为白色
                    }
                }
            }
        }
    }
}
