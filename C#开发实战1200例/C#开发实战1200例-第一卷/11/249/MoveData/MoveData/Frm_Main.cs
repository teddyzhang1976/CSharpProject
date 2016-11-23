using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoveData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void MoveData_Load(object sender,EventArgs e)
        {
            listView1.Items.Add("香蕉");//向listView1中添加“香蕉”项
            listView1.Items.Add("苹果");//向listView1中添加“苹果”项
            listView1.Items.Add("大鸭梨");//向listView1中添加“大鸭梨”项
            listView1.Items.Add("柿子");//向listView1中添加“柿子”项
            listView1.Items.Add("橘子");//向listView1中添加“橘子”项
            listView1.Items.Add("水蜜桃");//向listView1中添加“水蜜桃”项
            listView1.Items.Add("西瓜");//向listView1中添加“西瓜”项
            listView1.Items.Add("橙子");//向listView1中添加“橙子”项
            listView1.Items.Add("猕猴桃");//向listView1中添加“猕猴桃”项
            DecideTrueOrFalse();//当listBox1中没有选择项时使所有按钮处于不可用状态
        }

        private void allLeft_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listView1中没有选择项时使所有按钮处于不可用状态
            TransferLeftTechnique();//将listView2中的所有选择项移动到listView1中
        }

        private void left_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listBox1中没有选择项时使所有按钮处于不可用状态
            TransferLeftTechnique();//将listView2中的所有选择项移动到listView1中
        }

        private void listView1_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)//当listView1中的选择项为0时
            {
                allRight.Enabled = false;//设置团购按钮为不可用状态
                allLeft.Enabled = false; //设置团退按钮为不可用状态
                right.Enabled = false;//设置单购按钮为不可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
            }
            else if(listView1.SelectedItems.Count == 1)//当listView1中的选择项为1时
            {
                allRight.Enabled = false;//设置团购按钮为不可用状态
                allLeft.Enabled = false;//设置团退按钮为不可用状态
                right.Enabled = true;//设置单购按钮为可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
            }
            else if(listView1.SelectedItems.Count > 1) //当listView1中的选择项大于1时
            {
                right.Enabled = false;//设置单购按钮为不可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
                allLeft.Enabled = false;//设置团退按钮为不可用状态
                allRight.Enabled = true;//设置团购按钮为可用状态
            }
        }

        private void right_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listBox1中没有选择项时使所有按钮处于不可用状态
            TransferRightTechnique();//调用购物方法
        }

        private void TransferRightTechnique()
        {
            ListView.SelectedListViewItemCollection SettleOnItem = new ListView.SelectedListViewItemCollection(this.listView1);//定义一个选择项的集合
            for(int i = 0; i < SettleOnItem.Count; )//循环遍历选择的每一项
            {
                listView2.Items.Add(SettleOnItem[i].Text);//向listView2中添加选择项
                listView1.Items.Remove(SettleOnItem[i]);//从listView1中移除选择项
            }
        }

        private void TransferLeftTechnique()
        {
            ListView.SelectedListViewItemCollection SettleOnItem = new ListView.SelectedListViewItemCollection(this.listView2);//定义一个选择项的集合
            for(int i = 0; i < SettleOnItem.Count; )//循环遍历选择的每一项
            {
                listView1.Items.Add(SettleOnItem[i].Text);//向listView1中添加选择项
                listView2.Items.Remove(SettleOnItem[i]);//从listView2中移除选择项
            }
        }
        private void allRight_Click(object sender,EventArgs e)
        {
            DecideTrueOrFalse();//当listBox1中没有选择项时使所有按钮处于不可用状态
            TransferRightTechnique();//调用购物方法
        }

        private void DecideTrueOrFalse()
        {
            if(listView1.SelectedIndices.Count == 0)//当listView1中的选择项为空时
            {
                allRight.Enabled = false;//设置团购按钮为不可用状态
                allLeft.Enabled = false;//设置团退按钮为不可用状态
                right.Enabled = false;//设置单购按钮为不可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
            }
        }

        private void listView2_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(listView2.SelectedIndices.Count == 0)//当listView2中的选择项为0时
            {
                allRight.Enabled = false;//设置团购按钮为不可用状态
                allLeft.Enabled = false;//设置团退按钮为不可用状态
                right.Enabled = false;//设置单购按钮为不可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
            }
            else if(listView2.SelectedItems.Count == 1)//当listView2中的选择项为1时
            {
                allRight.Enabled = false;//设置团购按钮为不可用状态
                allLeft.Enabled = false;//设置团退按钮为不可用状态
                right.Enabled = false; //设置单购按钮为不可用状态
                left.Enabled = true;//设置单退按钮为可用状态
            }
            else if(listView2.SelectedItems.Count > 1)//当listView2中的选择项为1时
            {
                right.Enabled = false;//设置单购按钮为不可用状态
                left.Enabled = false;//设置单退按钮为不可用状态
                allLeft.Enabled = true;//设置团退按钮为可用状态
                allRight.Enabled = false;//设置团购按钮为不可用状态
            }
        }
    }
}
