using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DropDownList
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn dgvc =//创建列对象
                new DataGridViewComboBoxColumn();
            dgvc.Items.Add("苹果");//向集合中添加元素
            dgvc.Items.Add("芒果");//向集合中添加元素
            dgvc.Items.Add("鸭梨");//向集合中添加元素
            dgvc.Items.Add("橘子");//向集合中添加元素
            dgvc.HeaderText = "水果";//设置列标题文本
            dgv_Message.Columns.Add(dgvc);//将列添加到集合
        }
    }
}
