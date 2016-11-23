using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;//添加控件及窗体的命名空间
using System.Drawing;//添加Point的命名空间
using System.Collections;//为ArrayList添加命名空间

namespace MagnetismForm
{
    class FrmClass
    {
        #region  磁性窗体-公共变量
        //记录窗体的隐藏与显示
        public static bool Example_ListShow = false;
        public static bool Example_LibrettoShow = false;
        public static bool Example_ScreenShow = false;

        //记录鼠标的当前位置
        public static Point CPoint;  //添加命名空间using System.Drawing;
        public static Point FrmPoint;
        public static int Example_FSpace = 10;//设置窗体间的距离

        //Frm_Play窗体的位置及大小
        public static int Example_Play_Top = 0;
        public static int Example_Play_Left = 0;
        public static int Example_Play_Width = 0;
        public static int Example_Play_Height = 0;
        public static bool Example_Assistant_AdhereTo = false;//辅助窗体是否磁性在一起

        //Frm_ListBos窗体的位置及大小
        public static int Example_List_Top = 0;
        public static int Example_List_Left = 0;
        public static int Example_List_Width = 0;
        public static int Example_List_Height = 0;
        public static bool Example_List_AdhereTo = false;//辅助窗体是否与主窗体磁性在一起

        //Frm_Libretto窗体的位置及大小
        public static int Example_Libretto_Top = 0;
        public static int Example_Libretto_Left = 0;
        public static int Example_Libretto_Width = 0;
        public static int Example_Libretto_Height = 0;
        public static bool Example_Libretto_AdhereTo = false;//辅助窗体是否与主窗体磁性在一起

        //窗体之间的距离差
        public static int Example_List_space_Top = 0;
        public static int Example_List_space_Left = 0;
        public static int Example_Libretto_space_Top = 0;
        public static int Example_Libretto_space_Left = 0;
        #endregion

