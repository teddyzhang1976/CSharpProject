using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "明日科技 C#编程词典";//定义绘制的字符串
            Font myFont = new Font("华文行楷", 20);//实例化Font对象
            SolidBrush myBrush = new SolidBrush(Color.DarkOrange);//实例化画刷对象
            Graphics myGraphics = this.CreateGraphics();//创建Graphics对象
            myGraphics.DrawString(str, myFont, myBrush,10,20);//绘制文本
        }
    }
}
