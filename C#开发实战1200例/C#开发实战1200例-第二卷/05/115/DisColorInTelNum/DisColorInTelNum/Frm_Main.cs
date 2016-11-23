using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisColorInTelNum
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "043184978981";//显示电话号码
            this.richTextBox1.Select(0, 3);//选中前3个号码
            this.richTextBox1.SelectionColor = Color.Red;//显示红色
            this.richTextBox1.Select(3, 3);//选中中前方3个号码
            this.richTextBox1.SelectionColor = Color.Blue;//显示蓝色色
            this.richTextBox1.Select(6, 3);//选中中后方3个号码
            this.richTextBox1.SelectionColor = Color.Green;//显示绿色
            this.richTextBox1.Select(9, 3);//选中后3个号码
            this.richTextBox1.SelectionColor = Color.Brown;//显示暗红色
        }
    }
}