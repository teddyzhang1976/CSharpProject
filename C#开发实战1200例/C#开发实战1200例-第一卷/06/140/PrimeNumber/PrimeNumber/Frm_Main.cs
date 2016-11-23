using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace PrimeNumber
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j;
            j = (int)Math.Ceiling(Math.Sqrt(Convert.ToDouble(textBox1.Text)));//开方
            for (int i = 1; i < j; i++)//遍历当前值
            {
                if (Math.IEEERemainder(Convert.ToDouble(textBox1.Text), i) == 0)//取整
                {
                    label2.Text = "不是素数";
                }
                else
                {
                    label2.Text = "是素数";
                }
            }
        }
    }
}