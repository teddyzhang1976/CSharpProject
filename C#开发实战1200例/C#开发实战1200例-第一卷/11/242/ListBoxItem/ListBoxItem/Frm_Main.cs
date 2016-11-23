using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListBoxItem
{
    public partial class ListBoxItem : Form
    {
        public ListBoxItem()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Load(object sender,EventArgs e)
        {
            listBox1.Items.Add("香蕉");//向listBox1控件中添加“香蕉”
            listBox1.Items.Add("苹果");//向listBox1控件中添加“苹果”
            listBox1.Items.Add("雪梨");//向listBox1控件中添加“雪梨”
            listBox1.Items.Add("西红柿");//向listBox1控件中添加“西红柿”
            listBox1.Items.Add("橘子");//向listBox1控件中添加“橘子”
            listBox1.Items.Add("甘蔗");//向listBox1控件中添加“甘蔗”
            listBox1.Items.Add("西瓜");//向listBox1控件中添加“西瓜”
            listBox1.Items.Add("橙子");//向listBox1控件中添加“橙子”
            listBox1.Items.Add("柚子");//向listBox1控件中添加“柚子”
            listBox1.Items.Add("猕猴桃");//向listBox1控件中添加“猕猴桃”
            DecideTrueOrFalse();//当listBox1中不存在选择项时，设定所有按钮为不可用状态
        }

        private void allLeft_Click(object sender,EventArgs e)
        {
            for(int i = 0; i < listBox2.SelectedItems.Count; )//循环遍历listBox2中的所有选定项
            {
                listBox1.Items.Add(listBox2.SelectedItems[i]);//向listBox1中添加listBox2中选定的项
                listBox2.Items.Remove(listBox2.SelectedItems[i]);//移除listBox2中的选定项
            }
            DecideTrueOrFalse();//当listBox1中不存在选择项时，设定所有按钮为不可用状态
        }

        private void left_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listBox1中不存在选择项时，设定所有按钮为不可用状态
            object SettleOnItem = listBox2.SelectedItem;//保存listBox2中的选定项
            if(listBox1.Items.Contains(SettleOnItem))//当listBox1中已存在该项时
            {
                MessageBox.Show(SettleOnItem.ToString() + "已存在！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);//弹出该项已存在的信息
            }
            else//当listBox1中不存在该项时
            {
                listBox2.Items.Remove(SettleOnItem);//从listBox2中移除该项
                listBox1.Items.Add(SettleOnItem);//向listBox1中添加该项
            }
        }

        private void listBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(listBox1.SelectedItem == null)//当listBox1中的选定项为空时
            {
                allRight.Enabled = false;//设定全部右移的按钮为不可用状态
                allLeft.Enabled = false;//设定全部左移的按钮为不可用状态
                right.Enabled = false; //设定右移的按钮为不可用状态
                left.Enabled = false; //设定左移的按钮为不可用状态
            }
            else if(listBox1.SelectedItems.Count == 1)//当listBox1中的选定项为1时
            {
                allRight.Enabled = false;//设定全部右移的按钮为不可用状态
                allLeft.Enabled = false;//设定全部左移的按钮为不可用状态
                right.Enabled = true; //设定右移的按钮为可用状态
                left.Enabled = false; //设定左移的按钮为不可用状态
            }
            else if(listBox1.SelectedItems.Count > 1)//当listBox1中的选定项大于1时
            {
                right.Enabled = false;//设定右移的按钮为可用状态
                left.Enabled = false;  //设定左移的按钮为不可用状态
                allLeft.Enabled = false; //设定全部左移的按钮为不可用状态
                allRight.Enabled = true; //设定全部右移的按钮为可用状态
            }
        }

        private void right_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listBox1中不存在选择项时，设定所有按钮为不可用状态
            object SettleOnItem = listBox1.SelectedItem;//保存listBox1中的选定项
            if(listBox2.Items.Contains(SettleOnItem)) //当listBox2中已存在该项时
            {
                MessageBox.Show(SettleOnItem.ToString() + "已存在！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Warning);//弹出该项已存在的信息
            }
            else//当listBox2中不存在该项时
            {
                listBox1.Items.Remove(SettleOnItem);//从listBox1中移除该项
                listBox2.Items.Add(SettleOnItem);//向listBox2中添加该项
            }
        }

        private void allRight_Click(object sender,EventArgs e)
        {
            for(int i = 0; i < listBox1.SelectedItems.Count; )//循环遍历listBox1中选定的各项
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);//向listBox2中添加listBox1中选定的各项
                listBox1.Items.Remove(listBox1.SelectedItems[i]);//从listBox1中移除listBox1中选定的项
            }
            DecideTrueOrFalse();//当listBox1中不存在选择项时，设定所有按钮为不可用状态
        }

        private void DecideTrueOrFalse()
        {
            if(listBox1.SelectedItem == null)//当listBox1中不存在选择项时，设定所有按钮为不可用状态
            {
                allRight.Enabled = false;//设定全部右移按钮为不可用状态
                allLeft.Enabled = false;//设定全部左移按钮为不可用状态
                right.Enabled = false;//设定右移按钮为不可用状态
                left.Enabled = false;//设定左移按钮为不可用状态
            }
        }

        private void listBox2_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(listBox2.SelectedItem == null)//当listBox2中的选择项不为空时
            {
                allRight.Enabled = false;//设定全部右移的按钮为不可用状态
                allLeft.Enabled = false;//设定全部左移的按钮为不可用状态
                right.Enabled = false; //设定右移按钮为不可用状态
                left.Enabled = false; //设定左移按钮为不可用状态
            }
            else if(listBox2.SelectedItems.Count == 1) //当listBox2中的选择项为1时
            {
                allRight.Enabled = false;//设定全部右移按钮为不可用状态
                allLeft.Enabled = false; //设定全部左移按钮为不可用状态
                right.Enabled = false; //设定右移按钮为不可用状态
                left.Enabled = true;   //设定左移按钮为可用状态
            }
            else if(listBox2.SelectedItems.Count > 1)//当listBox2中的选定项大于1时
            {
                right.Enabled = false;//设定右移按钮为不可用状态
                left.Enabled = false;//设定左移按钮为不可用状态
                allLeft.Enabled = true; //设定全部左移按钮为可用状态
                allRight.Enabled = false;//设定全部右移按钮为不可用状态
            }
        }
    }
}
