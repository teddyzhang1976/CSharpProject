using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GetSysEnvironment
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;//设置控件显示方式
            listView1.GridLines = true;//是否显示网格
            listView1.Columns.Add("环境变量", 150, HorizontalAlignment.Left);//添加列标头
            listView1.Columns.Add("变量值", 150, HorizontalAlignment.Left);//添加列标头
            ListViewItem myItem;//创建ListViewItem对象
            //获取系统环境变量及对应的变量值，并显示在ListView控件中
            foreach (DictionaryEntry DEntry in Environment.GetEnvironmentVariables())
            {
                myItem = new ListViewItem(DEntry.Key.ToString(), 0);//创建ListViewItem对象
                myItem.SubItems.Add(DEntry.Value.ToString());//添加子项集合
                listView1.Items.Add(myItem);//将子项集合添加到控件中
            }
        }
    }
}