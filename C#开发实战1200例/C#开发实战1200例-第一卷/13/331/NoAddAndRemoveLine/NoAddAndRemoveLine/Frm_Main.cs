using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoAddAndRemoveLine
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.Columns.Add("Name", "名称");//向控件中添加列
            dgv_Message.Columns.Add("Price", "价格");//向控件中添加列
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            dgv_Message.AllowUserToAddRows = false;//禁止添加行
            dgv_Message.AllowUserToDeleteRows = false;//禁止删除行
            dgv_Message.ReadOnly = true;//设置单元格为不可编辑
        }

    }
}
