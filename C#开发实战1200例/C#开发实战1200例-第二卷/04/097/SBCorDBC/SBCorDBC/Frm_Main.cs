using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SBCorDBC
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        #region 加载窗体时，焦点默认处于TextBox1上
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        #endregion

        #region 全角与半角互相切换
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            textBox1.Focus();
            controlIme.SetIme(textBox1);
            controlIme.ctl_Click(textBox1, e);
            textBox1.Focus();
            if (button1.Text == "半角")
            {
                button1.Text = "全角";
                flag = true;
            }
            if (flag == false)
            {
                if (button1.Text == "全角")
                {
                    button1.Text = "半角";
                }
            }
        }
        #endregion
    }
}
