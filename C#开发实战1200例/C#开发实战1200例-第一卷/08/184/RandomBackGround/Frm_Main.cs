using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomBackGround
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //定义一个字符串数组，用来存储背景图片列表
            string[] strImages = new string[] { "01.jpg", "02.jpg", "03.jpg", "04.jpg", "05.jpg" };
            Random rdn = new Random();//定义一个伪随机数生成器对象
            int intIndex = rdn.Next(0, strImages.Length - 1);//产生一个随机数
            this.BackgroundImage = Image.FromFile(strImages[intIndex]);//设置窗体的背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch;//设置背景图片拉伸显示
        }
    }
}