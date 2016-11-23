using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinCusSkin
{
    public partial class Frm_Main  : Form
    {

        String strImagesPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
        int top, left, hei, wid;
        bool bol = false, bo = false, bolTop = false, bolLeft = false, bolRight = false, bolBottom = false, bolLeftCornu = false, bolRightCornu = false;
        int x = 0, y = 0;

        public Frm_Main()
        {
            InitializeComponent();
        }

        //关闭事件。
        private void picClose_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        //最大化事件。  
        private void picMaximize_Click(object sender, System.EventArgs e)
        {
            if (!bol)
            {
                top = this.Top;
                left = this.Left;
                hei = this.Height;
                wid = this.Width;
                this.Top = 0;
                this.Left = 0;
                int hg = SystemInformation.MaxWindowTrackSize.Height;
                int wh = SystemInformation.MaxWindowTrackSize.Width;
                this.Height = hg;
                this.Width = wh;
                bol = true;
                if (menItemSkin1.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\purple\max.png");
                if (menItemSkin2.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\blue\max.png");
                if (menItemSkin3.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\green\max.png");
            }
            else
            {
                this.Top = top;
                this.Left = left;
                this.Height = hei;
                this.Width = wid;
                bol = false;
                if (menItemSkin1.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\purple\max_Normal.png");
                if (menItemSkin2.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\blue\max_Normal.png");
                if (menItemSkin3.Checked)
                    this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\green\max_Normal.png");
            }
        }
        //最小化事件。
        private void picMinimize_Click(object sender, System.EventArgs e)
        {
            top = this.Top;
            left = this.Left;
            hei = this.Height;
            wid = this.Width;
            this.Height = 0;
            this.Width = 0;
            bo = true;
        }
        //窗口再次被激活时。
        private void FormCusSkin_Activated(object sender, System.EventArgs e)
        {
            if (bo)
            {
                this.Top = top;
                this.Left = left;
                this.Height = hei;
                this.Width = wid;
                bo = false;
            }
        }
        //选择关闭。
        private void mItemColse_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        //上边框鼠标按下。
        private void panel_Top_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            this.bolTop = true;
        }
        //上边框鼠标移动。 
        private void panel_Top_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolTop)
            {
                this.Top += e.Y - y;
                this.Left += e.X - x;
            }
        }
        //上边框鼠标释放。
        private void panel_Top_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolTop = false;
        }
        //左边框鼠标按下。
        private void panel_Left_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x = e.X;
            this.bolLeft = true;
        }
        //左边框鼠标移动。
        private void panel_Left_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolLeft)
            {
                this.Width += x - e.X;
                this.Left += e.X - x;
            }
        }
        //左边框鼠标离开。
        private void panel_Left_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolLeft = false;
        }
        //右边框鼠标按下。
        private void panel_Right_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x = e.X;
            this.bolRight = true;
        }
        //右边框鼠标移动。
        private void panel_Right_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolRight)
            {
                this.Width += e.X - x;
            }
        }
        //右边框鼠标离开。
        private void panel_Right_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolRight = false;
        }
        //下边框鼠标按下。
        private void panel_Bottom_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            y = e.Y;
            this.bolBottom = true;
        }
        //下边框鼠标移动。
        private void panel_Bottom_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolBottom)
            {
                this.Height += e.Y - y;
            }
        }
        //下边框鼠标离开。
        private void panel_Bottom_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolBottom = false;
        }
        //左下角鼠标按下。
        private void panelLeftCornu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            this.bolLeftCornu = true;
        }
        //左下角鼠标移动。
        private void panelLeftCornu_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolLeftCornu)
            {
                this.Width += x - e.X;
                this.Left += e.X - x;
                this.Height += e.Y - y;
            }
        }
        //左下角鼠标离开。
        private void panelLeftCornu_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            this.bolLeftCornu = false;
        }
        //右下角鼠标按下。
        private void panelRightCornu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolRightCornu = true;
        }
        //右下角鼠标移动。
        private void panelRightCornu_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bolRightCornu)
            {
                this.Width += e.X - x;
                this.Height += e.Y - y;
            }
        }
        //右下角鼠标离开。
        private void panelRightCornu_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.bolRightCornu = false;
        }

        private void FormCusSkin_Load(object sender, EventArgs e)
        {
            menItemSkin2_Click(sender, e);//默认蓝色经典
        }

        private void menItemSkin1_Click(object sender, EventArgs e)
        {
            this.panel_Top.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\top.png");
            this.panel_Left.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\left.png");
            this.panel_Right.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\right.png");
            this.panel_Bottom.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\bottom.png");
            this.picMinimize.Image = Image.FromFile(strImagesPath + @"\images\purple\min.png");
            if (bol == true)
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\purple\max.png");
            }
            else
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\purple\max_normal.png");
            }
            this.picClose.Image = Image.FromFile(strImagesPath + @"\images\purple\close.png");
            this.menItemSkin1.Checked = true;
            this.menItemSkin2.Checked = false;
            this.menItemSkin3.Checked = false;
            this.menuStrip1.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\menu.gif");
            this.BackgroundImage = Image.FromFile(strImagesPath + @"\images\purple\background.gif");
        }

        private void menItemSkin2_Click(object sender, EventArgs e)
        {
            this.panel_Top.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\top.png");
            this.panel_Left.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\left.png");
            this.panel_Right.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\right.png");
            this.panel_Bottom.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\bottom.png");
            this.picMinimize.Image = Image.FromFile(strImagesPath + @"\images\blue\min.png");
            if (bol == true)
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\blue\max.png");
            }
            else
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\blue\max_normal.png");
            }
            this.picClose.Image = Image.FromFile(strImagesPath + @"\images\blue\close.png");
            this.menItemSkin1.Checked = false;
            this.menItemSkin2.Checked = true;
            this.menItemSkin3.Checked = false;
            this.menuStrip1.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\menu.gif");
            this.BackgroundImage = Image.FromFile(strImagesPath + @"\images\blue\background.gif");
        }

        private void menItemSkin3_Click(object sender, EventArgs e)
        {
            this.panel_Top.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\top.png");
            this.panel_Left.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\left.png");
            this.panel_Right.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\right.png");
            this.panel_Bottom.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\bottom.png");
            this.picMinimize.Image = Image.FromFile(strImagesPath + @"\images\green\min.png");
            if (bol == true)
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\green\max.png");
            }
            else
            {
                this.picMaximize.Image = Image.FromFile(strImagesPath + @"\images\green\max_normal.png");
            }
            this.picClose.Image = Image.FromFile(strImagesPath + @"\images\green\close.png");
            this.menItemSkin1.Checked = false;
            this.menItemSkin2.Checked = false;
            this.menItemSkin3.Checked = true;
            this.menuStrip1.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\menu.gif");
            this.BackgroundImage = Image.FromFile(strImagesPath + @"\images\green\background.gif");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel_Top_DoubleClick(object sender, EventArgs e)
        {
            picMaximize_Click(sender, e);
        }
    }
}
