using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlackandWhiteImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image BlackandWhiteEffect(PictureBox Pict)
        {
            int Var_H = Pict.Image.Height;//获取图象的高度
            int Var_W = Pict.Image.Width;//获取图象的宽度
            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);//根据图象的大小实例化Bitmap类
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;//根据图象实例化Bitmap类
            //遍历图象的象素
            for (int i = 0; i < Var_W; i++)
                for (int j = 0; j < Var_H; j++)
                {
                    Color tem_color = Var_SaveBmp.GetPixel(i, j);//获取当前象素的颜色值
                    int tem_r, tem_g, tem_b, tem_Value = 0;//定义变量
                    tem_r = tem_color.R;//获取R色值
                    tem_g = tem_color.G;//获取G色值
                    tem_b = tem_color.B;//获取B色值
                    tem_Value = ((tem_r + tem_g + tem_b) / 3);//用平均值法产生黑白图像
                    Var_bmp.SetPixel(i, j, Color.FromArgb(tem_Value, tem_Value, tem_Value));//改变当前象素的颜色值
                }
            return Var_bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = BlackandWhiteEffect(pictureBox1);
        }
    }
}
