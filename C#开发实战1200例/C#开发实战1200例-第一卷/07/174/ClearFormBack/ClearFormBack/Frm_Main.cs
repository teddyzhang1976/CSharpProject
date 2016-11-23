using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClearFormBack
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("test.jpg");//设置窗体的背景图片
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();//创建绘图对象
            graphics.Clear(Color.White);//清空背景
            graphics.Dispose();//释放绘图资源
        }
    }
}
