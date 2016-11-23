using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RecordMouse
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            string str = textBox1.Text;//记录文本框中的内容
            if (e.Button == MouseButtons.Right)//如果按下鼠标右键
            {
                str += "鼠标右键按下 ";//记录鼠标右键按下
            }
            if (e.Button == MouseButtons.Left)//如果按下鼠标左键
            {
                str += "鼠标左键按下 ";//记录鼠标左键按下
            }
            if (e.Button == MouseButtons.Middle)//如果按下鼠标中间键
            {
                str += "鼠标中间键按下 ";//记录鼠标中间键按下
            }
            textBox1.Text = str;//显示鼠标按键行为
        }
    }
}