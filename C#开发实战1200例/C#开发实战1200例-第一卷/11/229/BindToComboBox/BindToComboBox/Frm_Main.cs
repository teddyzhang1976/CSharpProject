using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BindToComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cbox_Display.DataSource =//绑定到数据表中的数据
                new DataTier().GetMessage();
                cbox_Display.DisplayMember = "book";//设置显示属性
                cbox_Display.ValueMember = "count";//设置实际值
        }

        private void cbox_Display_SelectedIndexChanged(object sender, EventArgs e)
        {
                cbox_Display.DisplayMember = "book";//设置显示属性
                cbox_Display.ValueMember = "count";//设置实际值
                lb_text.Text = //显示图书数量
                    cbox_Display.SelectedValue.ToString() + " 本";
        }

    }
}
