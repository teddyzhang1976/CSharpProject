using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReplaceString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_replace_Click(object sender, EventArgs e)
        {
            txt_str.Text = //使用字符串对象的Reaplce方法替换所有满足条件的字符串
                txt_str.Text.Replace(txt_find.Text, txt_replace.Text);
        }
    }
}
