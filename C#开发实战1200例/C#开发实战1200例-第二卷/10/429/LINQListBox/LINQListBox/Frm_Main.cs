using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LINQListBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        DataClassesDataContext dc = new DataClassesDataContext();//创建LINQ对象
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = dc.DictionaryType.Select(itm => new { itm.DictTypeID, itm.DictTypeName });//设置comboBox1数据源
            comboBox1.DisplayMember = "DictTypeName";//将字典类别信息绑定到comboBox1
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))//判断类别是否为空
            {
                string str = comboBox1.SelectedValue.ToString();//记录选择的类别
                int id = Convert.ToInt32(str.Substring(str.IndexOf('=') + 1, str.IndexOf(',') - str.IndexOf('=') - 1));//获取选定类别对应的ID
                var query = dc.DictionaryItem.Where(itm => itm.DictTypeID == id);//查询字典项信息
                listBox1.DataSource = query;//设置ListBox数据源
                listBox1.DisplayMember = "DictItemName";//将字典项信息绑定到listBox1
            }
        }
    }
}
