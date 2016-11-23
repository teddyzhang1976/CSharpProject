using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LikesXP
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private static Panel Var_Panel = new Panel();//创建静态字段
        private static PictureBox Var_Pict = //创建静态字段
            new PictureBox();
        private static int Var_i = 0;//创建静态字段
        private Font Var_Font = new Font("宋体", 9); //创建字体字段

        private void pictureBox_1_Click(object sender, EventArgs e)
        {
            Var_i = Convert.ToInt16((//得到控件中的数据
                (PictureBox)sender).Tag.ToString());
            switch (Var_i)
            {
                case 1:
                    {
                        Var_Panel = panel_Gut_1;//得到面板对象引用
                        Var_Pict = pictureBox_1;//得到PictureBox对象引用
                        break;
                    }
                case 2:
                    {
                        Var_Panel = panel_Gut_2;//得到面板对象引用
                        Var_Pict = pictureBox_2;//得到PictureBox对象引用
                        break;
                    }
                case 3:
                    {
                        Var_Panel = panel_Gut_3;//得到面板对象引用
                        Var_Pict = pictureBox_3;//得到PictureBox对象引用
                        break;
                    }
            }
            if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 0 || Convert.ToInt16(Var_Panel.Tag.ToString()) == 2)
            {
                Var_Panel.Tag = 1;//设置为隐藏标识
                Var_Pict.Image = Properties.Resources.朝下按钮;//设置图像属性
                Var_Panel.Visible = false;//隐藏面板
            }
            else
            {
                if (Convert.ToInt16(Var_Panel.Tag.ToString()) == 1)
                {
                    Var_Panel.Tag = 2;//设置为显示标识
                    Var_Pict.Image = Properties.Resources.朝上按钮;//设置图像属性
                    Var_Panel.Visible = true;//显示面板
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_1.Image = Properties.Resources.朝上按钮;//设置图像信息
            pictureBox_2.Image = Properties.Resources.朝上按钮;//设置图像信息
            pictureBox_3.Image = Properties.Resources.朝上按钮;//设置图像信息
            Var_Font = label_1.Font;//得到字体对象
        }

        private void label_1_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;//设置控件文字字颜色
            ((Label)sender).Font = //设置控件字体
                new Font(Var_Font, Var_Font.Style | FontStyle.Underline);
        }

        private void label_1_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;//设置控件文字颜色
            ((Label)sender).Font = //设置控件字体
                new Font(Var_Font, Var_Font.Style);
        }
    }
}
