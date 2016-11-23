using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddScroll
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void vsbar_Scroll_Scroll(object sender, ScrollEventArgs e)
        {
            rtbox_Display.ScrollBars = RichTextBoxScrollBars.Vertical;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbox_Display.AppendText(//向控件中添加文本
                "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n12\r\n13\r\n14\r\n15\r\n16\r\n17");
        }

        int i = 0, start = 0;

        private void btn_Up_Click(object sender, EventArgs e)
        {
            i = --i > -1 ? i : ++i;//计算滚动的行数
            start =//得到行首第一个字符索引
                rtbox_Display.GetFirstCharIndexFromLine(i);
            rtbox_Display.SelectionStart = start;//设置文本框选定的起始点
            rtbox_Display.ScrollToCaret();//滚动到起始点位置
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            i =//计算滚动的行数
                ++i < rtbox_Display.Lines.Length ? i : --i;
            start = //得到行首第一个字符索引
                rtbox_Display.GetFirstCharIndexFromLine(i);
            rtbox_Display.SelectionStart = start;//设置文本框选定的起始点
            rtbox_Display.ScrollToCaret();//滚动到起始点位置
        }

    }
}
