using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BadgeImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public Image SetBadge(PictureBox Pict, String Str, Font font, int place)
        {
            Image Var_Image = Pict.Image;//根据图片实例化Image类
            int Var_FontSize = (int)font.Size;//获取字体大小
            bool Var_isSetFont = false;//判断当前文字是否超出图片的大小
            int Var_W = Var_Image.Width;//获取图片的宽度
            int Var_H = Var_Image.Height;//获取图片的高度
            int Var_StrX = 0;//记录文字的X位置
            int Var_StrY = 0;//记录文字的Y位置

            Bitmap Var_bmp = new Bitmap(Var_W, Var_H);//实例化Image类
            Bitmap Var_SaveBmp = new Bitmap(Var_Image);//实例化Image类
            Graphics g = Graphics.FromImage(Var_bmp);//用指定的Bitmap实例化Graphics
            Graphics tem_Graphics = Graphics.FromImage(Var_Image);//用指定的Bitmap实例化Graphics
            SizeF Var_Size = new SizeF(Var_W, Var_H);//实例化SizeF类
            Font tem_Font = font;//获取文字的设置文本
            g.Clear(Color.White);//清空图片
            while (Var_isSetFont == false)//如果文字超出图片的大小
            {
                //设置文字的文本
                tem_Font = new Font(font.Name, Var_FontSize, font.Bold ? FontStyle.Bold : FontStyle.Regular);
                Var_Size = g.MeasureString(Str, tem_Font);//对文字进行测量
                if (Var_Size.Width < Var_bmp.Width - 10)//如果文字的宽度没有超出图片
                {
                    if (Var_Size.Height < Var_bmp.Height - 10)//如果文字的高度没有超出图片
                        Var_isSetFont = true;//不减小文字的大小
                }
                else
                    Var_FontSize = Var_FontSize - 1;//文字的字体大小减1
            }
            switch (place)//选择文字的显示位置
            {
                case 1://右下角
                    {
                        Var_StrX = (int)(Var_bmp.Width - Var_Size.Width-3);//设置文字的X坐标值
                        Var_StrY = (int)(Var_bmp.Height - Var_Size.Height);//设置文字的Y坐标值
                        break;
                    }
                case 2://右上角
                    {
                        Var_StrX = (int)(Var_bmp.Width - Var_Size.Width - 3);
                        Var_StrY = 1;
                        break;
                    }
                case 3://左下角
                    {
                        Var_StrX = 1;
                        Var_StrY = (int)(Var_bmp.Height - Var_Size.Height);
                        break;
                    }
                case 4://左上角
                    {
                        Var_StrX = 1;
                        Var_StrY = 1;
                        break;
                    }
                case 5://顶局中
                    {
                        Var_StrX = (int)(Var_bmp.Width - Var_Size.Width-2)/2;
                        Var_StrY = 1;
                        break;
                    }
                case 6://底局中
                    {
                        Var_StrX = (int)(Var_bmp.Width - Var_Size.Width - 2) / 2;
                        Var_StrY = (int)(Var_bmp.Height - Var_Size.Height);
                        break;
                    }

            }
            g.DrawString(Str, tem_Font, new SolidBrush(Color.Black), Var_StrX, Var_StrY);//绘制前景色为黑色的文字
            int tem_Become = 40;//设置文字的变色深度
            //遍历图片的所有象素
            for (int x = 1; x < Var_bmp.Width; x++)
            {
                for (int y = 1; y < Var_bmp.Height; y++)
                {
                    int tem_a, tem_r, tem_g, tem_b, tem_r1, tem_g1, tem_b1;//定义变量
                    if (Var_bmp.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())//如果当前象素的颜色为黑色
                    {
                        tem_a = Var_SaveBmp.GetPixel(x, y).A;//获取当前象素的alpha分量值
                        tem_r = Var_SaveBmp.GetPixel(x, y).R;//获取当前象素的R色值
                        tem_g = Var_SaveBmp.GetPixel(x, y).G;//获取当前象素的G色值
                        tem_b = Var_SaveBmp.GetPixel(x, y).B;//获取当前象素的B色值
                        tem_r1 = tem_r;//临时存储R色值
                        tem_g1 = tem_g;//临时存储G色值
                        tem_b1 = tem_b;//临时存储B色值
                        //根据加深后的图片背景显示文字
                        if (tem_b + tem_Become < 255)//如果B色值加上当前深度小于255
                            tem_b = tem_b + 255;//B色值加上深度值
                        if (tem_g + tem_Become < 255)
                            tem_g = tem_g + 255;
                        if (tem_r + tem_Become < 255)
                            tem_r = tem_r + 255;
                        if (tem_r1 - tem_Become > 0)//如果B色值加上当前深度大于0
                            tem_r1 = tem_r1 - tem_Become;//B色值减去深度值
                        if (tem_g1 - tem_Become > 0)
                            tem_g1 = tem_g1 - tem_Become;
                        if (tem_b1 - tem_Become > 0)
                            tem_b1 = tem_b1 - tem_Become;
                        tem_Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black)), x, y + 1, 3, 3);//绘制文字的阴影
                        //以深后的图片背景显示文字
                        tem_Graphics.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(tem_a, tem_r1, tem_g1, tem_b1))), x, y, 1, 1);
                    }
                }
            }
            return Var_Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V_p = comboBox1.SelectedIndex + 1;//设置文字的显示位置
            pictureBox1.Image = SetBadge(pictureBox1, textBox1.Text, V_font, V_p);//调用自定义方法
        }

        Font V_font;
        int V_p = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            V_font = new Font("宋体", 12, FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                V_font = fontDialog1.Font;
        }
    }
}
