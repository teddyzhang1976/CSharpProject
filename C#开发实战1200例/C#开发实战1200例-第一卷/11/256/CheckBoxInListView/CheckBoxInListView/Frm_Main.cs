using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO ;//引用与文件输入输出流有关的命名空间


namespace CheckBoxInListView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void CheckBoxInListView_Load(object sender,EventArgs e)
        {
            listView1.CheckBoxes = true;//设置listView1的复选框属性为真
            listView1.View = View.Details;//设置listView1的视图方式
            listView1.GridLines = true;//设置listView1显示网格线
            listView1.Columns.Add("文件名称",150,HorizontalAlignment.Left);//向listView1中添加“文件名称”列
            listView1.Columns.Add("创建时间",200,HorizontalAlignment.Left);//向listView1中添加“创建时间”列
            foreach(String fileName in Directory.GetFiles("C:\\"))//循环遍历C盘的内容
            {
                FileInfo file = new FileInfo(fileName);//定义一个操作文件的实例
                ListViewItem OptionItem = new ListViewItem(file.Name);//定义一个listView选择项的实例
                OptionItem.SubItems.Add(file.CreationTime.ToString());//向listView控件中添加文件创建时间列
                listView1.Items.Add(OptionItem);//执行添加操作
            }
        }

        private void checkAll_Click(object sender,EventArgs e)
        {
            foreach(ListViewItem tempItem in listView1.Items)//循环遍历listView控件中的每一项
            {
                if(tempItem.Checked == false)//如果当前项处于未选中状态
                {
                    tempItem.Checked = true;//设置当前项为选中状态
                }
            }
        }

        private void cleanUp_Click(object sender,EventArgs e)
        {
            foreach(ListViewItem tempItem in listView1.Items)//循环遍历listView控件中的每一项
            {
                if(tempItem.Checked)//如果当前项处于选中状态
                {
                    tempItem.Checked = false;//设置当前项为未选中状态
                }
            }
        }
    }
}
