using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeFormSize
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public static int Example_X = 0;
        public static int Example_Y = 0;
        public static int Example_W = 0;
        public static Point CPoint;

        #region  利用窗体上的控件移动窗体
        /// <summary>
        /// 利用控件移动窗体
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">控件的移动事件</param>
        public void FrmMove(Form Frm, MouseEventArgs e)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                myPosittion.Offset(CPoint.X, CPoint.Y);//重载当前鼠标的位置
                Frm.DesktopLocation = myPosittion;//设置当前窗体在屏幕上的位置
            }
        }
        #endregion

        #region  获取鼠标的当前位置
        /// <summary>
        /// 获取鼠标的当前位置
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">窗体上有关鼠标的一些信息</param>
        public void FrmScreen_SizeInfo(Form Frm, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Example_X = e.X;
                Example_Y = e.Y;
                Example_W = Frm.Width;
            }
        }
        #endregion

        #region  改变窗体的大小(用于鼠标的移动事件)
        /// <summary>
        /// 改变窗体的大小(用于鼠标的移动事件)
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param Pan="Panel">设置窗体边框的控件</param>
        /// <param e="MouseEventArgs">窗体上有关鼠标的一些信息</param>
        public void FrmScreen_EnlargeSize(Form Frm, Panel Pan, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (Pan.Name)
                {
                    case "panel_Right":						//如果移动的是窗体的右边框
                        {
                            if (this.Width <= 70)				//如果窗体的宽度小于等于70
                            {
                                Frm.Width = 70;				//设置窗体的宽度为70
                                //如果用鼠标向右移动窗体的右边框
                                if (Cursor.Position.X - Frm.Left + (Pan.Width - Example_X) > Frm.Width)
                                {
                                    //根据鼠标的移动值，增加窗体的宽度
                                    Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                }
                                break;
                            }
                            //根据鼠标的移动值，增加窗体的宽度
                            Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                            break;
                        }
                    case "panel_BR":						//如果移动的是窗体的右下角
                        {
                            //如果窗体的大小不为窗体大小的最小值
                            if (this.Width > 70 && this.Height > (panel_Title.Height + panel_Bn.Height + 1))
                            {
                                //根据鼠标的移动改变窗体的大小
                                Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                            }
                            else
                            {
                                if (this.Width <= 70)			//如果窗体的宽度小于等于最小值
                                {
                                    Frm.Width = 70;			//设置窗体的宽度为70
                                    if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果窗体的高小于最小值
                                    {
                                        Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//设置窗体的最小高度
                                        //如果用鼠标向下移动窗体的底边框
                                        if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                        {
                                            //根据鼠标的移动值，增加窗体的高度
                                            Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);
                                        }
                                        break;
                                    }
                                    //如果用鼠标向右移动窗体
                                    if (Cursor.Position.X - Frm.Left + (Pan.Width - Example_X) > Frm.Width)
                                    {
                                        //增加窗体的宽度
                                        Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);
                                    }
                                    break;
                                }
                                if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果窗体的高度小于等于最小值
                                {
                                    Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//设置窗体的高度为最小值
                                    Frm.Width = Cursor.Position.X - Frm.Left + (Pan.Width - Example_X);//改变窗体的宽度
                                    //如果用鼠标向下移动窗体的边框
                                    if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                    {
                                        Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);//增加窗体的高度
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    case "panel_Bn"://如果移动的是窗体的底边框
                        {
                            if (this.Height <= (panel_Title.Height + panel_Bn.Height + 1))//如果窗体的高度小于等于最小值
                            {
                                Frm.Height = panel_Title.Height + panel_Bn.Height + 1;//设置窗体的高度为最小值
                                //如果用鼠标向下移动窗体的下边框
                                if (Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y) > Frm.Height)
                                {
                                    Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);	//增加窗体的高度
                                }
                                break;
                            }
                            Frm.Height = Cursor.Position.Y - Frm.Top + (Pan.Height - Example_Y);			//增加窗体的高度
                            break;
                        }
                }
            }
        }
        #endregion

        private void panel_Right_MouseDown(object sender, MouseEventArgs e)
        {
            FrmScreen_SizeInfo(this, e);//获取鼠标的当前位置
        }

        private void panel_Right_MouseMove(object sender, MouseEventArgs e)
        {
            FrmScreen_EnlargeSize(this, (Panel)sender, e);//改变窗体的大小
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_TitL_MouseDown(object sender, MouseEventArgs e)
        {
            int Tem_X = -e.X;
            if (Convert.ToInt16(((Panel)sender).Tag.ToString()) == 2)//如果移动的是标题栏的中间部分
                Tem_X = -e.X - panel_TitL.Width;
            if (Convert.ToInt16(((Panel)sender).Tag.ToString()) == 3)//如果移动的是标题栏的尾端
                Tem_X = -(this.Width - ((Panel)sender).Width) - e.X;
            CPoint = new Point(Tem_X, -e.Y);
        }

        private void panel_TitL_MouseMove(object sender, MouseEventArgs e)
        {
            FrmMove(this, e);
        }

    }
}
