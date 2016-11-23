using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseDPie
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//实例化Graphics类
            Pen mypen = new Pen(Color.Black, 3);//实例化Pen类
            ghs.DrawPie(mypen, 20, 10, 120, 100, 210, 120);//绘制扇形
        }
    }
}