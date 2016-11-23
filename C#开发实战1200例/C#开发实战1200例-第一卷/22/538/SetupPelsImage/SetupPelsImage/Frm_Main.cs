using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SetupPelsImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        int Var_MouseX = 0;//记录鼠标的X坐标的位置
        int Var_MouseY = 0;//记录鼠标的X坐标的位置
        int Var_MouseW = 0;//记录鼠标拖动矩形框的宽度
        int Var_MouseH = 0;//记录鼠标拖动矩形框的高度
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Var_MouseX = e.X;//记录鼠标按下时的X坐标值
            Var_MouseY = e.Y;//记录鼠标按下时的Y坐标值
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Var_MouseW = e.X - Var_MouseX;//获取鼠标拖动矩形框的宽度
            Var_MouseH = e.Y - Var_MouseY;//获取鼠标拖动矩形框的高度
            if (Var_MouseW == 0)//矩形框的宽度为0
                Var_MouseW = 1;//设置宽度为1
            if (Var_MouseH == 0)//矩形框的高度为0
                Var_MouseH = 1;//设置高度为1
            label_X.Text = Var_MouseX.ToString();//显示X的坐标值
            label_Y.Text = Var_MouseY.ToString();//显示Y的坐标值
            label_W.Text = Var_MouseW.ToString();//显示宽度
            label_H.Text = Var_MouseH.ToString();//显示高度
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)//打开颜色对话框
                panel1.BackColor = colorDialog1.Color;//显示选择的颜色
        }

        public Image SetPels(PictureBox Pict, Panel panel, Color color, int x, int y, int w, int h)
        {
            Bitmap Var_Bmp = new Bitmap(w, h);//根据矩形框的大小实例化Bitmap类
            Bitmap Var_SaveBmp = (Bitmap)Pict.Image;//实例化Bitmap
            //遍历矩形框内的各象素点
            for (int i = x; i < x + w; i++)
                for (int j = y; j < y + h; j++)
                {
                    Var_SaveBmp.SetPixel(i, j, color);//设置当前象素点的颜色
                }
            return Var_SaveBmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //调用自定义方法修改图片的颜色
            pictureBox1.Image = SetPels(pictureBox1, panel1, panel1.BackColor, Var_MouseX, Var_MouseY, Var_MouseW, Var_MouseH);
        }
    }
}
