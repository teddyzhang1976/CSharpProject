using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex09_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText.ToString() == "")
            {
                MessageBox.Show(//弹出提示信息
                    "请选重要替换的文本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.richTextBox1.SelectedText = txt_Content.Text;//替换选中的文本
            }
        }
    }
}