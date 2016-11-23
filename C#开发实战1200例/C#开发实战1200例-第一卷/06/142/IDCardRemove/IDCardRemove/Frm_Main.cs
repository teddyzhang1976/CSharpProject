using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace IDCardRemove
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Shen(textBox1.Text);
        }
        public string Shen(string id)
        {
            int[] w = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };
            char[] a = new char[] { '1', '0', 'x', '9', '8', '7', '6', '5', '4', '3', '2' };			//设置18位最后一位的值
            string newID = "";
            if (id.Length == 15)									//判断位数
            {
                int s = 0;
                newID = id.Insert(6, "19");							//插入字符串
                for (int i = 0; i < 17; i++)								//生成前17位
                {
                    int k = Convert.ToInt32(newID[i]) * w[i];
                    s = s + k;
                }
                int h = 0;
                Math.DivRem(s, 11, out h);							//取余数
                newID = newID + a[h];								//生成18位
            }
            return newID;
        }
    }
}