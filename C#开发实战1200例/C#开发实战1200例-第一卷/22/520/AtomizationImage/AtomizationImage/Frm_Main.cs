using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtomizationImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image AtomizationEffect(PictureBox Pict, int effect)
        {
            int Var_W = Pict.Width;									//获取图片的宽度
            int Var_H = Pict.Height;									//获取图片的高度
            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);				//根据图片的大小实例化Bitmap类
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;					//根据图片实例化Bitmap类
            for (int i = 0; i < Var_W; i++)								//遍历图片中的各象素
            {
                for (int j = 0; j < Var_H; j++)
                {
                    Random Var_random = new Random();				//实例化Random类
                    int k = Var_random.Next(200000);					//获取随机数
                    //获取象素块
                    int tem_w = i + k % effect;
                    int tem_h = j + k % effect;
                    //获取的象素不超出图片的大小
                    if (tem_w >= Var_W)
                        tem_w = Var_W - 1;
                    if (tem_h >= Var_H)
                        tem_h = Var_H - 1;
                    Color tem_Color = Var_SaveBmp.GetPixel(tem_w, tem_h);	//获取当前象素的颜色
                    Var_bmp.SetPixel(i, j, tem_Color);					//设置当前象素的颜色
                }
            }
            return Var_bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = AtomizationEffect(pictureBox1, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
