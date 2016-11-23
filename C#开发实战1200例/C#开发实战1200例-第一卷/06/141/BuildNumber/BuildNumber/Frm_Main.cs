using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace BuildNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Return)						//如果按下回车键
            {
                if (textBox1.Text.Length > 8)							//如果位数大于8
                {
                    textBox1.Text = textBox1.Text.Substring(0, 8);			//获取前8位数
                }
                else
                {
                    int j = 8 - textBox1.Text.Length;						//确定增加的位数
                    for (int i = 0; i < j; i++)
                    {
                        textBox1.Text = "0" + textBox1.Text;
                    }
                }
            }
        }
    }
}