        #region  检测各窗体是否连接在一起
        /// <summary>
        /// 检测各窗体是否连接在一起
        /// </summary>
        public void FrmBackCheck()
        {
            bool Tem_Magnetism = false;
            //Frm_ListBos与主窗体
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_List_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left - Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_List_Left + Example_List_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top - Example_List_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_List_Top + Example_List_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_List_AdhereTo = true;

            //Frm_Libretto与主窗体
            Tem_Magnetism = false;
            if ((Example_Play_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_Play_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Libretto_AdhereTo = true;

            //两个辅窗体
            Tem_Magnetism = false;
            if ((Example_List_Top - Example_Libretto_Top) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left - Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Left - Example_Libretto_Left + Example_Libretto_Width) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top - Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if ((Example_List_Top - Example_Libretto_Top + Example_Libretto_Height) == 0)
                Tem_Magnetism = true;
            if (Tem_Magnetism)
                Example_Assistant_AdhereTo = true;
        }
        #endregion

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

        #region  计算窗体之间的距离差
        /// <summary>
        /// 计算窗体之间的距离差
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param Follow="Form">跟随窗体</param>
        public void FrmDistanceJob(Form Frm, Form Follow)
        {
            switch (Follow.Name)
            {
                case "Frm_ListBox":
                    {
                        Example_List_space_Top = Follow.Top - Frm.Top;
                        Example_List_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
                case "Frm_Libretto":
                    {
                        Example_Libretto_space_Top = Follow.Top - Frm.Top;
                        Example_Libretto_space_Left = Follow.Left - Frm.Left;
                        break;
                    }
            }
        }
        #endregion

        #region  磁性窗体的移动
        /// <summary>
        /// 磁性窗体的移动
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">控件的移动事件</param>
        /// <param Follow="Form">跟随窗体</param>
        public void ManyFrmMove(Form Frm, MouseEventArgs e, Form Follow)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            if (e.Button == MouseButtons.Left)
            {
                int Tem_Left = 0;
                int Tem_Top = 0;
                Point myPosittion = Control.MousePosition;//获取当前鼠标的屏幕坐标
                switch (Follow.Name)
                {
                    case "Frm_ListBox":
                        {
                            Tem_Top = Example_List_space_Top - FrmPoint.Y;
                            Tem_Left = Example_List_space_Left - FrmPoint.X;
                            break;
                        }
                    case "Frm_Libretto":
                        {
                            Tem_Top = Example_Libretto_space_Top - FrmPoint.Y;
                            Tem_Left = Example_Libretto_space_Left - FrmPoint.X;
                            break;
                        }
                }
                myPosittion.Offset(Tem_Left, Tem_Top);
                Follow.DesktopLocation = myPosittion;
            }
        }
        #endregion

        #region  对窗体的位置进行初始化
        /// <summary>
        /// 对窗体的位置进行初始化
        /// </summary>
        /// <param Frm="Form">窗体</param>
        public void FrmInitialize(Form Frm)
        {
            switch (Frm.Name)
            {
                case "Frm_Play":
                    {
                        Example_Play_Top = Frm.Top;
                        Example_Play_Left = Frm.Left;
                        Example_Play_Width = Frm.Width;
                        Example_Play_Height = Frm.Height;
                        break;
                    }
                case "Frm_ListBox":
                    {
                        Example_List_Top = Frm.Top;
                        Example_List_Left = Frm.Left;
                        Example_List_Width = Frm.Width;
                        Example_List_Height = Frm.Height;
                        break;
                    }
                case "Frm_Libretto":
                    {
                        Example_Libretto_Top = Frm.Top;
                        Example_Libretto_Left = Frm.Left;
                        Example_Libretto_Width = Frm.Width;
                        Example_Libretto_Height = Frm.Height;
                        break;
                    }
            }

        }
        #endregion

        #region  存储各窗体的当前信息
        /// <summary>
        /// 存储各窗体的当前信息
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">控件的移动事件</param>
        public void FrmPlace(Form Frm)
        {
            FrmInitialize(Frm);
            FrmMagnetism(Frm);
        }
        #endregion

        #region  窗体的磁性设置
        /// <summary>
        /// 窗体的磁性设置
        /// </summary>
        /// <param Frm="Form">窗体</param>
        public void FrmMagnetism(Form Frm)
        {
            if (Frm.Name != "Frm_Play")
            {
                FrmMagnetismCount(Frm, Example_Play_Top, Example_Play_Left, Example_Play_Width, Example_Play_Height, "Frm_Play");
            }
            if (Frm.Name != "Frm_ListBos")
            {
                FrmMagnetismCount(Frm, Example_List_Top, Example_List_Left, Example_List_Width, Example_List_Height, "Frm_ListBos");
            }
            if (Frm.Name != "Frm_Libratto")
            {
                FrmMagnetismCount(Frm, Example_Libretto_Top, Example_Libretto_Left, Example_Libretto_Width, Example_Libretto_Height, "Frm_Libratto");
            }
            FrmInitialize(Frm);
        }
        #endregion

        #region  磁性窗体的计算
        /// <summary>
        /// 磁性窗体的计算
        /// </summary>
        /// <param Frm="Form">窗体</param>
        /// <param e="MouseEventArgs">控件的移动事件</param>
        public void FrmMagnetismCount(Form Frm, int top, int left, int width, int height, string Mforms)
        {
            bool Tem_Magnetism = false;//判断是否有磁性发生
            string Tem_MainForm = "";//临时记录主窗体
            string Tem_AssistForm = "";//临时记录辅窗体

            //上面进行磁性窗体
            if ((Frm.Top + Frm.Height - top) <= Example_FSpace && (Frm.Top + Frm.Height - top) >= -Example_FSpace)
            {
                //当一个主窗体不包含辅窗体时
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //当一个主窗体包含辅窗体时
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top - Frm.Height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }

            }

            //下面进行磁性窗体
            if ((Frm.Top - (top + height)) <= Example_FSpace && (Frm.Top - (top + height)) >= -Example_FSpace)
            {
                //当一个主窗体不包含辅窗体时
                if ((Frm.Left >= left && Frm.Left <= (left + width)) || ((Frm.Left + Frm.Width) >= left && (Frm.Left + Frm.Width) <= (left + width)))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
                //当一个主窗体包含辅窗体时
                if (Frm.Left <= left && (Frm.Left + Frm.Width) >= (left + width))
                {
                    Frm.Top = top + height;
                    if ((Frm.Left - left) <= Example_FSpace && (Frm.Left - left) >= -Example_FSpace)
                        Frm.Left = left;
                    Tem_Magnetism = true;
                }
            }

            //左面进行磁性窗体
            if ((Frm.Left + Frm.Width - left) <= Example_FSpace && (Frm.Left + Frm.Width - left) >= -Example_FSpace)
            {
                //当一个主窗体不包含辅窗体时
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //当一个主窗体包含辅窗体时
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left - Frm.Width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }

            //右面进行磁性窗体
            if ((Frm.Left - (left + width)) <= Example_FSpace && (Frm.Left - (left + width)) >= -Example_FSpace)
            {
                //当一个主窗体不包含辅窗体时
                if ((Frm.Top > top && Frm.Top <= (top + height)) || ((Frm.Top + Frm.Height) >= top && (Frm.Top + Frm.Height) <= (top + height)))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
                //当一个主窗体包含辅窗体时
                if (Frm.Top <= top && (Frm.Top + Frm.Height) >= (top + height))
                {
                    Frm.Left = left + width;
                    if ((Frm.Top - top) <= Example_FSpace && (Frm.Top - top) >= -Example_FSpace)
                        Frm.Top = top;
                    Tem_Magnetism = true;
                }
            }
            if (Frm.Name == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Frm.Name;
            if (Mforms == "Frm_Play")
                Tem_MainForm = "Frm_Play";
            else
                Tem_AssistForm = Mforms;
            if (Tem_MainForm == "")
            {
                Example_Assistant_AdhereTo = Tem_Magnetism;
            }
            else
            {
                switch (Tem_AssistForm)
                {
                    case "Frm_ListBos":
                        Example_List_AdhereTo = Tem_Magnetism;
                        break;
                    case "Frm_Libratto":
                        Example_Libretto_AdhereTo = Tem_Magnetism;
                        break;
                }
            }
        }
        #endregion

        #region  恢复窗体的初始大小
        /// <summary>
        /// 恢复窗体的初始大小(当松开鼠标时，如果窗体的大小小于300*200,恢复初始状态)
        /// </summary>
        /// <param Frm="Form">窗体</param>
        public void FrmScreen_FormerlySize(Form Frm, int PWidth, int PHeight)
        {
            if (Frm.Width < PWidth || Frm.Height < PHeight)
            {
                Frm.Width = PWidth;
                Frm.Height = PHeight;
                //Example_Size = false;
            }
        }
        #endregion

    }
}
