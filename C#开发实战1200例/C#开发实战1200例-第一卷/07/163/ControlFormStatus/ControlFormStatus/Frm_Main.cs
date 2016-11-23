using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlFormStatus
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.Width = Properties.Resources.登录界面标题.Width;//设置体的宽度
            this.Height = Properties.Resources.登录界面标题.Height + Properties.Resources.登录界面下面.Height;//设置窗体的高度
            panel_Title.BackgroundImage = Properties.Resources.登录界面标题;//显示窗体标题栏的图片
            panel_ALL.BackgroundImage = Properties.Resources.登录界面下面;//显示窗体标题栏下同的图片
            pictureBox_Min.Image = null;//清空PictuteBox控件
            pictureBox_Min.Image = Properties.Resources.最小化按钮;//显示最小化按钮的图片
            pictureBox_Max.Image = null; //清空PictuteBox控件
            pictureBox_Max.Image = Properties.Resources.最大化按钮;//显示最大化按钮的图片
            pictureBox_Close.Image = null;//清空PictuteBox控件
            pictureBox_Close.Image = Properties.Resources.关闭按钮;//显示关闭按钮的图片
        }

        #region  设置窗体的最大化、最小化和关闭按钮的单击事件
        /// <summary>
        /// 设置窗体的最大化、最小化和关闭按钮的单击事件
        /// </summary>
        /// <param Frm_Tem="Form">窗体</param>
        /// <param n="int">标识</param>
        public void FrmClickMeans(Form Frm_Tem, int n)
        {
            switch (n)//窗体的操作样式
            {
                case 0://窗体最小化
                    Frm_Tem.WindowState = FormWindowState.Minimized;//窗体最小化
                    break;
                case 1://窗体最大化和还原的切换
                    {
                        if (Frm_Tem.WindowState == FormWindowState.Maximized)//如果窗体当前是最大化
                            Frm_Tem.WindowState = FormWindowState.Normal;//还原窗体大小
                        else
                            Frm_Tem.WindowState = FormWindowState.Maximized;//窗体最大化
                        break;
                    }
                case 2:	//关闭窗体
                    Frm_Tem.Close();
                    break;
            }
        }
        #endregion

        #region  控制图片的切换状态
        /// <summary>
        /// 控制图片的切换状态
        /// </summary>
        /// <param sender =" object ">要改变图片的对象</param>
        /// <param n="int">标识</param>
        /// <param ns="int">移出移入标识</param>
        public static PictureBox Tem_PictB = new PictureBox();//实例化PictureBox控件
        public void ImageSwitch(object sender, int n, int ns)
        {
            Tem_PictB = (PictureBox)sender;
            switch (n)//获取标识
            {
                case 0://当前为最小化按钮
                    {
                        Tem_PictB.Image = null;//清空图片
                        if (ns == 0)//鼠标移入
                            Tem_PictB.Image = Properties.Resources.最小化变色;
                        if (ns == 1)//鼠标移出
                            Tem_PictB.Image = Properties.Resources.最小化按钮;
                        break;
                    }
                case 1://最大化按钮
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.最大化变色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.最大化按钮;
                        break;
                    }
                case 2://关闭按钮
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.关闭变色;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.关闭按钮;
                        break;
                    }
            }
        }
        #endregion

        private void pictureBox_Close_Click(object sender, EventArgs e)//单击事件
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));//设置鼠标单击时按钮的图片
        }
        private void pictureBox_Close_MouseEnter(object sender, EventArgs e)//鼠标移入事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);//设置鼠标移入后按钮的图片
        }
        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)//鼠标移出事件
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);//设置鼠标移出后按钮的图片
        }
    }
}
