using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ButtonMagnifier
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Location = new Point(80, 10);//设置按钮位置
            button1.Font = new Font("隶书", 18);//设置按钮字体样式
            button1.Width = 200;//设置按钮宽度
            button1.Height = 80;//设置按钮高度
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Location = new Point(130, 30);//设置按钮位置
            button1.Font = new Font("宋体",9);//设置按钮字体样式
            button1.Width = 100;//设置按钮宽度
            button1.Height = 40;//设置按钮高度
        }
    }
}
