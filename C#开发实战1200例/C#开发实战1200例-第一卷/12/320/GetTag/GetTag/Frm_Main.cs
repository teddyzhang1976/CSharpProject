using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GetTag
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Tag.Tag = "本技巧是Tag属性应用";//为按钮的数据对象赋值
        }

        private void btn_Tag_Click(object sender, EventArgs e)
        {
            MessageBox.Show(//弹出消息对话框
                this.btn_Tag.Tag.ToString(),"提示！");
        }
    }
}