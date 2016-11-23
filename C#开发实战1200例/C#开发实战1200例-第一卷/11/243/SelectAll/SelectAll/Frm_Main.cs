using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SelectAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("游戏");//向控件中添加数据项
            this.listBox1.Items.Add("看书");//向控件中添加数据项
            this.listBox1.Items.Add("上网");//向控件中添加数据项
            this.listBox1.Items.Add("音乐");//向控件中添加数据项
            this.listBox1.Items.Add("电影");//向控件中添加数据项
        }

        private void bntList_Click(object sender, EventArgs e)
        {
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;//可能选多项
            for (int i = 0; i < listBox1.Items.Count; i++)//遍历数据项集合
            {
                this.listBox1.SetSelected(i, true);//选定数据项
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
                listBox1.SelectedItems.Count.ToString()+"项被选中","提示！");
        }
    }
}