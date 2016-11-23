using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WatermarkImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image pp(PictureBox Pict, int x, int y, int R, float better)//R强光照射面的半径，即”光晕”
        {
            Bitmap Var_Bmp = new Bitmap(Pict.Image, Pict.Width, Pict.Height);//根据图象实例化Bitmap类
            int tem_W = Var_Bmp.Width;//获取图象的宽度
            int tem_H = Var_Bmp.Height;//获取图象的高度
            //定义一个Bitmap类的复本
            Bitmap Var_SaveBmp = Var_Bmp.Clone(new RectangleF(0, 0, tem_W, tem_H), System.Drawing.Imaging.PixelFormat.DontCare);
            Point Var_Center = new Point(x, y);//光晕的中心点
            //遍历图象中的各象素
            for (int i = tem_W - 1; i >= 1; i--)
            {
                for (int j = tem_H - 1; j >= 1; j--)
                {
                    float Var_Length = (float)Math.Sqrt(Math.Pow((i - Var_Center.X), 2) + Math.Pow((j - Var_Center.Y), 2));//设置光晕的范围
                    //如果像素位于”光晕”之内
                    if (Var_Length < R)
                    {
                        Color Var_Color = Var_SaveBmp.GetPixel(i, j);
                        int r, g, b;
                        float Var_Pixel = better * (1.0f - Var_Length / R);//设置光亮度的强弱
                        r = Var_Color.R + (int)Var_Pixel;//设置加强后的R值
                        r = Math.Max(0, Math.Min(r, 255));//如果R值不在颜色值的范围内，对R值进行设置
                        g = Var_Color.G + (int)Var_Pixel;//设置加强后的G值
                        g = Math.Max(0, Math.Min(g, 255));//如果G值不在颜色值的范围内，对G值进行设置
                        b = Var_Color.B + (int)Var_Pixel;//设置加强后的B值
                        b = Math.Max(0, Math.Min(b, 255));//如果B值不在颜色值的范围内，对B值进行设置
                        Var_SaveBmp.SetPixel(i, j, Color.FromArgb(255, r, g, b));//将增亮后的像素值回写到位图
                    }
                }
            }
            return Var_SaveBmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pp(pictureBox1,49,47,40,100F);
        }
    }
}
