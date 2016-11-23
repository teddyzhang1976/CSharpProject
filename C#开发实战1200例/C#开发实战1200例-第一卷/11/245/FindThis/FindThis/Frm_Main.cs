using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FindThis
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int intIndex = //查找指定项的索引
                this.listBox1.FindString(cbox_Select.Text);
            if (intIndex != ListBox.NoMatches)
            {
                listBox1.SelectedIndex = intIndex;//选中指定项
                MessageBox.Show(//弹出消息对话框
                    "指定项的索引是：" + intIndex.ToString(), 
                    "提示!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(//弹出消息对话框
                    "没有找到相关的选项",
                    "信息提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("C#编程词典");//向控件中添加数据项
            listBox1.Items.Add("C#编程宝典");//向控件中添加数据项
            listBox1.Items.Add("C#视频学");//向控件中添加数据项
            listBox1.Items.Add("C#范例宝典");//向控件中添加数据项
            listBox1.Items.Add("C#实点宝典");//向控件中添加数据项
            cbox_Select.SelectedIndex = 0;//设置控件默认选择项
        }
    }
}